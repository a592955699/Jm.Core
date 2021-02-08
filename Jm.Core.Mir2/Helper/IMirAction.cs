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
    /// <summary>
    /// 挂机相关方法接口
    /// </summary>
    public interface IMirAction
    {
        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="mirDirection">移动方向</param>
        /// <param name="runType">走/跑</param>
        /// <returns></returns>
        bool Move(MirDirection mirDirection, RunType runType);
        /// <summary>
        /// 随机移动
        /// </summary>
        /// <param name="runType"></param>
        /// <returns></returns>
        bool RandomMove(RunType runType);
        /// <summary>
        /// 指定范围内随机移动
        /// </summary>
        /// <param name="runType"></param>
        /// <param name="leftUp"></param>
        /// <param name="rightDown"></param>
        /// <returns></returns>
        bool RandomMove(RunType runType,Point leftUp,Point rightDown);
        /// <summary>
        /// 获取 Hp
        /// </summary>
        /// <returns></returns>
        BaseNumber GetHP();
        /// <summary>
        /// 获取魔法值
        /// </summary>
        /// <returns></returns>
        BaseNumber GetMP();
        /// <summary>
        /// 获取等级
        /// </summary>
        /// <returns></returns>
        int GetLevel();
        /// <summary>
        /// 获取角色名
        /// </summary>
        /// <returns></returns>
        string GetRoleName();
        /// <summary>
        /// 获取位置信息
        /// </summary>
        /// <returns></returns>
        PositionInfo GetPosition();
        /// <summary>
        /// 获取怪物信息
        /// </summary>
        /// <returns></returns>
        List<MasterInfo> GetMaster();
        /// <summary>
        /// 获取地上物品信息
        /// </summary>
        /// <returns></returns>
        List<ItemInfo> GetItemInfo();
        /// <summary>
        /// 拾取物品
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool PickupItem(ItemInfo item);
        /// <summary>
        /// 打怪
        /// </summary>
        /// <param name="masterInfo"></param>
        void AttackMaster(MasterInfo masterInfo, CancellationTokenSource cancellationTokenSource);
        /// <summary>
        /// 小退
        /// </summary>
        /// <returns></returns>
        bool ExitRole();
        /// <summary>
        /// 大退
        /// </summary>
        /// <returns></returns>
        bool Exit();
        /// <summary>
        /// 对话 NPC
        /// </summary>
        /// <returns></returns>
        bool DialogueNPC(NPCInfo npcInfo);
        /// <summary>
        /// 选择对话内容
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        bool SelectDialogueContent(string content);
        /// <summary>
        /// 打开包裹面板
        /// </summary>
        /// <returns></returns>
        bool OpenPackage();
        /// <summary>
        /// 关闭包裹面板
        /// </summary>
        /// <returns></returns>
        bool ClosePackage();
        /// <summary>
        /// 打开角色信息面板（F9）
        /// </summary>
        /// <returns></returns>
        bool OpenRoleInfo();
        /// <summary>
        /// 关闭角色信息面板（F9）
        /// </summary>
        /// <returns></returns>
        bool CloseRoleInfo();
        /// <summary>
        /// 打开角色属性面板（F9）
        /// </summary>
        /// <returns></returns>
        bool OpenRoleAttributeInfo();
        /// <summary>
        /// 关闭角色属性面板（F9）
        /// </summary>
        /// <returns></returns>
        bool CloseRoleAttributeInfo();
        /// <summary>
        /// 打开技能面板
        /// </summary>
        /// <returns></returns>
        bool OpenMagicInfo();
        /// <summary>
        /// 关闭技能面板
        /// </summary>
        /// <returns></returns>
        bool CloseMagicInfo();
        /// <summary>
        /// 买装备
        /// </summary>
        /// <param name="itemInfo"></param>
        /// <returns></returns>
        bool Buy(ItemInfo itemInfo);
        /// <summary>
        /// 卖装备
        /// </summary>
        /// <param name="itemInfo"></param>
        /// <returns></returns>
        bool Sell(ItemInfo itemInfo);
        /// <summary>
        /// 修理装备
        /// </summary>
        /// <param name="itemInfo"></param>
        /// <returns></returns>
        bool Repair(ItemInfo itemInfo);
        /// <summary>
        /// 特修装备
        /// </summary>
        /// <param name="itemInfo"></param>
        /// <returns></returns>
        bool SRepair(ItemInfo itemInfo);
        /// <summary>
        /// 存装备
        /// </summary>
        /// <param name="itemInfo"></param>
        /// <returns></returns>
        bool Storage(ItemInfo itemInfo);
        /// <summary>
        /// 计算移动方向
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        MirDirection CalculationDirection(APoint p1, APoint p2);
        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        int CalculationDistance(APoint p1, APoint p2);
        /// <summary>
        /// 计算移动方式
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        RunType CalculationRunType(APoint p1, APoint p2, APoint p3);
    }
}
