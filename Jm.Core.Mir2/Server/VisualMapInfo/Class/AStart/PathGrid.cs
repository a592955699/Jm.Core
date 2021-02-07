using System.Collections.Generic;
using System.Linq;
using System;

namespace Jm.Core.Mir2.Server.VisualMapInfo.Class.AStart
{
    public class PathGrid
    {
        private SortedDictionary<int, List<APoint>> openTree = new SortedDictionary<int, List<APoint>>();

        private HashSet<APoint> openSet = new HashSet<APoint>();
        private HashSet<APoint> closeSet = new HashSet<APoint>();
        private Dictionary<APoint, PathNode> allNodes = new Dictionary<APoint, PathNode>();

        private APoint endPos;
        private APoint gridSize;

        private List<APoint> currentPath;

        //这一部分在实际寻路中并不需要，只是为了方便外部程序实现寻路可视化
        public HashSet<APoint> GetCloseList()
        {
            return closeSet;
        }

        //这一部分在实际寻路中并不需要，只是为了方便外部程序实现寻路可视化
        public HashSet<APoint> GetOpenList()
        {
            return openSet;
        }

        //这一部分在实际寻路中并不需要，只是为了方便外部程序实现寻路可视化
        public List<APoint> GetCurrentPath()
        {
            return currentPath;
        }

        //新建一个PathGrid，包含了网格大小和障碍物信息
        //public PathGrid(int x, int y, List<APoint> walls)
        public PathGrid(int x, int y, int[,] walls)
        {
            gridSize = new APoint(x, y);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    APoint newPos = new APoint(i, j);
                    allNodes.Add(newPos, new PathNode(walls[i,j]==1, newPos));
                }
            }
        }

        //寻路主要逻辑，通过调用该方法来获取路径信息，由一串Point2代表
        public List<APoint> FindPath(APoint beginPos, APoint endPos)
        {
            List<APoint> result = new List<APoint>();

            this.endPos = endPos;
            APoint currentPos = beginPos;
            openSet.Add(currentPos);

            while (!currentPos.Equals(this.endPos))
            {
                UpdatePath(currentPos);
                if (openSet.Count == 0) return null;

                currentPos = openTree.First().Value.First();
            }

            APoint path = currentPos;

            while (!path.Equals(beginPos))
            {
                result.Add(path);
                path = allNodes[path].parent.position;
                currentPath = result;
            }

            result.Add(beginPos);
            return result;
        }

        //寻路
        private void UpdatePath(APoint currentPos)
        {
            closeSet.Add(currentPos);
            RemoveOpen(currentPos, allNodes[currentPos]);
            List<APoint> neighborNodes = FindNeighbor(currentPos);
            foreach (APoint nodePos in neighborNodes)
            {

                PathNode newNode = new PathNode(false, nodePos);
                newNode.parent = allNodes[currentPos];

                int g;
                int h;

                g = currentPos.X == nodePos.X || currentPos.Y == nodePos.Y ? 10 : 14;

                int xMoves = Math.Abs(nodePos.X - endPos.X);
                int yMoves = Math.Abs(nodePos.Y - endPos.Y);

                int min = Math.Min(xMoves, yMoves);
                int max = Math.Max(xMoves, yMoves);
                h = min * 14 + (max - min) * 10;


                newNode.gCost = g + newNode.parent.gCost;
                newNode.hCost = h;

                PathNode originNode = allNodes[nodePos];

                if (openSet.Contains(nodePos))
                {
                    if (newNode.fCost < originNode.fCost)
                    {
                        UpdateNode(newNode, originNode);
                    }
                }
                else
                {
                    allNodes[nodePos] = newNode;
                    AddOpen(nodePos, newNode);
                }
            }
        }

        //将旧节点更新为新节点
        private void UpdateNode(PathNode newNode, PathNode oldNode)
        {
            APoint nodePos = newNode.position;
            int oldCost = oldNode.fCost;
            allNodes[nodePos] = newNode;
            List<APoint> sameCost;

            if (openTree.TryGetValue(oldCost, out sameCost))
            {
                sameCost.Remove(nodePos);
                if (sameCost.Count == 0) openTree.Remove(oldCost);
            }

            if (openTree.TryGetValue(newNode.fCost, out sameCost))
            {
                sameCost.Add(nodePos);
            }
            else
            {
                sameCost = new List<APoint> { nodePos };
                openTree.Add(newNode.fCost, sameCost);
            }
        }

        //将目标节点移出开启列表
        private void RemoveOpen(APoint pos, PathNode node)
        {
            openSet.Remove(pos);
            List<APoint> sameCost;
            if (openTree.TryGetValue(node.fCost, out sameCost))
            {
                sameCost.Remove(pos);
                if (sameCost.Count == 0) openTree.Remove(node.fCost);
            }
        }

        //将目标节点加入开启列表
        private void AddOpen(APoint pos, PathNode node)
        {
            openSet.Add(pos);
            List<APoint> sameCost;
            if (openTree.TryGetValue(node.fCost, out sameCost))
            {
                sameCost.Add(pos);
            }
            else
            {
                sameCost = new List<APoint> { pos };
                openTree.Add(node.fCost, sameCost);
            }
        }

        //找到某节点的所有相邻节点
        private List<APoint> FindNeighbor(APoint nodePos)
        {
            List<APoint> result = new List<APoint>();

            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    if (x == 0 && y == 0) continue;

                    APoint currentPos = new APoint(nodePos.X + x, nodePos.Y + y);

                    if (currentPos.X >= gridSize.X || currentPos.Y >= gridSize.Y || currentPos.X < 0 || currentPos.Y < 0) continue; //out of bondary
                    if (closeSet.Contains(currentPos)) continue; // already in the close list
                    if (allNodes[currentPos].isWall) continue;  // the node is a wall

                    result.Add(currentPos);
                }
            }

            return result;
        }
    }
}