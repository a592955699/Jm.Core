using Jm.Core.Win32Api;
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

namespace Jm.WinformTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Shell32.SHEmptyRecycleBin(Form.ActiveForm.Handle, "", 0x00000000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Shell32.ShellExecute(Form.ActiveForm.Handle, "Open", this.txt_url.Text, "", "", 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User32.MessageBox(IntPtr.Zero, "Windows API调用演示", "测试标题", 0);
            Thread.Sleep(1000);
            User32.MessageBox(IntPtr.Zero, "Windows API调用演示", "测试标题", 1);
            Thread.Sleep(1000);
            User32.MessageBox(IntPtr.Zero, "Windows API调用演示", "测试标题", 2);
            Thread.Sleep(1000);
            User32.MessageBox(IntPtr.Zero, "Windows API调用演示", "测试标题", 3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Shell32.ShellAbout(IntPtr.Zero, "test shell about", "xxx",IntPtr.Zero);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int hand = User32.FindWindow(null, txt_WindowTitle.Text);
            MessageBox.Show(hand.ToString());
        }

        /// <summary>
        /// 声明一个hook对象
        /// </summary>
        GlobalHook hook;

        private void button6_Click(object sender, EventArgs e)
        {
            bool r = hook.Start();
            if (r)
            {
                MessageBox.Show("安装钩子成功!");
            }
            else
            {
                MessageBox.Show("安装钩子失败!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化钩子对象
            if (hook == null)
            {
                hook = new GlobalHook();
                hook.KeyDown += new KeyEventHandler(hook_KeyDown);
                hook.KeyPress += new KeyPressEventHandler(hook_KeyPress);
                hook.KeyUp += new KeyEventHandler(hook_KeyUp);
                hook.OnMouseActivity += new MouseEventHandler(hook_OnMouseActivity);
            }
        }

        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        void hook_OnMouseActivity(object sender, MouseEventArgs e)
        {
            lbMouseState.Text = "X:" + e.X + " Y:" + e.Y;
        }
        /// <summary>
        /// 键盘抬起
        /// </summary>
        void hook_KeyUp(object sender, KeyEventArgs e)
        {
            //e.KeyData= 

            lbKeyState.Text = "键盘抬起, " + e.KeyData.ToString() + " 键码:" + e.KeyValue;
        }
        /// <summary>
        /// 键盘输入
        /// </summary>
        void hook_KeyPress(object sender, KeyPressEventArgs e)
        { }
        /// <summary>
        /// 键盘按下
        /// </summary>
        void hook_KeyDown(object sender, KeyEventArgs e)
        {
            lbKeyState.Text = "键盘按下, " + e.KeyData.ToString() + " 键码:" + e.KeyValue;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hook.Stop();
            MessageBox.Show("卸载钩子成功!");
        }
    }
}
