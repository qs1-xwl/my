B 版菜单素材（SHADOW KEEP · 铁艺窗月光）
========================================

文件
----
menu_shadow_keep_full.png   1920×1080  含标题与三块木牌按钮的完整效果图
menu_shadow_keep_bg.png     1920×1080  纯背景版：文字、按钮、铁链已清除

两张都是像素风（480 像素基准 / 48 色 / 最近邻放大到 1920×1080），同一个场景、同一个光照，
差别只在于 full 版把标题和按钮画在图里，bg 版把它们去掉了。

用途
----
menu_shadow_keep_full.png
    快速看效果用。直接当整张背景贴上去，画面就像成品菜单。
    但按钮是画死的图案，不能点。要点的话得在上面盖透明 Button 热区。

menu_shadow_keep_bg.png
    正式搭菜单用。背景干净，标题和按钮你自己用 TMP 文字 + Button 组件叠上去，
    这样按钮能点、能改字、能做悬停发光。

【最重要的导入设置】
------------------
选中任意一张 png，在 Inspector 右侧设置：

    Texture Type        Sprite (2D and UI)
    Sprite Mode         Single
    Pixels Per Unit     100
    Mesh Type           Full Rect
    Extrude Edges       0
    Filter Mode         Point (no filter)      ← 像素风必须，设 Bilinear 会糊成一团
    Compression         None                    ← 或者 High Quality，别用 Normal
    Generate Mip Maps   取消勾选
    Max Size            2048                    ← 默认如果是 1024 会把 1920 缩成 1024，像素就毁了
    Alpha Is Transparency  勾上（如果以后要抠图）

改完点 Apply，图就不会被拉糊了。

搭建菜单的步骤
--------------
1. Hierarchy 右键 > UI > Canvas
   会自动生成 Canvas + Canvas Scaler + Graphic Raycaster，EventSystem 也会自动加上

2. 选中 Canvas，Inspector 里的 Canvas Scaler 设置：
       UI Scale Mode          Scale With Screen Size
       Reference Resolution   1920 × 1080
       Screen Match Mode      Match Width Or Height
       Match                  0.5

3. 在 Canvas 下右键 > UI > Image，命名 MenuBackground
   RectTransform 点锚点预设里的 full stretch（按住 Alt 点右下角那个图标），
   Left/Top/Right/Bottom 全填 0
   Source Image 拖入 menu_shadow_keep_bg

4. 标题：MenuBackground 下右键 > UI > Text - TextMeshPro
   输入你的游戏名，字号 80 左右，颜色用淡青灰 #C8DCE4，加投影
   （第一次用 TMP 会弹 TMP Essentials 导入提示，点 Import 即可）
   中文字要显示的话，需要 TMP 字体资产支持中文，见下方说明

5. 按钮：Canvas 下右键 > UI > Button - TextMeshPro
   复制三份，垂直排列在右侧，文字分别写 开始游戏 / 设置 / 退出
   每个 Button 的 Image 可以先用半透明深色圆角，或者以后我给你做木牌切图

6. 挂脚本：给三个 Button 的 OnClick 拖入你要调用的方法
   开始游戏 -> SceneManager.LoadScene("Level1")
   退出     -> Application.Quit()

中文字体说明
------------
TextMeshPro 默认字体不含中文。要用中文，两种办法：
  A. Window > TextMeshPro > Font Asset Creator，导入一个中文像素字体（比如 Fusion Pixel / Zpix），
     字符集选 Custom Characters，把你要用的字填进去（开始游戏设置退出继续），生成字体资产
  B. 用旧版 UI Text 组件，Font 选系统字体，字号调小一点，也能显示中文，只是不够像素

建议 A，像素字体才跟画面搭。

原文件备份
----------
C:\Users\a\Doubao\chats\2026-10-29\new-chat\menu_b_px1.png      成品含字
C:\Users\a\Doubao\chats\2026-10-29\new-chat\menu_b_bg_px.png    纯背景
C:\Users\a\Doubao\chats\2026-10-29\new-chat\menu_b_raw.png       AI 原始出图（平滑渲染，未像素化）
另外三版候选（A 大厅 / C 祭坛 / D 裂隙）也在同目录：menu_a_px1 / menu_c_px1 / menu_d_px1
