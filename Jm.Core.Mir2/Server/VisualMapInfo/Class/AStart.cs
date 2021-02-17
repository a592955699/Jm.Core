using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace Jm.Core.Mir2
{
    /// <summary>
    /// 自动寻路中的点的定义
    /// A星寻路法的点定义
    /// </summary>
    public class RoutePoint
    {
        public int y;
        public int x;
        public int G;//从开始点到达当前点的距离，移动距离
        public int H;//当前点到终点的距离，这个是估算值
        public RoutePoint father;//上一个节点

        public RoutePoint()
        {

        }

        public RoutePoint(Point p)
        {
            this.x = p.X;
            this.y = p.Y;
        }

        public RoutePoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public RoutePoint(int x0, int y0, int G0, int H0, RoutePoint F)
        {
            x = x0;
            y = y0;
            G = G0;
            H = H0;
            father = F;
        }

        public override string ToString()
        {
            return "{" + x + "," + y + "}";
        }

        public Point getPoint()
        {
            return new Point(x, y);
        }
    }

    /// <summary>
    /// 自动寻路的实现
    /// </summary>
    public class AutoRoute
    {
        //数组用1表示可通过，0表示障碍物,3表示关闭
        int[,] R;

        int w, h;//宽，高

        public AutoRoute(int[,] R)
        {
            this.R = R;
            this.w = R.GetLength(0);
            this.h = R.GetLength(1);
        }

        //开启列表(这个开启列表其实还可以优化的)
        //List<RoutePoint> Open_List = new List<RoutePoint>();
        Dictionary<string, RoutePoint> Open_dic = new Dictionary<string, RoutePoint>();

        //从开启列表查找F值最小的节点(就是G+H最小的点)
        private RoutePoint GetMinFFromOpenList()
        {
            RoutePoint Pmin = null;
            //foreach (RoutePoint p in Open_List) if (Pmin == null || Pmin.G + Pmin.H > p.G + p.H) Pmin = p;
            foreach (RoutePoint p in Open_dic.Values)
            {
                if (Pmin == null || Pmin.G + Pmin.H > p.G + p.H) Pmin = p;
            }
            return Pmin;
        }
        //加入开启列表
        private void OpenAdd(RoutePoint p)
        {
            //Open_List.Add(p);
            string key = p.x + "," + p.y;
            if (!Open_dic.ContainsKey(key))
            {
                Open_dic.Add(key, p);
            }
        }
        //从开启列表删除
        private void OpenRemove(RoutePoint p)
        {
            //Open_List.Remove(p);
            string key = p.x + "," + p.y;
            Open_dic.Remove(key);
        }

        //从开启列表返回对应坐标的点
        private RoutePoint GetPointFromOpenList(int x, int y)
        {
            string key = x + "," + y;
            if (Open_dic.ContainsKey(key))
            {
                return Open_dic[key];
            }
            return null;
        }

        //计算某个点的G值
        private int GetG(RoutePoint p)
        {
            if (p.father == null) return 0;
            if (p.x == p.father.x || p.y == p.father.y) return p.father.G + 10;
            else return p.father.G + 14;
        }

        //计算某个点的H值
        private int GetH(RoutePoint p, RoutePoint pb)
        {
            return Math.Abs(p.x - pb.x) * 10 + Math.Abs(p.y - pb.y) * 10;
        }


        /// <summary>
        /// 寻找附近可到坐标
        /// 附近的8个点
        /// </summary>
        /// <param name="cp">当前坐标</param>
        /// <returns>附近可达坐标数组</returns>
        private List<RoutePoint> FindNearCell(RoutePoint p0)
        {
            List<RoutePoint> NearCellPoints = new List<RoutePoint>();
            for (int xt = p0.x - 1; xt <= p0.x + 1; xt++)
            {
                for (int yt = p0.y - 1; yt <= p0.y + 1; yt++)
                {
                    //排除超过边界的点
                    if (xt < 0 || yt < 0 || xt >= w || yt >= h)
                    {
                        continue;
                    }
                    //排除自己
                    if (xt == p0.x && yt == p0.y)
                    {
                        continue;
                    }
                    //排除不通的点
                    if (R[xt, yt] != 1)
                    {
                        continue;
                    }
                    NearCellPoints.Add(new RoutePoint(xt, yt));
                }
            }
            return NearCellPoints;
        }


        //入口，开始节点pa,目标节点pb
        public List<Point> FindeWay(Point _pa, Point _pb)
        {
            RoutePoint pa = new RoutePoint(_pa);
            RoutePoint pb = new RoutePoint(_pb);
            List<Point> myp = new List<Point>();
            OpenAdd(pa);
            bool isEnd = false;//是否结束
            while (Open_dic.Count > 0 && !isEnd)
            {
                RoutePoint p0 = GetMinFFromOpenList();
                if (p0 == null) return myp;
                OpenRemove(p0);
                R[p0.x, p0.y] = 3;//关闭掉
                foreach (RoutePoint childCell in FindNearCell(p0))
                {
                    //如果已经到了终点，把终点的父亲指向当前点，并直接结束掉
                    if (childCell.x == pb.x && childCell.y == pb.y)
                    {
                        pb.father = p0;
                        isEnd = true;
                        break;
                    }
                    //在开启列表,则取出来，重新计算G值，如果从当前节点过去的G值更低，则更新那个点的G值和父亲
                    RoutePoint pt = GetPointFromOpenList(childCell.x, childCell.y);
                    if (pt != null)
                    {
                        int G_new = 0;
                        if (p0.x == pt.x || p0.y == pt.y)
                            G_new = p0.G + 10;
                        else
                            G_new = p0.G + 14;

                        if (G_new < pt.G)
                        {
                            pt.father = p0;
                            pt.G = G_new;
                        }
                    }
                    else
                    {
                        //不在开启列表中,全新的点,则加入开启列表
                        childCell.father = p0;
                        childCell.G = GetG(childCell);
                        childCell.H = GetH(childCell, pb);
                        OpenAdd(childCell);
                    }
                }
            }
            //终点在列表里，起点不在
            while (pb.father != null)
            {
                myp.Add(pb.getPoint());
                pb = pb.father;
            }
            return myp;
        }

    }
}
