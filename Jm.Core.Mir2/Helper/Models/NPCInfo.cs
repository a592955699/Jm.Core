using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Models
{
    /// <summary>
    /// NPC 信息
    /// </summary>
    public class NPCInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PositionInfo Position { get; set; }
    }
}
