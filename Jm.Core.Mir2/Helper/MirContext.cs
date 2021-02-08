using Jm.Core.Mir2.Server.VisualMapInfo.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Jm.Core.Mir2.Helper.Models
{
    public class MirContext
    {
        /// <summary>
        /// 
        /// </summary>
        public CancellationTokenSource CancellationTokenSource { get; private set; }
        /// <summary>
        /// 挂机设置
        /// </summary>
        public MirSetting MirSetting { get; private set; }
        /// <summary>
        /// 角色信息
        /// </summary>
        public RoleInfo Role { get; set; }
        /// <summary>
        /// 角色属性
        /// </summary>
        public RoleAttributeInfo RoleAttribute { get; set; } = new RoleAttributeInfo();
        /// <summary>
        /// 地图信息
        /// </summary>
        public ReadMap ReadMap { get; set; }
        /// <summary>
        /// 攻击目标
        /// </summary>
        public MasterInfo AttackTarget { get; set; }
        /// <summary>
        /// 最后打怪时间，判断是否长期没打怪，或者一直打一个假怪
        /// </summary>
        public DateTime LastAttackTime { get; set; } = new DateTime();
        /// <summary>
        /// 最后移动时间，判断卡位后停止挂机等情况
        /// </summary>
        public DateTime LastMoveTime { get; set; } = new DateTime();
        /// <summary>
        /// 最后获取经验时间，判断长时间获取不到经验后，回城重新出发等逻辑
        /// </summary>
        public DateTime LastExperienceTime { get; set; } = new DateTime();

        /// <summary>
        /// 当前位置信息
        /// </summary>
        public PositionInfo Position { get; set; }
       
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
