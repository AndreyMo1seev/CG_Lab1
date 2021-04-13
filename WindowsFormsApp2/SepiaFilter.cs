using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 20;
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = Intensity(sourceImage, x, y);
            intensity = Clamp(intensity, 0, 255);
            Color resultColor = Color.FromArgb(Clamp(intensity + 2*k, 0, 255), Clamp(Convert.ToInt32(intensity + 0.5*k), 0, 255), Clamp(intensity -1*k, 0, 255));
            return resultColor;
        }
    }
}
