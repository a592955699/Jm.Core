using Jm.Core.Mir2.Helper.Enums;
using Jm.Core.Mir2.Helper.Extensions;
using Jm.Core.Mir2.Helper.Models;
using Jm.Core.Mir2.Server.VisualMapInfo.Class.AStart;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
namespace Jm.Core.Mir2.Helper
{
    /// <summary>
    /// 挂机流程控制抽象类
    /// <para>调用 IMirAction 方法来实现功能流程，不在该类中些具体的单个小点的实现</para>
    /// </summary>
    public abstract class AbstractMirMain
    {
        #region 构造函数
        public AbstractMirMain(IMirAction mirAction, MirContext mirContext, CancellationTokenSource cancellationTokenSource)
        {
            this.MirAction = mirAction;
            this.MirContext = mirContext;
        }

        public MirContext MirContext { get; private set; }
        public IMirAction MirAction { get; private set; }
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
                bool needBackCity = CheckBackToCity();
                if (needBackCity)
                {
                    #region 回城
                    message = BackToCity(MirContext.CancellationTokenSource);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        Warn("回城异常：" + message);
                        break;
                    }
                    #endregion

                    #region 存、卖、修
                    message = Storage(CancellationTokenSource);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        Warn("存装备异常：" + message);
                        break;
                    }

                    message = SellRing(CancellationTokenSource);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        Warn("卖戒指异常：" + message);
                        break;
                    }

                    message = RepairRing(CancellationTokenSource);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        Warn("修戒指异常：" + message);
                        break;
                    }

                    message = SellBracelet(CancellationTokenSource);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        Warn("卖手镯异常：" + message);
                        break;
                    }

                    message = RepairBracelet(CancellationTokenSource);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        Warn("修手镯异常：" + message);
                        break;
                    }

                    message = SellNecklace(CancellationTokenSource);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        Warn("卖项链异常：" + message);
                        break;
                    }

                    message = RepairNecklace(CancellationTokenSource);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        Warn("修项链异常：" + message);
                        break;
                    }

                    message = SellHelmet(CancellationTokenSource);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        Warn("卖头盔异常：" + message);
                        break;
                    }

                    message = RepairHelmet(CancellationTokenSource);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        Warn("修头盔异常：" + message);
                        break;
                    }

                    message = SellArmour(CancellationTokenSource);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        Warn("卖衣服异常：" + message);
                        break;
                    }

                    message = RepairArmour(CancellationTokenSource);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        Warn("修头衣服常：" + message);
                        break;
                    }

                    //#TODO 卖靴子、修鞋子；卖腰带、修腰带；卖勋章、修勋章
                    #endregion
                }
                #region 出发去挂机地图
                message = ReadyGo(CancellationTokenSource);
                if (!string.IsNullOrWhiteSpace(message))
                {
                    Warn("出发异常：" + message);
                    break;
                }
                #endregion

                //自动打怪
                AutoFire(CancellationTokenSource);
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
        public string MoveToPoint(MapInfo mapInfo, APoint point, CancellationTokenSource cancellationTokenSource, int distance = 2)
        {
            var position = MirAction.GetPosition();
            //同一个地图判断
            if (!position.MapInfo.Equals(mapInfo))
            {
                return Consts.NotSameMap;
            }

            //距离判断
            if (MirAction.CalculationDistance(position.Point, point) <= distance)
            {
                return string.Empty;
            }

            /**
             * 1.找到两个点的路径
             * 2.循环路径，一个个点的走过去（需要考虑人怪卡位问题）
             */
            string message = string.Empty;
            #region 1.找到两个点的路径
            PathGrid pathGrid = new PathGrid(MirContext.ReadMap.Width, MirContext.ReadMap.Height, MirContext.ReadMap.Maze);
            var pathPoints = pathGrid.FindPath(position.Point, point);
            if (!pathPoints.Any())
            {
                return Consts.AutoRoteFail;
            }
            #endregion

            #region 循环路径，一个个点的走过去（需要考虑人怪卡位问题）
            APoint firstAPoint = pathPoints.FirstOrDefault();
            APoint secondAPoint = null;
            MirDirection mirDirection = MirDirection.None;
            RunType runType = RunType.FastRun;
            //移动是否成功
            bool moveState = false;

            //循环条件
            //还有点位没有走到
            //没有被取消
            //同一个地图
            //距离大于 distance
            while (firstAPoint != null
                && !cancellationTokenSource.IsCancellationRequested
                && position.MapInfo.Equals(mapInfo)
                && MirAction.CalculationDistance(position.Point, point) > distance)
            {

                try
                {
                    #region 计算移动方向
                    mirDirection = MirAction.CalculationDirection(position.Point, firstAPoint);
                    if (mirDirection == MirDirection.None)
                    {
                        message = Consts.CalculationDirectionFail;
                        break;
                    }
                    #endregion

                    #region 计算移动方式
                    if (pathPoints.Count > 1)
                    {
                        secondAPoint = pathPoints[1];
                    }
                    else
                    {
                        secondAPoint = null;
                    }
                    runType = MirAction.CalculationRunType(position.Point, firstAPoint, secondAPoint);
                    #endregion

                    #region 移动
                    moveState = MirAction.Move(mirDirection, runType);
                    if (moveState)
                    {
                        //更新最后移动时间
                        MirContext.LastMoveTime = new DateTime();

                        pathPoints.Remove(firstAPoint);
                    }
                    #endregion
                }
                finally
                {
                    firstAPoint = pathPoints.FirstOrDefault();
                    position = MirAction.GetPosition();
                }
            }
            #endregion
            return message;
        }
        /// <summary>
        /// 边打边走到位置
        /// <para>可以考虑寻路一个线程，找怪打怪一个线程，两个线程通讯协同处理</para>
        /// </summary>
        /// <param name="mapInfo"></param>
        /// <param name="point"></param>
        /// <param name="cancellationTokenSource"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        [Obsolete]
        public string MoveAndFireToPoint(MapInfo mapInfo, APoint point, CancellationTokenSource cancellationTokenSource, int distance = 2)
        {
            var position = MirAction.GetPosition();
            //同一个地图判断
            if (!position.MapInfo.Equals(mapInfo))
            {
                return Consts.NotSameMap;
            }

            //距离判断
            if (MirAction.CalculationDistance(position.Point, point) <= distance)
            {
                return string.Empty;
            }

            /**
             * 1.找到两个点的路径
             * 2.循环路径，一个个点的走过去（需要考虑人怪卡位问题）
             * 3.走一步，就找怪，打怪，拾取物品
             */
            string message = string.Empty;
            #region 1.找到两个点的路径
            PathGrid pathGrid = new PathGrid(MirContext.ReadMap.Width, MirContext.ReadMap.Height, MirContext.ReadMap.Maze);
            var pathPoints = pathGrid.FindPath(position.Point, point);
            if (!pathPoints.Any())
            {
                return Consts.AutoRoteFail;
            }
            #endregion

            #region 循环路径，一个个点的走过去（需要考虑人怪卡位问题）
            APoint firstAPoint = pathPoints.FirstOrDefault();
            APoint secondAPoint = null;
            MirDirection mirDirection = MirDirection.None;
            RunType runType = RunType.FastRun;
            //移动是否成功
            bool moveState = false;

            //循环条件
            //还有点位没有走到
            //没有被取消
            //同一个地图
            //距离大于 distance
            while (firstAPoint != null
                && !cancellationTokenSource.IsCancellationRequested
                && position.MapInfo.Equals(mapInfo)
                && MirAction.CalculationDistance(position.Point, point) > distance)
            {

                try
                {
                    #region 计算移动方向
                    mirDirection = MirAction.CalculationDirection(position.Point, firstAPoint);
                    if (mirDirection == MirDirection.None)
                    {
                        message = Consts.CalculationDirectionFail;
                        break;
                    }
                    #endregion

                    #region 计算移动方式
                    if (pathPoints.Count > 1)
                    {
                        secondAPoint = pathPoints[1];
                    }
                    else
                    {
                        secondAPoint = null;
                    }
                    runType = MirAction.CalculationRunType(position.Point, firstAPoint, secondAPoint);
                    #endregion

                    #region 移动
                    moveState = MirAction.Move(mirDirection, runType);
                    if (moveState)
                    {
                        //更新最后移动时间
                        MirContext.LastMoveTime = new DateTime();
                        pathPoints.Remove(firstAPoint);

                        bool move = false;

                        #region 打怪
                        var masters = MirAction.GetMaster();
                        while (masters.Any() && !cancellationTokenSource.IsCancellationRequested)
                        {
                            position = MirAction.GetPosition();
                            var nearByMaster = masters.NearbyMaster(position);

                            //开始打怪
                            MirContext.LastAttackTime = DateTime.Now;
                            MirAction.AttackMaster(nearByMaster, cancellationTokenSource);

                            masters = MirAction.GetMaster();

                            move = true;
                        } 
                        #endregion

                        #region 拾取物品
                        var items = MirAction.GetItemInfo();
                        if(items.Any())
                        {
                            position = MirAction.GetPosition();
                            foreach (var item in items)
                            {
                                if (cancellationTokenSource.IsCancellationRequested)
                                {
                                    break;
                                }
                                position = MirAction.GetPosition();
                                MoveToPoint(position.MapInfo, item.Position.Point, cancellationTokenSource, 0);
                                move = true;
                                MirAction.PickupItem(item);
                            }
                        }
                        #endregion

                        #region 由于打怪和拾取物品，需要修正线路
                        if (move)
                        {
                            message = MoveAndFireToPoint(position.MapInfo, firstAPoint, cancellationTokenSource, 0);
                            if (!string.IsNullOrWhiteSpace(message))
                            {
                                return message;
                            }
                        }
                        #endregion

                        position = MirAction.GetPosition();
                    }
                    #endregion
                }
                finally
                {
                    firstAPoint = pathPoints.FirstOrDefault();
                    position = MirAction.GetPosition();
                }
            }
            #endregion
            return message;
        }
        /// <summary>
        /// 范围内随机移动
        /// </summary>
        /// <param name="mapInfo"></param>
        /// <param name="point"></param>
        /// <param name="cancellationTokenSource"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public string RandomRangeMove(MapInfo mapInfo, Point point, CancellationTokenSource cancellationTokenSource, int distance = 2)
        {
            return string.Empty;
        }
        #endregion

        #region 内部方法

        #region 买/卖/修
        /// <summary>
        /// 卖武器
        /// </summary>
        /// <returns></returns>
        protected virtual string BuyWeapon(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 卖武器
        /// </summary>
        /// <returns></returns>
        protected virtual string SellWeapon(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 修理武器
        /// </summary>
        /// <returns></returns>
        protected virtual string RepairWeapon(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 买衣服
        /// </summary>
        /// <returns></returns>
        protected virtual string BuyArmour(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 卖衣服
        /// </summary>
        /// <returns></returns>
        protected virtual string SellArmour(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 修理衣服
        /// </summary>
        /// <returns></returns>
        protected virtual string RepairArmour(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 买头盔
        /// </summary>
        /// <returns></returns>
        protected virtual string BuyHelmet(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 卖头盔
        /// </summary>
        /// <returns></returns>
        protected virtual string SellHelmet(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 修理头盔
        /// </summary>
        /// <returns></returns>
        protected virtual string RepairHelmet(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 买项链
        /// </summary>
        /// <returns></returns>
        protected virtual string BuyNecklace(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 卖项链
        /// </summary>
        /// <returns></returns>
        protected virtual string SellNecklace(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 修理项链
        /// </summary>
        /// <returns></returns>
        protected virtual string RepairNecklace(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 买手镯
        /// </summary>
        /// <returns></returns>
        protected virtual string BuyBracelet(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 卖手镯
        /// </summary>
        /// <returns></returns>
        protected virtual string SellBracelet(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 修理手镯
        /// </summary>
        /// <returns></returns>
        protected virtual string RepairBracelet(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 买戒指
        /// </summary>
        /// <returns></returns>
        protected virtual string BuyRing(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 卖戒指
        /// </summary>
        /// <returns></returns>
        protected virtual string SellRing(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 修理戒指
        /// </summary>
        /// <returns></returns>
        protected virtual string RepairRing(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 买毒符
        /// </summary>
        /// <returns></returns>
        protected virtual string BuyAmulet(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 卖毒符
        /// </summary>
        /// <returns></returns>
        protected virtual string SellAmulet(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 修理毒符
        /// </summary>
        /// <returns></returns>
        protected virtual string RepairAmulet(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 买药水
        /// </summary>
        /// <returns></returns>
        protected virtual string BuyPotion(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 卖药水
        /// </summary>
        /// <returns></returns>
        protected virtual string SellPotion(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        #endregion

        /// <summary>
        /// 存装备
        /// </summary>
        /// <returns></returns>
        protected virtual string Storage(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string ReadyGo(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }

        /// <summary>
        /// 自动战斗
        /// </summary>
        /// <returns></returns>
        protected virtual string AutoFire(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }

        /// <summary>
        /// 回城
        /// </summary>
        /// <returns></returns>
        protected virtual string BackToCity(CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
        }
        /// <summary>
        /// 检查药水
        /// </summary>
        /// <returns></returns>
        protected bool CheckPotion()
        {
            return true;
        }
        /// <summary>
        /// 检查装备持久
        /// </summary>
        /// <returns></returns>
        protected bool CheckDurability()
        {
            return true;
        }
        /// <summary>
        /// 检查包裹是否满了
        /// </summary>
        /// <returns></returns>
        protected bool CheckPackage()
        {
            return true;
        }
        /// <summary>
        /// 检查是否需要回城
        /// </summary>
        /// <returns></returns>
        protected bool CheckBackToCity()
        {
            //检查红药水数据量
            //检查蓝药水数量
            //检查护身符数量
            //检查毒药数量
            //检查空包裹格子数量
            //检查装备持久度
            return CheckPackage() || CheckDurability() || CheckPotion();
        }
        /// <summary>
        /// 过地图
        /// </summary>
        /// <param name="fromMap"></param>
        /// <param name="toMap"></param>
        /// <returns></returns>
        protected string GoToMap(MapInfo fromMap, MapInfo toMap, CancellationTokenSource cancellationTokenSource)
        {
            return string.Empty;
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
