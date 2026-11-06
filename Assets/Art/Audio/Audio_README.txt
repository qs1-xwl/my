Audio_README.txt — 糖果风游戏音效/音乐素材清单
目录: Assets\Art\Audio\

【一、背景音乐 BGM】
- BGM\bgm_happy_accident.mp3 (2.6 MB, 8bit 欢快循环)
  来源: OpenGameArt "Happy Accident" by Mega Pixel Music Lab
  https://opengameart.org/content/happy-accident
  许可: CC-BY 3.0 (可商用，需署名)
  署名: "Happy Accident by Mega Pixel Music Lab (opengameart.org)"

【二、金币音效】
- SFX\coin_plingy.wav (可爱的 pling 拾取声) ★主推
  来源: OpenGameArt "Plingy Coin" by Fupi
  许可: CC0 (无需署名)
- SFX\collect_8bit.wav / SFX\coin_8bit.wav (8bit 收集音效备选)

【三、跳跃音效】
- SFX\jump_cartoon.ogg (卡通 boing 跳跃声) ★主推
  来源: OpenGameArt "Cute Cartoon Jump" by cfork & qubodup
  许可: CC-BY 3.0 (需署名)
  署名: "Boing Raw Copyright 2005 cfork; Boing Jump Copyright 2012 Iwan Gabovitch"
- SFX\jump_8bit.wav (8bit 跳跃备选)

【四、受伤 / 死亡音效（已换可爱 8bit 风格）】
- SFX\death_hero.wav — 8bit 合成"角色死亡"音效 ★主推
- SFX\hit_cute.wav — 8bit 合成"受击"音效 ★主推
- SFX\hit_8bit.wav / SFX\death_8bit.wav — 备选
  以上来源: OpenGameArt "8-Bit Sound Effects Library" by Little Robot Sound Factory
  https://opengameart.org/content/8-bit-sound-effects-library
  许可: CC-BY 3.0 (需署名)
  署名: "8-Bit Sound Effects Library by Little Robot Sound Factory (www.littlerobotsoundfactory.com)"
- SFX\8bit_library\ — 完整 40 个 8bit 音效仓库 (Mp3+Wav)，可自行挑更多

【废弃】
- SFX\hurt_death\ (19 个人声喊叫) — 风格不搭可爱角色，已弃用待删除

【Unity 用法】
1. 等 Unity 自动导入（出现 .meta 即已导入）
2. 背景音乐: 空物体挂 AudioSource，勾 Loop + Play On Awake，拖 BGM 文件
3. 音效: 代码 AudioSource.PlayOneShot(clip) 播放
   跳跃 -> Jump 处播放 jump_cartoon.ogg
   受伤 -> 受击处播放 hit_cute.wav
   死亡 -> Die() 处播放 death_hero.wav
   金币 -> 碰撞金币时播放 coin_plingy.wav