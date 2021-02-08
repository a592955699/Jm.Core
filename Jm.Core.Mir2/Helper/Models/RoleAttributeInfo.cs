using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Models
{
    /// <summary>
    /// 角色属性
    /// </summary>
    public class RoleAttributeInfo
    {
        /// <summary>
        /// 人物 Hp
        /// </summary>
        public BaseNumber HP { get; set; }
        /// <summary>
        /// 人物 Mp
        /// </summary>
        public BaseNumber MP { get; set; }
        /// <summary>
        /// 防御
        /// </summary>
        public BaseNumber AC { get; set; }
        /// <summary>
        /// 魔法防御
        /// </summary>
        public BaseNumber MAC { get; set; }
        /// <summary>
        /// 攻击
        /// </summary>
        public BaseNumber DC { get; set; }
        /// <summary>
        /// 魔法
        /// </summary>
        public BaseNumber MC { get; set; }
        /// <summary>
        /// 道术
        /// </summary>
        public BaseNumber SC { get; set; }
        //魔法躲避
        //毒物恢复
        //攻击速度
        //敏捷
        //幸运值
    }
}
