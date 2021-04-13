using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApp2
{
    class GrayWorld : Filters
    {
        protected Color calculateNewPixelColor(Bitmap sourceImage, int x, int y, Color maxV)
        {

            Color sourceColor = sourceImage.GetPixel(x, y);
            double dR = (double)255 / maxV.R;
            double dG = (double)255 / maxV.G;
            double dB = (double)255 / maxV.B;
            Color resultColor = Color.FromArgb((int)(sourceColor.R * dR),
                (int)(sourceColor.G * dG), (int)(sourceColor.B * dB));
            return resultColor;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(145,
                145, 145);
            return resultColor;
        }
        //public override Color maxValues(Bitmap sourceImage, BackgroundWorker worker)
        //{
        //    Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
        //    int Rmax = 0;
        //    int Gmax = 0;
        //    int Bmax = 0;
        //    for (int i = 0; i < sourceImage.Width; i++)
        //    {
        //        worker.ReportProgress((int)((float)i / resultImage.Width * 100));
        //        //if (worker.CancellationPending)
        //        //    return null;
        //        for (int j = 0; j < sourceImage.Height; j++)
        //        {

        //            if (sourceImage.GetPixel(i, j).R > Rmax)
        //            {
        //                Rmax = sourceImage.GetPixel(i, j).R;
        //            }
        //            if (sourceImage.GetPixel(i, j).G > Rmax)
        //            {
        //                Gmax = sourceImage.GetPixel(i, j).G;
        //            }
        //            if (sourceImage.GetPixel(i, j).B > Rmax)
        //            {
        //                Bmax = sourceImage.GetPixel(i, j).B;
        //            }
        //        }

        //    }
        //    Color res = Color.FromArgb(Rmax, Gmax, Bmax);
        //    return res;
        //}
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Color maxV = maxValues(sourceImage, worker);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j, maxV));
                }
            }
            return resultImage;
        }
    }
}
