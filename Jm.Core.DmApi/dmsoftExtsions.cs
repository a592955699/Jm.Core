using Jm.Core.DmApi.Models;
using Jm.Core.DmApi.Args;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Jm.Core.DmApi
{
    /// <summary>
    /// 大漠插件扩展类
    /// 处理根据配置获取到的配置对象，直接调用。
    /// 不需要再每次按大漠插件规定的格式再传递参数
    /// </summary>
    public static class dmsoftExtsions
    {
        #region 基本设置
        /// <summary>
        /// 调用此函数来注册，从而使用插件的高级功能.推荐使用此函数.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="reg"></param>
        /// <returns></returns>
        public static int Reg(this dmsoft dmsoft, Reg reg)
        {
            //#TODO 免注册 dm.dll 相关逻辑代码

            dmsoft.SetPath(reg.WorkPath);
            return dmsoft.Reg(reg.RegCode, reg.VerInfo);
        }
        #endregion

        #region 后台设置
        /// <summary>
        /// 绑定指定的窗口,并指定这个窗口的屏幕颜色获取方式,鼠标仿真模式,键盘仿真模式,以及模式设定,高级用户可以参考BindWindowEx更加灵活强大
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="bindWindow"></param>
        /// <returns>如果返回false，可以调用GetLastError来查看具体失败错误码,帮助分析问题.</returns>
        public static bool BindWindow(this dmsoft dmsoft, int hwnd, BindWindow bindWindow)
        {
            return dmsoft.BindWindow(hwnd, bindWindow.Display, bindWindow.Mouse, bindWindow.Keypad, bindWindow.Mode) == 1;
        }
        /// <summary>
        /// 绑定指定的窗口,并指定这个窗口的屏幕颜色获取方式,鼠标仿真模式,键盘仿真模式 高级用户使用.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="hwnd"></param>
        /// <param name="bindWindow"></param>
        /// <returns></returns>
        public static bool BindWindowEx(this dmsoft dmsoft, int hwnd, BindWindowEx bindWindow)
        {
            return dmsoft.BindWindowEx(hwnd, bindWindow.Display, bindWindow.Mouse, bindWindow.Keypad, bindWindow.Public, bindWindow.Mode) == 1;
        }
        #endregion

        #region 图色
        /// <summary>
        /// 抓取指定区域(x1, y1, x2, y2)的图像,保存为file(24位位图)
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="capture"></param>
        /// <returns></returns>
        public static bool Capture(this dmsoft dmsoft, Capture capture)
        {
            return dmsoft.Capture(capture.X1, capture.Y1, capture.X2, capture.Y2, capture.File) == 1;
        }
        /// <summary>
        /// 抓取指定区域(x1, y1, x2, y2)的动画，保存为gif格式
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="capture"></param>
        /// <returns></returns>
        public static bool CaptureGif(this dmsoft dmsoft, CaptureGif capture)
        {
            return dmsoft.CaptureGif(capture.X1, capture.Y1, capture.X2, capture.Y2, capture.File, capture.Delay, capture.Time) == 1;
        }
        /// <summary>
        /// 抓取指定区域(x1, y1, x2, y2)的图像,保存为file(JPG压缩格式)
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="capture"></param>
        /// <returns></returns>
        public static bool CaptureJpg(this dmsoft dmsoft, CaptureJpg capture)
        {
            return dmsoft.CaptureJpg(capture.X1, capture.Y1, capture.X2, capture.Y2, capture.File, capture.Quality) == 1;
        }
        /// <summary>
        /// 同Capture函数，只是保存的格式为PNG.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="capture"></param>
        /// <returns></returns>
        public static bool CapturePng(this dmsoft dmsoft, Capture capture)
        {
            return dmsoft.CapturePng(capture.X1, capture.Y1, capture.X2, capture.Y2, capture.File) == 1;
        }
        /// <summary>
        /// 查找指定区域内的颜色,颜色格式"RRGGBB-DRDGDB",注意,和按键的颜色格式相反
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findColor"></param>
        /// <returns></returns>
        public static Point FindColor(this dmsoft dmsoft, FindColor findColor)
        {
            int x, y;
            int ret = dmsoft.FindColor(findColor.X1, findColor.Y1, findColor.X2, findColor.Y2, findColor.Color, findColor.Sim, findColor.Dir, out x, out y);
            if (ret == 0)
            {
                return new Point();
            }
            else
            {
                return new Point(x, y);
            }
        }
        /// <summary>
        /// 查找指定区域内的颜色块,颜色格式"RRGGBB-DRDGDB",注意,和按键的颜色格式相反
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findColor"></param>
        /// <returns>指向颜色块的左上角</returns>
        public static Point FindColorBlock(this dmsoft dmsoft, FindColorBlock findColor)
        {
            int x, y;
            int ret = dmsoft.FindColorBlock(findColor.X1, findColor.Y1, findColor.X2, findColor.Y2, findColor.Color, findColor.Sim, findColor.Count, findColor.Width, findColor.Height, out x, out y);
            if (ret == 0)
            {
                return new Point();
            }
            else
            {
                return new Point(x, y);
            }
        }
        /// <summary>
        /// 查找指定区域内的所有颜色块,颜色格式"RRGGBB-DRDGDB",注意,和按键的颜色格式相反
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findColor"></param>
        /// <returns>查找指定区域内的所有颜色块,颜色格式"RRGGBB-DRDGDB",注意,和按键的颜色格式相反</returns>
        public static List<Point> FindColorBlockEx(this dmsoft dmsoft, FindColorBlock findColor)
        {
            int x, y;
            List<Point> points = new List<Point>();
            string s = dmsoft.FindColorBlockEx(findColor.X1, findColor.Y1, findColor.X2, findColor.Y2, findColor.Color, findColor.Sim, findColor.Count, findColor.Width, findColor.Height);

            var index = 0;
            var count = dmsoft.GetResultCount(s);
            while (index < count)
            {
                dmsoft.GetResultPos(s, index++, out x, out y);
                points.Add(new Point(x, y));
            }
            return points;
        }
        /// <summary>
        /// 查找指定区域内的颜色,颜色格式"RRGGBB-DRDGDB",注意,和按键的颜色格式相反
        /// 易语言用不了FindColor可以用此接口来代替
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findColor"></param>
        /// <returns></returns>
        [Obsolete]
        public static Point FindColorE(this dmsoft dmsoft, FindColorE findColor)
        {
            Point point = new Point();
            string pos = dmsoft.FindColorE(findColor.X1, findColor.Y1, findColor.X2, findColor.Y2, findColor.Color, findColor.Sim, findColor.Dir);
            if (!string.IsNullOrWhiteSpace(pos))
            {
                var arr = pos.Split('|');
                point.X = int.Parse(arr[0]);
                point.Y = int.Parse(arr[1]);
            }
            return point;
        }
        /// <summary>
        /// 查找指定区域内的所有颜色,颜色格式"RRGGBB-DRDGDB",注意,和按键的颜色格式相反
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findColor"></param>
        /// <returns></returns>
        public static List<Point> FindColorEx(this dmsoft dmsoft, FindColorEx findColor)
        {
            List<Point> points = new List<Point>();
            string s = dmsoft.FindColorEx(findColor.X1, findColor.Y1, findColor.X2, findColor.Y2, findColor.Color, findColor.Sim, findColor.Dir);
            int x, y;
            int index = 0;
            int count = dmsoft.GetResultCount(s);
            while (index < count)
            {
                dmsoft.GetResultPos(s, index++, out x, out y);
                points.Add(new Point(x, y));
            }
            return points;
        }
        /// <summary>
        /// 查找指定区域内的所有颜色
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findColor"></param>
        /// <returns></returns>
        public static bool FindMultiColor(this dmsoft dmsoft, FindMulColor findColor)
        {
            return dmsoft.FindMulColor(findColor.X1, findColor.Y1, findColor.X2, findColor.Y2, findColor.Color, findColor.Sim) == 1;
        }
        /// <summary>
        /// 根据指定的多点查找颜色坐标
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findColor"></param>
        /// <returns></returns>
        public static Point FindMultiColor(this dmsoft dmsoft, FindMultiColor findColor)
        {
            int x, y;
            var res = dmsoft.FindMultiColor(findColor.X1, findColor.Y1, findColor.X2, findColor.Y2, findColor.FirstColor, findColor.OffsetColor, findColor.Sim, findColor.Dir, out x, out y);
            if (res == 1)
                return new Point(x, y);
            else
                return new Point();
        }
        /// <summary>
        /// 根据指定的多点查找颜色坐标
        /// 易语言用不了FindMultiColor可以用此接口来代替
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findColor"></param>
        /// <returns></returns>
        [Obsolete]
        public static Point FindMultiColorE(this dmsoft dmsoft, FindMultiColorE findColor)
        {
            var pos = dmsoft.FindMultiColorE(findColor.X1, findColor.Y1, findColor.X2, findColor.Y2, findColor.FirstColor, findColor.OffsetColor, findColor.Sim, findColor.Dir);
            if (string.IsNullOrWhiteSpace(pos))
            {
                var arr = pos.Split('|');
                return new Point(int.Parse(arr[0]), int.Parse(arr[1]));
            }
            else
            {
                return new Point();
            }
        }
        /// <summary>
        /// 根据指定的多点查找所有颜色坐标
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findColor"></param>
        /// <returns>返回所有颜色信息的坐标值,然后通过GetResultCount等接口来解析(由于内存限制,返回的坐标数量最多为1800个左右)</returns>
        public static List<Point> FindMultiColorEx(this dmsoft dmsoft, FindMultiColorEx findColor)
        {
            List<Point> points = new List<Point>();
            string s = dmsoft.FindMultiColorEx(findColor.X1, findColor.Y1, findColor.X2, findColor.Y2, findColor.FirstColor, findColor.OffsetColor, findColor.Sim, findColor.Dir);
            int x, y;
            int index = 0;
            int count = dmsoft.GetResultCount(s);
            while (index < count)
            {
                dmsoft.GetResultPos(s, index++, out x, out y);
                points.Add(new Point(x, y));
            }
            return points;
        }
        /// <summary>
        /// 查找指定区域内的图片,位图必须是24位色格式,支持透明色,当图像上下左右4个顶点的颜色一样时,则这个颜色将作为透明色处理
        /// 这个函数可以查找多个图片,只返回第一个找到的X Y坐标
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findPic"></param>
        /// <returns></returns>
        public static Point FindPic(this dmsoft dmsoft, FindPic findPic)
        {
            int x, y;
            var res = dmsoft.FindPic(findPic.X1, findPic.Y1, findPic.X2, findPic.Y2, findPic.PicName, findPic.DeltaColor, findPic.Sim, findPic.Dir, out x, out y);
            if (res != -1)
                return new Point(x, y);
            else
                return new Point();
        }
        /// <summary>
        /// 查找指定区域内的图片,位图必须是24位色格式,支持透明色,当图像上下左右4个顶点的颜色一样时,则这个颜色将作为透明色处理.
        /// 这个函数可以查找多个图片,只返回第一个找到的X Y坐标.
        /// 易语言用不了FindPic可以用此接口来代替
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findPic"></param>
        /// <returns></returns>
        [Obsolete]
        public static Point FindPicE(this dmsoft dmsoft, FindPicE findPic)
        {
            var res = dmsoft.FindPicE(findPic.X1, findPic.Y1, findPic.X2, findPic.Y2, findPic.PicName, findPic.DeltaColor, findPic.Sim, findPic.Dir);
            if (string.IsNullOrWhiteSpace(res))
            {
                var arr = res.Split('|');
                return new Point(int.Parse(arr[0]), int.Parse(arr[1]));
            }
            else
                return new Point();
        }
        /// <summary>
        /// 查找指定区域内的图片,位图必须是24位色格式,支持透明色,当图像上下左右4个顶点的颜色一样时,则这个颜色将作为透明色处理.
        /// 这个函数可以查找多个图片,并且返回所有找到的图像的坐标.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findColor"></param>
        /// <returns>(由于内存限制,返回的图片数量最多为1500个左右)</returns>
        public static List<Point> FindPicEx(this dmsoft dmsoft, FindPicEx findColor)
        {
            List<Point> points = new List<Point>();
            string s = dmsoft.FindPicEx(findColor.X1, findColor.Y1, findColor.X2, findColor.Y2, findColor.PicName, findColor.DeltaColor, findColor.Sim, findColor.Dir);
            int x, y;
            int index = 0;
            int count = dmsoft.GetResultCount(s);
            while (index < count)
            {
                dmsoft.GetResultPos(s, index++, out x, out y);
                points.Add(new Point(x, y));
            }
            return points;
        }
        /// <summary>
        /// 查找指定区域内的图片,位图必须是24位色格式,支持透明色,当图像上下左右4个顶点的颜色一样时,则这个颜色将作为透明色处理.
        /// 这个函数可以查找多个图片,并且返回所有找到的图像的坐标.此函数同FindPicEx.只是返回值不同.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findColor"></param>
        /// <returns>(由于内存限制,返回的图片数量最多为1500个左右)</returns>
        public static List<Point> FindPicExS(this dmsoft dmsoft, FindPicExS findColor)
        {
            List<Point> points = new List<Point>();
            string s = dmsoft.FindPicExS(findColor.X1, findColor.Y1, findColor.X2, findColor.Y2, findColor.PicName, findColor.DeltaColor, findColor.Sim, findColor.Dir);
            int x, y;
            int index = 0;
            int count = dmsoft.GetResultCount(s);
            while (index < count)
            {
                dmsoft.GetResultPos(s, index++, out x, out y);
                points.Add(new Point(x, y));
            }
            return points;
        }
        /// <summary>
        /// 查找指定区域内的图片,位图必须是24位色格式,支持透明色,当图像上下左右4个顶点的颜色一样时,则这个颜色将作为透明色处理.
        /// 这个函数可以查找多个图片,只返回第一个找到的X Y坐标.这个函数要求图片是数据地址.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findPic"></param>
        /// <returns></returns>
        public static Point FindPicMem(this dmsoft dmsoft, FindPicMem findPic)
        {
            int x, y;
            var res = dmsoft.FindPicMem(findPic.X1, findPic.Y1, findPic.X2, findPic.Y2, findPic.PicInfo, findPic.DeltaColor, findPic.Sim, findPic.Dir, out x, out y);
            if (res != -1)
            {
                return new Point(x, y);
            }
            else
                return new Point();
        }
        /// <summary>
        /// 查找指定区域内的图片,位图必须是24位色格式,支持透明色,当图像上下左右4个顶点的颜色一样时,则这个颜色将作为透明色处理.
        /// 这个函数可以查找多个图片,只返回第一个找到的X Y坐标.这个函数要求图片是数据地址.
        /// 易语言用不了FindPicMem可以用此接口来代替
        /// 注 : 内存中的图片格式必须是24位色，并且不能加密.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findPic"></param>
        /// <returns></returns>
        [Obsolete]
        public static List<Point> FindPicMemE(this dmsoft dmsoft, FindPicMemE findPic)
        {
            List<Point> points = new List<Point>();
            var s = dmsoft.FindPicMemE(findPic.X1, findPic.Y1, findPic.X2, findPic.Y2, findPic.PicInfo, findPic.DeltaColor, findPic.Sim, findPic.Dir);
            int x, y;
            int index = 0;
            int count = dmsoft.GetResultCount(s);
            while (index < count)
            {
                dmsoft.GetResultPos(s, index++, out x, out y);
                points.Add(new Point(x, y));
            }
            return points;
        }
        /// <summary>
        /// 查找指定区域内的图片,位图必须是24位色格式,支持透明色,当图像上下左右4个顶点的颜色一样时,则这个颜色将作为透明色处理.
        /// 这个函数可以查找多个图片,并且返回所有找到的图像的坐标.这个函数要求图片是数据地址.
        /// (由于内存限制,返回的图片数量最多为1500个左右)
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findPic"></param>
        /// <returns></returns>
        public static List<Point> FindPicMemEx(this dmsoft dmsoft, FindPicMemEx findPic)
        {
            List<Point> points = new List<Point>();
            var s = dmsoft.FindPicMemEx(findPic.X1, findPic.Y1, findPic.X2, findPic.Y2, findPic.PicInfo, findPic.DeltaColor, findPic.Sim, findPic.Dir);
            string[] arr1;
            string[] arr2;
            if (!string.IsNullOrWhiteSpace(s))
            {
                arr1 = s.Split('|');
                foreach (var item in arr1)
                {
                    arr2 = item.Split(',');
                    points.Add(new Point(int.Parse(arr2[1]), int.Parse(arr2[2])));
                }
            }
            return points;
        }
        /// <summary>
        /// 查找指定区域内的图片,位图必须是24位色格式,支持透明色,当图像上下左右4个顶点的颜色一样时,则这个颜色将作为透明色处理.
        /// 这个函数可以查找多个图片,只返回第一个找到的X Y坐标.此函数同FindPic.只是返回值不同
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findPic"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static string FindPicS(this dmsoft dmsoft, FindPicS findPic, out Point point)
        {
            int x, y;
            var res = dmsoft.FindPicS(findPic.X1, findPic.Y1, findPic.X2, findPic.Y2, findPic.PicName, findPic.DeltaColor, findPic.Sim, findPic.Dir, out x, out y);
            point = new Point(x, y);
            return res;
        }
        /// <summary>
        /// 查找指定的形状. 形状的描述同按键的抓抓. 具体可以参考按键的抓抓. 
        /// 和按键的语法不同，需要用大漠综合工具的颜色转换.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findPic"></param>
        /// <returns></returns>
        public static Point FindShape(this dmsoft dmsoft, FindShape findPic)
        {
            int x, y;
            var res = dmsoft.FindShape(findPic.X1, findPic.Y1, findPic.X2, findPic.Y2, findPic.OffsetColor, findPic.Sim, findPic.Dir, out x, out y);
            if (res == 1)
            {
                return new Point(x, y);
            }
            else
                return new Point();
        }
        /// <summary>
        /// 查找指定的形状. 形状的描述同按键的抓抓. 具体可以参考按键的抓抓. 
        /// 和按键的语法不同，需要用大漠综合工具的颜色转换.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findPic"></param>
        /// <returns></returns>
        [Obsolete]
        public static Point FindShapeE(this dmsoft dmsoft, FindShapeE findPic)
        {
            var res = dmsoft.FindShapeE(findPic.X1, findPic.Y1, findPic.X2, findPic.Y2, findPic.OffsetColor, findPic.Sim, findPic.Dir);
            if (string.IsNullOrWhiteSpace(res))
            {
                return new Point();
            }
            else
            {
                var arr = res.Split('|');
                return new Point(int.Parse(arr[0]), int.Parse(arr[1]));
            }
        }
        /// <summary>
        /// 查找所有指定的形状的坐标. 形状的描述同按键的抓抓. 具体可以参考按键的抓抓. 
        /// 和按键的语法不同，需要用大漠综合工具的颜色转换
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findPic"></param>
        /// <returns>(由于内存限制,返回的坐标数量最多为1800个左右)</returns>
        public static List<Point> FindShapeEx(this dmsoft dmsoft, FindShapeEx findPic)
        {
            List<Point> points = new List<Point>();
            var res = dmsoft.FindShapeEx(findPic.X1, findPic.Y1, findPic.X2, findPic.Y2, findPic.OffsetColor, findPic.Sim, findPic.Dir);
            int x, y;
            int index = 0;
            int count = dmsoft.GetResultCount(res);
            while (index < count)
            {
                dmsoft.GetResultPos(res, index++, out x, out y);
                points.Add(new Point(x, y));
            }
            return points;
        }
        /// <summary>
        /// 获取范围(x1,y1,x2,y2)颜色的均值,返回格式"H.S.V"
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="getAveHSV"></param>
        /// <returns>颜色字符串</returns>
        public static string GetAveHSV(this dmsoft dmsoft, GetAveHSV getAveHSV)
        {
            return dmsoft.GetAveHSV(getAveHSV.X1, getAveHSV.Y1, getAveHSV.X2, getAveHSV.Y2);
        }
        /// <summary>
        /// 获取范围(x1,y1,x2,y2)颜色的均值,返回格式"RRGGBB"
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="getAveHSV"></param>
        /// <returns></returns>
        public static string GetAveRGB(this dmsoft dmsoft, GetAveHSV getAveHSV)
        {
            return dmsoft.GetAveRGB(getAveHSV.X1, getAveHSV.Y1, getAveHSV.X2, getAveHSV.Y2);
        }
        /// <summary>
        /// 获取指定区域的颜色数量,颜色格式"RRGGBB-DRDGDB",注意,和按键的颜色格式相反
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="getColorNum"></param>
        /// <returns></returns>
        public static int GetColorNum(this dmsoft dmsoft, GetColorNum getColorNum)
        {
            return dmsoft.GetColorNum(getColorNum.X1, getColorNum.Y1, getColorNum.X2, getColorNum.Y2, getColorNum.Color, getColorNum.Sim);
        }
        /// <summary>
        /// 获取指定区域的图像,用二进制数据的方式返回,（不适合按键使用）方便二次开发
        /// 注意,调用完此接口后，返回的数据指针在当前dm对象销毁时，或者再次调用GetScreenData时，会自动释放.
        /// 从2.1120版本之后，调用完此函数后，没必要再调用FreeScreenData了,插件会自动释放.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="getColorNum"></param>
        /// <returns>返回的是指定区域的二进制颜色数据地址,每个颜色是4个字节,表示方式为(00RRGGBB)</returns>
        public static int GetScreenData(this dmsoft dmsoft, GetScreenData getColorNum)
        {
            return dmsoft.GetScreenData(getColorNum.X1, getColorNum.Y1, getColorNum.X2, getColorNum.Y2);
        }
        /// <summary>
        /// 获取指定区域的图像,用24位位图的数据格式返回,方便二次开发.（或者可以配合SetDisplayInput的mem模式）
        /// 需要注意的是,调用此接口获取的数据指针保存在当前对象中,到下次调用此接口时,内部就会释放.
        /// 哪怕是转成字节集,这个地址也还是在此字节集中使用.如果您要此地址一直有效，那么您需要自己拷贝字节集到自己的字节集中.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="getColorNum"></param>
        /// <param name="data"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool GetScreenDataBmp(this dmsoft dmsoft, GetScreenDataBmp getColorNum, out int data, out int size)
        {
            return dmsoft.GetScreenDataBmp(getColorNum.X1, getColorNum.Y1, getColorNum.X2, getColorNum.Y2, out data, out size) == 1;
        }
        /// <summary>
        /// 判断指定的区域，在指定的时间内(秒),图像数据是否一直不变.(卡屏). (或者绑定的窗口不存在也返回1)
        /// 注:此函数的原理是不停的截取指定区域的图像，然后比较，如果改变就立刻返回0,否则等待直到指定的时间到达
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="getColorNum"></param>
        /// <returns></returns>
        public static bool IsDisplayDead(this dmsoft dmsoft, IsDisplayDead getColorNum)
        {
            return dmsoft.IsDisplayDead(getColorNum.X1, getColorNum.Y1, getColorNum.X2, getColorNum.Y2, getColorNum.Tiem) == 1;
        }
        #endregion

        #region 文字识别
        /// <summary>
        /// 在屏幕范围(x1,y1,x2,y2)内,查找string(可以是任意个字符串的组合),并返回符合color_format的坐标位置,相似度sim同Ocr接口描述.
        //  (多色, 差色查找类似于Ocr接口, 不再重述)
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        public static Point FindStr(this dmsoft dmsoft, FindStr findStr)
        {
            int x, y;
            var res = dmsoft.FindStr(findStr.X1, findStr.Y1, findStr.X2, findStr.Y2, findStr.String, findStr.ColorFormat, findStr.Sim, out x, out y);
            if (res == -1)
                return new Point();
            else
                return new Point(x, y);
        }
        /// <summary>
        /// 在屏幕范围(x1,y1,x2,y2)内,查找string(可以是任意个字符串的组合),并返回符合color_format的坐标位置,相似度sim同Ocr接口描述.
        /// (多色, 差色查找类似于Ocr接口, 不再重述)
        /// 易语言用不了FindStr可以用此接口来代替
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        [Obsolete]
        public static Point FindStrE(this dmsoft dmsoft, FindStrE findStr)
        {
            int x, y;
            var pos = dmsoft.FindStrE(findStr.X1, findStr.Y1, findStr.X2, findStr.Y2, findStr.String, findStr.ColorFormat, findStr.Sim);
            if (string.IsNullOrWhiteSpace(pos))
                return new Point();
            else
            {
                var res = dmsoft.GetResultPos(pos, 0, out x, out y);
                if (res == 1)
                    return new Point(x, y);
                else
                    return new Point();
            }
        }
        /// <summary>
        /// 在屏幕范围(x1,y1,x2,y2)内,查找string(可以是任意字符串的组合),并返回符合color_format的所有坐标位置,相似度sim同Ocr接口描述
        /// (多色,差色查找类似于Ocr接口,不再重述)
        /// 注: 此函数的原理是先Ocr识别，然后再查找。所以速度比FindStrExFast要慢，尤其是在字库
        /// 很大，或者模糊度不为1.0时。
        /// 一般字库字符数量小于100左右，模糊度为1.0时，用FindStrEx要快一些,否则用FindStrFastEx.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        public static List<Point> FindStrEx(this dmsoft dmsoft, FindStrEx findStr)
        {
            List<Point> points = new List<Point>();
           int x, y;
            var pos = dmsoft.FindStrEx(findStr.X1, findStr.Y1, findStr.X2, findStr.Y2, findStr.String, findStr.ColorFormat, findStr.Sim);
            if (string.IsNullOrWhiteSpace(pos))
                return points;
            else
            {
                string[] arr1;
                string[] arr2;
                arr1 = pos.Split('|');
                foreach (var item in arr1)
                {
                    arr2 = item.Split(',');
                    points.Add(new Point(int.Parse(arr2[1]), int.Parse(arr2[2])));
                }
                return points;
            }
        }
        /// <summary>
        /// 在屏幕范围(x1,y1,x2,y2)内,查找string(可以是任意字符串的组合),并返回符合color_format的所有坐标位置,相似度sim同Ocr接口描述
        /// (多色,差色查找类似于Ocr接口,不再重述). 此函数同FindStrEx,只是返回值不同
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        public static List<StrPoint> FindStrExS(this dmsoft dmsoft, FindStrExS findStr)
        {
            List<StrPoint> points = new List<StrPoint>();
            int x, y;
            var pos = dmsoft.FindStrExS(findStr.X1, findStr.Y1, findStr.X2, findStr.Y2, findStr.String, findStr.ColorFormat, findStr.Sim);
            if (string.IsNullOrWhiteSpace(pos))
                return points;
            else
            {
                string[] arr1;
                string[] arr2;
                arr1 = pos.Split('|');
                foreach (var item in arr1)
                {
                    arr2 = item.Split(',');
                    points.Add(new StrPoint(arr2[0], int.Parse(arr2[1]), int.Parse(arr2[2])));
                }
                return points;
            }
        }
        /// <summary>
        /// 在屏幕范围(x1,y1,x2,y2)内,查找string(可以是任意个字符串的组合),并返回符合color_format的坐标位置,相似度sim同Ocr接口描述.
        /// (多色, 差色查找类似于Ocr接口, 不再重述)
        /// 
        /// 注: 此函数比FindStr要快很多，尤其是在字库很大时，或者模糊识别时，效果非常明显。
        /// 推荐使用此函数。
        /// 另外由于此函数是只识别待查找的字符，所以可能会有如下情况出现问题。
        /// 
        /// 比如 字库中有"张和三" 一共3个字符数据，然后待识别区域里是"张和三",如果用FindStr查找
        /// "张三"肯定是找不到的，但是用FindStrFast却可以找到，因为"和"这个字符没有列入查找计划中
        /// 所以，在使用此函数时，也要特别注意这一点。
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        public static Point FindStrFast(this dmsoft dmsoft, FindStrFast findStr)
        {
            int x, y;
            var res = dmsoft.FindStrFast(findStr.X1, findStr.Y1, findStr.X2, findStr.Y2, findStr.String, findStr.ColorFormat, findStr.Sim, out x, out y);
            if (res == -1)
                return new Point();
            else
                return new Point(x, y);
        }
        /// <summary>
        /// 在屏幕范围(x1,y1,x2,y2)内,查找string(可以是任意个字符串的组合),并返回符合color_format的坐标位置,相似度sim同Ocr接口描述.
        /// (多色, 差色查找类似于Ocr接口, 不再重述)
        /// 易语言用不了FindStrFast可以用此接口来代替
        /// 
        /// 注: 此函数比FindStrE要快很多，尤其是在字库很大时，或者模糊识别时，效果非常明显。
        /// 推荐使用此函数。
        /// 
        /// 另外由于此函数是只识别待查找的字符，所以可能会有如下情况出现问题。
        /// 
        /// 比如 字库中有"张和三" 一共3个字符数据，然后待识别区域里是"张和三",如果用FindStrE查找
        /// "张三"肯定是找不到的，但是用FindStrFastE却可以找到，因为"和"这个字符没有列入查找计划中
        /// 所以，在使用此函数时，也要特别注意这一点。
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        [Obsolete]
        public static Point FindStrFastE(this dmsoft dmsoft, FindStrFastE findStr)
        {
            var res = dmsoft.FindStrFastE(findStr.X1, findStr.Y1, findStr.X2, findStr.Y2, findStr.String, findStr.ColorFormat, findStr.Sim);
            if (string.IsNullOrWhiteSpace(res))
                return new Point();
            else
            {
                var arr =  res.Split('|');
                return new Point(int.Parse(arr[1]), int.Parse(arr[2]));
            }
        }
        /// <summary>
        /// 在屏幕范围(x1,y1,x2,y2)内,查找string(可以是任意个字符串的组合),并返回符合color_format的坐标位置,相似度sim同Ocr接口描述.
        /// (多色, 差色查找类似于Ocr接口, 不再重述)
        /// 易语言用不了FindStrFast可以用此接口来代替
        /// 
        /// 注: 此函数比FindStrEx要快很多，尤其是在字库很大时，或者模糊识别时，效果非常明显。
        /// 推荐使用此函数。
        /// 
        /// 另外由于此函数是只识别待查找的字符，所以可能会有如下情况出现问题。
        /// 
        /// 比如 字库中有"张和三" 一共3个字符数据，然后待识别区域里是"张和三",如果用FindStrEx查找
        /// "张三"肯定是找不到的，但是用FindStrFastEx却可以找到，因为"和"这个字符没有列入查找计划中
        /// 所以，在使用此函数时，也要特别注意这一点。
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        public static List<Point> FindStrFastEx(this dmsoft dmsoft, FindStrFastEx findStr)
        {
            List<Point> points = new List<Point>();
            var res = dmsoft.FindStrFastEx(findStr.X1, findStr.Y1, findStr.X2, findStr.Y2, findStr.String, findStr.ColorFormat, findStr.Sim);
            if (string.IsNullOrWhiteSpace(res))
                return points;
            else
            {
                string[] arr1= res.Split('|');
                string[] arr2;
                foreach (var item in arr1)
                {
                    arr2 = item.Split(',');
                    points.Add(new Point(int.Parse(arr2[1]), int.Parse(arr2[2])));
                }
                return points;
            }
        }
        /// <summary>
        /// 在屏幕范围(x1,y1,x2,y2)内,查找string(可以是任意个字符串的组合),并返回符合color_format的坐标位置,相似度sim同Ocr接口描述.
        /// (多色, 差色查找类似于Ocr接口, 不再重述)
        /// 易语言用不了FindStrFast可以用此接口来代替
        /// 
        /// 注: 此函数比FindStrExS要快很多，尤其是在字库很大时，或者模糊识别时，效果非常明显。
        /// 推荐使用此函数。
        /// 
        /// 另外由于此函数是只识别待查找的字符，所以可能会有如下情况出现问题。
        /// 
        /// 比如 字库中有"张和三" 一共3个字符数据，然后待识别区域里是"张和三",如果用FindStrExS查找
        /// "张三"肯定是找不到的，但是用FindStrFastExS却可以找到，因为"和"这个字符没有列入查找计划中
        /// 所以，在使用此函数时，也要特别注意这一点。
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        public static List<StrPoint> FindStrFastExS(this dmsoft dmsoft, FindStrFastExS findStr)
        {
            List<StrPoint> points = new List<StrPoint>();
            var res = dmsoft.FindStrFastExS(findStr.X1, findStr.Y1, findStr.X2, findStr.Y2, findStr.String, findStr.ColorFormat, findStr.Sim);
            if (string.IsNullOrWhiteSpace(res))
                return points;
            else
            {
                string[] arr1 = res.Split('|');
                string[] arr2;
                foreach (var item in arr1)
                {
                    arr2 = item.Split(',');
                    points.Add(new StrPoint(arr2[0], int.Parse(arr2[1]), int.Parse(arr2[2])));
                }
                return points;
            }
        }
        /// <summary>
        /// 在屏幕范围(x1,y1,x2,y2)内,查找string(可以是任意个字符串的组合),并返回符合color_format的坐标位置,相似度sim同Ocr接口描述.
        /// (多色, 差色查找类似于Ocr接口, 不再重述).此函数同FindStr,只是返回值不同.
        /// 
        /// 注: 此函数比FindStrS要快很多，尤其是在字库很大时，或者模糊识别时，效果非常明显。
        /// 推荐使用此函数。
        /// 另外由于此函数是只识别待查找的字符，所以可能会有如下情况出现问题。
        /// 
        /// 比如 字库中有"张和三" 一共3个字符数据，然后待识别区域里是"张和三",如果用FindStrS查找
        /// "张三"肯定是找不到的，但是用FindStrFastS却可以找到，因为"和"这个字符没有列入查找计划中
        /// 所以，在使用此函数时，也要特别注意这一点。
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        public static StrPoint FindStrFastS(this dmsoft dmsoft, FindStrFastS findStr)
        {
            int x, y;
            var str = dmsoft.FindStrFastS(findStr.X1, findStr.Y1, findStr.X2, findStr.Y2, findStr.String, findStr.ColorFormat, findStr.Sim, out x, out y);
            if (string.IsNullOrWhiteSpace(str))
            {
                return new StrPoint();
            }
            else
            {
                return new StrPoint(str, x, y);
            }
        }
        /// <summary>
        /// 在屏幕范围(x1,y1,x2,y2)内,查找string(可以是任意个字符串的组合),并返回符合color_format的坐标位置,相似度sim同Ocr接口描述.
        /// (多色, 差色查找类似于Ocr接口, 不再重述).此函数同FindStr,只是返回值不同.
        /// 
        /// 注: 此函数的原理是先Ocr识别，然后再查找。所以速度比FindStrFastS要慢，尤其是在字库
        /// 很大，或者模糊度不为1.0时。
        /// 一般字库字符数量小于100左右，模糊度为1.0时，用FindStrS要快一些,否则用FindStrFastS.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        public static StrPoint FindStrS(this dmsoft dmsoft, FindStrS findStr)
        {
            int x, y;
            var str = dmsoft.FindStrFastS(findStr.X1, findStr.Y1, findStr.X2, findStr.Y2, findStr.String, findStr.ColorFormat, findStr.Sim, out x, out y);
            if (string.IsNullOrWhiteSpace(str))
            {
                return new StrPoint();
            }
            else
            {
                return new StrPoint(str, x, y);
            }
        }
        /// <summary>
        /// 同FindStr，但是不使用SetDict设置的字库，而利用系统自带的字库，速度比FindStr稍慢.
        /// 
        /// 注: 对于如何获取字体尺寸以及名字等信息，可以参考视频教程，如何使用系统字库.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        public static StrPoint FindStrWithFont(this dmsoft dmsoft, FindStrWithFont findStr)
        {
            int x, y;
            int res = dmsoft.FindStrWithFont(findStr.X1, findStr.Y1, findStr.X2, findStr.Y2, findStr.String, findStr.ColorFormat, findStr.Sim, findStr.FontName, findStr.FontSize, findStr.Flag, out x, out y);
            if (res==-1)
            {
                return new StrPoint();
            }
            else
            {
                var str = findStr.String.Split('|')[res];
                return new StrPoint(str, x, y);
            }
        }
        /// <summary>
        /// 同FindStrE，但是不使用SetDict设置的字库，而利用系统自带的字库，速度比FindStrE稍慢
        /// 
        /// 注: 对于如何获取字体尺寸以及名字等信息，可以参考视频教程，如何使用系统字库.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        public static StrPoint FindStrWithFontE(this dmsoft dmsoft, FindStrWithFontE findStr)
        {
            var res = dmsoft.FindStrWithFontE(findStr.X1, findStr.Y1, findStr.X2, findStr.Y2, findStr.String, findStr.ColorFormat, findStr.Sim, findStr.FontName, findStr.FontSize, findStr.Flag);
            if (string.IsNullOrWhiteSpace(res))
            { 
                return new StrPoint();
            }
            else
            {
                var arr = res.Split('|');
                return new StrPoint(arr[0], int.Parse(arr[1]), int.Parse(arr[2]));
            }
        }
        /// <summary>
        /// 同FindStrEx，但是不使用SetDict设置的字库，而利用系统自带的字库，速度比FindStrEx稍慢
        /// 
        /// 注: 对于如何获取字体尺寸以及名字等信息，可以参考视频教程，如何使用系统字库
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        public static List<StrPoint> FindStrWithFontEx(this dmsoft dmsoft, FindStrWithFontEx findStr)
        {
            List<StrPoint> points = new List<StrPoint>();
           var res = dmsoft.FindStrWithFontEx(findStr.X1, findStr.Y1, findStr.X2, findStr.Y2, findStr.String, findStr.ColorFormat, findStr.Sim, findStr.FontName, findStr.FontSize, findStr.Flag);
            if (string.IsNullOrWhiteSpace(res))
            {
                return points;
            }
            else
            {
                var arr1 = res.Split('|');
                string[] arr2;
                foreach (var item in arr1)
                {
                    arr2 = item.Split(',');
                    points.Add(new StrPoint(arr2[0], int.Parse(arr2[1]), int.Parse(arr2[2])));
                }
                return points;
            }
        }
        /// <summary>
        /// 识别屏幕范围(x1,y1,x2,y2)内符合color_format的字符串,并且相似度为sim,sim取值范围(0.1-1.0),
        /// 这个值越大越精确,越大速度越快,越小速度越慢,请斟酌使用!
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="ocr"></param>
        /// <returns></returns>
        public static string Ocr(this dmsoft dmsoft, Ocr ocr)
        {
            return dmsoft.Ocr(ocr.X1, ocr.Y1, ocr.X2, ocr.Y2, ocr.ColorFormat, ocr.Sim);
        }
        /// <summary>
        /// 识别屏幕范围(x1,y1,x2,y2)内符合color_format的字符串,并且相似度为sim,sim取值范围(0.1-1.0),
        /// 这个值越大越精确,越大速度越快,越小速度越慢,请斟酌使用!
        /// 这个函数可以返回识别到的字符串，以及每个字符的坐标.
        /// 
        /// 注: OcrEx不再像Ocr一样,支持换行分割了.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="ocr"></param>
        /// <returns></returns>
        public static List<StrPoint> OcrEx(this dmsoft dmsoft, OcrEx ocr)
        {
            List<StrPoint> points = new List<StrPoint>();
            var pos = dmsoft.OcrEx(ocr.X1, ocr.Y1, ocr.X2, ocr.Y2, ocr.ColorFormat, ocr.Sim);
            if(!string.IsNullOrWhiteSpace(pos))
            {
                var arr = pos.Split('|');
                string[] arr2;
                foreach (var item in arr)
                {
                    arr2 = item.Split('$');
                    points.Add(new StrPoint(arr2[0],int.Parse(arr2[1]),int.Parse(arr2[2])));
                }
            }
            return points;
        }
        /// <summary>
        /// 识别屏幕范围(x1,y1,x2,y2)内符合color_format的字符串,并且相似度为sim,sim取值范围(0.1-1.0),
        /// 这个值越大越精确,越大速度越快,越小速度越慢,请斟酌使用!
        /// 这个函数可以返回识别到的字符串，以及每个字符的坐标.这个同OcrEx,另一种返回形式.
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="ocr"></param>
        /// <returns></returns>
        public static List<StrPoint> OcrExOne(this dmsoft dmsoft, OcrExOne ocr)
        {
            List<StrPoint> points = new List<StrPoint>();
            var pos = dmsoft.OcrExOne(ocr.X1, ocr.Y1, ocr.X2, ocr.Y2, ocr.ColorFormat, ocr.Sim);
            if (!string.IsNullOrWhiteSpace(pos))
            {
                var arr = pos.Split(',');
                string[] arr2;
                foreach (var item in arr)
                {
                    arr2 = item.Split('|');
                    points.Add(new StrPoint(arr2[0], int.Parse(arr2[1]), int.Parse(arr2[2])));
                }
            }
            return points;
        }
        /// <summary>
        /// 识别位图中区域(x1,y1,x2,y2)的文字
        /// </summary>
        /// <param name="dmsoft"></param>
        /// <param name="ocrInFile"></param>
        /// <returns></returns>
        public static string OcrInFile(this dmsoft dmsoft, OcrInFile ocrInFile)
        {
            return dmsoft.OcrInFile(ocrInFile.X1, ocrInFile.Y1, ocrInFile.X2, ocrInFile.Y2, ocrInFile.PicName, ocrInFile.ColorFormat, ocrInFile.Sim);
        }
        #endregion
    }
}
