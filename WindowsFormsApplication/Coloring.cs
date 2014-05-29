using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication
{
    class Coloring
    {
        private Bitmap cBitmap;
        private Bitmap prBitmap;
        private bool[,] plan;
        private Contour cContour;
        private Color linesColor;
        private Pen penContour;
        private int min;
        private int max;
        private double step;
        private int range;
        private int[] histogram;
        private double[] percents;
        private int percentsLength;
        private int histogramSumm = 0;

        public Coloring(Bitmap bitmap, Contour contour)
        {
            histogram = new int[256];
            for (int i = 0; i < 256; i++)
            {
                histogram[i] = 0;
            }
            cBitmap = new Bitmap(bitmap);
            prBitmap = new Bitmap(bitmap);
            cContour = contour;
            penContour = new Pen(new SolidBrush(Color.DarkRed));
            min = 255;
            max = 0;
            histogramSumm = 0;
        }
        public static double[] calculateHistogram(Bitmap bitmap)
        {
            double[] hist = new double[256];
            int histSumm = 0;
            Color c;
            for (int i = 0; i < 256; i++)
            {
                hist[i] = 0;
            }
            if (bitmap != null)
            {
                for (int i = 0; i < bitmap.Width; i++)
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        c = bitmap.GetPixel(i, j);
                        hist[c.G] += 1;
                        histSumm++;
                    }
                for (int i = 0; i < 256; i++)
                {
                    hist[i] = hist[i] / (double)histSumm;
                }
            }
            return hist;
        }

        public static double calculateMaxHistogramValue(double[] Histogram)
        {
            double max = 0;
            for (int i = 0; i < 256; i++)
            {
                if (Histogram[i] > max) max = Histogram[i];
            }
            return max;
        }

        public static Bitmap RectangleCut(int x, int y, int width, int height, Bitmap bitmap)
        {
            if (width != 0 && height != 0)
            {
                Bitmap currentBitmap = new Bitmap(width, height);
                for (int i = 0; i < height; i++)
                    for (int j = 0; j < width; j++)
                        currentBitmap.SetPixel(j, i, bitmap.GetPixel(x + j, y + i));
                return currentBitmap;
            }
            else
                return null;
        }

        private void SearchInternalArea(Bitmap bitmap, Color color)
        {
            plan = new bool[bitmap.Width, bitmap.Height];
            int inside = -1;
            int count = 0;
            linesColor = color;
            Color c1;
            Color c2 = bitmap.GetPixel(0, cBitmap.Height - 1); ;
            for (int i = 0; i < cBitmap.Width; i++)
            {
                plan[i, 0] = false;
                for (int j = 1; j < (cBitmap.Height - 1); j++)
                {
                    c1 = bitmap.GetPixel(i, j);
                    c2 = bitmap.GetPixel(i, j + 1);
                    if ((c1 == color) && (c2 != color))
                    {
                        inside *= -1;
                        count++;
                    }
                    if (inside > 0)
                    {
                        plan[i, j + 1] = true;
                    }
                    else
                        plan[i, j + 1] = false;
                }
                if ((inside > 0) && (c2 != color))
                {
                    //если граница встретилась только 1 раз
                    if (count == 1)
                    {
                        for (int j = 1; j < (cBitmap.Height - 1); j++)
                        {
                            plan[i, j + 1] = false;
                        }
                    }
                    else
                    {
                        int j = cBitmap.Height - 1;
                        c2 = bitmap.GetPixel(i, cBitmap.Height - 1);
                        while ((c2 != color) && (j > 0))
                        {
                            plan[i, j] = false;
                            j--;
                            c2 = bitmap.GetPixel(i, j);
                        }
                    }
                }
                count = 0;
                inside = -1;
            }
        }

        private bool GetChangePixel(int i, int j)
        {
            return plan[i, j];
        }

        public Bitmap ColoringBitmap()
        {
            var gr = Graphics.FromImage(cBitmap);
            for (int i = (cContour.GetNumOfPoint() - 1); i > 0; i--)
                gr.DrawLine(penContour, cContour.GetPointByIndex(i), cContour.GetPointByIndex(i - 1));
            gr.DrawLine(penContour, cContour.GetPointByIndex(0), cContour.GetPointByIndex(cContour.GetNumOfPoint() - 1));
            SearchInternalArea(cBitmap, penContour.Color);
            GetRange();
            for (int i = 0; i < cBitmap.Width; i++)
                for (int j = 1; j < cBitmap.Height; j++)
                {
                    if (GetChangePixel(i, j))
                    {
                        cBitmap.SetPixel(i, j, GetColor(cBitmap.GetPixel(i, j).G));
                    }
                }
            return cBitmap;
        }
        /*
        public Bitmap coloringBitmap()
        {
            var gr = Graphics.FromImage(cBitmap);
            for (int i = (cContour.GetNumOfPoint() - 1); i > 0; i--)
                gr.DrawLine(penContour, cContour.GetPointByIndex(i), cContour.GetPointByIndex(i - 1));
            gr.DrawLine(penContour, cContour.GetPointByIndex(0), cContour.GetPointByIndex(cContour.GetNumOfPoint() - 1));
            getRange();
            int inside = -1;
            Color c;
            for (int i = 0; i < cBitmap.Width; i++)
            {
                for (int j = 1; j < cBitmap.Height; j++)
                {
                    c = cBitmap.GetPixel(i, j);
                    if ((c.R == 139) && (c.B != 139) && !((cBitmap.GetPixel(i, j - 1).R == 139) && (cBitmap.GetPixel(i, j - 1).B != 139)))
                    {
                        inside *= -1;
                    }
                    else
                    {
                        if (inside > 0 && !((c.A == 255) && (c.R == 139)))
                        {
                            prBitmap.SetPixel(i, j, getColor(c.G));
                        }
                    }
                }
                inside = -1;
            }
            return prBitmap;
        }
        */
        private void GetRange()
        {
            Color c;
            for (int i = 0; i < cBitmap.Width; i++)
                for (int j = 1; j < cBitmap.Height; j++)
                {
                    if (GetChangePixel(i, j))
                    {
                        c = cBitmap.GetPixel(i, j);
                        if (linesColor != c)
                        {
                            if (c.G > max) max = c.G;
                            if (c.G < min) min = c.G;
                        }
                    }
                }
            step = 255 / ((max - min));
            range = (max - min) / 4;
        }

        public void CalculateHistogramAndPercents(int parts)
        {
            Color c;
            int st = 0;
            percentsLength = parts;
            if (histogramSumm == 0)
            {
                for (int i = 0; i < cBitmap.Width; i++)
                    for (int j = 1; j < cBitmap.Height; j++)
                    {
                        if (GetChangePixel(i, j))
                        {
                            c = prBitmap.GetPixel(i, j);
                            histogram[c.G] += 1;
                            histogramSumm++;
                        }
                    }
            }
            percents = new double[parts];
            st = (max - min) / parts;
            for (int i = 0; i < (parts - 1); i++)
            {
                for (int j = i * st; j < (i + 1) * st; j++)
                    percents[i] += histogram[j + min];
            }
            for (int i = 0; i < (parts - 1); i++)
            {
                percents[parts - 1] -= percents[i];
                percents[i] *= 100.0 / histogramSumm;
            }
            percents[parts - 1] += histogramSumm;
            percents[parts - 1] *= 100.0 / histogramSumm;
        }

        public int GetMinValueInPart(int i)
        {
            if ((i >= 0) && (i < percentsLength))
            {
                return min + i * (max - min) / percentsLength;
            }
            else
                return 0;
        }

        public int GetMaxValueInPart(int i)
        {
            if ((i >= 0) && (i < percentsLength))
            {
                return min + (i + 1) * (max - min) / percentsLength;
            }
            else
                return 0;
        }

        public int GetMinMaxDistance()
        {
            return max - min;
        }

        public string GetIntervalOfPart(int i)
        {
            if ((i >= 0) && (i < percentsLength))
            {
                return (min + i * (max - min) / percentsLength).ToString() + "-" + (min + (i + 1) * (max - min) / percentsLength).ToString();
            }
            else
                return "";
        }

        public double GetPercents(int i)
        {
            if ((i >= 0) && (i < percentsLength))
            {
                return percents[i];
            }
            else
                return 0;
        }

        public int GetPercentsPartsNum()
        {
            return percentsLength;
        }

        private Color GetColor(int grayScale)
        {
            Color c;
            if ((grayScale - min) <= range)
            {
                c = Color.FromArgb(255, 255, 0, 0);
                //c = Color.FromArgb(255, 255, 255 - (grayScale - min)*4 * step, 0);
                //c = Color.FromArgb(255, 255, (grayScale - min) * 4 * step, 0);
            }
            else
                if (((grayScale - min) > range) && (((grayScale - min) <= range * 2)))
                {
                    c = Color.FromArgb(255, 255, 255, 0);
                    //c = Color.FromArgb(255, (grayScale - min) * step * 2, 255, 0);
                    //c = Color.FromArgb(255, 255 - (grayScale-min) * step*2, 255, 0);
                }
                else
                    if (((grayScale - min) > range * 2) && (((grayScale - min) <= range * 3)))
                    {
                        c = Color.FromArgb(255, 0, 255, 0);
                        //c = Color.FromArgb(255, 0, 255, (grayScale - min)*4 * step/3);
                    }
                    else
                    {
                        c = Color.FromArgb(255, 0, 0, 255);
                        //c = Color.FromArgb(255, 0, 255 - (grayScale - min) * step, 255);
                    }
            return c;
        }
    }
}
