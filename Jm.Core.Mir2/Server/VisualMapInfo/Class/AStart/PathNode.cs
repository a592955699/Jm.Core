using System;
using System.Collections.Generic;
using System.Text;

namespace Jm.Core.Mir2.Server.VisualMapInfo.Class.AStart
{
    public class PathNode
    {
        public PathNode(bool isWall, APoint position)
        {
            this.isWall = isWall;
            this.position = position;
        }

        public readonly APoint position;

        public bool isWall { get; set; }

        public PathNode parent { get; set; }

        public int gCost { get; set; }

        public int hCost { get; set; }

        public int fCost
        {
            get
            {
                return gCost + hCost;
            }
        }

        public override bool Equals(object obj)
        {
            PathNode node = obj as PathNode;
            return node.isWall == this.isWall && node.gCost == this.gCost && node.hCost == this.hCost && node.parent == this.parent && this.position == node.position;
        }

        public override int GetHashCode()
        {
            return gCost ^ (hCost * 128) + position.GetHashCode();
        }

        public static bool operator ==(PathNode a, PathNode b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(PathNode a, PathNode b)
        {
            return !a.Equals(b);
        }
    }
}
