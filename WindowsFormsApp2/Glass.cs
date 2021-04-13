using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Glass : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int k, int l)
        {
            Random rng = new Random();
            // Color sourceColor = sourceImage.GetPixel(k, l);
            int stride = sourceImage.Width;
            int height = sourceImage.Height;
            // int stride = 3;
            int newX = Clamp(k + (int)(rng.Next(3) - 0.5) * 10, 0, stride - 1);
            int newY = Clamp(l + (int)(rng.Next(2) - 0.5) * 10, 0, height - 1);
            return sourceImage.GetPixel(newX, newY);
        }
    }
}
