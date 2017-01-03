using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace JXTMoveImageToFTP
{
    public static class ImageExtenensions
    {
        public static string GetExtension(this Image img)
        {
            string extension = "bmp";

            if (ImageFormat.Gif.Equals(img.RawFormat))
            {
                extension = "gif";
            }
            else if (ImageFormat.Icon.Equals(img.RawFormat))
            {
                extension = "ico";
            }
            else if (ImageFormat.Jpeg.Equals(img.RawFormat))
            {
                extension = "jpg";
            }
            else if (ImageFormat.Png.Equals(img.RawFormat))
            {
                extension = "png";
            }
            return extension;
        }
    }
}
