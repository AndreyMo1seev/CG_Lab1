using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;


namespace WindowsFormsApp2
{
    class LinearTension: Filters
    {
        protected Color calculateNewPixelColor(Bitmap sourceImage, int x, int y, Color maxV, Color minV)
        {

            Color sourceColor = sourceImage.GetPixel(x, y);
            int dR = (int)((sourceColor.R - minV.R) * ((double)255 / (maxV.R - minV.R)));
            int dG = (int)((sourceColor.G - minV.G) * ((double)255 / (maxV.G - minV.G)));
            int dB = (int)((sourceColor.B - minV.B) * ((double)255 / (maxV.B - minV.B)));
            Color resultColor = Color.FromArgb(dR, dG, dB);
            return resultColor;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(145,
                145, 145);
            return resultColor;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Color maxV = maxValues(sourceImage, worker);
            Color minV = minValues(sourceImage, worker);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j, maxV, minV));
                }
            }
            return resultImage;
        }

    }
}
