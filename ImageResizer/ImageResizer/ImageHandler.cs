using System;
using System.Drawing;

namespace ImageResizer
{
    public class ImageHandler
    {
        public static Image ResizeImageFromFile(string OriginalFileLocation
            , int heigth
            , int width
            , bool keepAspectRatio
            , bool getCenter)
        {
            int newHeigth = heigth;
            int newWidth = width;
            Image FullsizeImage = Image.FromFile(OriginalFileLocation);

            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

            int minSide = Math.Min(FullsizeImage.Width, FullsizeImage.Height);

            if (FullsizeImage.Width == minSide)
            {
                if (keepAspectRatio || getCenter)
                {
                    int bmpY = 0;
                    float resize = (float) FullsizeImage.Width / width;
                    if (getCenter)
                    {
                        bmpY = (int) ((FullsizeImage.Height - (heigth * resize)) / 2);
                        Rectangle section = new Rectangle(new Point(0, bmpY),
                            new Size(FullsizeImage.Width, (int) (heigth * resize)));
                        Bitmap orImg = new Bitmap((Bitmap) FullsizeImage);

                        FullsizeImage.Dispose();

                        using (Bitmap tempImg = new Bitmap(section.Width, section.Height))
                        {
                            Graphics cutImg = Graphics.FromImage(tempImg);
                            cutImg.DrawImage(orImg, 0, 0, section, GraphicsUnit.Pixel);
                            FullsizeImage = tempImg;
                            orImg.Dispose();
                            cutImg.Dispose();
                            return FullsizeImage.GetThumbnailImage(width, heigth, null, IntPtr.Zero);
                        }
                    }
                    else newHeigth = (int) (FullsizeImage.Height / resize);
                }
            }

            if (FullsizeImage.Height == minSide)
            {
                if (keepAspectRatio || getCenter)
                {
                    int bmpX = 0;
                    float resize = (float) FullsizeImage.Height / heigth;
                    if (getCenter)
                    {
                        bmpX = (int) ((FullsizeImage.Width - (width * resize)) / 2);
                        Rectangle section = new Rectangle(new Point(bmpX, 0),
                            new Size((int) (width * resize), FullsizeImage.Height));
                        Bitmap orImg = new Bitmap((Bitmap) FullsizeImage);

                        FullsizeImage.Dispose();

                        using (Bitmap tempImg = new Bitmap(section.Width, section.Height))
                        {
                            Graphics cutImg = Graphics.FromImage(tempImg);
                            cutImg.DrawImage(orImg, 0, 0, section, GraphicsUnit.Pixel);
                            FullsizeImage = tempImg;
                            orImg.Dispose();
                            cutImg.Dispose();
                            return FullsizeImage.GetThumbnailImage(width, heigth, null, IntPtr.Zero);
                        }
                    }
                    else newWidth = (int) (FullsizeImage.Width / resize);
                }
            }


            return FullsizeImage.GetThumbnailImage(newWidth, newHeigth, null, IntPtr.Zero);
        }
    }
}