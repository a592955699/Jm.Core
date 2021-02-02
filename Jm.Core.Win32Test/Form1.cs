using Jm.Core.WinForm.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jm.Core.Win32Test
{
    public partial class Form1 : Form
    {
        GlobalHooks _GlobalHooks;
        public Form1()
        {
            InitializeComponent();

            _GlobalHooks = new GlobalHooks(this.Handle);
            _GlobalHooks.Keyboard.OnKeyDown += Mouse_KeyDown;
            _GlobalHooks.Keyboard.OnKeyPress += Mouse_KeyPress;
            _GlobalHooks.Keyboard.OnKeyUp += Mouse_KeyUp;
            _GlobalHooks.Mouse.OnMouseActivity += Mouse_OnMouseActivity;
        }

        private void Mouse_OnMouseActivity(object sender, MouseEventArgs e)
        {
            lbMouseState.Text = "X:" + e.X + " Y:" + e.Y;
        }

        private void Mouse_KeyUp(object sender, KeyEventArgs e)
        {
            lbKeyState.Text = "键盘抬起, " + e.KeyData.ToString() + " 键码:" + e.KeyValue;
        }

        private void Mouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbKeyState.Text = "键盘输入,"+ e.KeyChar;
        }

        private void Mouse_KeyDown(object sender, KeyEventArgs e)
        {
            lbKeyState.Text = "键盘按下, " + e.KeyData.ToString() + " 键码:" + e.KeyValue;
        }

        private void btn_Bind_Click(object sender, EventArgs e)
        {
            _GlobalHooks.Mouse.Start();
            _GlobalHooks.Keyboard.Start();
            if (!_GlobalHooks.Mouse.IsActive)
                MessageBox.Show("Mouse 钩子状态:" + _GlobalHooks.Mouse.IsActive.ToString());
            if (!_GlobalHooks.Keyboard.IsActive)
                MessageBox.Show("Keyboard 钩子状态:" + _GlobalHooks.Mouse.IsActive.ToString());
        }

        private void btn_UnBind_Click(object sender, EventArgs e)
        {
            _GlobalHooks.Mouse.Stop();
            _GlobalHooks.Keyboard.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _GlobalHooks.Keyboard.IgnoreInput = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _GlobalHooks.Keyboard.IgnoreInput = false;
        }
    }
}
