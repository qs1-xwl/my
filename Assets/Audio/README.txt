PlayerSwordman / Wolf 音效包
============================

生成时间：2026-11-05
格式：WAV  PCM  40000 Hz  双声道  16 bit（已重新封装为标准 44 字节头，Unity 可直接识别）
来源：AI 音频生成（seed-audio），无版权限制，可商用可改

目录
----
Assets\Audio\Player\
    player_jump.wav     跳跃     0.80 秒
    player_hurt.wav     受击     1.10 秒
    player_death.wav    死亡     2.00 秒
    player_attack.wav   攻击     0.50 秒（挥剑破空 + 少女短喝）
    player_defend.wav   防御格挡 0.40 秒（金属撞击"叮" + 少女用力一声）

Assets\Audio\Wolf\
    wolf_attack.wav     攻击     0.80 秒（低吼转扑咬）
    wolf_hurt.wav       受击     0.50 秒
    wolf_death.wav      死亡     2.50 秒（长哀嚎）

怎么接（项目里已有字段，不需要写新代码）
----------------------------------------
1. Player 上的 PlayerController 组件
   - Audio Source  -> 已经有挂在 Player 上的 AudioSource 就拖进去（没有就给 Player 加一个 AudioSource）
   - Jump Sound    -> player_jump.wav

2. Player 上的 PlayerHealth 组件
   - Audio Source  -> 同上
   - Hurt Sound    -> player_hurt.wav
   - Death Sound   -> player_death.wav

3. Enemy(Wolf) 上的 Enemy 组件 + 已有的 AudioSource
   - Audio Source  -> 该物体上的 AudioSource
   - Hurt Sound    -> wolf_hurt.wav
   - Death Sound   -> wolf_death.wav

4. 主角攻击 / 防御音效（唯一需要动一处脚本的地方）
   CombatSystem.cs 目前只有 attackDamage / attackRange / attackCooldown / attackPoint / enemyLayer，
   没有音效字段。要接 player_attack.wav 和 player_defend.wav 需要加：
        public AudioClip attackSound;
        public AudioClip defendSound;
   攻击：在 Input.GetKeyDown(KeyCode.J) 判定成功那一行之后调用
        audioSource.PlayOneShot(attackSound);
   防御：在 isDefending 由 false 变 true 的那一帧调用（按住 C 不要每帧都播）
        audioSource.PlayOneShot(defendSound);

建议 Unity 导入设置（可选）
--------------------------
选中这批 wav，在 Inspector 的 Audio Importer 里：
   - Load Type：Decompress On Load（短音效）
   - Force To Mono：勾上（2D 游戏双声道没意义，省一半内存）
   - 关闭 Normalize？（保持默认即可）
