using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldTree.EXMethod
{
    public class ThumIMG
    {
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="imagePath">原图片路径</param>
        /// <param name="thumbPath">缩略图路径></param>
        ///默认等比例宽高有50_50,70_70,100_100三种
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="mode">模式</param>
        public void GenerateThumb(string imagePath, string thumbPath, int width, int height, string mode,ref string bs64)
        {
            if (File.Exists(imagePath))
            {
                Image image = Image.FromFile(imagePath);

                string extension = imagePath.Substring(imagePath.LastIndexOf(".")).ToLower();
                ImageFormat imageFormat = null;
                switch (extension)
                {
                    case ".jpg":
                    case ".jpeg":
                        imageFormat = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        imageFormat = ImageFormat.Bmp;
                        break;
                    case ".png":
                        imageFormat = ImageFormat.Png;
                        break;
                    case ".gif":
                        imageFormat = ImageFormat.Gif;
                        break;
                    default:
                        imageFormat = ImageFormat.Jpeg;
                        break;
                }

                int toWidth = width > 0 ? width : image.Width;
                int toHeight = height > 0 ? height : image.Height;

                int x = 0;
                int y = 0;
                int ow = image.Width;
                int oh = image.Height;

                switch (mode)
                {
                    case "HW"://指定高宽缩放（可能变形）           
                        break;
                    case "W"://指定宽，高按比例             
                        toHeight = image.Height * width / image.Width;
                        break;
                    case "H"://指定高，宽按比例
                        toWidth = image.Width * height / image.Height;
                        break;
                    case "Cut"://指定高宽裁减（不变形）           
                        if ((double)image.Width / (double)image.Height > (double)toWidth / (double)toHeight)
                        {
                            oh = image.Height;
                            ow = image.Height * toWidth / toHeight;
                            y = 0;
                            x = (image.Width - ow) / 2;
                        }
                        else
                        {
                            ow = image.Width;
                            oh = image.Width * height / toWidth;
                            x = 0;
                            y = (image.Height - oh) / 2;
                        }
                        break;
                    default:
                        break;
                }

                //新建一个bmp
                Image bitmap = new Bitmap(toWidth, toHeight);

                //新建一个画板
                Graphics g = Graphics.FromImage(bitmap);

                //设置高质量插值法
                g.InterpolationMode = InterpolationMode.High;

                //设置高质量,低速度呈现平滑程度
                g.SmoothingMode = SmoothingMode.HighQuality;

                //清空画布并以透明背景色填充
                g.Clear(Color.Transparent);

                //在指定位置并且按指定大小绘制原图片的指定部分
                g.DrawImage(image,
                            new Rectangle(0, 0, toWidth, toHeight),
                            new Rectangle(x, y, ow, oh),
                            GraphicsUnit.Pixel);

                try
                {
                    bitmap.Save(thumbPath, imageFormat);
                    bs64 = ImgToBase64String(thumbPath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (g != null)
                        g.Dispose();
                    if (bitmap != null)
                        bitmap.Dispose();
                    if (image != null)
                        image.Dispose();
                }
            }

        }
        //图片转为base64编码的字符串
        protected string ImgToBase64String(string Imagefilename)
        {
            try
            {
                Bitmap bmp = new Bitmap(Imagefilename);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //threeebase64编码的字符串转为图片
        protected Bitmap Base64StringToImage(string strbase64)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(strbase64);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);

                bmp.Save(@"d:\test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //bmp.Save(@"d:\"test.bmp", ImageFormat.Bmp);
                //bmp.Save(@"d:\"test.gif", ImageFormat.Gif);
                //bmp.Save(@"d:\"test.png", ImageFormat.Png);
                ms.Close();
                return bmp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
