using Jm.Core.DmApi;
using Jm.Core.DmApi.Args;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jm.Core.TestForms
{
    public partial class Form1 : Form
    {
        dmsoft dmsoft ;
        public Form1()
        {
            InitializeComponent();

            dmsoft = new dmsoft();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = "比奇省";
            var a = test(str1);
            //u6bd4u5947u7701


            string str2 = "服装店";
            var b = test(str2);
            //u670du88c5u5e97

            BytesTranfer.HexStringToASCII("00B7FED7B0B5EA20");

            //var hexStr = BytesTranfer.StringToHexArray(str1);
            //string asciiStr = BytesTranfer.HexStringToASCII(hexStr);
        }

        private string test(string voicestr)
        {
            /***************** 汉字转换为十六进制数（hex）部分 ********************************/
            //把汉字转换为十六进制数（hex）
            if ((voicestr.Length % 2) != 0)
            {
                voicestr += " ";//空格
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding("gb2312");
            byte[] bytes = chs.GetBytes(voicestr);
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str += string.Format("{0:X}", bytes[i]);
            }
            return str;
        }

        /// <summary>
        /// 字符串转Unicode码
        /// </summary>
        /// <returns>The to unicode.</returns>
        /// <param name="value">Value.</param>
        private string StringToUnicode(string value)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(value);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i += 2)
            {
                // 取两个字符，每个字符都是右对齐。
                stringBuilder.AppendFormat("u{0}{1}", bytes[i + 1].ToString("x").PadLeft(2, '0'), bytes[i].ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Unicode转字符串
        /// </summary>
        /// <returns>The to string.</returns>
        /// <param name="unicode">Unicode.</param>
        private string UnicodeToString(string unicode)
        {
            string resultStr = "";
            string[] strList = unicode.Split('u');
            for (int i = 1; i < strList.Length; i++)
            {
                resultStr += (char)int.Parse(strList[i], System.Globalization.NumberStyles.HexNumber);
            }
            return resultStr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            var hwnd = dmsoft.GetForegroundWindow();
            if (hwnd == 0)
            {
                rtb_message.AppendText("找不到窗口句柄\r\n");
                return;
            }

            string title = dmsoft.GetWindowTitle(hwnd);

            BindWindowEx bindWindowEx = new BindWindowEx() { 
            Display= "normal",
            Mouse= "normal",
            Keypad= "normal",
            Public="",
            Mode=0
            };

            bool res = dmsoft.BindWindowEx(hwnd, bindWindowEx);
            if (res)
            {
                rtb_message.AppendText($"绑定窗口 {title} 成功");
                return;
            }
            else
            {
                rtb_message.AppendText($"绑定窗口 {title} 失败");
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int dm_ret = dmsoft.Reg(new Reg()
            {
                RegCode = "2663231107dbcf6e2076d4e2787c9b72afbe6165d1",
                WorkPath = @"C:\Users\rober\Desktop\dm root"
            });
            dmsoft.AddDict(0, "宋体10.txt");
            if (dm_ret != 1)
            {
                string 错误提示 = @"-1 : 无法连接网络,(可能防火墙拦截,如果可以正常访问大漠插件网站，那就可以肯定是被防火墙拦截)
-2 : 进程没有以管理员方式运行. (出现在win7 win8 vista 2008.建议关闭uac)
0 : 失败 (未知错误)
1 : 成功
2 : 余额不足
3 : 绑定了本机器，但是账户余额不足50元.
4 : 注册码错误
5 : 你的机器或者IP在黑名单列表中或者不在白名单列表中.
6 : 非法使用插件. 
7 : 你的帐号因为非法使用被封禁. （如果是在虚拟机中使用插件，必须使用Reg或者RegEx，不能使用RegNoMac或者RegExNoMac,否则可能会造成封号，或者封禁机器）
8 : ver_info不在你设置的附加白名单中.
77： 机器码或者IP因为非法使用，而被封禁. （如果是在虚拟机中使用插件，必须使用Reg或者RegEx，不能使用RegNoMac或者RegExNoMac,否则可能会造成封号，或者封禁机器）
     封禁是全局的，如果使用了别人的软件导致77，也一样会导致所有注册码均无法注册。解决办法是更换IP，更换MAC.
-8 : 版本附加信息长度超过了20
-9 : 版本附加信息里包含了非法字母.
空 : 这是不可能返回空的，如果出现空，那肯定是当前使用的版本不对,老的插件里没这个函数导致返回为空.最好参考文档中的标准写法,判断插件版本号.";
                rtb_message.AppendText($"VIP注册失败,错误码:{dm_ret}\r\n提示:{错误提示}\r\n");
            }
            else
            {
                rtb_message.AppendText($"注册成功！版本:{dmsoft.Ver()}\r\n");
            }
        }
    }
}
