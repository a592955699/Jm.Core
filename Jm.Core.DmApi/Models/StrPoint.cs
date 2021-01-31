using System;
using System.Collections.Generic;
using System.Text;

namespace Jm.Core.DmApi.Models
{
    public class StrPoint
    {
        public StrPoint() { }
        public StrPoint(string str,int x,int y) {
            String = str;
            X = x;
            Y = y;
        }
        public string String { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsEmpty()
        {
            return X == 0 && Y == 0;
        }
    }
}
