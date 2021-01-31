using System;
using System.Collections.Generic;
using System.Text;

namespace Jm.Core.DmApi.Args
{
    public class FindPicS
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
        /// <summary>
        /// 图片名,可以是多个图片,比如"test.bmp|test2.bmp|test3.bmp"
        /// </summary>
        public string PicName { get; set; }
        /// <summary>
        ///  颜色色偏比如"203040" 表示RGB的色偏分别是20 30 40 (这里是16进制表示)
        /// </summary>
        public string DeltaColor { get; set; }
    }
}
