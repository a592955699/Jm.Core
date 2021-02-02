using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Jm.Core.WinForm.Win32.CommonApis;

namespace Jm.Core.WinForm.Win32
{

    //public delegate void HookReplacedEventHandler();
    //public delegate void WindowEventHandler(IntPtr Handle);
    //public delegate void SysCommandEventHandler(int SysCommand, int lParam);
    //public delegate void ActivateShellWindowEventHandler();
    //public delegate void TaskmanEventHandler();
    //public delegate void BasicHookEventHandler(IntPtr Handle1, IntPtr Handle2);
    //public delegate void WndProcEventHandler(IntPtr Handle, IntPtr Message, IntPtr wParam, IntPtr lParam);

    public class KeyboardHook : Hook
    {
        public KeyboardHook(IntPtr handle) : base(handle) { }
        public override int IdHook { 
            get { return (int)HookType .WH_KEYBOARD_LL; }
        }

        /// <summary>
		/// 按键按下事件
		/// </summary>
		public event KeyEventHandler OnKeyDown;

        /// <summary>
        /// 按键按下并释放事件
        /// </summary>
        public event KeyPressEventHandler OnKeyPress;

        /// <summary>
        /// 按键释放事件
        /// </summary>
        public event KeyEventHandler OnKeyUp;
        /// <summary>
        /// 屏蔽键盘
        /// </summary>
        public bool IgnoreInput { get; set; }
        protected override int HookProcMethod(int nCode, int wParam, IntPtr lParam)
        {
            if (IgnoreInput)//屏蔽键盘
                return 1;




            bool handled = false;
            //it was ok and someone listens to events
            if ((nCode >= 0) && (this.OnKeyDown != null || this.OnKeyUp != null || this.OnKeyPress != null))
            {
                //read structure KeyboardHookStruct at lParam
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                //raise KeyDown
                if (this.OnKeyDown != null && (wParam == (int)MsgType.WM_KEYDOWN || wParam == (int)MsgType.WM_SYSKEYDOWN))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.VKCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    this.OnKeyDown(this, e);
                    handled = handled || e.Handled;
                }

                // raise KeyPress
                if (this.OnKeyPress != null && wParam == (int)MsgType.WM_KEYDOWN)
                {
                    bool isDownShift, isDownCapslock;
                    try
                    {
                        isDownShift = ((CommonApis.GetKeyStates((int)VK_Codes.VK_SHIFT) & 0x80) == 0x80 ? true : false);
                        isDownCapslock = (CommonApis.GetKeyStates((int)VK_Codes.VK_CAPITAL) != 0 ? true : false);
                    }
                    catch
                    {
                        isDownCapslock = false;
                        isDownShift = false;
                    }

                    byte[] keyState = new byte[256];
                    CommonApis.GetKeyboardState(keyState);
                    byte[] inBuffer = new byte[2];
                    if (CommonApis.ToAscii(MyKeyboardHookStruct.VKCode,
                              MyKeyboardHookStruct.ScanCode,
                              keyState,
                              inBuffer,
                              MyKeyboardHookStruct.Flags) == 1)
                    {
                        char key = (char)inBuffer[0];
                        if ((isDownCapslock ^ isDownShift) && Char.IsLetter(key)) key = Char.ToUpper(key);
                        KeyPressEventArgs e = new KeyPressEventArgs(key);
                        this.OnKeyPress(this, e);
                        handled = handled || e.Handled;
                    }
                }
                // raise KeyUp
                if (this.OnKeyUp != null && (wParam == (int)MsgType.WM_KEYUP || wParam == (int)MsgType.WM_SYSKEYUP))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.VKCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    this.OnKeyUp(this, e);
                    handled = handled || e.Handled;
                }

            }

            //if event handled in application do not handoff to other listeners
            if (handled)
                return 1;
            else
                return CommonApis.CallNextHookEx(_hHook, nCode, wParam, lParam);
        }
    }
}
