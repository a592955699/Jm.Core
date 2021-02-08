using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Enums
{
    /// <summary>
    /// 装备位置
    /// </summary>
    public enum EquipmentSlot : byte
    {
        Weapon = 0,//武器
        Armour = 1,//衣服
        Helmet = 2,//头盔
        Torch = 3,//火把
        Necklace = 4,//项链
        BraceletL = 5,//手镯
        BraceletR = 6,
        RingL = 7,//戒指
        RingR = 8,
        Amulet = 9,//毒符
        Belt = 10,//腰带
        Boots = 11,//鞋子
        Stone = 12,//宝石
        Mount = 13//坐骑
    }
}
