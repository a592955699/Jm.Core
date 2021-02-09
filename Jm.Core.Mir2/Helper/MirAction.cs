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
        public ActionResult AttackMaster(MasterInfo masterInfo, CancellationTokenSource cancellationTokenSource)
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
            throw new NotImplementedException();
        }

        public ActionResult<List<MasterInfo>> FindMaster()
        {
            throw new NotImplementedException();
        }

        public ActionResult<BaseNumber> GetHP()
        {
            throw new NotImplementedException();
        }

        public ActionResult<int> GetLevel()
        {
            throw new NotImplementedException();
        }

        public ActionResult<BaseNumber> GetMP()
        {
            throw new NotImplementedException();
        }

        public ActionResult<PositionInfo> GetPosition()
        {
            throw new NotImplementedException();
        }

        public ActionResult<string> GetRoleName()
        {
            throw new NotImplementedException();
        }

        public ActionResult<bool> Move(MirDirection mirDirection, RunType runType)
        {
            throw new NotImplementedException();
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
