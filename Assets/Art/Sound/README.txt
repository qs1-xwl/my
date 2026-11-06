Unity Cute Click Sound (可爱点击音效)
=====================================

来源   : OpenGameArt
作者   : NenadSimic (https://opengameart.org/users/nenadsimic)
许可   : CC-BY 3.0 — 作者在页面评论区明确留言
         "You don't need to credit me :) I'm just happy you found
          this sound useful." (无需署名); 本 README 仍保留作者信息。
页面   : https://opengameart.org/content/menu-selection-click

文件清单:
- Menu_Click.wav  0.23 秒  清脆滴答点击音 (bright / crisp / ticking)
                           适合: 菜单按钮 / 吃金币 / 拾取道具 / UI 通用

音色说明: 高频明亮 (过零率约 0.16, 远高于低频沉闷声的 0.07),
          20770 次下载的高口碑 UI 点击音, 游戏内描述为
          "ticking selection button sound" (滴答式选择按钮音)。

Unity 用法:
1. 最简单: 把 Menu_Click.wav 从 Project 面板拖到场景任意物体上,
   会自动生成带 AudioSource 的物体。
2. 已有物体: Add Component -> AudioSource, 把 WAV 拖进 AudioClip 槽,
   播放时调用 Play / PlayOneShot。
3. 配合现有 Coin.cs (推荐): 选中金币物体, 在 Inspector 的 Coin
   组件里把 Menu_Click.wav 拖进 coinSound 槽, 吃金币自动播放
   (Level1 已有 MainCamera, 不会再报空引用)。
4. UI 按钮: Button 的 OnClick 列表拖入带 AudioSource 的物体,
   选 AudioSource.PlayOneShot, 参数槽拖入 Menu_Click.wav。