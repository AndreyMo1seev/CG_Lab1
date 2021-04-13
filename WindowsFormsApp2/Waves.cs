using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Waves : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int k, int l)
        {
            // Color sourceColor = sourceImage.GetPixel(k, l);
            int stride = sourceImage.Width;
            // int stride = 3;
            int newX = Clamp(k + (int)(20 * Math.Sin(2 * Math.PI * l / 60)), 0, stride - 1);
            return sourceImage.GetPixel(newX, l);
        }
    }
}
