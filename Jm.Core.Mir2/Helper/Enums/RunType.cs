using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Enums
{
    /// <summary>
    /// 跑步类型
    /// </summary>
    public enum RunType : byte
    {
        Normal = 0,//正常跑步，需要起步
        FastRun = 1,//不需要起步，直接跑步
    }
}
