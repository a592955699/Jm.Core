using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Jm.Core.Mir2.Server.VisualMapInfo.Class.AStart
{
    //A class used to store the position information
    public class APoint
    {
        public APoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            return this.X == (obj as APoint).X && this.Y == (obj as APoint).Y;
        }

        public override int GetHashCode()
        {
            //return X ^ (Y * 256);
            return X + Y << 16;
        }

        public override string ToString()
        {
            return X + "," + Y;
        }

        public static bool operator ==(APoint a, APoint b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(APoint a, APoint b)
        {
            return !a.Equals(b);
        }
    }
}
