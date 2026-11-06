using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

// 一键生成小鸭子角色的四个动画文件 + Animator 控制器
// 使用：Unity 顶部菜单 Tools → 生成角色动画 (Player_Idle/Walk/Run/Jump)
public static class GeneratePlayerAnimation
{
    private const string AnimFolder = "Assets/Animations";

    [MenuItem("Tools/生成角色动画 (Player_Idle/Walk/Run/Jump)")]
    public static void Generate()
    {
        // 1. 确保 Animations 文件夹存在
        if (!AssetDatabase.IsValidFolder(AnimFolder))
            AssetDatabase.CreateFolder("Assets", "Animations");

        string duckRoot = "Assets/Art/DuckyDuck/FOWL ANIMAL DUCKY/Animation PNG/DUCKY/NUDE";

        // 2. 收集每个动画的帧图片（按文件名排序）
        var sets = new Dictionary<string, string[]>
        {
            { "Player_Idle", new[] { duckRoot + "/01-Idle/01-Idle" } },
            { "Player_Walk", new[] { duckRoot + "/03-Walk" } },
            { "Player_Run",  new[] { duckRoot + "/04-Run" } },
            { "Player_Jump", new[] { duckRoot + "/06-Jump/01-Jump_Up", duckRoot + "/06-Jump/02-Jump_Fall" } },
        };

        var clips = new Dictionary<string, AnimationClip>();
        foreach (var kv in sets)
        {
            List<Sprite> frames = new List<Sprite>();
            foreach (string folder in kv.Value)
            {
                string[] guids = AssetDatabase.FindAssets("t:Sprite", new[] { folder });
                List<Sprite> inFolder = new List<Sprite>();
                foreach (string g in guids)
                {
                    Sprite s = AssetDatabase.LoadAssetAtPath<Sprite>(AssetDatabase.GUIDToAssetPath(g));
                    if (s != null) inFolder.Add(s);
                }
                inFolder.Sort((a, b) => string.CompareOrdinal(a.name, b.name));
                frames.AddRange(inFolder);
            }

            if (frames.Count == 0)
            {
                Debug.LogError("[生成动画] 在文件夹找不到帧图片: " + kv.Value[0] + " ，请检查素材是否已导入");
                continue;
            }

            AnimationClip clip = new AnimationClip();
            clip.name = kv.Key;
            clip.frameRate = 12;

            var binding = EditorCurveBinding.PPtrCurve("", typeof(SpriteRenderer), "m_Sprite");
            var keys = new ObjectReferenceKeyframe[frames.Count];
            for (int i = 0; i < frames.Count; i++)
            {
                keys[i] = new ObjectReferenceKeyframe { time = i / 12f, value = frames[i] };
            }
            AnimationUtility.SetObjectReferenceCurve(clip, binding, keys);

            var settings = AnimationUtility.GetAnimationClipSettings(clip);
            settings.loopTime = (kv.Key != "Player_Jump");
            AnimationUtility.SetAnimationClipSettings(clip, settings);

            string path = AnimFolder + "/" + kv.Key + ".anim";
            AssetDatabase.DeleteAsset(path);
            AssetDatabase.CreateAsset(clip, path);
            clips[kv.Key] = clip;
        }

        // 3. 创建 Animator 控制器（Idle / Walk / Run / Jump + 三个参数）
        string controllerPath = AnimFolder + "/PlayerAnimator.controller";
        AssetDatabase.DeleteAsset(controllerPath);
        AnimatorController ac = AnimatorController.CreateAnimatorControllerAtPath(controllerPath);

        ac.AddParameter("Speed", AnimatorControllerParameterType.Float);
        ac.AddParameter("isGrounded", AnimatorControllerParameterType.Bool);
        ac.AddParameter("yVelocity", AnimatorControllerParameterType.Float);

        AnimatorStateMachine sm = ac.layers[0].stateMachine;
        AnimatorState idle = AddState(sm, "Idle", clips.ContainsKey("Player_Idle") ? clips["Player_Idle"] : null);
        AnimatorState walk = AddState(sm, "Walk", clips.ContainsKey("Player_Walk") ? clips["Player_Walk"] : null);
        AnimatorState run  = AddState(sm, "Run",  clips.ContainsKey("Player_Run")  ? clips["Player_Run"]  : null);
        AnimatorState jump = AddState(sm, "Jump", clips.ContainsKey("Player_Jump") ? clips["Player_Jump"] : null);
        sm.defaultState = idle;

        AnimatorStateTransition t;
        t = idle.AddTransition(walk); t.hasExitTime = false; t.duration = 0; t.AddCondition(AnimatorConditionMode.Greater, 0.1f, "Speed");
        t = walk.AddTransition(idle); t.hasExitTime = false; t.duration = 0; t.AddCondition(AnimatorConditionMode.Less, 0.1f, "Speed");
        t = walk.AddTransition(run);  t.hasExitTime = false; t.duration = 0; t.AddCondition(AnimatorConditionMode.Greater, 2f, "Speed");
        t = run.AddTransition(walk);  t.hasExitTime = false; t.duration = 0; t.AddCondition(AnimatorConditionMode.Less, 2f, "Speed");
        t = idle.AddTransition(jump); t.hasExitTime = false; t.duration = 0; t.AddCondition(AnimatorConditionMode.IfNot, 0, "isGrounded");
        t = walk.AddTransition(jump); t.hasExitTime = false; t.duration = 0; t.AddCondition(AnimatorConditionMode.IfNot, 0, "isGrounded");
        t = run.AddTransition(jump);  t.hasExitTime = false; t.duration = 0; t.AddCondition(AnimatorConditionMode.IfNot, 0, "isGrounded");
        t = jump.AddTransition(idle); t.hasExitTime = false; t.duration = 0; t.AddCondition(AnimatorConditionMode.If, 0, "isGrounded");

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("[生成动画] 完成！已生成 4 个动画 + PlayerAnimator.controller 到 " + AnimFolder);
    }

    private static AnimatorState AddState(AnimatorStateMachine sm, string name, AnimationClip clip)
    {
        AnimatorState st = sm.AddState(name);
        st.motion = clip;
        return st;
    }
}
