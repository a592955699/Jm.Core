using System;
using System.Collections.Generic;
using System.Text;

namespace Jm.Core.DmApi
{
    public class Reg
    {
        /// <summary>
        /// 大漠 dm.dll 存在目录
        /// 注意：不注册调用dm.dll的方法时才需要
        /// </summary>
        public string DllPath { get; set; }
        /// <summary>
        /// 大漠插件的工作目录
        /// </summary>
        public string WorkPath { get; set; }
        /// <summary>
        /// 注册码. (从大漠插件后台获取)

        /// </summary>
        public string RegCode { get; set; }
        /// <summary>
        /// 版本附加信息. 可以在后台详细信息查看. 可以任意填写. 可留空. 长度不能超过20. 并且只能包含数字和字母以及小数点. 这个版本信息不是插件版本.
        /// </summary>
        public string VerInfo { get; set; }
    }
}
