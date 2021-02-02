using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jm.Core.WinForm.Win32
{
    /* The heart of the Program Profiles. Thanks a bunch ChrisP!
     * This class lets me hook into some crucial low level global hooks
     * in the .net framework. It by default does not allow this. Though this lets me do 
     * more hooks than WH_CBT, this is what I use it for (Hook for when a window is created)
     * 
     * Code Project Page: http://www.codeproject.com/Articles/18638/Using-Window-Messages-to-Implement-Global-System-H
     * More from author: http://chrisburkina.blogspot.com 
     * More from author: https://github.com/Foohy/WindowManager
     */

    public class GlobalHooks
    {
        // Handle of the window intercepting messages
        private IntPtr _Handle;

        public MouseHook Mouse { get; private set; }
        public KeyboardHook Keyboard { get; private set; }

        public GlobalHooks(IntPtr Handle)
        {
            _Handle = Handle;

            Mouse = new MouseHook(_Handle);
            Keyboard = new KeyboardHook(_Handle);
        }

        ~GlobalHooks()
        {
            Mouse.Stop();
            Keyboard.Stop();
        }
    }
}
