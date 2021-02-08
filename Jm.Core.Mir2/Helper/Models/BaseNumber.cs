using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Models
{
    public class BaseNumber
    {
        /// <summary>
        /// 但前置
        /// </summary>
        public int Current { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public int Max { get; set; }
        /// <summary>
        /// 百分比 例如：80% 值为 80
        /// </summary>
        public float Percentage {
            get {
                if (Max == 0) 
                    return 0f;
                else 
                    return Current / (float)Max * 100;
            }
        }
        public override string ToString()
        {
            if (Max == 0)
                return "0/0 (0.00%)";
            else
                return $"{Current}/{Max} ({Percentage:f2}%)";
        }
        /// <summary>
        /// 将 Current 归 0
        /// </summary>
        public void Zero()
        {
            this.Current = 0;
        }
        /// <summary>
        /// 将 Current、Clear 归 0
        /// </summary>
        public void Clear()
        {
            this.Max = this.Current = 0;
        }
    }
}
