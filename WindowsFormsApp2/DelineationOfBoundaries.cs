using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class DelineationOfBoundaries : MatrixFilter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernelx.GetLength(0) / 2;
            int radiusY = kernelx.GetLength(1) / 2;
            float resultRx = 0;
            float resultGx = 0;
            float resultBx = 0;
            float resultRy = 0;
            float resultGy = 0;
            float resultBy = 0;
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultRx += neighborColor.R * kernelx[k + radiusX, l + radiusY];
                    resultGx += neighborColor.G * kernelx[k + radiusX, l + radiusY];
                    resultBx += neighborColor.B * kernelx[k + radiusX, l + radiusY];
                }
            }
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultRy += neighborColor.R * kernely[k + radiusX, l + radiusY];
                    resultGy += neighborColor.G * kernely[k + radiusX, l + radiusY];
                    resultBy += neighborColor.B * kernely[k + radiusX, l + radiusY];
                }
            }
            return Color.FromArgb(Clamp((int)(Math.Sqrt(Math.Pow(resultRx, 2) + Math.Pow(resultRy, 2))), 0, 255), Clamp((int)(Math.Sqrt(Math.Pow(resultGx, 2) + Math.Pow(resultGy, 2))), 0, 255),
                Clamp((int)(Math.Sqrt(Math.Pow(resultBx, 2) + Math.Pow(resultBy, 2))), 0, 255));
        }

        public DelineationOfBoundaries()
        {

            kernelx = new float[,]
                        {{3, 0, -3 },
                        {10, 0, -10 },
                        {3, 0, -3 }};

            kernely = new float[,]
                        {{3, 10, 3 },
                        {0, 0, 0 },
                        {-3, -10, -3 }};

        }
    }
}
