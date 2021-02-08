using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Enums
{
    /// <summary>
    /// 怪物攻击行为
    /// </summary>
    public enum MirAction : byte
    {
        Standing,//站立
        Walking,//行走
        Running,//跑步，玩家才有
        Pushed,//被推动,针对人物的后退动作，怪物的话，没有，怪物都是直接移动到那边去的
        DashL,//短跑
        DashR,
        DashFail,
        Stance,//站立
        Stance2,//站立2
        Attack1,//攻击
        Attack2,
        Attack3,
        Attack4,
        Attack5,
        AttackRange1,//范围攻击
        AttackRange2,
        AttackRange3,
        Special,
        Struck,//被攻击
        Harvest,//收获，这个是针对玩家的
        Spell,//施法
        Die,//正死亡
        Dead,//已死亡
        Skeleton,//骨架
        Show,//显示,如石化的祖玛怪物的激活，如神兽的激活（变大）等
        Hide,//隐身
        Stoned,//石化,比如祖玛卫士等石化效果
        Appear,//显现，出现，主要针对召唤骷髅，召唤神兽，需要显示出来的.
        Revive,//复活，这个大部分的都是和Die（正死亡）的动作是一样的
        SitDown,//坐下
        Mine,//挖矿
        Sneek,//蛇形走位，针对刺客
        DashAttack,//跑动攻击，针对刺客
        Lunge,//弓步

        WalkingBow,
        RunningBow,
        Jump,

        MountStanding,
        MountWalking,
        MountRunning,
        MountStruck,
        MountAttack,

        FishingCast,
        FishingWait,
        FishingReel,

        Standing2,//另外一种形态下的站立
        Walking2,//另外一种形态下的站立
        Struck2,//另外一种形态被攻击
        MoveAttack1,//移动攻击
        MoveAttack2,//移动攻击
        MoveAttack3//移动攻击
    }
}
