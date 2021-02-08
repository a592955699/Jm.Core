using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Enums
{
    /// <summary>
    /// 这个是装备的属性类型
    /// </summary>
    public enum StatType : byte
    {
        AC = 0,
        MAC = 1,
        DC = 2,
        MC = 3,
        SC = 4,
        HP = 5,
        MP = 6,
        HP_Percent = 7,
        MP_Percent = 8,
        HP_Regen = 9,
        MP_Regen = 10,
        ASpeed = 11,
        Luck = 12,
        Strong = 13,
        Accuracy = 14,
        Agility = 15,
        MagicResist = 16,
        PoisonResist = 17,
        PoisonAttack = 18,
        PoisonRegen = 19,
        Freezing = 20,
        Holy = 21,
        Durability = 22,
        Unknown = 23
    }
}
