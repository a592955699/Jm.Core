using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Enums
{
    /// <summary>
    /// 毒药类型
    /// </summary>
    [Flags]
    public enum PoisonType : ushort
    {
        None = 0,
        Green = 1,
        Red = 2,
        Slow = 4,//减速
        Frozen = 8,//冰冻，不能动了
        Stun = 16,//打昏
        Paralysis = 32,//麻痹
        DelayedExplosion = 64,//延期爆炸
        Bleeding = 128,//流血
        LRParalysis = 256,//解毒？
        DelayedBomb = 512,//延期自爆（契约兽的自爆）
    }
}
