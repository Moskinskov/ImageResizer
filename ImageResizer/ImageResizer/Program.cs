using System.Drawing;
using System.IO;

namespace ImageResizer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //example
            string imagePathIn = Path.GetFullPath(@"C:\Users\Ilia\Desktop\Screenshot_2.png");
            string imagePathOut = Path.GetFullPath(@"C:\Users\Ilia\Desktop\NewImage2.png");

            Image resizedImage =
                ImageHandler.ResizeImageFromFile(imagePathIn, 512, 512, true, true);
            resizedImage.Save(imagePathOut);
        }
    }
}