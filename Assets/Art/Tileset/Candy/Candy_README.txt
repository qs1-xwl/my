Candy Tileset - 糖果奶油卡通地形（Colorosse）
=====================================================
来源：Colorosse  https://www.colorosse.com/assets/2d/tilesets/candy-tileset
作者：Oğuzhan Girgin
许可：CC-BY-4.0 —— 免费使用、可商用；必须署名，推荐署名行：
  "Candy Tileset — baldosas de suelo" by Oğuzhan Girgin, licensed under CC BY 4.0 — https://www.colorosse.com/assets/2d/tilesets/candy-tileset

内容：
  - png\：47 个自动拼接图块 + 地面/墙壁变体 + 灌木/木箱/石头/路标装饰
    每个图块有 @1x(32px) / @2x(64px) / @4x(128px) 三档透明 PNG
  - *.svg：矢量源文件（想改颜色/改形状可直接编辑 SVG）

Unity 使用（推荐 4x，128px）：
  1) 用 png\ 下 @4x 的图（128x128）→ Inspector：Texture Type=Sprite (2D and UI)、Pixels Per Unit=128
  2) 铺地面：ground-base@4x 平铺做主体，growth/rubble 穿插增加变化
  3) 墙：wall-base + wall-cap 组合；装饰：prop-bush / prop-crate / prop-rock / prop-post
  4) 高级：autotile-XXX 按 bitmask 编号，配合 Tile Palette 自动拼接
  5) 注意整数倍缩放（1x/2x/4x），不要 1.5x，否则拼缝出毛边

说明：Desert（上级目录）与更早的手绘包已弃用，确认不需要后可删除。