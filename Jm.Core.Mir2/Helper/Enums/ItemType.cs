using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Enums
{
    /// <summary>
    /// 物品分类
    /// </summary>
    public enum ItemType : byte
    {
        Nothing = 0,
        Weapon = 1,//武器
        Armour = 2,//盔甲
        Helmet = 4, //头盔
        Necklace = 5,//项链
        Bracelet = 6,//手链
        Ring = 7,//戒指
        Amulet = 8,//护身符
        Belt = 9,//腰带
        Boots = 10,//靴子
        Stone = 11,//石头
        Torch = 12,//火把
        Potion = 13,//药剂(药水)
        Ore = 14,//矿石
        Meat = 15,//肉
        CraftingMaterial = 16,
        Scroll = 17,
        Gem = 18,
        Mount = 19,
        Book = 20,
        Script = 21,
        Reins = 22,
        Bells = 23,
        Saddle = 24,
        Ribbon = 25,
        Mask = 26,
        Food = 27,
        Hook = 28,
        Float = 29,
        Bait = 30,
        Finder = 31,
        Reel = 32,
        Fish = 33,
        Quest = 34,
        Awakening = 35,
        Pets = 36,
        Transform = 37,
        Deco = 38,
        Socket = 39
    }
}
