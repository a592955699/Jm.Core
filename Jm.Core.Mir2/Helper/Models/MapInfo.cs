using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Models
{
    public class MapInfo
    {
        /// <summary>
        /// 地图编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 地图名称
        /// </summary>
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            return Id == ((MapInfo)obj).Id;
        }
    }
}
