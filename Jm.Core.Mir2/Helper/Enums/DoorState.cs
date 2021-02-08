using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Enums
{
    /// <summary>
    /// 门状态
    /// </summary>
    public enum DoorState : byte
    {
        Closed = 0,
        Opening = 1,
        Open = 2,
        Closing = 3
    }
}
