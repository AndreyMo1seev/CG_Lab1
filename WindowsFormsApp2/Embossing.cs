using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Embossing : MatrixFilter
    {
        
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = Intensity(sourceImage, x, y);
            intensity = Clamp(intensity, 0, 255);
            Color resultColor = Color.FromArgb(intensity,
                intensity, intensity);
            return resultColor;
        }
        
        public Embossing()
        {
            kernel = new float[,]
                   {{0, 1, 0 },
                        {1, 0, -1 },
                        {0, -1, 0 }};

        }
    }
}
