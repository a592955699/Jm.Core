using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Models
{
    public class BaseMinMax
    {
        /// <summary>
        /// 下限
        /// </summary>
        public int Min { get; set; }
        /// <summary>
        /// 上限
        /// </summary>
        public int Max { get; set; }
        public override string ToString()
        {
            return $"{Min}/{Max}";
        }
    }
}
