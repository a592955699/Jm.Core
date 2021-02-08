using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Enums
{
    public enum AttackMode : byte
    {
        /// <summary>
        /// 和平模式
        /// </summary>
        Peace = 0,
        /// <summary>
        /// 编组模式
        /// </summary>
        Group = 1,
        /// <summary>
        /// 行会模式
        /// </summary>
        Guild = 2,
        /// <summary>
        /// 
        /// </summary>
        EnemyGuild = 3,
        /// <summary>
        /// 红名模式
        /// </summary>
        RedBrown = 4,
        /// <summary>
        /// 全体模式
        /// </summary>
        All = 5
    }
}
