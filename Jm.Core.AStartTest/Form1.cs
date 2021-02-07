using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jm.Core.AStartTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] array = {
                           { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                           { 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1},
                           { 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1},
                           { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1},
                           { 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1},
                           { 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1},
                           { 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1},
                           { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
                           };
            Maze maze = new Maze(array);
            APoint start = new APoint(1, 1);
            APoint end = new APoint(6, 10);
            var parent = maze.FindPath(start, end, false);

            Console.WriteLine("Print path:");
            while (parent != null)
            {
                Console.WriteLine(parent.X + ", " + parent.Y);
                parent = parent.ParentPoint;
            }
        }
    }
}
