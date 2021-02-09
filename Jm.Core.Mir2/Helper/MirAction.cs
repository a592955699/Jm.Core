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

        public List<ItemInfo> FindItems()
        {
            throw new NotImplementedException();
        }

        public int GetLevel()
        {
            throw new NotImplementedException();
        }

        public List<MasterInfo> FindMaster()
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
