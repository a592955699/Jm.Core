using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.AStartTest
{
    public class AStar
    {
        public const int OBLIQUE = 14;
        public const int STEP = 10;
        public int[,] MazeArray { get; private set; }
        List<APoint> CloseList;
        List<APoint> OpenList;

        public AStar(int[,] maze)
        {
            this.MazeArray = maze;
            OpenList = new List<APoint>(MazeArray.Length);
            CloseList = new List<APoint>(MazeArray.Length);
        }
        public List<APoint> FindPath(APoint start, APoint end)
        {
            List<APoint> points = new List<APoint>();

           var parent = FindPath(start, end, false);

            while (parent != null)
            {
                points.Add(parent);
                parent = parent.ParentPoint;
            }
            return points;
        }
        private APoint FindPath(APoint start, APoint end, bool IsIgnoreCorner)
        {
            OpenList.Add(start);
            while (OpenList.Count != 0)
            {
                //找出F值最小的点
                var tempStart = OpenList.MinPoint();
                OpenList.RemoveAt(0);
                CloseList.Add(tempStart);
                //找出它相邻的点
                var surroundPoints = SurrroundPoints(tempStart, IsIgnoreCorner);
                foreach (APoint point in surroundPoints)
                {
                    if (OpenList.Exists(point))
                        //计算G值, 如果比原来的大, 就什么都不做, 否则设置它的父节点为当前点,并更新G和F
                        FoundPoint(tempStart, point);
                    else
                        //如果它们不在开始列表里, 就加入, 并设置父节点,并计算GHF
                        NotFoundPoint(tempStart, end, point);
                }
                if (OpenList.Get(end) != null)
                    return OpenList.Get(end);
            }
            return OpenList.Get(end);
        }

        private void FoundPoint(APoint tempStart, APoint point)
        {
            var G = CalcG(tempStart, point);
            if (G < point.G)
            {
                point.ParentPoint = tempStart;
                point.G = G;
                point.CalcF();
            }
        }

        private void NotFoundPoint(APoint tempStart, APoint end, APoint point)
        {
            point.ParentPoint = tempStart;
            point.G = CalcG(tempStart, point);
            point.H = CalcH(end, point);
            point.CalcF();
            OpenList.Add(point);
        }

        private int CalcG(APoint start, APoint point)
        {
            int G = (Math.Abs(point.X - start.X) + Math.Abs(point.Y - start.Y)) == 2 ? STEP : OBLIQUE;
            int parentG = point.ParentPoint != null ? point.ParentPoint.G : 0;
            return G + parentG;
        }

        private int CalcH(APoint end, APoint point)
        {
            int step = Math.Abs(point.X - end.X) + Math.Abs(point.Y - end.Y);
            return step * STEP;
        }

        //获取某个点周围可以到达的点
        public List<APoint> SurrroundPoints(APoint point, bool IsIgnoreCorner)
        {
            var surroundPoints = new List<APoint>(9);

            for (int x = point.X - 1; x <= point.X + 1; x++)
                for (int y = point.Y - 1; y <= point.Y + 1; y++)
                {
                    if (CanReach(point, x, y, IsIgnoreCorner))
                        surroundPoints.Add(x, y);
                }
            return surroundPoints;
        }

        //在二维数组对应的位置不为障碍物
        private bool CanReach(int x, int y)
        {
            return MazeArray[x, y] == 0;
        }

        public bool CanReach(APoint start, int x, int y, bool IsIgnoreCorner)
        {
            if (!CanReach(x, y) || CloseList.Exists(x, y))
                return false;
            else
            {
                if (Math.Abs(x - start.X) + Math.Abs(y - start.Y) == 1)
                    return true;
                //如果是斜方向移动, 判断是否 "拌脚"
                else
                {
                    if (CanReach(Math.Abs(x - 1), y) && CanReach(x, Math.Abs(y - 1)))
                        return true;
                    else
                        return IsIgnoreCorner;
                }
            }
        }
    }

    //Point 类型
    public class APoint
    {
        public APoint ParentPoint { get; set; }
        /// <summary>
        /// 综合权重 F=G+H
        /// </summary>
        public int F { get; set; }
        /// <summary>
        /// 到达父节点权重
        /// </summary>
        public int G { get; set; }
        /// <summary>
        /// 到达终点权重
        /// </summary>
        public int H { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public APoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public void CalcF()
        {
            this.F = this.G + this.H;
        }
    }

    //对 List<Point> 的一些扩展方法
    public static class ListHelper
    {
        public static bool Exists(this List<APoint> points, APoint point)
        {
            foreach (APoint p in points)
                if ((p.X == point.X) && (p.Y == point.Y))
                    return true;
            return false;
        }

        public static bool Exists(this List<APoint> points, int x, int y)
        {
            foreach (APoint p in points)
                if ((p.X == x) && (p.Y == y))
                    return true;
            return false;
        }

        public static APoint MinPoint(this List<APoint> points)
        {
            points = points.OrderBy(p => p.F).ToList();
            return points[0];
        }
        public static void Add(this List<APoint> points, int x, int y)
        {
            APoint point = new APoint(x, y);
            points.Add(point);
        }

        public static APoint Get(this List<APoint> points, APoint point)
        {
            foreach (APoint p in points)
                if ((p.X == point.X) && (p.Y == point.Y))
                    return p;
            return null;
        }

        public static void Remove(this List<APoint> points, int x, int y)
        {
            foreach (APoint point in points)
            {
                if (point.X == x && point.Y == y)
                    points.Remove(point);
            }
        }
    }
}
