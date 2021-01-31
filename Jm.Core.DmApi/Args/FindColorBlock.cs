using System;
using System.Collections.Generic;
using System.Text;

namespace Jm.Core.DmApi.Args
{
    public class FindColorBlock
    {
        /// <summary>
        /// 区域的左上X坐标
        /// </summary>
        public int X1 { get; set; }
        /// <summary>
        /// 区域的左上Y坐标
        /// </summary>
        public int Y1 { get; set; }
        /// <summary>
        /// 区域的右下X坐标
        /// </summary>
        public int X2 { get; set; }
        /// <summary>
        /// 区域的右下Y坐标
        /// </summary>
        public int Y2 { get; set; }
        /// <summary>
        ///  颜色字符串,可以支持偏色,多色,例如 "ffffff-202020|000000-000000" 这个表示白色偏色为202020,和黑色偏色为000000.颜色最多支持10种颜色组合
        ///  注意，这里只支持RGB颜色.
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 相似度(0.1-1.0)
        /// </summary>
        public double Sim { get; set; }
        /// <summary>
        /// 在宽度为width,高度为height的颜色块中，符合color颜色的最小数量.
        /// (注意,这个颜色数量可以在综合工具的二值化区域中看到)
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 颜色块的宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 颜色块的高度
        /// </summary>
        public int Height { get; set; }
    }
}
