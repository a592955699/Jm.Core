using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Enums
{
    public enum BuffType : byte
    {
        None = 0,

        //魔法
        //magics
        TemporalFlux,//瞬移？
        Hiding,//隐藏
        Haste,//匆忙,体 迅 风，刺客技能
        SwiftFeet,//轻盈，增加移动速度
        Fury,//愤怒,增加攻击速度
        SoulShield,//灵魂盾牌
        BlessedArmour,//美甲
        LightBody,//光体
        UltimateEnhancer,//终极增强者
        ProtectionField,
        Rage,
        Curse,//诅咒
        MoonLight,
        DarkBody,
        Concentration,
        VampireShot,//噬血状态，噬血箭法
        PoisonShot,
        CounterAttack,
        MentalState,
        EnergyShield,
        MagicBooster,
        PetEnhancer,//血龙水
        ImmortalSkin,
        MagicShield,//魔法盾

        //特殊
        //special
        GameMaster = 100,//游戏玩家
        General,//一般
        Exp,//经验加成
        Drop,//掉落
        Gold,//金币？
        BagWeight,//负重？
        Transform,//改变,时装
        RelationshipEXP,//结婚经验
        Mentee,
        Mentor,//
        Guild,//行会
        Prison,//监狱，
        Rested,

        //统计
        //stats
        Impact = 200,//冲击
        Magic,//
        Taoist,
        Storm,
        HealthAid,
        ManaAid,
        Defence,
        MagicDefence,
        WonderDrug,
        Knapsack
    }
}
