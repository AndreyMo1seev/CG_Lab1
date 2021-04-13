using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class MedianFilter : MatrixFilter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = 5 / 2;
            int radiusY = 5 / 2;
            List<int> listR = new List<int>();
            List<int> listG = new List<int>();
            List<int> listB = new List<int>();
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    listR.Add(sourceImage.GetPixel(idX, idY).R);
                    listG.Add(sourceImage.GetPixel(idX, idY).G);
                    listB.Add(sourceImage.GetPixel(idX, idY).B);
                }
            }
            listR.Sort();
            listG.Sort();
            listB.Sort();

            return Color.FromArgb(Clamp((int)listR[listR.Count / 2], 0, 255), Clamp((int)listG[listG.Count / 2], 0, 255),
                Clamp((int)listB[listB.Count / 2], 0, 255));
        }
    }
}
