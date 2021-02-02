using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.WinForm.Win32
{
    public abstract class Hook
    {
        public Hook(IntPtr handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// 定义鼠标处理过程的委托对象
        /// </summary>
        public HookProc HookProcedure { get; protected set; }
        /// <summary>
        /// 钩子常量(from Microsoft SDK  Winuser.h )
        /// </summary>
        public abstract int IdHook { get;  }
        /// <summary>
        /// 是否安装
        /// </summary>
        public bool IsActive { get; private set; }
        /// <summary>
        /// Handle of the window intercepting messages
        /// </summary>
        public IntPtr Handle { get; protected set; }

        /// <summary>
        /// 定义钩子句柄.
        /// </summary>
        protected static IntPtr _hHook = IntPtr.Zero;

        ~Hook()
        {
            Stop();
        }


        public void Start()
        {
            if (!IsActive)
            {
                IsActive = true;
                OnStart();
            }
        }

        public void Stop()
        {
            if (IsActive)
            {
                OnStop();
                IsActive = false;
            }
        }

        private void OnStart()
        {
            try
            {
                HookProcedure = new HookProc(HookProcMethod);
      
                var pInstance = CommonApis.GetModuleHandle(null);
                // https://blog.csdn.net/wpwalter/article/details/106335266
                // 你可能会在网上搜索到下面注释掉的这种代码，但实际上已经过时了。
                //   下面代码在 .NET Core 3.x 以上可正常工作，在 .NET Framework 4.0 以下可正常工作。
                //   如果不满足此条件，你也可能可以正常工作，详情请阅读本文后续内容。
                // var hModule = Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]);

                _hHook = CommonApis.SetWindowsHookEx(IdHook, HookProcedure, pInstance, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (_hHook == IntPtr.Zero)
            {
                IsActive = false;
                Stop();
            }
            else
            {
                IsActive = true;
            }
        }
        private void OnStop()
        {
            if (_hHook != IntPtr.Zero)
            {
                CommonApis.UnhookWindowsHookEx(_hHook);
                IsActive = false;
                _hHook = IntPtr.Zero;
            }
        }
        protected abstract int HookProcMethod(int nCode, Int32 wParam, IntPtr lParam);
    }
}
