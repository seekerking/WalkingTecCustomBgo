using System;
using System.Drawing;
using System.IO;
using Microsoft.Extensions.Caching.Memory;
using WalkingTec.Mvvm.Core.CacheOptions;

namespace WalkingTec.Mvvm.Mvc.Helper
{
  public  static class ImageCodeHelper
  {
      public const string CacheKey = "PersonImageValidatePredix";
        public static byte[] ImageCodeToByte(string uuid)
        {
            string code = RandomHelper.GetRandomCode(4);
            string key =  CacheKey+ uuid;
            MemoryCacheTime.SetChacheValue(key,code, 300);
            byte[] bytes = CreateImage(code); 
            return bytes;
        }


        public static byte[] CreateImage(string checkCode)
        {
            int iwidth = (int)(checkCode.Length * 13);
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 23);
            Graphics g = Graphics.FromImage(image);
            Font f = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Bold));

            // 前景色
            Brush b = new System.Drawing.SolidBrush(Color.Black);

            // 背景色
            g.Clear(Color.White);

            // 填充文字
            g.DrawString(checkCode, f, b, 0, 1);

            // 随机线条
            Pen linePen = new Pen(Color.Gray, 0);
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                int x1 = rand.Next(image.Width);
                int y1 = rand.Next(image.Height);
                int x2 = rand.Next(image.Width);
                int y2 = rand.Next(image.Height);
                g.DrawLine(linePen, x1, y1, x2, y2);
            }

            // 随机点
            for (int i = 0; i < 30; i++)
            {
                int x = rand.Next(image.Width);
                int y = rand.Next(image.Height);
                image.SetPixel(x, y, Color.Gray);
            }

            // 边框
            g.DrawRectangle(new Pen(Color.Gray), 0, 0, image.Width - 1, image.Height - 1);

            // 输出图片
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            g.Dispose();
            image.Dispose();
            return ms.GetBuffer();
        }


        public static string GetBase64FromImage(Bitmap bmp)
        {
                string strbaser64 = "";
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                strbaser64 = Convert.ToBase64String(arr);
               return strbaser64;
        }
    }
}
