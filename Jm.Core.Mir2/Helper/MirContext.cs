using Jm.Core.Mir2.Server.VisualMapInfo.Class;
using Jm.Core.Mir2.Server.VisualMapInfo.Class.AStart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Jm.Core.Mir2.Helper.Models
{
    public class MirContext
    {
        public MirContext(IMirAction mirAction)
        {
            MirAction = mirAction;
        }
        public IMirAction MirAction { get; private set; }

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
        public PositionInfo Position { get { return MirAction.GetPosition().Data; } }
        /// <summary>
        /// 生命值
        /// </summary>
        public BaseNumber HP { get { return MirAction.GetHP().Data; } }
        /// <summary>
        /// 魔法值
        /// </summary>
        public BaseNumber MP { get { return MirAction.GetMP().Data; } }
        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get { return MirAction.GetLevel().Data; } }
        /// <summary>
        /// 巡逻点规则 
        /// true:按照 PatrolPoint 索引升序对应的 Point 巡逻
        /// false:按照 PatrolPoint 索引降序序对应的 Point 巡逻
        /// </summary>
        public bool PatrolReverse { get; set; }

        /// <summary>
        /// 临时障碍物，例如给人怪堵住了
        /// </summary>
        private readonly List<BarPoint> barPoints = new List<BarPoint>();
        /// <summary>
        /// 临时障碍物
        /// </summary>
        /// <param name="aPoint"></param>
        public void AddBartPoint(APoint point,MapInfo map,DateTime dateTime)
        {
            barPoints.Add(new BarPoint(point, map, dateTime));
        }
        /// <summary>
        /// 地图迷宫
        /// <para>处理临时障碍物</para>
        /// </summary>
        /// <returns></returns>
        public int[,] Maze(MapInfo map) {
            if(barPoints.Any())
            {
                //移除过期障碍物
                var removeList = barPoints.Where(x => (DateTime.Now - x.DateTime).TotalMilliseconds > 15 || !x.Map.Equals(map));
                foreach (var item in removeList)
                {
                    barPoints.Remove(item);
                }
            }
            if(barPoints.Any())
            {
                var maze = (int[,])ReadMap.Maze.Clone();
                foreach (var item in barPoints)
                {
                    //设置改点为地图迷宫格为障碍物
                    maze[item.Point.X, item.Point.Y] = 1;
                }
                return maze;
            }
            else
            {
                return ReadMap.Maze;
            }
        }
    }
    /// <summary>
    /// 临时障碍物
    /// </summary>
    public class BarPoint
    {
        public BarPoint() { }
        public BarPoint(APoint point,MapInfo map,DateTime dateTime) {
            this.DateTime = dateTime;
            this.Point = point;
            this.Map = map;
        }
        public DateTime DateTime { get; set; }
        public MapInfo Map { get; set; }
        public APoint Point { get; set; }
    }

}
