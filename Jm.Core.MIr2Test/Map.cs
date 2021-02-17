using Jm.Core.Mir2;
using Jm.Core.Mir2.Server.VisualMapInfo.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jm.Core.MIr2Test
{
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
            width = Width;
            height = Height;
        }

        int width, height;
        ReadMap readMap = new ReadMap();
        List<Point> points = new List<Point>();
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_findPath_Click(object sender, EventArgs e)
        {
            if (points.Count != 2)
            {
                MessageBox.Show("Please select start point and end point!");
                return;
            }
            var start = points[0];
            var end = points[1];
            Stopwatch stopwatch = new Stopwatch();

            AutoRoute autoRoute = new AutoRoute(readMap.Maze);
            stopwatch.Start();
            var tempPoints = autoRoute.FindeWay(start, end);
            stopwatch.Stop();
            if (tempPoints == null || tempPoints.Count == 0)
            {
                lbl_info.Text = "Can't find the path！";
                return;
            }
            lbl_info.Text = $"times:{stopwatch.ElapsedMilliseconds}\r\nDistance:{tempPoints.Count}";

            var newBitmap = (Bitmap)readMap.clippingZone.Clone();
            pic_map.Image = newBitmap;
            
            foreach (var item in tempPoints)
            {
                newBitmap.SetPixel(item.X, item.Y, Color.Red);
            }
            pic_map.Image = newBitmap;
        }

        private void pic_map_MouseMove(object sender, MouseEventArgs e)
        {
            lbl_point.Text = $"X:{e.X} Y:{e.Y}";
        }
        /// <summary>
        /// 重绘地图
        /// </summary>

        private void pic_map_MouseClick(object sender, MouseEventArgs e)
        {
            lbl_info.Text = "";

            if(readMap.Maze[e.X,e.Y]==0)
            {
                MessageBox.Show("This point is a bar!");
                return;
            }
            if (points.Count == 2)
            {
                lbl_start.Text = lbl_end.Text = "--";
                points.Clear();
                pic_map.Image = (Bitmap)readMap.clippingZone.Clone();
            }

            points.Add(new Point(e.X, e.Y));

            var start = points[0];
            lbl_start.Text = $"X:{start.X} Y:{start.Y}";

            if (points.Count == 2)
            {
                var end = points[1];
                lbl_end.Text = $"X:{end.X} Y:{end.Y}";
            }

            var bitmap = (Bitmap)readMap.clippingZone.Clone();

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (var item in points)
                {
                    //大小，椭圆的还是半圆的还是月饼自己写参数
                    Rectangle r = new Rectangle(item.X, item.Y, 6, 6);
                    using (LinearGradientBrush br = new LinearGradientBrush(r, Color.Red, Color.Red, LinearGradientMode.Vertical))
                    {
                        g.FillEllipse(br, r);
                    }
                }
            }
            
            pic_map.Image = bitmap;
        }

        private void btn_brower_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "Please select a file.";
            fileDialog.Filter = "All files(map)|*.map"; //设置要选择的文件的类型
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;//返回文件的完整路径     

                try
                {
                    readMap.mapFile = file;
                    readMap.Load();

                    lbl_fileName.Text = fileDialog.SafeFileName;
                    lbl_MapSize.Text = $"{readMap.Width} * {readMap.Height}";
                    //lbl_mapName.Text = readMap.MapTitle;
                    pic_map.Width = readMap.Width;
                    panel_map.Width = readMap.Width;
                    pic_map.Height = readMap.Height;
                    
                    pic_map.Image = (Bitmap)readMap.clippingZone.Clone();

                    var w = gb_mapinfo.Width + readMap.Width;
                    if (w < width)
                        w = width;
                    this.Width = w;
                    this.Height = readMap.Height < height ? height : (readMap.Height+40);

                    //this.Width = 999;
                    //this.Height = 999;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
