传送门素材（像素风·空间裂隙）
================================

文件
----
Assets\Art\Portal\portal_rift_pixel.png
    512 x 512，RGBA 透明底，像素风（128 像素源 26 色，最近邻 4 倍放大）
    背景已扣成全透明，直接叠在场景上不会有方形暗块

用法（不用改任何脚本）
--------------------
1. Hierarchy 右键 > 2D Object > Sprites > Square，或者直接把 png 拖进 Scene
   （拖到 Scene 里 Unity 会自动建一个带 SpriteRenderer 的物体）

2. 选中该物体，Sprite Renderer 里设置：
   - Sprite           -> portal_rift_pixel
   - Order in Layer   -> 比地面瓦片高（瓦片用 0 的话这里填 2～3）
   - Color            -> 白色不动
   - Material         -> Sprite-Default

3. Transform：
   - Scale 先保持 1（PPU 100 时这张图在场景里约 5.1 个单位高，
     如果觉得太大，Scale 改成 0.4 ~ 0.6）

4. 导入设置（选中 png，Inspector 里）：
   - Texture Type        -> Sprite (2D and UI)
   - Sprite Mode         -> Single
   - Pixels Per Unit     -> 100（和你现有的瓦片保持一致）
   - Filter Mode         -> Point (no filter)  ← 像素风必须用这个，否则会糊
   - Compression         -> None
   - Generate Mip Maps   -> 取消勾选
   - Alpha Is Transparency -> 勾上

想做"呼吸闪烁"效果（可选，不用写代码）
------------------------------------
在物体上加一个 Animator，用两个 Sprite 交替？
更简单的做法：给 Sprite Renderer 的 Color.a 做一个动画
   - Window > Animation > Create，选中该物体
   - 在 0 秒和 1 秒各记一个关键帧：
       0 秒  Color = 白，alpha 1.0
       0.5 秒 Color = 白，alpha 0.7
       1 秒  Color = 白，alpha 1.0
   - Loop Time 勾上，它就会一直缓缓明暗呼吸

还可以再加一个子物体当光晕：
   在传送门下面建一个 Light 2D（Point Light，颜色取 (104,196,182)，Intensity 1.2）
   和你的 dark_brick 边缘光同色，氛围最统一。
