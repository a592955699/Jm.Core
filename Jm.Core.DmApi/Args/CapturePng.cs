using System;
using System.Collections.Generic;
using System.Text;

namespace Jm.Core.DmApi.Args
{
    public class CapturePng 
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
        /// 保存的文件名,保存的地方一般为SetPath中设置的目录
        /// 当然这里也可以指定全路径名.
        /// </summary>
        public string File { get; set; }
    }
}
