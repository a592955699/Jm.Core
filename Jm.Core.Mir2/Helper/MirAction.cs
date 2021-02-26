using Jm.Core.DmApi;
using Jm.Core.Mir2.Helper.Enums;
using Jm.Core.Mir2.Helper.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper
{
    public class MirAction : IMirAction
    {
        dmsoft dmsoft;
        MirContext mirContext;
        public MirAction() { }
        public MirAction(dmsoft _dmsoft, MirContext _mirContext)
        {
            dmsoft = _dmsoft;
            mirContext = _mirContext;
        }
        public MirResult AttackMaster(MasterInfo masterInfo, CancellationTokenSource cancellationTokenSource)
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> Buy(ItemInfo itemInfo)
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> CloseMagicInfo()
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> ClosePackage()
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> CloseRoleAttributeInfo()
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> CloseRoleInfo()
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> DialogueNPC(NPCInfo npcInfo)
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> Exit()
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> ExitRole()
        {
            throw new NotImplementedException();
        }

        public ActionResult<List<ItemInfo>> FindItems()
        {
            return new ActionResult<List<ItemInfo>>(new List<ItemInfo>());
        }

        public ActionResult<List<MasterInfo>> FindMaster()
        {
            return new ActionResult<List<MasterInfo>>(new List<MasterInfo>());
        }

        public ActionResult<BaseNumber> GetHP()
        {
            var all = dmsoft.Ocr(29, 560, 88, 575, "ffffff-000000", 1.0);
            var arr = all.Split('/');
            //var hp = (int)dmsoft.ReadInt(mirContext.Hwnd, "<TDmir3G.exe>+3B244A", 0);
            BaseNumber baseNumber = new BaseNumber(int.Parse(arr[0]),int.Parse(arr[1]));
            return new ActionResult<BaseNumber>(baseNumber);
        }

        public ActionResult<int> GetLevel()
        {
            throw new NotImplementedException();
        }

        public ActionResult<BaseNumber> GetMP()
        {
            var all = dmsoft.Ocr(95, 561, 157, 575, "ffffff-000000", 1.0);
            var arr = all.Split('/');
            //var mp = (int) dmsoft.ReadInt(mirContext.Hwnd, "<TDmir3G.exe>+3B244A", 0);
            BaseNumber baseNumber = new BaseNumber(int.Parse(arr[0]), int.Parse(arr[1]));
            return new ActionResult<BaseNumber>(baseNumber);
        }
        Regex positionRegex = new Regex("(?<n>[^\\d]+)(?<x>\\d+):(?<y>\\d+)");
        public ActionResult<PositionInfo> GetPosition()
        {
            //var x = (int)dmsoft.ReadInt(mirContext.Hwnd, "<TDmir3G.exe>+3B2368", 2);
            //var y = (int)dmsoft.ReadInt(mirContext.Hwnd, "<TDmir3G.exe>+3B236A", 2);
            //var name = dmsoft.ReadString(mirContext.Hwnd, "<TDmir3G.exe>+2C3938", 0, 9);
            //return new ActionResult<PositionInfo>(new PositionInfo()
            //{
            //    Point = new Point(x, y),
            //    MapInfo = new MapInfo()
            //    {
            //        Name = name
            //    }
            //});
           
            var str = dmsoft.Ocr(28, 581, 137, 595, "ffffff-000000", 1.0);
            var match = positionRegex.Match(str);
            if(match.Success)
            {
                return new ActionResult<PositionInfo>(new PositionInfo()
                {
                    Point = new Point(int.Parse(match.Groups["x"].Value), int.Parse(match.Groups["x"].Value)),
                    MapInfo = new MapInfo()
                    {
                        Name = match.Groups["n"].Value
                    }
                });
            }
            else
            {
                return new ActionResult<PositionInfo>(-1,"识别位置信息失败");
            }
        }

        public ActionResult<string> GetRoleName()
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> Move(MirDirection mirDirection, RunType runType)
        {
            int x = 0, y = 0;
            switch (mirDirection)
            {
                case MirDirection.Up:
                    y = -70;
                    break;
                case MirDirection.UpRight:
                    y = -70;
                    x = 70;
                    break;
                case MirDirection.Right:
                    x = 90;
                    break;
                case MirDirection.DownRight:
                    y = 70;
                    x = 70;
                    break;
                case MirDirection.Down:
                    y = 70;
                    break;
                case MirDirection.DownLeft:
                    y = 70;
                    x = -70;
                    break;
                case MirDirection.Left:
                    x = -90;
                    break;
                case MirDirection.UpLeft:
                    x = -70;
                    y = -70;
                    break;
            }
            //dmsoft.MoveTo(mirContext.MouseCenter.X, mirContext.MouseCenter.Y);
            //Thread.Sleep(2000);
            dmsoft.MoveTo(mirContext.MouseCenter.X + x, mirContext.MouseCenter.Y + y);
            Thread.Sleep(10);
            if (runType == RunType.Normal)
            {
                dmsoft.LeftDown();
                Thread.Sleep(200);
                dmsoft.LeftUp();
            }
            else
            {
                dmsoft.RightDown();
                Thread.Sleep(300);
                dmsoft.RightUp();
            }
            return new ActionResult<bool>(true);
        }

        public ActionResult<bool> OpenMagicInfo()
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> OpenPackage()
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> OpenRoleAttributeInfo()
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> OpenRoleInfo()
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> PickupItem(ItemInfo item)
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> RandomMove(RunType runType)
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> RandomMove(RunType runType, Point leftUp, Point rightDown)
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> Repair(ItemInfo itemInfo)
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> SelectDialogueContent(string content)
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> Sell(ItemInfo itemInfo)
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> SRepair(ItemInfo itemInfo)
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> Storage(ItemInfo itemInfo)
        {
            throw new NotImplementedException();
        }
    }
}
