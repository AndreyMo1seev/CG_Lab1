using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Brightness : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int c = 15;
            Color resultColor = Color.FromArgb(Clamp(c + sourceColor.R, 0, 255),
                Clamp(c + sourceColor.G, 0, 255), Clamp(c + sourceColor.B, 0, 255));
            return resultColor;
        }
    }
}
