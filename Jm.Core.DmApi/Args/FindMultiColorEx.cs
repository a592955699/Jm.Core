using System;
using System.Collections.Generic;
using System.Text;

namespace Jm.Core.DmApi.Args
{
    public class FindMultiColorEx
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
        /// 颜色格式为"RRGGBB-DRDGDB|RRGGBB-DRDGDB|…………",比如"123456-000000"
        /// 这里的含义和按键自带Color插件的意义相同，只不过我的可以支持偏色和多种颜色组合
        /// 所有的偏移色坐标都相对于此颜色.注意，这里只支持RGB颜色.
        /// </summary>
        public string FirstColor { get; set; }
        /// <summary>
        /// 偏移颜色可以支持任意多个点 格式和按键自带的Color插件意义相同, 只不过我的可以支持偏色和多种颜色组合
        /// 格式为"x1|y1|RRGGBB-DRDGDB|RRGGBB-DRDGDB……,……xn|yn|RRGGBB-DRDGDB|RRGGBB-DRDGDB……"
        /// 比如"1|3|aabbcc|aaffaa-101010,-5|-3|123456-000000|454545-303030|565656"等任意组合都可以，支持偏色
        ///还可以支持反色模式，比如"1|3|-aabbcc|-334455-101010,-5|-3|-123456-000000|-353535|454545-101010","-"表示除了指定颜色之外的颜色.
        /// </summary>
        public string OffsetColor { get; set; }
    }
}
