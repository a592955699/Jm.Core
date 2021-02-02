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
    public class MouseHook : Hook
    {
        public MouseHook(IntPtr handle) : base(handle) { }
        public override int IdHook { 
            get { return (int)WH_Codes.WH_MOUSE_LL; }
        }
        public event MouseEventHandler OnMouseActivity;

        protected override int HookProcMethod(int nCode, int wParam, IntPtr lParam)
        {
            /*if ( ( nCode >= 0 ) && ( this.OnMouseUpdate != null )
				&& ( wParam == ( int )WM_MOUSE.WM_MOUSEMOVE || wParam == ( int )WM_MOUSE.WM_MOUSEWHEEL ) )
			{
				MouseHookStruct MouseInfo = ( MouseHookStruct )Marshal.PtrToStructure( lParam, typeof( MouseHookStruct ) );
				this.OnMouseUpdate( MouseInfo.Point.X, MouseInfo.Point.Y );
			}*/
            //*
            if ((nCode >= 0) && (OnMouseActivity != null))
            {
                //Marshall the data from callback.
                MouseHookStruct mouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));

                //detect button clicked
                MouseButtons button = MouseButtons.None;
                short mouseDelta = 0;
                switch (wParam)
                {
                    case (int)WM_MOUSE.WM_LBUTTONDOWN:
                        //case WM_LBUTTONUP: 
                        //case WM_LBUTTONDBLCLK: 
                        button = MouseButtons.Left;
                        break;
                    case (int)WM_MOUSE.WM_RBUTTONDOWN:
                        //case WM_RBUTTONUP: 
                        //case WM_RBUTTONDBLCLK: 
                        button = MouseButtons.Right;
                        break;
                    case (int)WM_MOUSE.WM_MOUSEWHEEL:
                        //If the message is WM_MOUSEWHEEL, the high-order word of mouseData member is the wheel delta. 
                        //One wheel click is defined as WHEEL_DELTA, which is 120. 
                        //(value >> 16) & 0xffff; retrieves the high-order word from the given 32-bit value
                        mouseDelta = (short)((mouseHookStruct.MouseData >> 16) & 0xffff);
                        //TODO: X BUTTONS (I havent them so was unable to test)
                        //If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, 
                        //or WM_NCXBUTTONDBLCLK, the high-order word specifies which X button was pressed or released, 
                        //and the low-order word is reserved. This value can be one or more of the following values. 
                        //Otherwise, mouseData is not used. 
                        break;
                }

                //double clicks
                int clickCount = 0;
                if (button != MouseButtons.None)
                    if (wParam == (int)WM_MOUSE.WM_LBUTTONDBLCLK || wParam == (int)WM_MOUSE.WM_RBUTTONDBLCLK) clickCount = 2;
                    else clickCount = 1;

                //generate event 
                MouseEventArgs e = new MouseEventArgs(
                                                   button,
                                                   clickCount,
                                                   mouseHookStruct.Point.X,
                                                   mouseHookStruct.Point.Y,
                                                   mouseDelta);
                //raise it
                OnMouseActivity(this, e);
            }

            //*
            return CommonApis.CallNextHookEx(_hHook, nCode, wParam, lParam);
        }
    }
}
