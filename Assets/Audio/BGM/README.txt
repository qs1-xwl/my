背景音乐：哥特地窖（第二关用）
================================

文件
----
Assets\Audio\BGM\bgm_dark_hall.wav
    时长 54.50 秒 / 40000 Hz / 立体声 / 16 bit / 8.7 MB
    低沉管风琴 + 大提琴长音 + 远处钟声，无任何人声

【重要】这个文件已经做过无缝循环处理
    AI 原始版长 60 秒，但末尾 3.5 秒是逐级淡到完全静音的——
    如果直接勾 Loop，每轮循环会空 3 秒多，听起来像音乐断了再重来。
    现在的版本：裁掉了那段静音，并把结尾 2 秒与开头 2 秒做了交叉淡化。
    实测首帧 1515、末帧 1516，差 1 个采样点，勾 Loop 是无缝的。

接入步骤（不用写代码）
--------------------
1. Hierarchy 里右键 > Create Empty，命名 BGM

2. 选中它，Inspector 里 Add Component > Audio Source

3. Audio Source 里设置：
   - AudioClip          -> bgm_dark_hall
   - Loop               -> 勾上（这个文件已经无缝，可以放心勾）
   - Play On Awake      -> 勾上（进关自动播）
   - Spatial Blend      -> 拖到最左边 2D（一定要，否则声音会随相机距离衰减）
   - Volume             -> 0.6 起（这首偏响，实测 RMS 1495）
   - Priority           -> 128（默认即可）
   - Mute               -> 不勾

4. 运行，进第二关就能听到一直循环的 BGM

注意
----
- 不要给这个 AudioSource 挂 Audio Listener，场景里 Main Camera 已经有一个了，
  一个场景只能有一个 Audio Listener。
- 如果觉得低音太厚，Volume 降到 0.4 ~ 0.5。
- 如果要做探索/战斗分段切歌，跟我说，我按你选定的另外两首再配一套切换方案。

原文件位置（项目外备份）
------------------------
C:\Users\a\Doubao\chats\2026-10-29\new-chat\bgm_organ.wav          原始 60 秒版
C:\Users\a\Doubao\chats\2026-10-29\new-chat\bgm_organ_seamless.wav 无缝版（已复制进项目）
C:\Users\a\Doubao\chats\2026-10-29\new-chat\bgm_piano.wav          B 钢琴（备用）
C:\Users\a\Doubao\chats\2026-10-29\new-chat\bgm_strings.wav        C 弦乐（备用）
