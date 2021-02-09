using Jm.Core.Mir2.Helper.Enums;
using Jm.Core.Mir2.Helper.Extensions;
using Jm.Core.Mir2.Helper.Models;
using Jm.Core.Mir2.Server.VisualMapInfo.Class.AStart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
namespace Jm.Core.Mir2.Helper
{
    /// <summary>
    /// 挂机流程控制抽象类
    /// <para>调用 IMirAction 方法来实现功能流程，不在该类中些具体的单个小点的实现</para>
    /// </summary>
    public abstract class AbstractMirService
    {
        #region 构造函数
        public AbstractMirService(MirContext mirContext, CancellationTokenSource cancellationTokenSource)
        {
            this.MirContext = mirContext;
        }

        public MirContext MirContext { get; private set; }
        public IMirAction MirAction { get { return MirContext.MirAction; } }
        public CancellationTokenSource CancellationTokenSource { get; private set; }
        #endregion

        #region 挂机逻辑入口
        /// <summary>
        /// 开始挂机
        /// </summary>
        /// <returns></returns>
        public void Start()
        {
            do
            {
                string message = string.Empty;

                #region 判断回城
                var checkBackToCity = CheckBackToCity();
                if (checkBackToCity.Success)
                {
                    #region 回城
                    var backToCity = BackToCity(MirContext.CancellationTokenSource);
                  
                    if (!backToCity.Success)
                    {
                        Warn("回城异常：" + backToCity.Message);
                        break;
                    }
                    #endregion

                    #region 存、卖、修
                    var storage = Storage(CancellationTokenSource);
                    if (!storage.Success)
                    {
                        Warn("存装备异常：" + storage.Message);
                        break;
                    }

                    var sellRing = SellRing(CancellationTokenSource);
                    if (!sellRing.Success)
                    {
                        Warn("卖戒指异常：" + sellRing.Message);
                        break;
                    }

                    var repairRing = RepairRing(CancellationTokenSource);
                    if (!repairRing.Success)
                    {
                        Warn("修戒指异常：" + repairRing.Message);
                        break;
                    }

                    var sellBracelet = SellBracelet(CancellationTokenSource);
                    if (!sellBracelet.Success)
                    {
                        Warn("卖手镯异常：" + sellBracelet.Message);
                        break;
                    }

                    var repairBracelet = RepairBracelet(CancellationTokenSource);
                    if (!repairBracelet.Success)
                    {
                        Warn("修手镯异常：" + repairBracelet.Message);
                        break;
                    }

                    var sellNecklace = SellNecklace(CancellationTokenSource);
                    if (!sellNecklace.Success)
                    {
                        Warn("卖项链异常：" + sellNecklace.Message);
                        break;
                    }

                    var repairNecklace = RepairNecklace(CancellationTokenSource);
                    if (!repairNecklace.Success)
                    {
                        Warn("修项链异常：" + repairNecklace.Message);
                        break;
                    }

                    var sellHelmet = SellHelmet(CancellationTokenSource);
                    if (!sellHelmet.Success)
                    {
                        Warn("卖头盔异常：" + sellHelmet.Message);
                        break;
                    }

                    var repairHelmet = RepairHelmet(CancellationTokenSource);
                    if (!repairHelmet.Success)
                    {
                        Warn("修头盔异常：" + repairHelmet.Message);
                        break;
                    }

                    var sellArmour = SellArmour(CancellationTokenSource);
                    if (!sellArmour.Success)
                    {
                        Warn("卖衣服异常：" + sellArmour.Message);
                        break;
                    }

                    var repairArmour = RepairArmour(CancellationTokenSource);
                    if (!repairArmour.Success)
                    {
                        Warn("修头衣服常：" + repairArmour.Message);
                        break;
                    }

                    //#TODO 卖靴子、修鞋子；卖腰带、修腰带；卖勋章、修勋章
                    #endregion
                }
                #region 出发去挂机地图
                var readyGo = ReadyGo(CancellationTokenSource);
                if (!readyGo.Success)
                {
                    Warn("出发异常：" + readyGo.Message);
                    break;
                }
                #endregion

                //自动打怪
                var autoFire = AutoFire(CancellationTokenSource);
                if(!autoFire.Success)
                {
                    Warn("自动打怪异常：" + autoFire.Message);
                    break;
                }
                #endregion
            } while (MirContext.CancellationTokenSource.IsCancellationRequested);
        }
        /// <summary>
        /// 走到坐标
        /// </summary>
        /// <param name="mapInfo"></param>
        /// <param name="point"></param>
        /// <param name="cancellationTokenSource"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public ActionResult MoveToPoint(MapInfo mapInfo, APoint point, CancellationTokenSource cancellationTokenSource, int distance = 2, Func<bool> func = null)
        {
            var position = MirContext.Position;
            //同一个地图判断
            if (!position.MapInfo.Equals(mapInfo))
            {
                return new ActionResult(Consts.NotSameMap,"不在同一个地图");
            }

            //距离判断
            if (CalculationDistance(position.Point, point) <= distance)
            {
                return new ActionResult();
            }

            /**
             * 1.找到两个点的路径
             * 2.循环路径，一个个点的走过去（需要考虑人怪卡位问题）
             */
            string message = string.Empty;

            #region 1.找到两个点的路径
            var findPath = FindPath(position, point);
            var pathPoints = findPath.Data;
            if (findPath.Success && !pathPoints.Any())
            {
                return new ActionResult(Consts.AutoRoteFail, findPath.Message);
            }
            #endregion

            #region 循环路径，一个个点的走过去（需要考虑人怪卡位问题）
            APoint firstAPoint = pathPoints.FirstOrDefault();
            //APoint secondAPoint = null;
            MirDirection mirDirection = MirDirection.None;
            RunType runType = RunType.FastRun;
            //移动是否成功
            bool moveState = false;
            bool reFindPath = false;
            //循环条件
            //还有点位没有走到
            //没有被取消
            //同一个地图
            //距离大于 distance
            while (firstAPoint != null
                && !cancellationTokenSource.IsCancellationRequested
                && position.MapInfo.Equals(mapInfo)
                && CalculationDistance(position.Point, point) > distance)
            {
                try
                {
                    #region 计算移动方向
                    mirDirection = CalculationDirection(position.Point, firstAPoint);
                    if (mirDirection == MirDirection.None)
                    {
                        //已经到达位置，需要重新计算路线
                        findPath = FindPath(MirContext.Position, point);
                        if(findPath.Success && findPath.Data.Any())
                        {
                            pathPoints = findPath.Data;
                        }
                        else
                        {
                            pathPoints = new List<APoint>();
                        }
                        continue;
                    }
                    #endregion

                    #region 计算移动方式
                    runType = CalculationRunType(position, firstAPoint);
                    #endregion

                    #region 移动
                    var actionResult = MirAction.Move(mirDirection, runType);
                    //#TODO 判断 actionResult 状态，并输入日志
                    moveState = actionResult.Data;
                    if (moveState)
                    {
                        //更新最后移动时间
                        MirContext.LastMoveTime = new DateTime();
                        pathPoints.Remove(firstAPoint);

                        //打怪过程有移动过，这重新寻路
                        if (func != null)
                        {
                            reFindPath = func();
                        }
                    }
                    else
                    {
                        var nextPoint = GetNextPoint(position.Point, mirDirection, runType);
                        //#TODO，如果是跑，需要再处理下
                        //移动失败，15秒内不走这个点
                        MirContext.AddBartPoint(nextPoint, position.MapInfo, DateTime.Now.AddSeconds(15));

                        if(LongTimeNotMove())
                        {
                            //长时间被堵住，随用随机飞
                        }
                        //被堵后，重新寻路
                        reFindPath = true;
                    }
                    if(reFindPath)
                    {
                        findPath = FindPath(MirContext.Position, point);
                        if (findPath.Success && findPath.Data.Any())
                        {
                            pathPoints = findPath.Data;
                        }
                        else
                        {
                            pathPoints = new List<APoint>();
                            return new ActionResult(findPath.Code, findPath.Message);
                        }
                    }
                    #endregion
                }
                finally
                {
                    firstAPoint = pathPoints.FirstOrDefault();
                    position = MirContext.Position;
                }
            }
            #endregion
            return new ActionResult();
        }

        public ActionResult MoveAndFireToPoint(MapInfo mapInfo, APoint point, CancellationTokenSource cancellationTokenSource, int distance = 2)
        {
            return MoveToPoint(mapInfo,point,cancellationTokenSource,distance,()=> {
                bool move = true;
                var actionResult = MirAction.FindMaster();
                //#TODO 判断 actionResult ,并输出日志
                var masters = actionResult.Data;
                while(masters.Any())
                {
                    move = true;
                    var master = masters.NearbyMaster(MirContext.Position);
                    MirAction.AttackMaster(master, cancellationTokenSource);
                }
                var actionResult2= MirAction.FindItems();
                //#TODO 判断 actionResult ,并输出日志
                var items = actionResult2.Data;
                while(items.Any())
                {
                    //#TODO ,需要判断物品所在位置被人怪站住的情况
                    var item = items.NearbyItem(MirContext.Position);
                    MirAction.PickupItem(item);
                }
                return move;
            });
        }
        /// <summary>
        /// 范围内随机移动
        /// </summary>
        /// <param name="mapInfo"></param>
        /// <param name="point"></param>
        /// <param name="cancellationTokenSource"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public ActionResult RandomRangeMove(MapInfo mapInfo, Point point, CancellationTokenSource cancellationTokenSource, int distance = 2)
        {
            return new ActionResult();
        }
        #endregion

        #region 内部方法
        #region 移动相关
        /// <summary>
        /// 检测四面八方都被堵路
        /// <para>5分钟未成功移动过</para>
        /// </summary>
        /// <returns></returns>
        protected bool LongTimeNotMove()
        {
            return (DateTime.Now - MirContext.LastMoveTime).TotalMinutes > 5;
        }

        /// <summary>
        /// 计算位置方向
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public MirDirection CalculationDirection(APoint p1, APoint p2)
        {
            if (p2 == null || p1 == null)
                return MirDirection.None;

            if (p1.X == p2.X && p1.Y < p2.Y)
            {
                return MirDirection.Up;
            }
            if (p1.X == p2.X && p1.Y > p2.Y)
            {
                return MirDirection.Down;
            }
            else if (p1.X < p2.X && p1.Y < p2.Y)
            {
                return MirDirection.UpRight;
            }
            else if (p1.X < p2.X && p1.Y > p2.Y)
            {
                return MirDirection.DownRight;
            }
            else if (p1.X > p2.X && p1.Y == p2.Y)
            {
                return MirDirection.Left;
            }
            else if (p1.X > p2.X && p1.Y > p2.Y)
            {
                return MirDirection.DownLeft;
            }
            else if (p1.X > p2.X && p1.Y < p2.Y)
            {
                return MirDirection.UpLeft;
            }
            else
                return MirDirection.None;
        }
        public APoint GetNextPoint(APoint point, MirDirection mirDirection, RunType runType)
        {
            int step = runType == RunType.Normal ? 1 : 2;
            APoint temp = null;
            switch (mirDirection)
            {
                case MirDirection.Up:
                    temp = new APoint(point.X, point.Y + step);
                    break;
                case MirDirection.UpRight:
                    temp = new APoint(point.X + step, point.Y + step);
                    break;
                case MirDirection.Right:
                    temp = new APoint(point.X + step, point.Y);
                    break;
                case MirDirection.DownRight:
                    temp = new APoint(point.X + step, point.Y - step);
                    break;
                case MirDirection.Down:
                    temp = new APoint(point.X, point.Y - step);
                    break;
                case MirDirection.DownLeft:
                    temp = new APoint(point.X - step, point.Y - step);
                    break;
                case MirDirection.Left:
                    temp = new APoint(point.X - step, point.Y );
                    break;
                case MirDirection.UpLeft:
                    temp = new APoint(point.X - step, point.Y + step);
                    break;
            }
            return temp;
        }

        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public int CalculationDistance(APoint p1, APoint p2)
        {
            int dx = Math.Abs(p1.X - p2.Y);
            int dy = Math.Abs(p1.Y - p2.Y);
            return dx > dy ? dx : dy;
        }
        /// <summary>
        /// 计算移动方式
        /// <para>必须保证 p1 p2相临再跑一步的距离内</para>
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        public RunType CalculationRunType(PositionInfo position, APoint p2)
        {
            var xd = position.Point.X - p2.X;
            var yd = position.Point.Y - p2.Y;
            if (Math.Abs(xd) <= 1 && Math.Abs(yd) <= 1)
            {
                return RunType.Normal;
            }
            else
            {
                //APoint p3 = new APoint(p2.X + x, p2.Y + y);
                var maze = MirContext.Maze(position.MapInfo);
                int x = p2.X + xd;
                int y = p2.Y + yd;
                if(x>MirContext.ReadMap.Width ||y>MirContext.ReadMap.Height)//跑步终点坐标超出地图
                {
                    return RunType.Normal;
                }
                else
                {
                    //跑步终点坐标有障碍物则走，否则跑
                    return maze[x, y] == 1 ? RunType.Normal : RunType.FastRun;
                }
            }
        }

        /// <summary>
        /// 过地图
        /// </summary>
        /// <param name="fromMap"></param>
        /// <param name="toMap"></param>
        /// <returns></returns>
        protected ActionResult GoToMap(MapInfo fromMap, MapInfo toMap, CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        } 
        #endregion

        #region 买/卖/修
        /// <summary>
        /// 卖武器
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult BuyWeapon(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 卖武器
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult SellWeapon(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 修理武器
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult RepairWeapon(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 买衣服
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult BuyArmour(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 卖衣服
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult SellArmour(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 修理衣服
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult RepairArmour(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 买头盔
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult BuyHelmet(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 卖头盔
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult SellHelmet(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 修理头盔
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult RepairHelmet(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 买项链
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult BuyNecklace(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 卖项链
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult SellNecklace(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 修理项链
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult RepairNecklace(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 买手镯
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult BuyBracelet(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 卖手镯
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult SellBracelet(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 修理手镯
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult RepairBracelet(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 买戒指
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult BuyRing(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 卖戒指
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult SellRing(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 修理戒指
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult RepairRing(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 买毒符
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult BuyAmulet(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 卖毒符
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult SellAmulet(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 修理毒符
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult RepairAmulet(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 买药水
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult BuyPotion(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 卖药水
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult SellPotion(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        #endregion

        /// <summary>
        /// 寻路
        /// </summary>
        /// <param name="position"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        protected ActionResult<List<APoint>> FindPath(PositionInfo position, APoint to)
        {
            PathGrid pathGrid = new PathGrid(MirContext.ReadMap.Width, MirContext.ReadMap.Height, MirContext.Maze(position.MapInfo));
            return new ActionResult<List<APoint>>(pathGrid.FindPath(position.Point, to));
        }

        /// <summary>
        /// 存装备
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult Storage(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult ReadyGo(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }

        /// <summary>
        /// 自动战斗
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult AutoFire(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }

        /// <summary>
        /// 回城
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult BackToCity(CancellationTokenSource cancellationTokenSource)
        {
            return new ActionResult();
        }
        /// <summary>
        /// 检查药水
        /// </summary>
        /// <returns></returns>
        protected ActionResult CheckPotion()
        {
            return new ActionResult();
        }
        /// <summary>
        /// 检查装备持久
        /// </summary>
        /// <returns></returns>
        protected ActionResult CheckDurability()
        {
            return new ActionResult();
        }
        /// <summary>
        /// 检查包裹是否满了
        /// </summary>
        /// <returns></returns>
        protected ActionResult CheckPackage()
        {
            return new ActionResult();
        }
        /// <summary>
        /// 检查是否需要回城
        /// </summary>
        /// <returns></returns>
        protected ActionResult CheckBackToCity()
        {
            //检查红药水数据量
            //检查蓝药水数量
            //检查护身符数量
            //检查毒药数量
            //检查空包裹格子数量
            //检查装备持久度
            var checkPackage = CheckPackage();
            if (!checkPackage.Success)
            {
                return checkPackage;
            }
            var checkDurability = CheckDurability();
            if (!checkDurability.Success)
            {
                return checkDurability;
            }
            var checkPotion = CheckPotion();
            if (!checkPotion.Success)
            {
                return checkPotion;
            }
            return new ActionResult();
        }
        #endregion

        #region 错误处理
        public void Error(string message) { }
        public void Warn(string message) { }
        public void Info(string message) { }
        public void Debug(string message) { }
        #endregion
    }
}
