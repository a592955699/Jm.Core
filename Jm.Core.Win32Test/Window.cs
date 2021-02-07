using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WindowManager
{
    //A class to hold information about the windows in the main listView
    class Window
    {
        public int Handle;
        public Icon Icon; //For the moment, useless
        public string Title;

        public override string ToString()
        {
            return Title;
        }
    }
}
