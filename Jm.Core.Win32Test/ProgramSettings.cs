using System;
using System.Collections.Generic;
using System.Text;

namespace WindowManager
{
    //Class to hold settings for "Program Profiles"
    [Serializable]
    class ProgramSettings
    {
        public string Filepath;
        public string FileName;
        public bool Enabled;
        public BorderStyle Borderstyle;
        public WinState WindowState;
        public uint Style; //If set to custom borderstyle, the style will be set here.

        public ProgramSettings(string file, string NiceName)
        {
            Filepath = file;
            FileName = NiceName;

            //Some defaults
            Borderstyle = BorderStyle.SIZABLE;
            WindowState = WinState.NORMAL;
            Style = 382664704;

            Enabled = false;
        }
    }

    public enum BorderStyle
    {
        NONE,
        SIZABLE,
        CUSTOM,
    }

    public enum WinState
    {
        NORMAL,
        MINIMIZED,
        MAXIMIZED,
    }

}
