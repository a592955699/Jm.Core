using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Enums
{
    /// <summary>
    /// 技能效果
    /// </summary>
    public enum SpellEffect : byte
    {
        None,
        FatalSword,//基本刺术的效果
        Teleport,//传送效果
        Healing,//治疗效果
        RedMoonEvil,//赤月恶魔的地钉
        TwinDrakeBlade,//双龙，特效
        MagicShieldUp,//魔法盾
        MagicShieldDown,//魔法盾
        GreatFoxSpirit,//悲月天珠的特效
        Entrapment,//擒龙手特效
        Reflect,//反伤？
        Critical,
        Mine,
        ElementalBarrierUp,//金刚盾
        ElementalBarrierDown,//金刚盾
        DelayedExplosion,//延迟炸弹特效
        MPEater,//真气调息,吸收蓝的效果
        Hemorrhage,//血风击
        Bleeding,//流血效果
        AwakeningSuccess,
        AwakeningFail,
        AwakeningMiss,
        AwakeningHit,
        StormEscape,//风暴传送，风雷术
        TurtleKing,//大龟王的特效
        Behemoth,//怨恶的特效
        Stunned,//击晕特效
        IcePillar,//冰柱效果
        TreeQueen,//树的女王的树钉
        GreatFoxThunder,//悲月的雷电特效
        Focus,//基本箭法，聚集，焦点，噬血等
        FlameRound,//火焰环绕
        PoisonRain,//毒雨
        DelayedBomb,//自爆效果，爆炸效果（契约兽的自爆）
    }
}
