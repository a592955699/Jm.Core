using Jm.Core.Mir2.Server.VisualMapInfo.Class.AStart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Models
{
    /// <summary>
    /// 位置信息
    /// </summary>
    public class PositionInfo
    {
        public MapInfo MapInfo { get; set; } = new MapInfo();
        /// <summary>
        /// 坐标信息
        /// </summary>
        public APoint Point { get; set; }
    }
}
