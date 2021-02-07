using Jm.Core.Mir2.Server.VisualMapInfo.Class;
using Jm.Core.Mir2.Server.VisualMapInfo.Class.AStart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        List<APoint> points = new List<APoint>();
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_findPath_Click(object sender, EventArgs e)
        {
            if (points.Count != 2)
            {
                MessageBox.Show("请选择开始、结束点位置!");
                return;
            }
            var start = points[0];
            var end = points[1];
            Stopwatch stopwatch = new Stopwatch();
            PathGrid pathGrid = new PathGrid(readMap.Width, readMap.Height, readMap.Maze);
            stopwatch.Start();
            var tempPoints = pathGrid.FindPath(start, end);
            stopwatch.Stop();
            if (tempPoints == null || tempPoints.Count == 0)
            {
                lbl_info.Text = "未找到路线！";
                return;
            }
            lbl_info.Text = $"耗时:{stopwatch.ElapsedMilliseconds}\r\n消耗:{tempPoints.Count}";

            Bitmap newBitmap = new Bitmap(readMap.clippingZone.Width, readMap.clippingZone.Height);
            if (CopyBitmap(readMap.clippingZone, newBitmap))
            {
                pic_map.Image = newBitmap;
            }
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
        private Bitmap reCopyMap()
        {
            Bitmap newBitmap = new Bitmap(readMap.Width, readMap.Height);
            CopyBitmap(readMap.clippingZone, newBitmap);
            return newBitmap;
        }
        private void pic_map_MouseClick(object sender, MouseEventArgs e)
        {
            lbl_info.Text = "";

            if(readMap.Maze[e.X,e.Y]==1)
            {
                MessageBox.Show("该位置为障碍物!");
                return;
            }
            if (points.Count == 2)
            {
                lbl_start.Text = lbl_end.Text = "--";
                points.Clear();
                pic_map.Image = reCopyMap();
            }

            points.Add(new APoint(e.X, e.Y));

            var start = points[0];
            lbl_start.Text = $"X:{start.X} Y:{start.Y}";

            if (points.Count == 2)
            {
                var end = points[1];
                lbl_end.Text = $"X:{end.X} Y:{end.Y}";
            }

            var bitmap = reCopyMap();
            foreach (var item in points)
            {
                bitmap.SetPixel(item.X, item.Y, Color.Red);
            }
            pic_map.Image = bitmap;

        }

        private void btn_brower_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(map)|*.map"; //设置要选择的文件的类型
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;//返回文件的完整路径     

                try
                {
                    readMap.mapFile = file;
                    readMap.Load();

                    lbl_fileName.Text = fileDialog.FileName;
                    lbl_MapSize.Text = $"{readMap.Width} * {readMap.Height}";
                    //lbl_mapName.Text = readMap.MapTitle;
                    pic_map.Width = readMap.Width;
                    panel_map.Width = readMap.Width;
                    pic_map.Height = readMap.Height;
                    
                    pic_map.Image = reCopyMap();

                    var w = gb_mapinfo.Width + readMap.Width;
                    if (w < width)
                        w = width;
                    this.Width = w;
                    this.Height = readMap.Height < height ? height : readMap.Height;

                    //this.Width = 999;
                    //this.Height = 999;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public bool CopyBitmap(Bitmap source, Bitmap destination)
        {
            if ((source.Width != destination.Width) || (source.Height != destination.Height) || (source.PixelFormat != destination.PixelFormat))
            {
                return false;
            }

            int bitdepth_per_pixel = Bitmap.GetPixelFormatSize(source.PixelFormat) / 8;

            if (bitdepth_per_pixel != 1 && bitdepth_per_pixel != 3 && bitdepth_per_pixel != 4)
            {
                return false;
            }

            BitmapData source_bitmapdata = null;
            BitmapData destination_bitmapdata = null;

            try
            {
                source_bitmapdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite,
                                                source.PixelFormat);
                destination_bitmapdata = destination.LockBits(new Rectangle(0, 0, destination.Width, destination.Height), ImageLockMode.ReadWrite,
                                                destination.PixelFormat);

                int source_bitmapdata_bitdepth_width = source_bitmapdata.Width * bitdepth_per_pixel;
                int source_bitmapdata_height = source_bitmapdata.Height;
                int source_bitmapdata_bitdepth_stride = source_bitmapdata.Stride;

                unsafe
                {
                    byte* source_ptr = (byte*)source_bitmapdata.Scan0;
                    byte* destination_ptr = (byte*)destination_bitmapdata.Scan0;

                    int offset = source_bitmapdata_bitdepth_stride - source_bitmapdata_bitdepth_width;

                    for (int i = 0; i < source_bitmapdata_height; i++)
                    {
                        for (int j = 0; j < source_bitmapdata_bitdepth_width; j++, source_ptr++, destination_ptr++)
                        {
                            *destination_ptr = *source_ptr;
                        }

                        source_ptr += offset;
                        destination_ptr += offset;
                    }
                }

                source.UnlockBits(source_bitmapdata);
                destination.UnlockBits(destination_bitmapdata);

                return true;
            }
            catch { return false; }
        }
    }
}
