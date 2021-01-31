using System;
using System.Collections.Generic;
using System.Text;

namespace Jm.Core.DmApi.Args
{
    public class BindWindow
    {
        /// <summary>
        /// 屏幕颜色获取方式 取值有以下几种
        /// "normal" : 正常模式,平常我们用的前台截屏模式
        /// "gdi" : gdi模式,用于窗口采用GDI方式刷新时.此模式占用CPU较大.参考SetAero win10以上系统使用此模式，如果截图失败，尝试把目标程序重新开启再试试。
        /// "gdi2" : gdi2模式,此模式兼容性较强,但是速度比gdi模式要慢许多,如果gdi模式发现后台不刷新时,可以考虑用gdi2模式.
        /// "dx2" : dx2模式,用于窗口采用dx模式刷新,如果dx方式会出现窗口所在进程崩溃的状况,可以考虑采用这种.采用这种方式要保证窗口有一部分在屏幕外.win7 win8或者vista不需要移动也可后台.此模式占用CPU较大.参考SetAero.win10以上系统使用此模式，如果截图失败，尝试把目标程序重新开启再试试。
        /// "dx3" : dx3模式, 同dx2模式, 但是如果发现有些窗口后台不刷新时, 可以考虑用dx3模式, 此模式比dx2模式慢许多.此模式占用CPU较大.参考SetAero.win10以上系统使用此模式，如果截图失败，尝试把目标程序重新开启再试试。
        /// "dx" : dx模式, 等同于BindWindowEx中，display设置的"dx.graphic.2d|dx.graphic.3d", 具体参考BindWindowEx
        /// </summary>
        public string Display { get; set; }
        /// <summary>
        /// 鼠标仿真模式 取值有以下几种
        /// "normal" : 正常模式,平常我们用的前台鼠标模式
        /// "windows": Windows模式,采取模拟windows消息方式 同按键自带后台插件.
        /// "windows2": Windows2 模式, 采取模拟windows消息方式(锁定鼠标位置) 此模式等同于BindWindowEx中的mouse为以下组合
        /// "dx.mouse.position.lock.api|dx.mouse.position.lock.message|dx.mouse.state.message"
        /// "windows3": Windows3模式，采取模拟windows消息方式, 可以支持有多个子窗口的窗口后台.
        /// "dx": dx模式, 采用模拟dx后台鼠标模式, 这种方式会锁定鼠标输入.有些窗口在此模式下绑定时，需要先激活窗口再绑定(或者绑定以后激活)，否则可能会出现绑定后鼠标无效的情况.此模式等同于BindWindowEx中的mouse为以下组合
        /// "dx.public.active.api|dx.public.active.message|dx.mouse.position.lock.api|dx.mouse.position.lock.message|dx.mouse.state.api|dx.mouse.state.message|dx.mouse.api|dx.mouse.focus.input.api|dx.mouse.focus.input.message|dx.mouse.clip.lock.api|dx.mouse.input.lock.api|dx.mouse.cursor"
        /// "dx2"：dx2模式, 这种方式类似于dx模式, 但是不会锁定外部鼠标输入.
        /// 有些窗口在此模式下绑定时，需要先激活窗口再绑定(或者绑定以后手动激活)，否则可能会出现绑定后鼠标无效的情况.此模式等同于BindWindowEx中的mouse为以下组合
        /// "dx.public.active.api|dx.public.active.message|dx.mouse.position.lock.api|dx.mouse.state.api|dx.mouse.api|dx.mouse.focus.input.api|dx.mouse.focus.input.message|dx.mouse.clip.lock.api|dx.mouse.input.lock.api| dx.mouse.cursor"
        /// </summary>
        public string Mouse { get; set; }
        /// <summary>
        /// 键盘仿真模式 取值有以下几种
        /// "normal" : 正常模式,平常我们用的前台键盘模式
        /// "windows": Windows模式,采取模拟windows消息方式 同按键的后台插件.
        /// "dx": dx模式, 采用模拟dx后台键盘模式。有些窗口在此模式下绑定时，需要先激活窗口再绑定(或者绑定以后激活)，否则可能会出现绑定后键盘无效的情况.此模式等同于BindWindowEx中的keypad为以下组合
        /// "dx.public.active.api|dx.public.active.message| dx.keypad.state.api|dx.keypad.api|dx.keypad.input.lock.api"
        /// </summary>
        public string Keypad { get; set; }
        /// <summary>
        /// 模式。 取值有以下几种
        ///  0 : 推荐模式此模式比较通用，而且后台效果是最好的.
        ///  2 : 同模式0,如果模式0有崩溃问题，可以尝试此模式.注意0和2模式，当主绑定(第一个绑定同个窗口的对象)绑定成功后，那么调用主绑定的线程必须一致维持,否则线程一旦推出,对应的绑定也会消失.
        ///  101 : 超级绑定模式.可隐藏目标进程中的dm.dll.避免被恶意检测.效果要比dx.public.hide.dll好.推荐使用.
        ///  103 : 同模式101，如果模式101有崩溃问题，可以尝试此模式.
        ///  11 : 需要加载驱动,适合一些特殊的窗口,如果前面的无法绑定，可以尝试此模式.此模式不支持32位系统
        ///  13 : 需要加载驱动,适合一些特殊的窗口,如果前面的无法绑定，可以尝试此模式.此模式不支持32位系统
        ///  需要注意的是: 模式101 103在大部分窗口下绑定都没问题。但也有少数特殊的窗口，比如有很多子窗口的窗口，对于这种窗口，在绑定时，一定要把
        ///  鼠标指向一个可以输入文字的窗口，比如一个文本框，最好能激活这个文本框，这样可以保证绑定的成功.
        /// </summary>
        public int Mode { get; set; }
    }
}
