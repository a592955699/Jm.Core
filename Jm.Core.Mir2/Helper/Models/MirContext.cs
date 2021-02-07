using Jm.Core.Mir2.Server.VisualMapInfo.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Models
{
    public class MirContext
    {
        /// <summary>
        /// 挂机角色信息
        /// </summary>
        public RoleInfo Role { get; set; }
        /// <summary>
        /// 人物 Hp
        /// </summary>
        public Hp Hp { get; set; }
        //人物 Mp
        public Hp Mp { get; set; }
        #region 待处理属性
        //攻击
        //魔法
        //道术
        //防御
        //魔防
        //魔法躲避
        //毒物恢复
        //攻击速度
        //敏捷
        #endregion
        /// <summary>
        /// 地图信息
        /// </summary>
        public ReadMap ReadMap { get; set; }
        /// <summary>
        /// 攻击目标
        /// </summary>
        public object AttackTarget { get; set; }
        /// <summary>
        /// 装备信息
        /// </summary>
        public Weaponry Weaponry { get; set; }
        /// <summary>
        /// 当前位置信息
        /// </summary>
        public Position Position { get; set; }
        /// <summary>
        /// 挂机巡逻点
        /// <para>这个是通过读取配置获得的</para>
        /// </summary>
        public List<Point> PatrolPoints { get; set; } = new List<Point>();
        /// <summary>
        /// 巡逻点规则 
        /// true:按照 PatrolPoint 索引升序对应的 Point 巡逻
        /// false:按照 PatrolPoint 索引降序序对应的 Point 巡逻
        /// </summary>
        public bool PatrolReverse { get; set; }
        /// <summary>
        /// 挂机路线图 
        /// <para>注意：根据 巡逻点 PatrolPoints 获得后，就存储不变化</para>
        /// </summary>
        public List<Point> PathPoints { get; set; }
        /// <summary>
        /// 临时路线图
        /// <para>PatrolReverse=true 时,为 PathPoints 倒叙</para>
        /// <para>PatrolReverse=false 是，为 PathPoints 升序</para>
        /// <para>每到达一个点附近，则从 TempPathPoints 删除该点</para>
        /// </summary>
        public List<Point> TempPathPoints { get; set; } 
    }
}
