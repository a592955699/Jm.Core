using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.WinForm.Win32
{
    #region 委托定义

    /// <summary>
    /// 钩子委托声明
    /// </summary>
    /// <param name="nCode"></param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

    public delegate void HookReplacedEventHandler();
    public delegate void WindowEventHandler(IntPtr Handle);
    public delegate void SysCommandEventHandler(int SysCommand, int lParam);
    public delegate void ActivateShellWindowEventHandler();
    public delegate void TaskmanEventHandler();
    public delegate void BasicHookEventHandler(IntPtr Handle1, IntPtr Handle2);
    public delegate void WndProcEventHandler(IntPtr Handle, IntPtr Message, IntPtr wParam, IntPtr lParam);

    #endregion 委托定义
}
