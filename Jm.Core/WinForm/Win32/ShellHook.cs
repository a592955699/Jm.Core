using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.WinForm.Win32
{
    public class ShellHook:Hook
    {
        public ShellHook(IntPtr handle) : base(handle) { }
        public override int IdHook
        {
            get { return (int)HookType .WH_SHELL; }
        }

        protected override int HookProcMethod(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode == (int)SHELL_Codes.HSHELL_WINDOWCREATED)
            {
                
            }
            return CommonApis.CallNextHookEx(_hHook, nCode, wParam, lParam);
        }
    }
}
