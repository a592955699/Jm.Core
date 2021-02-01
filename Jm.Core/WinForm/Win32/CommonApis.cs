using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.WinForm.Win32
{
    public class CommonApis
    {
        #region User32
        [DllImport("User32", CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(HandleRef hWnd, StringBuilder lpString, int nMaxCount);

        //Enumerate top-level windows
        [DllImport("User32")]
        public static extern int EnumWindows(EnumWindowsCallback callback, int extraData);
        
        public delegate bool EnumWindowsCallback(int hWnd, int lParam);

        //Get Process ID from Handle
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int ID);
        #endregion
    }
}
