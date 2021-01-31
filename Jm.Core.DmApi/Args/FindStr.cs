using System;
using System.Collections.Generic;
using System.Text;

namespace Jm.Core.DmApi.Args
{
    public  class FindStr
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
        /// 待查找的字符串,可以是字符串组合，比如"长安|洛阳|大雁塔",中间用"|"来分割字符串
        /// 例：长安|洛阳
        /// </summary>
        public string String { get; set; }
        /// <summary>
        ///  颜色格式串, 可以包含换行分隔符,语法是","后加分割字符串. 具体可以查看下面的示例 .注意，RGB和HSV,以及灰度格式都支持
        ///  例：9f2e3f-000000
        /// </summary>
        public string ColorFormat { get; set; }
        /// <summary>
        /// 相似度(0.1-1.0)
        /// </summary>
        public double Sim { get; set; }
    }
}
