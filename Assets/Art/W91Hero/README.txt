W91 像素风横版角色序列 (用户网盘提供 hero1200...)
来源: 用户百度网盘 (W91像素风横版角色序列.zip, 艺创游戏美术资源)
格式: 每个角色编号 = 一个动画序列, 内含 idle/attack/hit/miss 四个动作

【主角 hero120008】(用户指定)
  红色连帽斗篷魔法少女, 手持月牙法杖(蓝月牙+金球)
  帧数: idle 9帧 / attack 15帧 / hit 12帧 / miss 7帧
  尺寸: 128x128 每帧, 透明背景, 卡通像素风

【角色库】角色\ 目录下共 165 个编号
  hero120xxx  二次元卡通角色 (001金发粉衣女剑士/002深发蓝紫剑士/008红斗篷法杖...)
  hero290xxx  像素风角色 (001精灵/501猫耳Q版少女...)
  hero2905xx  Q版可爱角色
  hero400xxx  少年战士等

【特效】特效\ 目录下 18 组
  buff1/rhp/dhp/lvUpText 增益回复
  jizhong/jizhong2/jizhong3/leiji/sk6/fireCircle 攻击命中/雷电/火焰特效
  didang 抵挡  cook_pao 烹饪泡  comestage 过关  shiqi 拾取 等

Unity 使用方法:
  1. 拖入 hero120008 的 idle 帧, 选中后 Inspector 设 Sprite Mode=Multiple,
     Filter Mode=Point, 勾 Alpha Is Transparency
  2. 同一动作的 frame 全选拖进 Animator 生成动画剪辑(帧率建议 12~15)
  3. 动作名: Idle / Attack / Hit / Miss, 对应 Animator 参数
  4. 特效目录同样切帧, 叠在角色上层(Sorting Order+1)
  注: 全部 .png 自带透明通道, 白色背景仅为预览底色