using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Jm.Core.Win32;

namespace WindowManager
{
    public partial class ManagerMain : Form
    {
        private IntPtr thumb;
        private List<Window> windows = new List<Window>();
        private List<ProgramSettings> settings = new List<ProgramSettings>();
        Win32Api.EnumWindowsCallback EnumCallback = null; //Callback for enumerating windows
       // User32.CBTProc CreateWnd_Callback = null; //Callback for when a window is created
        //private int hHook = 0;
        Advanced adv = new Advanced();

        private GlobalHooks _GlobalHooks;

        public ManagerMain()
        {
            InitializeComponent();

            //Load settings
            Properties.Settings.Default.Reload();

            if (Properties.Settings.Default.Programs != null && Properties.Settings.Default.Programs.Count > 0)
            {
                settings = Properties.Settings.Default.Programs;

                listPrograms.Items.Clear();
                for (int i = 0; i < settings.Count; i++)
                {
                    listPrograms.Items.Add(settings[i].FileName).SubItems.Add(settings[i].Filepath);
                    listPrograms.Items[listPrograms.Items.Count - 1].Checked = settings[i].Enabled;
                }
            }

            checkMinToTray.Checked = Properties.Settings.Default.MinToTray;
            checkBalloonStart.Checked = Properties.Settings.Default.BalloontipStart;

            //Create the delegates to some winapi funcs
            EnumCallback = new Win32Api.EnumWindowsCallback(EnumWindows);

            _GlobalHooks = new GlobalHooks(this.Handle);
            _GlobalHooks.Shell.WindowCreated += new GlobalHooks.WindowEventHandler(WindowCreated);
           _GlobalHooks.Shell.Start();

            //Load our current list of windows open
            RefreshList();
        }


        //Override so we receive all messages
        protected override void WndProc(ref Message m)
        {
            if (_GlobalHooks != null)
                _GlobalHooks.ProcessWindowMessage(ref m);

            base.WndProc(ref m);
        }

        //Refresh the main windows list of..windows
        public void RefreshList()
        {
            listWindows.Items.Clear();
            windows.Clear();

            //Remove the thumbnail, our selection is lost
            if (thumb != IntPtr.Zero)
                Win32Api.DwmUnregisterThumbnail(thumb);

            //Ask for a new list of windows
            Win32Api.EnumWindows(EnumCallback, 0);
        }

        //Update the checkboxes on the "advanced" window
        public void UpdateOptions(int hWnd)
        {
            Win32Api.tagWINDOWINFO info = new Win32Api.tagWINDOWINFO();
            Win32Api.GetWindowInfo(hWnd, out info);

            int WinStyle = 0; //0 = normal, 1 = min, 2 = max
            int BorderStyle = 0; //0 = none, 1 = single, etc...

            #region GetWindowStyle
            if ((info.dwStyle & Win32Api.WS_MINIMIZE) != 0)
                WinStyle = 1;
            else if ((info.dwStyle & Win32Api.WS_MAXIMIZE) != 0)
                WinStyle = 2;

            comboWinStyle.SelectedIndex = WinStyle;
            #endregion

            #region GetBorderStyle
            if ((info.dwStyle & Win32Api.WS_BORDER) != 0)
            {
                BorderStyle = 1;

                if ((info.dwStyle & Win32Api.WS_POPUP) != 0)
                {
                 //   BorderStyle = 2;

                    if ((info.dwStyle & Win32Api.WS_THICKFRAME) != 0)
                    {
                    //    BorderStyle = 3;
                    }
                }

            }

            comboBorderStyle.SelectedIndex = BorderStyle;
            #endregion

            adv.PopulateCheckboxes(hWnd);

        }

        //Callback for winAPI. enumerates through all the current windows
        private bool EnumWindows( int hWnd, int lParam )
        {
            Win32Api.tagWINDOWINFO info = new Win32Api.tagWINDOWINFO();
            Win32Api.GetWindowInfo(hWnd, out info);

            if (hWnd != 0 && ((info.dwStyle & Win32Api.WS_VISIBLE) != 0)/*&& ((info.dwStyle & User32.WS_GROUP) != 0)*/) //Window is valid, visible, and
            {
                //The next three lines are all just getting the window title of the handle
                int capacity = Win32Api.GetWindowTextLength(new HandleRef(null, (IntPtr)hWnd)) * 2;
                StringBuilder stringBuilder = new StringBuilder(capacity);
                Win32Api.GetWindowText(new HandleRef(null, (IntPtr)hWnd), stringBuilder, stringBuilder.Capacity);

                //Program manager/Start aren't technically windows, and we don't want anything to do with them.
                //Start is the desktop, and Program Manager is something that manages programs. (Who knew!)
                if (stringBuilder.Length > 0 && stringBuilder.ToString() != "Program Manager" && stringBuilder.ToString() != "Start")
                {
                    //Get the process ID
                    int id = 0;
                    Win32Api.GetWindowThreadProcessId((IntPtr)hWnd, out id);
                    //We're going to use the process so we can get some useful info out of it
                    System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(id);

                    //Create a new window class (A class that just holds some important info about the current windows)
                    Window win = new Window();
                    win.Title = stringBuilder.ToString();
                    win.Handle = hWnd;
                    //win.Icon = User32.GetSmallIcon(p.MainModule.FileName); //I wanted to get the little 16x16 icon like the task manager, but it seemed like a huge task
                    windows.Add(win); //Add it to our list of windows

                    //Replacing the little icon I have a little sign of whether the window is responding or not.
                    //Doesn't look half bad if I say so myself
                    int index = 1;
                    if (p.Responding) index = 0;

                    //Finally, add the window to the listview
                    listWindows.Items.Add(win.Title);
                    listWindows.Items[listWindows.Items.Count -1].ImageIndex = index;
                }
               
            }
            //We must return true so we keep enumerating to the next window
            return true;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList(); //Refreshes the list
        }

        private void refreshNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList(); //I bet you will never guess what this does
        }

        //Update the thumbnail with new positions
        private void UpdateThumb()
        {
            if (thumb != IntPtr.Zero) //That would be bad!
            {
                Win32Api.PSIZE size;
                Win32Api.DwmQueryThumbnailSourceSize(thumb, out size); //Get the source thumbnail size

                Win32Api.DWM_THUMBNAIL_PROPERTIES props = new Win32Api.DWM_THUMBNAIL_PROPERTIES(); //And it's properties

                //We want it visible!
                props.fVisible = true;
                props.dwFlags = Win32Api.DWM_TNP_VISIBLE | Win32Api.DWM_TNP_RECTDESTINATION | Win32Api.DWM_TNP_OPACITY;
                props.opacity = (byte)255;
                Win32Api.RECT rect = new Win32Api.RECT();
                
                //I'm not exactly sure why this is like this.
                //It may be best to leave it be.
                //Just...don't touch it
                int offset = 23;
                    rect.Left = preview.Left + groupPreview.Left + container.Panel2.Left + container.Left + tabControl.Left + 5;
                    rect.Top = preview.Top + groupPreview.Top + container.Panel2.Top + +container.Top + tabControl.Top + offset;
                    rect.Right = preview.Right + groupPreview.Left + container.Panel2.Left + container.Left + tabControl.Left + 4;
                    rect.Bottom = preview.Bottom + groupPreview.Top + container.Panel2.Top + container.Top + tabControl.Top + offset -1;

                props.rcDestination = rect;

                //Update the properties with the new dimensions
                Win32Api.DwmUpdateThumbnailProperties(thumb, ref props);
            }
        }

        private void listWindows_ItemActivate(object sender, EventArgs e)
        {
            if (windows.Count <= 0 || listWindows.SelectedIndices.Count <= 0) return; //If there are zero windows or nothing is selected, do nothing

            Window w = windows[listWindows.SelectedItems[0].Index];

            //Update the thumbnail with the preview of the new window
            #region Thumbnail
            if (thumb != IntPtr.Zero)
                Win32Api.DwmUnregisterThumbnail(thumb);

            int i = Win32Api.DwmRegisterThumbnail(this.Handle, (IntPtr)w.Handle, out thumb);

            if (i == 0)
                UpdateThumb();
            else
                Console.WriteLine("Failed to get thumbnail");
            #endregion

            //Update the settings of the new window
            #region Information
            UpdateOptions(w.Handle);
            #endregion
        }

        private void ManagerMain_Resize(object sender, EventArgs e)
        {
            UpdateThumb(); //Update the thumbnail

            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
                WindowState = FormWindowState.Minimized;
                trayIcon.Visible = true;
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                trayIcon.Visible = false;
            }
        }

        private void container_SplitterMoved(object sender, SplitterEventArgs e)
        {
            UpdateThumb(); //Guess what this does? Updates the thumbnail.
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (windows.Count <= 0 || listWindows.SelectedIndices.Count <= 0) return; //If there are zero windows or nothing is selected, do nothing

            Window w = windows[listWindows.SelectedItems[0].Index];

            //Get some information for the selected window, to be used in settings its style
            Win32Api.tagWINDOWINFO info = new Win32Api.tagWINDOWINFO();
            Win32Api.GetWindowInfo(w.Handle, out info);

            //Get the current windows style
            uint lStyle = (uint)info.dwStyle;
            Console.WriteLine(lStyle); //DEBUG

            
            switch (comboBorderStyle.SelectedIndex)
            {
                case 0: //None
                    lStyle &= ~(Win32Api.WS_CAPTION | Win32Api.WS_BORDER ); //Bit shit that shift
                    break;

                case 1: //Sizable
                    lStyle = lStyle | Win32Api.WS_CAPTION; //These two enumerations make the border exist
                    lStyle = lStyle | Win32Api.WS_BORDER;
                    break;

                case 2: //Custom
                    lStyle = GetCustomStyle(); //Get the custom style selected in the advanced menu
                    break;

                default:
                    break;
            }

            //Set the window properties
            Win32Api.SetWindowLong((IntPtr)w.Handle, (int)Win32Api.WindowLongFlags.GWL_STYLE, (int)lStyle);

            //Window settings are cached, so we must set the position to update them
            Win32Api.SetWindowPos((IntPtr)w.Handle, IntPtr.Zero, info.rcWindow.Left, info.rcWindow.Top, info.rcWindow.Right - info.rcWindow.Left, info.rcWindow.Bottom - info.rcWindow.Top, Win32Api.SetWindowPosFlags.FrameChanged);

            //Now for the Window State
            switch (comboWinStyle.SelectedIndex)
            {
                case 0: //Normal
                    Win32Api.ShowWindowAsync((IntPtr)w.Handle, 1);
                    break;

                case 1: //Minimized
                    Win32Api.ShowWindowAsync((IntPtr)w.Handle, 2);
                    break;

                case 2: //Maximised
                    Win32Api.ShowWindowAsync((IntPtr)w.Handle, 3);
                    break;

                default:
                    break;
            }
        }

        //Get the custom style from the advanced menu.
        //Fun Fact: I want to kill myself after this
        private uint GetCustomStyle()
        {
            uint lStyle = 32;
            int amt = adv.CheckedAmount();
            for (int i = 0; i < amt; i++)
            {
                if (i == 0 && adv.isChecked(i))
                {
                    lStyle = lStyle | Win32Api.WS_BORDER; 
                }
                else if (i == 1 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_CAPTION;
                else if (i == 2 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_CHILD;
                else if (i == 3 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_CLIPCHILDREN;
                else if (i == 4 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_CLIPSIBLINGS;
                else if (i == 5 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_DISABLED;
                else if (i == 6 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_DLGFRAME;
                else if (i == 7 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_GROUP;
                else if (i == 8 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_HSCROLL;
                else if (i == 9 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_MAXIMIZE;
                else if (i == 10 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_MAXIMIZEBOX;
                else if (i == 11 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_MINIMIZE;
                else if (i == 12 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_MINIMIZEBOX;
                else if (i == 13 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_OVERLAPPED;
                else if (i == 14 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_POPUP;
                else if (i == 15 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_SYSMENU;
                else if (i == 16 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_TABSTOP;
                else if (i == 17 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_THICKFRAME;
                else if (i == 18 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_VISIBLE;
                else if (i == 19 && adv.isChecked(i))
                    lStyle = lStyle | Win32Api.WS_VSCROLL;
                                                        
            }
            Console.WriteLine("New Style: " + lStyle);
            //JESUS CHRIST FINALLY
            return lStyle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Don't actually ever hide the menu.
            This is so someone can have the window open
            and select different windows to update their properties */

            if (!adv.IsDisposed)
                adv.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Oh... okay.
            this.Close();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex != 0) //If we aren't on the main page, remove the thumbnail
            {
                if (thumb != IntPtr.Zero)
                    Win32Api.DwmUnregisterThumbnail(thumb);
            }
            else
            {
                if (windows.Count <= 0 || listWindows.SelectedIndices.Count <= 0) return;

                Window w = windows[listWindows.SelectedItems[0].Index];

                if (thumb != IntPtr.Zero)
                    Win32Api.DwmUnregisterThumbnail(thumb);

                int i = Win32Api.DwmRegisterThumbnail(this.Handle, (IntPtr)w.Handle, out thumb);

                if (i == 0)
                    UpdateThumb();
                else
                    Console.WriteLine("Failed to get thumbnail");
            }
        }

        private void btnAddProgram_Click(object sender, EventArgs e)
        {
            DialogResult res = openExec.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                listPrograms.Items.Add(openExec.SafeFileName).SubItems.Add(openExec.FileName);
                listPrograms.Items[listPrograms.Items.Count - 1].SubItems.Add("None");

                //Create the settings object
                ProgramSettings Psettings = new ProgramSettings(openExec.FileName, openExec.SafeFileName);
                settings.Add(Psettings);
            }
        }

        private void remSelected_Click(object sender, EventArgs e)
        {
            if (listPrograms.SelectedIndices.Count > 0 && listPrograms.SelectedIndices[0] < listPrograms.Items.Count)
            {
                settings.RemoveAt(listPrograms.SelectedIndices[0]);
                listPrograms.Items.RemoveAt(listPrograms.SelectedIndices[0]);

                if (listPrograms.Items.Count < 1)
                {
                    btnProgAdvanced.Enabled = false;
                    comboProgStatus.Enabled = false;
                    comboProgStyle.Enabled = false;
                }
            }
        }

        private void listPrograms_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Index < settings.Count)
            {
                settings[e.Item.Index].Enabled = listPrograms.Items[e.Item.Index].Checked;
            }
        }

        private void comboProgStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPrograms.SelectedIndices.Count > 0 && listPrograms.SelectedIndices[0] < listPrograms.Items.Count)
            {
                settings[listPrograms.SelectedIndices[0]].Borderstyle = (BorderStyle)comboProgStyle.SelectedIndex;
            }
        }

        private void comboProgStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPrograms.SelectedIndices.Count > 0 && listPrograms.SelectedIndices[0] < listPrograms.Items.Count)
            {
                settings[listPrograms.SelectedIndices[0]].WindowState = (WinState)comboProgStatus.SelectedIndex;
            }
        }

        private void btnProgAdvanced_Click(object sender, EventArgs e)
        {
            if (listPrograms.SelectedIndices.Count > 0 && listPrograms.SelectedIndices[0] < listPrograms.Items.Count)
            {
                uint style = settings[listPrograms.SelectedIndices[0]].Style;
                ProgramAdvanced adv = new ProgramAdvanced();
                adv.PopulateCheckboxes(style);
                adv.ShowDialog();

                if (!adv.Canceled)
                {
                    settings[listPrograms.SelectedIndices[0]].Style = adv.Style;
                }
            }
        }

        private void WindowCreated(IntPtr Handle)
        {
            int capacity = Win32Api.GetWindowTextLength(new HandleRef(null, Handle)) * 2;
            StringBuilder stringBuilder = new StringBuilder(capacity);
            Win32Api.GetWindowText(new HandleRef(null, Handle), stringBuilder, stringBuilder.Capacity);
            Console.WriteLine(stringBuilder.ToString());

            int id = 0;
            Win32Api.GetWindowThreadProcessId(Handle, out id);
            if (id != 0)
            {
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(id);
                Console.WriteLine(p.MainModule.FileName);

                //Loop through and see if this is a program we want to monitor
                for (int i = 0; i < settings.Count; i++)
                {
                    ProgramSettings set = settings[i];
                    if ( (p.MainModule.FileName.ToLower() == set.Filepath.ToLower()) && (set.Enabled))
                    {
                        ModifyProperties(set, Handle);
                        
                        //Show a balloon tip if we're set to
                        if (checkBalloonStart.Checked)
                        {
                            trayIcon.ShowBalloonTip(3000, "Program Profile Applied", "Window Manager has applied a profile to " + p.MainModule.ModuleName, ToolTipIcon.Info);
                        }
                    }
                }
            }
        }

        private void ModifyProperties(ProgramSettings settings, IntPtr Handle)
        {
            //System.Threading.Thread.Sleep(3000);
            Win32Api.tagWINDOWINFO info = new Win32Api.tagWINDOWINFO();
            Win32Api.GetWindowInfo((int)Handle, out info);
            uint lStyle = (uint)info.dwStyle;
            //Console.WriteLine(lStyle);

            switch (settings.Borderstyle)
            {
                case BorderStyle.NONE: //None
                    lStyle &= ~(Win32Api.WS_CAPTION | Win32Api.WS_BORDER);
                    break;

                case BorderStyle.SIZABLE: //Sizable
                    lStyle = lStyle | Win32Api.WS_CAPTION;
                    lStyle = lStyle | Win32Api.WS_BORDER;
                    break;

                case BorderStyle.CUSTOM: //Custom
                    lStyle = settings.Style;
                    break;

                default:
                    break;
            }

            Win32Api.SetWindowLong(Handle, (int)Win32Api.WindowLongFlags.GWL_STYLE, (int)lStyle);
            Win32Api.SetWindowPos(Handle, IntPtr.Zero, info.rcWindow.Left, info.rcWindow.Top, info.rcWindow.Right - info.rcWindow.Left, info.rcWindow.Bottom - info.rcWindow.Top, Win32Api.SetWindowPosFlags.FrameChanged);

            switch (settings.WindowState)
            {
                case WinState.NORMAL: //Normal
                    Win32Api.ShowWindowAsync(Handle, 1);
                    break;

                case WinState.MINIMIZED: //Minimized
                    Win32Api.ShowWindowAsync(Handle, 2);
                    break;

                case WinState.MAXIMIZED: //Maximised
                    Win32Api.ShowWindowAsync(Handle, 3);
                    break;

                default:
                    break;
            }
        }
        /*
        private int WindowCreated(int nCode, IntPtr wParam, IntPtr lParam)
        {
            //Console.WriteLine("RECEIVED: " + nCode);

            if (nCode == 5)//New Window?
            {
                Console.WriteLine(DateTime.Now + " New Window Created: " + nCode);
                int capacity = User32.GetWindowTextLength(new HandleRef(null, wParam)) * 2;
                StringBuilder stringBuilder = new StringBuilder(capacity);
                User32.GetWindowText(new HandleRef(null, wParam), stringBuilder, stringBuilder.Capacity);
                Console.WriteLine(stringBuilder.ToString());
            }


            if (nCode < 0)
            {
                return User32.CallNextHookEx(hHook, nCode, wParam, lParam);
            }
            else
            {
                return User32.CallNextHookEx(hHook, nCode, wParam, lParam);
            }
        }
        */
        private void btnProgSet_Click(object sender, EventArgs e)
        {
            //TODO: Save settings to file
            Properties.Settings.Default.Programs = settings;
            Properties.Settings.Default.Save();
        }

        private void btnProgReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();

            if (Properties.Settings.Default.Programs != null && Properties.Settings.Default.Programs.Count > 0)
            {
                settings = Properties.Settings.Default.Programs;

                listPrograms.Items.Clear();
                for (int i = 0; i < settings.Count; i++)
                {
                    listPrograms.Items.Add(settings[i].FileName).SubItems.Add(settings[i].Filepath);
                    listPrograms.Items[listPrograms.Items.Count - 1].Checked = settings[i].Enabled;
                }
            }
        }

        private void listPrograms_ItemActivate(object sender, EventArgs e)
        {
            if (listPrograms.SelectedItems[0].Index < settings.Count && listPrograms.SelectedItems[0].Index >= 0) //if our index is in a valid range..
            {
                //Populate the controls with the saved settings
                comboProgStyle.SelectedIndex = (int)settings[listPrograms.SelectedItems[0].Index].Borderstyle;
                comboProgStatus.SelectedIndex = (int)settings[listPrograms.SelectedItems[0].Index].WindowState;

                //We'll want to be able to change them too!
                btnProgAdvanced.Enabled = true;
                comboProgStatus.Enabled = true;
                comboProgStyle.Enabled = true;
            }
        }

        private void listPrograms_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listPrograms.SelectedItems.Count < 1) //If there are no items selected
            {
                //Disable the dudes
                btnProgAdvanced.Enabled = false;
                comboProgStatus.Enabled = false;
                comboProgStyle.Enabled = false;
            }
        }

        private void checkMinToTray_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MinToTray = checkMinToTray.Checked;
            Properties.Settings.Default.Save();
        }

        private void trayClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBalloonStart_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BalloontipStart = checkBalloonStart.Checked;
            Properties.Settings.Default.Save();
        }

        private void trayRestore_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void traySettings_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.tabControl.SelectedTab = tabPage2;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            int WM_SYSCOMMAND = 0x0112;
            int SC_CLOSE = 0xF060;

            if (windows.Count <= 0 || listWindows.SelectedIndices.Count <= 0) return; //If there are zero windows or nothing is selected, do nothing

            Window w = windows[listWindows.SelectedItems[0].Index];

            Win32Api.SendMessage(new IntPtr(w.Handle), WM_SYSCOMMAND, SC_CLOSE, new IntPtr());
        }
    }
}
