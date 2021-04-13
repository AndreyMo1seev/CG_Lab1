using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApp2
{
    struct myPixel
    {
        public int R, G, B, A;

    };
    abstract class Filters
    {
        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        //public int Intensity(byte[] sourceBuffer, int x)
        public int Intensity(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            return (int)((0.299f * sourceColor.R) + (0.587f * sourceColor.G) + (0.114f * sourceColor.B));
        }
        //public abstract myPixel calculateNewPixelColor(byte[] sourceBuffer, int stride, int height, int x, int y);
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);

        public Color maxValues(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            int Rmax = 0;
            int Gmax = 0;
            int Bmax = 0;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                //if (worker.CancellationPending)
                //    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {

                    if (sourceImage.GetPixel(i, j).R > Rmax)
                    {
                        Rmax = sourceImage.GetPixel(i, j).R;
                    }
                    if (sourceImage.GetPixel(i, j).G > Gmax)
                    {
                        Gmax = sourceImage.GetPixel(i, j).G;
                    }
                    if (sourceImage.GetPixel(i, j).B > Bmax)
                    {
                        Bmax = sourceImage.GetPixel(i, j).B;
                    }
                }

            }
            Color res = Color.FromArgb(Rmax, Gmax, Bmax);
            return res;
        }

        public Color minValues(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            int Rmin = 255;
            int Gmin = 255;
            int Bmin = 255;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                //if (worker.CancellationPending)
                //    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {

                    if (sourceImage.GetPixel(i, j).R < Rmin)
                    {
                        Rmin = sourceImage.GetPixel(i, j).R;
                    }
                    if (sourceImage.GetPixel(i, j).G < Gmin)
                    {
                        Gmin = sourceImage.GetPixel(i, j).G;
                    }
                    if (sourceImage.GetPixel(i, j).B < Bmin)
                    {
                        Bmin = sourceImage.GetPixel(i, j).B;
                    }
                }

            }
            Color res = Color.FromArgb(Rmin, Gmin, Bmin);
            return res;
        }

        public Bitmap BlackAndWhite(Bitmap sourceImage, BackgroundWorker worker, int _intensity)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Color black = Color.FromArgb(0, 0, 0);
            Color white = Color.FromArgb(255, 255, 255);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                //if (worker.CancellationPending)
                //    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {

                    if (Intensity(sourceImage, i, j) > _intensity)
                    {

                        resultImage.SetPixel(i, j, white);
                    }
                    else
                    {
                        resultImage.SetPixel(i, j, black);
                    }
                }

            }
            return resultImage;
        }

        public Bitmap subImage(Bitmap sourceImage1, Bitmap sourceImage2, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage1.Width, sourceImage1.Height);
            Color black = Color.FromArgb(0, 0, 0);
            for (int i = 0; i < sourceImage1.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage1.Height; j++)
                {
                    if (sourceImage1.GetPixel(i, j) != sourceImage2.GetPixel(i, j))
                    {
                        resultImage.SetPixel(i, j, black);
                    }
                }
            }
            return resultImage;
        }
        public Bitmap Copy(Bitmap sourceImage, BackgroundWorker worker)
        {
            return sourceImage;
        }
        virtual public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }
    }

    /*
    class InvertFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(255 - sourceColor.R,
                255 - sourceColor.G, 255 - sourceColor.B);
            return resultColor;
        }
    }
    */
}

