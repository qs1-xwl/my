C1951Hero - Elizabeth 主角素材包
=================================

来源
----
用户提供的 C1951.zip（素材站像素角色序列包），本目录只挑选主角 Elizabeth 及其配套魔法特效。

目录结构
--------
C1951Hero/
  README.txt            本说明
  Elizabeth/            主角 - Elizabeth（深色长发+金色头饰，魔法攻击型贵族少女）
    Idle/     frame0~1   待机（2帧）
    Walk/     frame0~5   走路（6帧）
    Attack/   frame0~7   魔法攻击（8帧，手部蓝红魔法特效）
    Sing/     frame0~9   吟唱/施法（10帧）
    Hit/      frame0     受击（1帧）
    Dead/     frame0~6   死亡（7帧）
  Effects/
    MagicPillar/ frame0~23  紫色能量柱特效（24帧，配魔法攻击）

使用说明
--------
1. 所有帧为 64x64 透明 PNG，导入 Unity 后 Sprite Mode 选 Single 或 Multiple 均可，
   建议单张拖入动画时间轴使用（与 hero120008 用法一致）。
2. 该包角色只有：走路/待机/攻击/吟唱/受击/死亡，没有跳跃、跑步、冲刺动画。
   - 跳跃：可暂时用 Idle 帧（或 Idle 帧上下位移）补齐；
   - 冲刺/跑步：可把 Walk 帧加快播放速度模拟。
3. MagicPillar 特效为攻击特效，可挂到攻击动画节点或作为子弹特效使用。

注意
----
本目录由 AI 整理挑选，仅包含主角 Elizabeth 与 1 组特效；
如需其他 190 个角色或 65 组特效，请告知再补充。
