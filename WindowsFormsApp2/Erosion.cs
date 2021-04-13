using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApp2
{
    class Erosion: Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(sourceColor.R,
                sourceColor.G, sourceColor.B);
            return resultColor;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            int _intensity = 110;
            int MW;
            int MH;
            int[,] structuralEl = {{0, 1, 0},
                                   {1, 1, 1},
                                   {0, 1, 0}};
            MW = structuralEl.GetLength(0);
            MH = structuralEl.GetLength(1);
            Color black = Color.FromArgb(0, 0, 0);
            Color white = Color.FromArgb(255, 255, 255);
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap BWImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            BWImage = BlackAndWhite(sourceImage, worker, _intensity);
            object v = BWImage.Clone();
            resultImage = (Bitmap)v;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    if (BWImage.GetPixel(i, j) == black)
                    {

                        for (int k = -MH / 2; k <= MH / 2; k++)
                        {
                            for (int l = -MW / 2; l <= MW / 2; l++)
                            {
                                if (structuralEl[k + MH / 2, l + MW / 2] == 1)
                                {
                                    if (BWImage.GetPixel(Clamp(i + k, 0, sourceImage.Width - 1), Clamp(j + l, 0, sourceImage.Height - 1)) == white)
                                    {
                                        resultImage.SetPixel(i, j, white);
                                        break;
                                    }
                                }
                            }
                        }

                    }

                }
            }
            return resultImage;
        }
    }
}
