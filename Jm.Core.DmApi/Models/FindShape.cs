using System;
using System.Collections.Generic;
using System.Text;

namespace Jm.Core.DmApi.Models
{
    public class FindShape
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
        public string OffsetColor { get; set; }
        /// <summary>
        /// 相似度(0.1-1.0)
        /// </summary>
        public double Sim { get; set; }
        /// <summary>
        /// 查找方向 0: 从左到右,从上到下 
        /// 1: 从左到右,从下到上 
        /// 2: 从右到左,从上到下 
        /// 3: 从右到左,从下到上 
        /// 4：从中心往外查找
        /// 5: 从上到下,从左到右 
        /// 6: 从上到下,从右到左
        /// 7: 从下到上,从左到右
        /// 8: 从下到上,从右到左
        /// </summary>
        public int Dir { get; set; }
    }
}
