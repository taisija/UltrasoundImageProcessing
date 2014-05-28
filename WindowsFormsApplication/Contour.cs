using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication
{
    class Contour
    {
        public Contour()
        {
            contourPoints = new List<Point>();
        }

        public void AddPoint(Point p)
        {
            contourPoints.Add(p);
        }

        public bool RemovePointByValue(Point p)
        {
            return contourPoints.Remove(p);
        }

        public bool RemovePointByIndex(int index)
        {
            try
            {
                contourPoints.RemoveAt(index);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public Point GetPointByIndex(int index)
        {
            int i = 0;
            IEnumerator<Point> iter = contourPoints.GetEnumerator();
            iter.Reset();
            while (iter.Current.IsEmpty == true) iter.MoveNext();
            while ((i < index) && iter.MoveNext())
            {
                i++;
            }
            if (i == index)
                return iter.Current;
            else
                return new Point(-1, -1);
        }

        public void ChangePointByIndex(int index, Point p)
        {
            contourPoints.RemoveAt(index);
            contourPoints.Insert(index, p);
        }

        public void InsertPointByIndex(int index, Point p)
        {
            contourPoints.Insert(index, p);
        }

        public int GetNumOfPoint()
        {
            return contourPoints.Count;
        }

        public void Clear()
        {
            contourPoints.Clear();
        }

        private List<Point> contourPoints;
    }
}
