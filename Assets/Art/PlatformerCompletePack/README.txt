Platformer Art Complete Pack (Kenney)
来源: https://opengameart.org/content/platformer-art-complete-pack-often-updated
许可: CC0 (可免费商用, 无需署名, 署名为非强制)
内容: 963 个文件, 包含背景/场景瓦片/角色/敌人/道具/HUD

目录说明:
  - Base pack          基础包(最重要的)
      Tiles            地形瓦片(草地/泥土/砖块/雪地等, 70x70)
      Items            道具(金币/钥匙/门/管道/旗子等)
      Player           玩家角色动画
      Enemies          敌人(含 enemies_spritesheet.png 全套敌人)
      HUD              界面元素(血条/按钮/数字)
      bg.png           远景背景图
      bg_castle.png    城堡远景背景图
  - Buildings expansion 建筑扩展
  - Candy expansion    糖果扩展
  - Ice expansion      冰雪扩展
  - Extra animations and enemies 额外动画和敌人
  - Request pack       追加素材(更多瓦片/道具)

Unity 用法:
  1. 背景: 把 bg.png / bg_castle.png 拖进场景做远景,
     把它的 Sprite Renderer 的 Sorting Order 设成 -10(最底层)
  2. 瓦片: 选 Tiles 下的 PNG, Inspector 里 Sprite Mode 改 Multiple,
     打开 Sprite Editor 按 Grid + 70x70 切片, Apply 后就能配合
     Tilemap 画关卡地形
  3. 敌人/角色: 直接把 PNG 拖进场景, 挂在 Sprite 上即可做预制体