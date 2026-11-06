角色头像接入说明
================

新加了 3 个文件，在 Assets\Art\UI\HUD\ 下：

hud_avatar_elizabeth.png   192×192   成品头像：深色圆底 + Elizabeth（你现在场景里正在用的那个）
hud_avatar_swordman.png    192×192   成品头像：深色圆底 + Swordman（你新换的主角素材）
hud_avatar_mask.png        192×192   实心白色圆形，给 Mask 组件当裁切遮罩用

前两张是"已经裁好圆的完整头像"，里面包含了深色圆底、角色、外面那圈石青圆环。
第三张在傻瓜做法里用不到，是给你以后想自己换角色时用的。

【做法一：最省事，三步搞定】
--------------------------
1. 在 Canvas 下右键 > UI > Image，命名 Avatar
2. RectTransform 里把 Width / Height 都设成 192
   顺便点一下锚点预设里左上角那一格，再填 Pos X = 40、Pos Y = -40
   （锚点在左上时，Pos Y 填负数才是往下走）
3. 把 hud_avatar_elizabeth.png 拖到 Source Image 上。完成。

就这样，不用挂 Mask，不用叠两层，因为它本来就是圆的，圆外是透明的。

想用 Swordman 版本就把 hud_avatar_swordman.png 拖进去，其它不用动。

导入设置（选中 png，Inspector 右侧）：
    Texture Type        Sprite (2D and UI)
    Sprite Mode         Single
    Pixels Per Unit     100
    Mesh Type           Full Rect
    Filter Mode         Point (no filter)     ← 必须
    Compression         None
    Max Size            2048
改完 Apply。

【做法二：想自己换角色 / 以后换皮肤用】
--------------------------------------
这个思路是"用一个圆形遮罩把角色图裁成圆的"，中间是角色，外面再盖圆环。

1. Canvas 下右键 UI > Image，命名 Avatar_Root
   Width / Height 都设 192
   Source Image 拖 hud_avatar_mask.png
   Color 设成白色，Alpha 不用动
   然后给这个物体 Add Component > Mask
   在 Mask 组件里把 Show Mask Graphic 取消勾选（否则会看到一个白圆）

2. 在 Avatar_Root 下面右键 UI > Image，命名 Avatar_Char
   RectTransform 点锚点预设中央，Width / Height 设成 192
   Source Image 拖你的角色 sprite（比如 Elizabeth\Idle\frame0.png）
   勾 Preserve Aspect
   用 Scale 或 Pos 微调，让角色正好填满这个圆
   —— 它会自动被父物体的 Mask 裁成圆形，超出的部分看不见

3. 再在 Avatar_Root 下面（和 Avatar_Char 同级、排在它后面）右键 UI > Image，命名 Avatar_Ring
   Width / Height 都设 192，Source Image 拖 hud_avatar_frame_stone.png
   这一层是圆环边框，盖在角色上，做出"金属圈"的效果
   注意它也要在 Mask 里面，不然圆环外沿会被裁掉一点点，问题不大

层级看起来应该是：
    Avatar_Root (Image + Mask)
      └─ Avatar_Char  (角色 sprite)
      └─ Avatar_Ring  (圆环)

以后想换角色，只改 Avatar_Char 的 Source Image 就行，圆圈和边框都不用动。

【摆放位置参考】
----------------
你现在 Canvas 是 1920×1080 的参考分辨率，头像放左上角：

    Avatar  RectTransform
        Anchor         左上 (0,1)
        Pos X          40
        Pos Y          -40
        Width/Height   192

血条从头像右边开始，比如 Avatar 右边留 24 的空隙：
    HP_Bar_Frame    Anchor 左上，Pos X = 256，Pos Y = -56

这样头像 192 + 间距，正好跟血条左边缘对齐。

【注意】
------
这批文件是刚复制进 Assets 的，Unity 切回窗口时才会生成 .meta 并导入。
如果 Inspector 里 Source Image 拖不进去、或者显示 None，
先点一下 Project 面板空白处，或者等 Unity 右下角的进度条转完。
