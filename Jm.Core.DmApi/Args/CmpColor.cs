using System;
using System.Collections.Generic;
using System.Text;

namespace Jm.Core.DmApi.Args
{
    public class CmpColor
    {
        /// <summary>
        /// X坐标
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y坐标
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        ///  颜色字符串,可以支持偏色,多色,例如 "ffffff-202020|000000-000000" 这个表示白色偏色为202020,和黑色偏色为000000.颜色最多支持10种颜色组合
        ///  注意，这里只支持RGB颜色.
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 相似度(0.1-1.0)
        /// </summary>
        public double Sim { get; set; }
    }
}
