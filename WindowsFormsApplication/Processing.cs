using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication
{
    class Processing
    {
        //initial image
        private Bitmap prBitmap;
        //current image
        private Bitmap prCurrentBitmap;
        //rectangle of current image in initial image
        private Rectangle prClipRectangle;
        //filters list
        private List<Node> nodeList;
        //images for filtration
        private double[,] currentImage;
        private double[,] newImage;

        public Processing(Bitmap bitmap)
        {
            prBitmap = bitmap;
            prClipRectangle = new Rectangle();
            nodeList = new List<Node>();
        }

        //resize rectangle of current image in initial image
        //and current image
        public Bitmap RectangleCut(int x, int y, int width, int height, Bitmap bitmap)
        {
            if (prClipRectangle.X != null)
            {
                prClipRectangle.X += x;
                prClipRectangle.Y += y;
            }
            else
            {
                prClipRectangle.X = x;
                prClipRectangle.Y = y;
            }
            prClipRectangle.Width = width;
            prClipRectangle.Height = height;
            prCurrentBitmap = new Bitmap(width, height);
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    prCurrentBitmap.SetPixel(j, i, bitmap.GetPixel(x + j, y + i));
            bitmap = prCurrentBitmap;
            return prCurrentBitmap;
        }

        public void AddFilterToList(int id)
        {
            nodeList.Add(NodesFactory.INSTANCE.NewNode(id));
        }

        public bool CleanList()
        {
            nodeList.Clear();
            return true;
        }

        public Bitmap ApplyChain()
        {
            currentImage = new double[prCurrentBitmap.Width, prCurrentBitmap.Height];
            newImage = new double[prCurrentBitmap.Width, prCurrentBitmap.Height];
            for (int i = 0; i < prCurrentBitmap.Width; i++)
                for (int j = 0; j < prCurrentBitmap.Height; j++)
                {
                    currentImage[i, j] = prCurrentBitmap.GetPixel(i, j).G;
                }
            IEnumerator<Node> iter = nodeList.GetEnumerator();
            while (iter.MoveNext())
            {
                while (iter.Current == null) iter.MoveNext();
                iter.Current.ApplyFilter(currentImage, newImage, prCurrentBitmap.Height, prCurrentBitmap.Width);
                if (iter.MoveNext())
                    iter.Current.ApplyFilter(newImage, currentImage, prCurrentBitmap.Height, prCurrentBitmap.Width);
                else
                    newImage = currentImage;
            }
            /*for (int i = 0; i < prCurrentBitmap.Width; i++)
                for (int j = 0; j < prCurrentBitmap.Height; j++)
                {
                    prCurrentBitmap.SetPixel(i, j, System.Drawing.Color.FromArgb((int)newImage[i, j], (int)newImage[i, j], (int)newImage[i, j]));
                }*/
            iter.Reset();
            return prBitmap;
        }

        public Contour SelectContour(int numOfPoints)
        {
            ContourBuilding cb = new ContourBuilding(newImage, prCurrentBitmap.Width, prCurrentBitmap.Height);
            cb.SetContourShift(new Point(prClipRectangle.X, prClipRectangle.Y));
            return cb.SimpleContourBuilding(numOfPoints, numOfPoints);
        }

    }
}

