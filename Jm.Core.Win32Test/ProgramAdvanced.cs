using Jm.Core.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowManager
{
    public partial class ProgramAdvanced : Form
    {
        public bool Canceled = false;
        public uint Style = 32;

        public ProgramAdvanced()
        {
            InitializeComponent();
        }

        //KILL. ME.
        public void PopulateCheckboxes(uint style)
        {
            ClearChecks();

            if ((style & Win32Api.WS_BORDER) != 0)
                winProgOptions.SetItemChecked(0, true);
            if ((style & Win32Api.WS_CAPTION) != 0)
                winProgOptions.SetItemChecked(1, true);
            if ((style & Win32Api.WS_CHILD) != 0)
                winProgOptions.SetItemChecked(2, true);
            if ((style & Win32Api.WS_CLIPCHILDREN) != 0)
                winProgOptions.SetItemChecked(3, true);
            if ((style & Win32Api.WS_CLIPSIBLINGS) != 0)
                winProgOptions.SetItemChecked(4, true);
            if ((style & Win32Api.WS_DISABLED) != 0)
                winProgOptions.SetItemChecked(5, true);
            if ((style & Win32Api.WS_DLGFRAME) != 0)
                winProgOptions.SetItemChecked(6, true);
            if ((style & Win32Api.WS_GROUP) != 0)
                winProgOptions.SetItemChecked(7, true);
            if ((style & Win32Api.WS_HSCROLL) != 0)
                winProgOptions.SetItemChecked(8, true);
            if ((style & Win32Api.WS_MAXIMIZE) != 0)
                winProgOptions.SetItemChecked(9, true);
            if ((style & Win32Api.WS_MAXIMIZEBOX) != 0)
                winProgOptions.SetItemChecked(10, true);
            if ((style & Win32Api.WS_MINIMIZE) != 0)
                winProgOptions.SetItemChecked(11, true);
            if ((style & Win32Api.WS_MINIMIZEBOX) != 0)
                winProgOptions.SetItemChecked(12, true);
            if ((style & Win32Api.WS_OVERLAPPED) != 0)
                winProgOptions.SetItemChecked(13, true);
            if ((style & Win32Api.WS_POPUP) != 0)
                winProgOptions.SetItemChecked(14, true);
            if ((style & Win32Api.WS_SYSMENU) != 0)
                winProgOptions.SetItemChecked(15, true);
            if ((style & Win32Api.WS_TABSTOP) != 0)
                winProgOptions.SetItemChecked(16, true);
            if ((style & Win32Api.WS_THICKFRAME) != 0)
                winProgOptions.SetItemChecked(17, true);
            if ((style & Win32Api.WS_VISIBLE) != 0)
                winProgOptions.SetItemChecked(18, true);
            if ((style & Win32Api.WS_VSCROLL) != 0)
                winProgOptions.SetItemChecked(19, true);
        }

        public bool isChecked(int i)
        {
            return winProgOptions.GetItemCheckState(i) == CheckState.Checked;
        }

        public int CheckedAmount()
        {
            return winProgOptions.Items.Count;
        }

        private void ClearChecks()
        {
            for (int i = 0; i < winProgOptions.Items.Count; i++)
            {
                winProgOptions.SetItemChecked(i, false);
            }
        }

        private uint GetCustomStyle()
        {
            uint lStyle = 32;
            int amt = CheckedAmount();
            for (int i = 0; i < amt; i++)
            {
                if (i == 0 && isChecked(i))
                {
                    lStyle = lStyle | Win32Api.WS_BORDER;
                }
                else if (i == 1 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_CAPTION;
                else if (i == 2 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_CHILD;
                else if (i == 3 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_CLIPCHILDREN;
                else if (i == 4 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_CLIPSIBLINGS;
                else if (i == 5 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_DISABLED;
                else if (i == 6 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_DLGFRAME;
                else if (i == 7 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_GROUP;
                else if (i == 8 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_HSCROLL;
                else if (i == 9 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_MAXIMIZE;
                else if (i == 10 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_MAXIMIZEBOX;
                else if (i == 11 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_MINIMIZE;
                else if (i == 12 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_MINIMIZEBOX;
                else if (i == 13 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_OVERLAPPED;
                else if (i == 14 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_POPUP;
                else if (i == 15 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_SYSMENU;
                else if (i == 16 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_TABSTOP;
                else if (i == 17 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_THICKFRAME;
                else if (i == 18 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_VISIBLE;
                else if (i == 19 && isChecked(i))
                    lStyle = lStyle | Win32Api.WS_VSCROLL;

            }

            return lStyle;
        }

        private void winProgOptions_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void buttonProgAccept_Click(object sender, EventArgs e)
        {
            Style = GetCustomStyle();
            this.Close();
        }

        private void btnProgCancel_Click(object sender, EventArgs e)
        {
            Canceled = true;
            this.Close();
        }

        private void btnProgRefresh_Click(object sender, EventArgs e)
        {
            Style = GetCustomStyle();
            styleProgOutput.Text = GetCustomStyle().ToString();
        }
    }
}
