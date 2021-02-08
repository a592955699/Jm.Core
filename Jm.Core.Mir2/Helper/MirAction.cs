using Jm.Core.Mir2.Helper.Enums;
using Jm.Core.Mir2.Helper.Models;
using Jm.Core.Mir2.Server.VisualMapInfo.Class.AStart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper
{
    public class MirAction : IMirAction
    {
        public void AttackMaster(MasterInfo masterInfo, CancellationTokenSource cancellationTokenSource)
        {
            throw new NotImplementedException();
        }

        public bool Buy(ItemInfo itemInfo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 计算位置
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public MirDirection CalculationDirection(Point p1, Point p2)
        {
            if (p2.IsEmpty || p1.IsEmpty)
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

        public MirDirection CalculationDirection(APoint p1, APoint p2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public int CalculationDistance(Point p1, Point p2)
        {
            int dx = Math.Abs(p1.X - p2.Y);
            int dy = Math.Abs(p1.Y - p2.Y);
            return dx > dy ? dx : dy;
        }
        /// <summary>
        /// 估算距离
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public int CalculationDistance(APoint p1, APoint p2)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 计算移动方式
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        public RunType CalculationRunType(APoint p1, APoint p2, APoint p3)
        {
            return (p1.X - p2.X == p2.X - p3.X && p1.Y - p2.Y == p2.Y - p3.Y) ? RunType.FastRun : RunType.Normal;
        }

        public bool CloseMagicInfo()
        {
            throw new NotImplementedException();
        }

        public bool ClosePackage()
        {
            throw new NotImplementedException();
        }

        public bool CloseRoleAttributeInfo()
        {
            throw new NotImplementedException();
        }

        public bool CloseRoleInfo()
        {
            throw new NotImplementedException();
        }

        public bool DialogueNPC(NPCInfo npcInfo)
        {
            throw new NotImplementedException();
        }

        public bool Exit()
        {
            throw new NotImplementedException();
        }

        public bool ExitRole()
        {
            throw new NotImplementedException();
        }

        public BaseNumber GetHP()
        {
            throw new NotImplementedException();
        }

        public List<ItemInfo> GetItemInfo()
        {
            throw new NotImplementedException();
        }

        public int GetLevel()
        {
            throw new NotImplementedException();
        }

        public List<MasterInfo> GetMaster()
        {
            throw new NotImplementedException();
        }

        public BaseNumber GetMP()
        {
            throw new NotImplementedException();
        }

        public PositionInfo GetPosition()
        {
            throw new NotImplementedException();
        }

        public string GetRoleName()
        {
            throw new NotImplementedException();
        }

        public bool Move(MirDirection mirDirection, RunType runType)
        {
            throw new NotImplementedException();
        }

        public bool OpenMagicInfo()
        {
            throw new NotImplementedException();
        }

        public bool OpenPackage()
        {
            throw new NotImplementedException();
        }

        public bool OpenRoleAttributeInfo()
        {
            throw new NotImplementedException();
        }

        public bool OpenRoleInfo()
        {
            throw new NotImplementedException();
        }

        public bool PickupItem(ItemInfo item)
        {
            throw new NotImplementedException();
        }

        public bool RandomMove(RunType runType)
        {
            throw new NotImplementedException();
        }

        public bool RandomMove(RunType runType, Point leftUp, Point rightDown)
        {
            throw new NotImplementedException();
        }

        public bool Repair(ItemInfo itemInfo)
        {
            throw new NotImplementedException();
        }

        public bool SelectDialogueContent(string content)
        {
            throw new NotImplementedException();
        }

        public bool Sell(ItemInfo itemInfo)
        {
            throw new NotImplementedException();
        }

        public bool SRepair(ItemInfo itemInfo)
        {
            throw new NotImplementedException();
        }

        public bool Storage(ItemInfo itemInfo)
        {
            throw new NotImplementedException();
        }
    }
}
