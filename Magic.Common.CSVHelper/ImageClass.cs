using System;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Magic.Common.CSVHelper
{
    public class ImageClass
    {
        public ImageClass()
        { }

        #region 缩略图
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW":  //指定高宽缩放（可能变形）                
                    break;
                case "W":   //指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H":   //指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut": //指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion

        #region 图片水印
        /// <summary>
        /// 图片水印处理方法
        /// </summary>
        /// <param name="path">需要加载水印的图片路径（绝对路径）</param>
        /// <param name="waterpath">水印图片（绝对路径）</param>
        /// <param name="location">水印位置（传送正确的代码）</param>
        //public static string ImageWatermark(string path, string waterpath, string location)
        //{
        //    string kz_name = Path.GetExtension(path);
        //    if (kz_name == ".jpg" || kz_name == ".bmp" || kz_name == ".jpeg")
        //    {
        //        DateTime time = DateTime.Now;
        //        string filename = "" + time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + time.Hour.ToString() + time.Minute.ToString() + time.Second.ToString() + time.Millisecond.ToString();
        //        Image img = Bitmap.FromFile(path);
        //        Image waterimg = Image.FromFile(waterpath);
        //        Graphics g = Graphics.FromImage(img);
        //        ArrayList loca = GetLocation(location, img, waterimg);
        //        g.DrawImage(waterimg, new Rectangle(int.Parse(loca[0].ToString()), int.Parse(loca[1].ToString()), waterimg.Width, waterimg.Height));
        //        waterimg.Dispose();
        //        g.Dispose();
        //        string newpath = Path.GetDirectoryName(path) + filename + kz_name;
        //        img.Save(newpath);
        //        img.Dispose();
        //        File.Copy(newpath, path, true);
        //        if (File.Exists(newpath))
        //        {
        //            File.Delete(newpath);
        //        }
        //    }
        //    return path;
        //}

        /// <summary>
        /// 图片水印位置处理方法
        /// </summary>
        /// <param name="location">水印位置</param>
        /// <param name="img">需要添加水印的图片</param>
        /// <param name="waterimg">水印图片</param>
        private static ArrayList GetLocation(string location, Image img, Image waterimg)
        {
            ArrayList loca = new ArrayList();
            int x = 0;
            int y = 0;

            if (location == "LT")
            {
                x = 10;
                y = 10;
            }
            else if (location == "T")
            {
                x = img.Width / 2 - waterimg.Width / 2;
                y = img.Height - waterimg.Height;
            }
            else if (location == "RT")
            {
                x = img.Width - waterimg.Width;
                y = 10;
            }
            else if (location == "LC")
            {
                x = 10;
                y = img.Height / 2 - waterimg.Height / 2;
            }
            else if (location == "C")
            {
                x = img.Width / 2 - waterimg.Width / 2;
                y = img.Height / 2 - waterimg.Height / 2;
            }
            else if (location == "RC")
            {
                x = img.Width - waterimg.Width;
                y = img.Height / 2 - waterimg.Height / 2;
            }
            else if (location == "LB")
            {
                x = 10;
                y = img.Height - waterimg.Height;
            }
            else if (location == "B")
            {
                x = img.Width / 2 - waterimg.Width / 2;
                y = img.Height - waterimg.Height;
            }
            else
            {
                x = img.Width - waterimg.Width;
                y = img.Height - waterimg.Height;
            }
            loca.Add(x);
            loca.Add(y);
            return loca;
        }
        #endregion

        #region 文字水印
        /// <summary>
        /// 文字水印处理方法
        /// </summary>
        /// <param name="path">图片路径（绝对路径）</param>
        /// <param name="size">字体大小</param>
        /// <param name="letter">水印文字</param>
        /// <param name="color">颜色</param>
        /// <param name="location">水印位置</param>
        public static string LetterWatermark(string path, int size, string letter, Color color, string location)
        {
            #region

            string kz_name = Path.GetExtension(path);
            if (kz_name == ".jpg" || kz_name == ".bmp" || kz_name == ".jpeg")
            {
                DateTime time = DateTime.Now;
                string filename = "" + time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + time.Hour.ToString() + time.Minute.ToString() + time.Second.ToString() + time.Millisecond.ToString();
                Image img = Bitmap.FromFile(path);
                Graphics gs = Graphics.FromImage(img);
                ArrayList loca = GetLocation(location, img, size, letter.Length);
                Font font = new Font("宋体", size);
                Brush br = new SolidBrush(color);
                gs.DrawString(letter, font, br, float.Parse(loca[0].ToString()), float.Parse(loca[1].ToString()));
                gs.Dispose();
                string newpath = Path.GetDirectoryName(path) + filename + kz_name;
                img.Save(newpath);
                img.Dispose();
                File.Copy(newpath, path, true);
                if (File.Exists(newpath))
                {
                    File.Delete(newpath);
                }
            }
            return path;

            #endregion
        }

        /// <summary>
        /// 文字水印位置的方法
        /// </summary>
        /// <param name="location">位置代码</param>
        /// <param name="img">图片对象</param>
        /// <param name="width">宽(当水印类型为文字时,传过来的就是字体的大小)</param>
        /// <param name="height">高(当水印类型为文字时,传过来的就是字符的长度)</param>
        private static ArrayList GetLocation(string location, Image img, int width, int height)
        {
            #region

            ArrayList loca = new ArrayList();  //定义数组存储位置
            float x = 10;
            float y = 10;

            if (location == "LT")
            {
                loca.Add(x);
                loca.Add(y);
            }
            else if (location == "T")
            {
                x = img.Width / 2 - (width * height) / 2;
                loca.Add(x);
                loca.Add(y);
            }
            else if (location == "RT")
            {
                x = img.Width - width * height;
            }
            else if (location == "LC")
            {
                y = img.Height / 2;
            }
            else if (location == "C")
            {
                x = img.Width / 2 - (width * height) / 2;
                y = img.Height / 2;
            }
            else if (location == "RC")
            {
                x = img.Width - height;
                y = img.Height / 2;
            }
            else if (location == "LB")
            {
                y = img.Height - width - 5;
            }
            else if (location == "B")
            {
                x = img.Width / 2 - (width * height) / 2;
                y = img.Height - width - 5;
            }
            else
            {
                x = img.Width - width * height;
                y = img.Height - width - 5;
            }
            loca.Add(x);
            loca.Add(y);
            return loca;

            #endregion
        }
        #endregion

        #region 调整光暗
        /// <summary>
        /// 调整光暗
        /// </summary>
        /// <param name="mybm">原始图片</param>
        /// <param name="width">原始图片的长度</param>
        /// <param name="height">原始图片的高度</param>
        /// <param name="val">增加或减少的光暗值</param>
        public Bitmap LDPic(Bitmap mybm, int width, int height, int val)
        {
            Bitmap bm = new Bitmap(width, height);//初始化一个记录经过处理后的图片对象
            int x, y, resultR, resultG, resultB;//x、y是循环次数，后面三个是记录红绿蓝三个值的
            Color pixel;
            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前像素的值
                    resultR = pixel.R + val;//检查红色值会不会超出[0, 255]
                    resultG = pixel.G + val;//检查绿色值会不会超出[0, 255]
                    resultB = pixel.B + val;//检查蓝色值会不会超出[0, 255]
                    bm.SetPixel(x, y, Color.FromArgb(resultR, resultG, resultB));//绘图
                }
            }
            return bm;
        }
        #endregion

        #region 反色处理
        /// <summary>
        /// 反色处理
        /// </summary>
        /// <param name="mybm">原始图片</param>
        /// <param name="width">原始图片的长度</param>
        /// <param name="height">原始图片的高度</param>
        public Bitmap RePic(Bitmap mybm, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);//初始化一个记录处理后的图片的对象
            int x, y, resultR, resultG, resultB;
            Color pixel;
            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前坐标的像素值
                    resultR = 255 - pixel.R;//反红
                    resultG = 255 - pixel.G;//反绿
                    resultB = 255 - pixel.B;//反蓝
                    bm.SetPixel(x, y, Color.FromArgb(resultR, resultG, resultB));//绘图
                }
            }
            return bm;
        }
        #endregion

        #region 浮雕处理
        /// <summary>
        /// 浮雕处理
        /// </summary>
        /// <param name="oldBitmap">原始图片</param>
        /// <param name="Width">原始图片的长度</param>
        /// <param name="Height">原始图片的高度</param>
        public Bitmap FD(Bitmap oldBitmap, int Width, int Height)
        {
            Bitmap newBitmap = new Bitmap(Width, Height);
            Color color1, color2;
            for (int x = 0; x < Width - 1; x++)
            {
                for (int y = 0; y < Height - 1; y++)
                {
                    int r = 0, g = 0, b = 0;
                    color1 = oldBitmap.GetPixel(x, y);
                    color2 = oldBitmap.GetPixel(x + 1, y + 1);
                    r = Math.Abs(color1.R - color2.R + 128);
                    g = Math.Abs(color1.G - color2.G + 128);
                    b = Math.Abs(color1.B - color2.B + 128);
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;
                    newBitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return newBitmap;
        }
        #endregion

        #region 拉伸图片
        /// <summary>
        /// 拉伸图片
        /// </summary>
        /// <param name="bmp">原始图片</param>
        /// <param name="newW">新的宽度</param>
        /// <param name="newH">新的高度</param>
        public static Bitmap ResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap bap = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(bap);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bap.Width, bap.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return bap;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 滤色处理
        /// <summary>
        /// 滤色处理
        /// </summary>
        /// <param name="mybm">原始图片</param>
        /// <param name="width">原始图片的长度</param>
        /// <param name="height">原始图片的高度</param>
        public Bitmap FilPic(Bitmap mybm, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);//初始化一个记录滤色效果的图片对象
            int x, y;
            Color pixel;

            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前坐标的像素值
                    bm.SetPixel(x, y, Color.FromArgb(0, pixel.G, pixel.B));//绘图
                }
            }
            return bm;
        }
        #endregion

        #region 左右翻转
        /// <summary>
        /// 左右翻转
        /// </summary>
        /// <param name="mybm">原始图片</param>
        /// <param name="width">原始图片的长度</param>
        /// <param name="height">原始图片的高度</param>
        public Bitmap RevPicLR(Bitmap mybm, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);
            int x, y, z; //x,y是循环次数,z是用来记录像素点的x坐标的变化的
            Color pixel;
            for (y = height - 1; y >= 0; y--)
            {
                for (x = width - 1, z = 0; x >= 0; x--)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前像素的值
                    bm.SetPixel(z++, y, Color.FromArgb(pixel.R, pixel.G, pixel.B));//绘图
                }
            }
            return bm;
        }
        #endregion

        #region 上下翻转
        /// <summary>
        /// 上下翻转
        /// </summary>
        /// <param name="mybm">原始图片</param>
        /// <param name="width">原始图片的长度</param>
        /// <param name="height">原始图片的高度</param>
        public Bitmap RevPicUD(Bitmap mybm, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);
            int x, y, z;
            Color pixel;
            for (x = 0; x < width; x++)
            {
                for (y = height - 1, z = 0; y >= 0; y--)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前像素的值
                    bm.SetPixel(x, z++, Color.FromArgb(pixel.R, pixel.G, pixel.B));//绘图
                }
            }
            return bm;
        }
        #endregion

        #region 压缩图片
        /// <summary>
        /// 压缩到指定尺寸
        /// </summary>
        /// <param name="oldfile">原文件</param>
        /// <param name="newfile">新文件</param>
        public  bool Compress(Image oldfile, string localFilePath, int width, int height, int iquality)
        {
            try
            {
                System.Drawing.Image img = oldfile;
                System.Drawing.Imaging.ImageFormat thisFormat = img.RawFormat;
                Size newSize = new Size(width, height);
                Bitmap outBmp = new Bitmap(newSize.Width, newSize.Height);
                Graphics g = Graphics.FromImage(outBmp);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, new Rectangle(0, 0, newSize.Width, newSize.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                g.Dispose();
                EncoderParameters encoderParams = new EncoderParameters();
                long[] quality = new long[1];
                quality[0] = iquality;
                EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                encoderParams.Param[0] = encoderParam;
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICI = null;
                for (int x = 0; x < arrayICI.Length; x++)
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICI = arrayICI[x]; //设置JPEG编码
                        break;
                    }
                img.Dispose();
                if (jpegICI != null) outBmp.Save(localFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                outBmp.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 图片灰度化
        public Color Gray(Color c)
        {
            int rgb = Convert.ToInt32((double)(((0.3 * c.R) + (0.59 * c.G)) + (0.11 * c.B)));
            return Color.FromArgb(rgb, rgb, rgb);
        }
        #endregion

        #region 转换为黑白图片
        /// <summary>
        /// 转换为黑白图片
        /// </summary>
        /// <param name="mybt">要进行处理的图片</param>
        /// <param name="width">图片的长度</param>
        /// <param name="height">图片的高度</param>
        public Bitmap BWPic(Bitmap mybm, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);
            int x, y, result; //x,y是循环次数，result是记录处理后的像素值
            Color pixel;
            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前坐标的像素值
                    result = (pixel.R + pixel.G + pixel.B) / 3;//取红绿蓝三色的平均值
                    bm.SetPixel(x, y, Color.FromArgb(result, result, result));
                }
            }
            return bm;
        }
        #endregion

        #region 获取图片中的各帧
        /// <summary>
        /// 获取图片中的各帧
        /// </summary>
        /// <param name="pPath">图片路径</param>
        /// <param name="pSavePath">保存路径</param>
        public void GetFrames(string pPath, string pSavedPath)
        {
            Image gif = Image.FromFile(pPath);
            FrameDimension fd = new FrameDimension(gif.FrameDimensionsList[0]);
            int count = gif.GetFrameCount(fd); //获取帧数(gif图片可能包含多帧，其它格式图片一般仅一帧)
            for (int i = 0; i < count; i++)    //以Jpeg格式保存各帧
            {
                gif.SelectActiveFrame(fd, i);
                gif.Save(pSavedPath + "\\frame_" + i + ".jpg", ImageFormat.Jpeg);
            }
        }
        #endregion

        /// <summary>
        /// 图片处理
        /// http://www.cnblogs.com/wu-jian/
        /// 
        /// 吴剑 2011-02-20 创建
        /// 吴剑 2012-08-08 修改
        /// </summary>
        public class MyImage
        {
            #region 正方型裁剪并缩放

            /// <summary>
            /// 正方型裁剪
            /// 以图片中心为轴心，截取正方型，然后等比缩放
            /// 用于头像处理
            /// </summary>
            /// <remarks>吴剑 2012-08-08</remarks>
            /// <param name="fromFile">原图Stream对象</param>
            /// <param name="fileSaveUrl">缩略图存放地址</param>
            /// <param name="side">指定的边长（正方型）</param>
            /// <param name="quality">质量（范围0-100）</param>
            public static void CutForSquare(System.IO.Stream fromFile, string fileSaveUrl, int side, int quality)
            {
                //创建目录
                string dir = Path.GetDirectoryName(fileSaveUrl);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                //原始图片（获取原始图片创建对象，并使用流中嵌入的颜色管理信息）
                System.Drawing.Image initImage = System.Drawing.Image.FromStream(fromFile, true);

                //原图宽高均小于模版，不作处理，直接保存
                if (initImage.Width <= side && initImage.Height <= side)
                {
                    initImage.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    //原始图片的宽、高
                    int initWidth = initImage.Width;
                    int initHeight = initImage.Height;

                    //非正方型先裁剪为正方型
                    if (initWidth != initHeight)
                    {
                        //截图对象
                        System.Drawing.Image pickedImage = null;
                        System.Drawing.Graphics pickedG = null;

                        //宽大于高的横图
                        if (initWidth > initHeight)
                        {
                            //对象实例化
                            pickedImage = new System.Drawing.Bitmap(initHeight, initHeight);
                            pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                            //设置质量
                            pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            //定位
                            Rectangle fromR = new Rectangle((initWidth - initHeight) / 2, 0, initHeight, initHeight);
                            Rectangle toR = new Rectangle(0, 0, initHeight, initHeight);
                            //画图
                            pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                            //重置宽
                            initWidth = initHeight;
                        }
                        //高大于宽的竖图
                        else
                        {
                            //对象实例化
                            pickedImage = new System.Drawing.Bitmap(initWidth, initWidth);
                            pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                            //设置质量
                            pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            //定位
                            Rectangle fromR = new Rectangle(0, (initHeight - initWidth) / 2, initWidth, initWidth);
                            Rectangle toR = new Rectangle(0, 0, initWidth, initWidth);
                            //画图
                            pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                            //重置高
                            initHeight = initWidth;
                        }

                        //将截图对象赋给原图
                        initImage = (System.Drawing.Image)pickedImage.Clone();
                        //释放截图资源
                        pickedG.Dispose();
                        pickedImage.Dispose();
                    }

                    //缩略图对象
                    System.Drawing.Image resultImage = new System.Drawing.Bitmap(side, side);
                    System.Drawing.Graphics resultG = System.Drawing.Graphics.FromImage(resultImage);
                    //设置质量
                    resultG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    resultG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //用指定背景色清空画布
                    resultG.Clear(Color.White);
                    //绘制缩略图
                    resultG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, side, side), new System.Drawing.Rectangle(0, 0, initWidth, initHeight), System.Drawing.GraphicsUnit.Pixel);

                    //关键质量控制
                    //获取系统编码类型数组,包含了jpeg,bmp,png,gif,tiff
                    ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo ici = null;
                    foreach (ImageCodecInfo i in icis)
                    {
                        if (i.MimeType == "image/jpeg" || i.MimeType == "image/bmp" || i.MimeType == "image/png" || i.MimeType == "image/gif")
                        {
                            ici = i;
                        }
                    }
                    EncoderParameters ep = new EncoderParameters(1);
                    ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);

                    //保存缩略图
                    resultImage.Save(fileSaveUrl, ici, ep);

                    //释放关键质量控制所用资源
                    ep.Dispose();

                    //释放缩略图资源
                    resultG.Dispose();
                    resultImage.Dispose();

                    //释放原始图片资源
                    initImage.Dispose();
                }
            }

            #endregion

            #region 自定义裁剪并缩放

            /// <summary>
            /// 指定长宽裁剪
            /// 按模版比例最大范围的裁剪图片并缩放至模版尺寸
            /// </summary>
            /// <remarks>吴剑 2012-08-08</remarks>
            /// <param name="fromFile">原图Stream对象</param>
            /// <param name="fileSaveUrl">保存路径</param>
            /// <param name="maxWidth">最大宽(单位:px)</param>
            /// <param name="maxHeight">最大高(单位:px)</param>
            /// <param name="quality">质量（范围0-100）</param>
            public static void CutForCustom(System.IO.Stream fromFile, string fileSaveUrl, int maxWidth, int maxHeight, int quality)
            {
                //从文件获取原始图片，并使用流中嵌入的颜色管理信息
                System.Drawing.Image initImage = System.Drawing.Image.FromStream(fromFile, true);

                //原图宽高均小于模版，不作处理，直接保存
                if (initImage.Width <= maxWidth && initImage.Height <= maxHeight)
                {
                    initImage.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    //模版的宽高比例
                    double templateRate = (double)maxWidth / maxHeight;
                    //原图片的宽高比例
                    double initRate = (double)initImage.Width / initImage.Height;

                    //原图与模版比例相等，直接缩放
                    if (templateRate == initRate)
                    {
                        //按模版大小生成最终图片
                        System.Drawing.Image templateImage = new System.Drawing.Bitmap(maxWidth, maxHeight);
                        System.Drawing.Graphics templateG = System.Drawing.Graphics.FromImage(templateImage);
                        templateG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        templateG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        templateG.Clear(Color.White);
                        templateG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, maxWidth, maxHeight), new System.Drawing.Rectangle(0, 0, initImage.Width, initImage.Height), System.Drawing.GraphicsUnit.Pixel);
                        templateImage.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    //原图与模版比例不等，裁剪后缩放
                    else
                    {
                        //裁剪对象
                        System.Drawing.Image pickedImage = null;
                        System.Drawing.Graphics pickedG = null;
                        //定位
                        Rectangle fromR = new Rectangle(0, 0, 0, 0);//原图裁剪定位
                        Rectangle toR = new Rectangle(0, 0, 0, 0);//目标定位

                        //宽为标准进行裁剪
                        if (templateRate > initRate)
                        {
                            //裁剪对象实例化
                            pickedImage = new System.Drawing.Bitmap(initImage.Width, (int)System.Math.Floor(initImage.Width / templateRate));
                            pickedG = System.Drawing.Graphics.FromImage(pickedImage);

                            //裁剪源定位
                            fromR.X = 0;
                            fromR.Y = (int)System.Math.Floor((initImage.Height - initImage.Width / templateRate) / 2);
                            fromR.Width = initImage.Width;
                            fromR.Height = (int)System.Math.Floor(initImage.Width / templateRate);

                            //裁剪目标定位
                            toR.X = 0;
                            toR.Y = 0;
                            toR.Width = initImage.Width;
                            toR.Height = (int)System.Math.Floor(initImage.Width / templateRate);
                        }
                        //高为标准进行裁剪
                        else
                        {
                            pickedImage = new System.Drawing.Bitmap((int)System.Math.Floor(initImage.Height * templateRate), initImage.Height);
                            pickedG = System.Drawing.Graphics.FromImage(pickedImage);

                            fromR.X = (int)System.Math.Floor((initImage.Width - initImage.Height * templateRate) / 2);
                            fromR.Y = 0;
                            fromR.Width = (int)System.Math.Floor(initImage.Height * templateRate);
                            fromR.Height = initImage.Height;

                            toR.X = 0;
                            toR.Y = 0;
                            toR.Width = (int)System.Math.Floor(initImage.Height * templateRate);
                            toR.Height = initImage.Height;
                        }

                        //设置质量
                        pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                        //裁剪
                        pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);

                        //按模版大小生成最终图片
                        System.Drawing.Image templateImage = new System.Drawing.Bitmap(maxWidth, maxHeight);
                        System.Drawing.Graphics templateG = System.Drawing.Graphics.FromImage(templateImage);
                        templateG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        templateG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        templateG.Clear(Color.White);
                        templateG.DrawImage(pickedImage, new System.Drawing.Rectangle(0, 0, maxWidth, maxHeight), new System.Drawing.Rectangle(0, 0, pickedImage.Width, pickedImage.Height), System.Drawing.GraphicsUnit.Pixel);

                        //关键质量控制
                        //获取系统编码类型数组,包含了jpeg,bmp,png,gif,tiff
                        ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
                        ImageCodecInfo ici = null;
                        foreach (ImageCodecInfo i in icis)
                        {
                            if (i.MimeType == "image/jpeg" || i.MimeType == "image/bmp" || i.MimeType == "image/png" || i.MimeType == "image/gif")
                            {
                                ici = i;
                            }
                        }
                        EncoderParameters ep = new EncoderParameters(1);
                        ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);

                        //保存缩略图
                        templateImage.Save(fileSaveUrl, ici, ep);
                        //templateImage.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);

                        //释放资源
                        templateG.Dispose();
                        templateImage.Dispose();

                        pickedG.Dispose();
                        pickedImage.Dispose();
                    }
                }

                //释放资源
                initImage.Dispose();
            }
            #endregion

            #region 等比缩放

            /// <summary>
            /// 图片等比缩放
            /// </summary>
            /// <remarks>吴剑 2012-08-08</remarks>
            /// <param name="fromFile">原图Stream对象</param>
            /// <param name="savePath">缩略图存放地址</param>
            /// <param name="targetWidth">指定的最大宽度</param>
            /// <param name="targetHeight">指定的最大高度</param>
            /// <param name="watermarkText">水印文字(为""表示不使用水印)</param>
            /// <param name="watermarkImage">水印图片路径(为""表示不使用水印)</param>
            public static void ZoomAuto(System.IO.Stream fromFile, string savePath, System.Double targetWidth, System.Double targetHeight, string watermarkText, string watermarkImage)
            {
                //创建目录
                string dir = Path.GetDirectoryName(savePath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                //原始图片（获取原始图片创建对象，并使用流中嵌入的颜色管理信息）
                System.Drawing.Image initImage = System.Drawing.Image.FromStream(fromFile, true);

                //原图宽高均小于模版，不作处理，直接保存
                if (initImage.Width <= targetWidth && initImage.Height <= targetHeight)
                {
                    //文字水印
                    if (watermarkText != "")
                    {
                        using (System.Drawing.Graphics gWater = System.Drawing.Graphics.FromImage(initImage))
                        {
                            System.Drawing.Font fontWater = new Font("黑体", 10);
                            System.Drawing.Brush brushWater = new SolidBrush(Color.White);
                            gWater.DrawString(watermarkText, fontWater, brushWater, 10, 10);
                            gWater.Dispose();
                        }
                    }

                    //透明图片水印
                    if (watermarkImage != "")
                    {
                        if (File.Exists(watermarkImage))
                        {
                            //获取水印图片
                            using (System.Drawing.Image wrImage = System.Drawing.Image.FromFile(watermarkImage))
                            {
                                //水印绘制条件：原始图片宽高均大于或等于水印图片
                                if (initImage.Width >= wrImage.Width && initImage.Height >= wrImage.Height)
                                {
                                    Graphics gWater = Graphics.FromImage(initImage);

                                    //透明属性
                                    ImageAttributes imgAttributes = new ImageAttributes();
                                    ColorMap colorMap = new ColorMap();
                                    colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
                                    colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
                                    ColorMap[] remapTable = { colorMap };
                                    imgAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

                                    float[][] colorMatrixElements = { 
                                   new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  0.0f,  0.0f,  0.5f, 0.0f},//透明度:0.5
                                   new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                };

                                    ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);
                                    imgAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                                    gWater.DrawImage(wrImage, new Rectangle(initImage.Width - wrImage.Width, initImage.Height - wrImage.Height, wrImage.Width, wrImage.Height), 0, 0, wrImage.Width, wrImage.Height, GraphicsUnit.Pixel, imgAttributes);

                                    gWater.Dispose();
                                }
                                wrImage.Dispose();
                            }
                        }
                    }

                    //保存
                    initImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    //缩略图宽、高计算
                    double newWidth = initImage.Width;
                    double newHeight = initImage.Height;

                    //宽大于高或宽等于高（横图或正方）
                    if (initImage.Width > initImage.Height || initImage.Width == initImage.Height)
                    {
                        //如果宽大于模版
                        if (initImage.Width > targetWidth)
                        {
                            //宽按模版，高按比例缩放
                            newWidth = targetWidth;
                            newHeight = initImage.Height * (targetWidth / initImage.Width);
                        }
                    }
                    //高大于宽（竖图）
                    else
                    {
                        //如果高大于模版
                        if (initImage.Height > targetHeight)
                        {
                            //高按模版，宽按比例缩放
                            newHeight = targetHeight;
                            newWidth = initImage.Width * (targetHeight / initImage.Height);
                        }
                    }

                    //生成新图
                    //新建一个bmp图片
                    System.Drawing.Image newImage = new System.Drawing.Bitmap((int)newWidth, (int)newHeight);
                    //新建一个画板
                    System.Drawing.Graphics newG = System.Drawing.Graphics.FromImage(newImage);

                    //设置质量
                    newG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    newG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    //置背景色
                    newG.Clear(Color.White);
                    //画图
                    newG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, newImage.Width, newImage.Height), new System.Drawing.Rectangle(0, 0, initImage.Width, initImage.Height), System.Drawing.GraphicsUnit.Pixel);

                    //文字水印
                    if (watermarkText != "")
                    {
                        using (System.Drawing.Graphics gWater = System.Drawing.Graphics.FromImage(newImage))
                        {
                            System.Drawing.Font fontWater = new Font("宋体", 10);
                            System.Drawing.Brush brushWater = new SolidBrush(Color.White);
                            gWater.DrawString(watermarkText, fontWater, brushWater, 10, 10);
                            gWater.Dispose();
                        }
                    }

                    //透明图片水印
                    if (watermarkImage != "")
                    {
                        if (File.Exists(watermarkImage))
                        {
                            //获取水印图片
                            using (System.Drawing.Image wrImage = System.Drawing.Image.FromFile(watermarkImage))
                            {
                                //水印绘制条件：原始图片宽高均大于或等于水印图片
                                if (newImage.Width >= wrImage.Width && newImage.Height >= wrImage.Height)
                                {
                                    Graphics gWater = Graphics.FromImage(newImage);

                                    //透明属性
                                    ImageAttributes imgAttributes = new ImageAttributes();
                                    ColorMap colorMap = new ColorMap();
                                    colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
                                    colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
                                    ColorMap[] remapTable = { colorMap };
                                    imgAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

                                    float[][] colorMatrixElements = { 
                                   new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  0.0f,  0.0f,  0.5f, 0.0f},//透明度:0.5
                                   new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                };

                                    ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);
                                    imgAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                                    gWater.DrawImage(wrImage, new Rectangle(newImage.Width - wrImage.Width, newImage.Height - wrImage.Height, wrImage.Width, wrImage.Height), 0, 0, wrImage.Width, wrImage.Height, GraphicsUnit.Pixel, imgAttributes);
                                    gWater.Dispose();
                                }
                                wrImage.Dispose();
                            }
                        }
                    }

                    //保存缩略图
                    newImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                    //释放资源
                    newG.Dispose();
                    newImage.Dispose();
                    initImage.Dispose();
                }
            }

            #endregion

            #region 其它

            /// <summary>
            /// 判断文件类型是否为WEB格式图片
            /// (注：JPG,GIF,BMP,PNG)
            /// </summary>
            /// <param name="contentType">HttpPostedFile.ContentType</param>
            /// <returns></returns>
            public static bool IsWebImage(string contentType)
            {
                if (contentType == "image/pjpeg" || contentType == "image/jpeg" || contentType == "image/gif" || contentType == "image/bmp" || contentType == "image/png")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            #endregion

        }//end class
    }
}