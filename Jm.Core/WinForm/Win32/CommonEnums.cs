using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.WinForm.Win32
{
    #region 枚举定义
    /// <summary>
    /// 钩子类型
    /// </summary>
    public enum WH_Codes : int
    {
        WH_CALLWNDPROC = 4,
        WH_CBT = 5,
        WH_DEBUG = 9,
        WH_FOREGROUNDIDLE = 11,
        WH_GETMESSAGE = 3,
        WH_HARDWARE = 8,
        WH_JOURNALPLAYBACK = 1,
        WH_JOURNALRECORD = 0,
        WH_KEYBOARD = 2,
        WH_MAX = 11,
        WH_MIN = (-1),
        WH_MOUSE = 7,
        /// <summary>
        /// 鼠标钩子常量(from Microsoft SDK  Winuser.h )
        /// </summary>
        WH_MOUSE_LL = 14,
        WH_MSGFILTER = (-1),
        WH_SHELL = 10,
        WH_SYSMSGFILTER = 6,
        /// <summary>
        /// 底层键盘钩子
        /// </summary>
        WH_KEYBOARD_LL = 13,
    }
    
    public enum WM_MOUSE : int
    {
        /// <summary>
        /// 鼠标开始
        /// </summary>
        WM_MOUSEFIRST = 0x200,

        /// <summary>
        /// 鼠标移动
        /// </summary>
        WM_MOUSEMOVE = 0x200,

        /// <summary>
        /// 左键按下
        /// </summary>
        WM_LBUTTONDOWN = 0x201,

        /// <summary>
        /// 左键释放
        /// </summary>
        WM_LBUTTONUP = 0x202,

        /// <summary>
        /// 左键双击
        /// </summary>
        WM_LBUTTONDBLCLK = 0x203,

        /// <summary>
        /// 右键按下
        /// </summary>
        WM_RBUTTONDOWN = 0x204,

        /// <summary>
        /// 右键释放
        /// </summary>
        WM_RBUTTONUP = 0x205,

        /// <summary>
        /// 右键双击
        /// </summary>
        WM_RBUTTONDBLCLK = 0x206,

        /// <summary>
        /// 中键按下
        /// </summary>
        WM_MBUTTONDOWN = 0x207,

        /// <summary>
        /// 中键释放
        /// </summary>
        WM_MBUTTONUP = 0x208,

        /// <summary>
        /// 中键双击
        /// </summary>
        WM_MBUTTONDBLCLK = 0x209,

        /// <summary>
        /// 滚轮滚动
        /// </summary>
        /// <remarks>WINNT4.0以上才支持此消息</remarks>
        WM_MOUSEWHEEL = 0x020A
    }

    public enum WM_KEYBOARD : int
    {
        /// <summary>
        /// 非系统按键按下
        /// </summary>
        WM_KEYDOWN = 0x100,

        /// <summary>
        /// 非系统按键释放
        /// </summary>
        WM_KEYUP = 0x101,

        /// <summary>
        /// 系统按键按下
        /// </summary>
        WM_SYSKEYDOWN = 0x104,

        /// <summary>
        /// 系统按键释放
        /// </summary>
        WM_SYSKEYUP = 0x105
    }
    public enum VK_KEY : int
    {
        VK_ADD = 0x6B,
        VK_ATTN = 0xF6,
        VK_BACK = 0x8,
        VK_CANCEL = 0x3,
        VK_CAPITAL = 0x14,
        VK_CLEAR = 0xC,
        VK_CONTROL = 0x11,
        VK_CRSEL = 0xF7,
        VK_DECIMAL = 0x6E,
        VK_DELETE = 0x2E,
        VK_DIVIDE = 0x6F,
        VK_DOWN = 0x28,
        VK_END = 0x23,
        VK_EREOF = 0xF9,
        VK_ESCAPE = 0x1B,
        VK_EXECUTE = 0x2B,
        VK_EXSEL = 0xF8,
        VK_F1 = 0x70,
        VK_F10 = 0x79,
        VK_F11 = 0x7A,
        VK_F12 = 0x7B,
        VK_F13 = 0x7C,
        VK_F14 = 0x7D,
        VK_F15 = 0x7E,
        VK_F16 = 0x7F,
        VK_F17 = 0x80,
        VK_F18 = 0x81,
        VK_F19 = 0x82,
        VK_F2 = 0x71,
        VK_F20 = 0x83,
        VK_F21 = 0x84,
        VK_F22 = 0x85,
        VK_F23 = 0x86,
        VK_F24 = 0x87,
        VK_F3 = 0x72,
        VK_F4 = 0x73,
        VK_F5 = 0x74,
        VK_F6 = 0x75,
        VK_F7 = 0x76,
        VK_F8 = 0x77,
        VK_F9 = 0x78,
        VK_HELP = 0x2F,
        VK_HOME = 0x24,
        VK_INSERT = 0x2D,
        VK_LBUTTON = 0x1,
        VK_LCONTROL = 0xA2,
        VK_LEFT = 0x25,
        VK_LMENU = 0xA4,
        VK_LSHIFT = 0xA0,
        VK_MBUTTON = 0x4,
        VK_MENU = 0x12,
        VK_MULTIPLY = 0x6A,
        VK_NEXT = 0x22,
        VK_NONAME = 0xFC,
        VK_NUMLOCK = 0x90,
        VK_NUMPAD0 = 0x60,
        VK_NUMPAD1 = 0x61,
        VK_NUMPAD2 = 0x62,
        VK_NUMPAD3 = 0x63,
        VK_NUMPAD4 = 0x64,
        VK_NUMPAD5 = 0x65,
        VK_NUMPAD6 = 0x66,
        VK_NUMPAD7 = 0x67,
        VK_NUMPAD8 = 0x68,
        VK_NUMPAD9 = 0x69,
        VK_OEM_CLEAR = 0xFE,
        VK_PA1 = 0xFD,
        VK_PAUSE = 0x13,
        VK_PLAY = 0xFA,
        VK_PRINT = 0x2A,
        VK_PRIOR = 0x21,
        VK_RBUTTON = 0x2,
        VK_RCONTROL = 0xA3,
        VK_RETURN = 0xD,
        VK_RIGHT = 0x27,
        VK_RMENU = 0xA5,
        VK_RSHIFT = 0xA1,
        VK_SCROLL = 0x91,
        VK_SELECT = 0x29,
        VK_SEPARATOR = 0x6C,
        VK_SHIFT = 0x10,
        VK_SNAPSHOT = 0x2C,
        VK_SPACE = 0x20,
        VK_SUBTRACT = 0x6D,
        VK_TAB = 0x9,
        VK_UP = 0x26,
        VK_ZOOM = 0xFB,
    }

    #endregion
}
