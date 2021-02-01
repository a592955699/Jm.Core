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
            _GlobalHooks.Shell.WindowCreated += new GlobalHooks.WindowEventHandler(WindowCreated);
            _GlobalHooks.Shell.Start();
        }

        private void WindowCreated(IntPtr Handle)
        {
            int capacity = CommonApis.GetWindowTextLength(new HandleRef(null, Handle)) * 2;
            StringBuilder stringBuilder = new StringBuilder(capacity);
            CommonApis.GetWindowText(new HandleRef(null, Handle), stringBuilder, stringBuilder.Capacity);
            Console.WriteLine(stringBuilder.ToString());

            int id = 0;
            CommonApis.GetWindowThreadProcessId(Handle, out id);
            if (id != 0)
            {
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(id);
                Console.WriteLine(p.MainModule.FileName);

                ////Loop through and see if this is a program we want to monitor
                //for (int i = 0; i < settings.Count; i++)
                //{
                //    ProgramSettings set = settings[i];
                //    if ((p.MainModule.FileName.ToLower() == set.Filepath.ToLower()) && (set.Enabled))
                //    {
                //        ModifyProperties(set, Handle);

                //        //Show a balloon tip if we're set to
                //        if (checkBalloonStart.Checked)
                //        {
                //            trayIcon.ShowBalloonTip(3000, "Program Profile Applied", "Window Manager has applied a profile to " + p.MainModule.ModuleName, ToolTipIcon.Info);
                //        }
                //    }
                //}
            }
        }
    }
}
