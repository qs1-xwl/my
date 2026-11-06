HUD 像素素材（血条 / 体力 / 头像框）
====================================

这批是给你现在那个纯文字 HUD（Coin: / HP: / SP:）换成图形化血条用的。
全部由程序逐像素绘制，硬边、无抗锯齿、无渐变模糊，和暗色瓦片族同一套配色逻辑。

文件与尺寸
----------
hud_bar_frame_stone.png      640×108   底框·石青（跟暗色瓦片、传送门一个色系）
hud_bar_frame_gold.png       640×108   底框·暗金（跟菜单标题 DARK HALL 一个色系）
hud_bar_frame_iron.png       640×108   底框·铁蓝（跟 B 版菜单冷蓝月光一个色系）
hud_bar_fill_hp.png          616×84    血量填充·红
hud_bar_fill_sp_green.png    616×84    体力填充·绿
hud_bar_fill_sp_blue.png     616×84    体力填充·蓝
hud_avatar_frame_stone.png   192×192   圆形头像框·石青（中间镂空，叠在角色图上用）
hud_avatar_frame_gold.png    192×192   圆形头像框·暗金

底框尺寸是逻辑尺寸 320×54 的 2 倍，填充是 308×42 的 2 倍。
2 倍是为了在高分辨率下也清晰，你在 UI 里就按 640×108 这个原始尺寸摆，1:1 像素对点，最锐利。

金币图标不在这批里——用你项目里现成的 Assets\Art\Coin\Coin_Front.png。
角色头像也不在这批里——用你主角的首帧（Elizabeth/Idle/frame0.png 或 PlayerSwordman/Idle/Idle_00.png）。

【导入设置】8 张都要改，不改会糊
------------------------------
选中 png，Inspector 右侧：

    Texture Type            Sprite (2D and UI)
    Sprite Mode             Single
    Pixels Per Unit         100
    Mesh Type               Full Rect          ← Image 用 Filled 模式必须 Full Rect
    Extrude Edges           0
    Filter Mode             Point (no filter)  ← 不回弹就必须这个
    Compression             None
    Generate Mip Maps       取消勾选
    Max Size                2048

改完 Apply。

【搭建血条】底框 + 填充，两层就够
----------------------------------
Unity 的 UI 是从上往下叠的，Hierarchy 里越靠下越显示在前面。
血条只用两层：底框（带实心深槽）放下面，填充放它里面。

1. Canvas 下右键 UI > Image，命名 HP_Bar_Frame
   RectTransform: Width 640, Height 108
   Source Image: hud_bar_frame_stone
   Image Type: Simple
   取消 Preserve Aspect

2. 在 HP_Bar_Frame 下面右键 UI > Image，命名 HP_Bar_Fill
   RectTransform 点锚点预设 stretch，Left/Top/Right/Bottom 全填 12
   （这样自动和底框内槽对齐，尺寸会变成 616×84）
   Source Image: hud_bar_fill_hp
   Image Type: Filled            ← 关键
   Fill Method: Horizontal
   Fill Origin: Left
   Fill Amount: 1

之后代码里调 HP_Bar_Fill.fillAmount 就是血量百分比，比如 3/5 血就填 0.6。
填充会在左端开始、右端被裁掉，正好符合"血在减"。

3. 体力条照抄一份，Source Image 换成 hud_bar_fill_sp_green（或 blue）

【搭建头像】
------------
1. Canvas 下 UI > Image，命名 Avatar_Content，Width/Height 都是 192
   Source Image 拖入主角首帧（frame0.png / Idle_00.png）
   勾 Preserve Aspect，把角色缩放摆到满框

2. 在 Avatar_Content 下面再放一个 UI > Image，命名 Avatar_Ring，尺寸 192×192
   Source Image: hud_avatar_frame_stone
   它是镂空的圆环，盖在角色图上面就形成"圆框裁切"的效果

如果角色超出圆框太多（比如剑穿出框外），可以在 Avatar_Content 上加 Mask 组件，
或者直接给它挂 Sprite Mask。

【搭建金币】
------------
UI > Image，Source Image 拖 Coin_Front，尺寸 68×68
右边放一个 TextMeshProUGUI 显示数字

【代码要加什么】
---------------
现在 UIManager.cs 只有三个 TextMeshProUGUI 字段，没有 Image，所以血条填不满。
要加的话，在你原来的写法上补这几行（中文注释、[Header]、if 判空，跟现有风格一致）：

    [Header("血条")]
    public UnityEngine.UI.Image hpFillImage;      // 红色血条填充
    public UnityEngine.UI.Image spFillImage;      // 体力条填充

    // 血量百分比，0~1
    public void UpdateHpFill(float percent)
    {
        if (hpFillImage != null)
        {
            hpFillImage.fillAmount = Mathf.Clamp01(percent);
        }
    }

    // 体力百分比，0~1
    public void UpdateSpFill(float percent)
    {
        if (spFillImage != null)
        {
            spFillImage.fillAmount = Mathf.Clamp01(percent);
        }
    }

然后在 Inspector 里把这两个字段拖上对应 Image。

原来的 healthText / staminaText 想留着显示数字就留着，想纯图形就干脆不挂。

配色怎么选
----------
三个底框随便挑一个，混用会不协调：
  stone  推荐，跟你场景里所有暗色瓦片同色系，最不突兀
  gold   适合想要"王座/宝箱"那种华丽感的界面
  iron   跟 B 版菜单（铁艺窗月光）的冷蓝调是一套的

体力条绿还是蓝：绿是常见的"耐力"，蓝更冷、更贴你这个暗色场景。看你要哪种感觉。

原文件
------
C:\Users\a\Doubao\chats\2026-10-29\new-chat\ui_preview.png          叠在菜单背景上的效果预览
C:\Users\a\Doubao\chats\2026-10-29\new-chat\ui_assets_overview.png  8 张切图总览
同目录另有 ui_bar_frame_v*.png / ui_bar_fill_*.png / ui_avatar_frame_*.png 原件
