using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Enums
{
    /// <summary>
    /// 宠物模式
    /// </summary>
    public enum PetMode : byte
    {
        /// <summary>
        /// 跟随 + 攻击
        /// </summary>
        Both = 0,
        /// <summary>
        /// 跟随
        /// </summary>
        MoveOnly = 1,
        /// <summary>
        /// 攻击
        /// </summary>
        AttackOnly = 2,
        /// <summary>
        /// 休息
        /// </summary>
        None = 3,
    }
}
