using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication
{
    class ContourBuilding
    {
        public ContourBuilding(double[,] image, int width, int height)
        {
            analyzableImage = new double[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    analyzableImage[i, j] = image[i, j];
                }
            cWidth = width;
            cHeight = height;
            contourShift = new Point(0, 0);
        }

        public void SetContourShift(Point p)
        {
            contourShift = p;
        }

        public Contour SimpleContourBuilding(int widthPartition, int heightPartition)
        {
            Contour contour = new Contour();
            int wStep = cWidth / widthPartition;
            int hStep = cHeight / heightPartition;
            for (int i = 0; i < cWidth; i += wStep)
                for (int j = 0; j < cHeight; j++)
                {
                    if (analyzableImage[i, j] > 0)
                    {
                        contour.AddPoint(new Point(i + contourShift.X, j + contourShift.Y));
                        break;
                    }
                }
            for (int i = (cWidth - 1); i >= 0; i -= wStep)
                for (int j = (cHeight - 1); j >= 0; j--)
                {
                    if (analyzableImage[i, j] > 0)
                    {
                        contour.AddPoint(new Point(i + contourShift.X, j + contourShift.Y));
                        break;
                    }
                }
            return contour;
        }

        private double[,] analyzableImage;
        private Point contourShift;
        private int cWidth;
        private int cHeight;
    }
}
