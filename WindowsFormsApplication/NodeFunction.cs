﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication
{
    class NodeFunction : Node
    {
        public NodeFunction()
        { }
        public NodeFunction(double[][,] Filters, int FilterNum, int[] FiltersSizes, int[] FiltersDenom, int SimpleFiltersNum, double[] Histogram)
        {
            filterInd = FilterNum;
            filterLen = FiltersSizes[filterInd];
            filterDenominatorSum = FiltersDenom[filterInd];
            filter = Filters[filterInd];
            filterSum = 1;
            numOfSimpleFilters = SimpleFiltersNum;
            mainHistogram = Histogram;
        }
        public NodeFunction(Node sourceNode)
        {
            filterInd = sourceNode.GetFilterIndex();
            filterLen = sourceNode.GetFilterLength();
            filterSum = sourceNode.GetFilterSum();
            filterDenominatorSum = sourceNode.GetFilterDenominatorSum();
            filter = new double[filterLen, filterLen];
            for (int i = 0; i < filterLen; i++)
                for (int j = 0; j < filterLen; j++)
                {
                    filter[i, j] = sourceNode.GetFilterValue(i, j);
                }
        }
        public override Node Clone()
        {
            NodeFunction newNode = new NodeFunction();
            newNode.filterInd = filterInd;
            newNode.filterLen = filterLen;
            newNode.filterSum = filterSum;
            newNode.mainHistogram = mainHistogram;
            newNode.numOfSimpleFilters = numOfSimpleFilters;
            newNode.filterDenominatorSum = filterDenominatorSum;
            newNode.filter = new double[filterLen, filterLen];
            for (int i = 0; i < filterLen; i++)
                for (int j = 0; j < filterLen; j++)
                {
                    newNode.filter[i, j] = filter[i, j];
                }
            return newNode;
        }
        public override double ApplyFilter(double[,] CurImage, double[,] NewImage, int Width, int Height)
        {
            switch (filterInd - numOfSimpleFilters)
            {
                case 0:
                case 1:
                    return Erosion(CurImage, NewImage, Width, Height);
                case 2:
                case 3:
                    return Dilation(CurImage, NewImage, Width, Height);
                case 4:
                case 6:
                    Erosion(CurImage, NewImage, Width, Height);
                    return Dilation(NewImage, NewImage, Width, Height);
                case 5:
                case 7:
                    Dilation(CurImage, NewImage, Width, Height);
                    return Erosion(NewImage, NewImage, Width, Height);
                case 8:
                case 9:
                    return Median(CurImage, NewImage, Width, Height);
                case 10:
                    return LinearTransformation(CurImage, NewImage, Width, Height);
                case 11:
                    return Threshold(CurImage, NewImage, Width, Height);
                case 12:
                    return HitigramMatching(CurImage, NewImage, Width, Height);
                case 13:
                    return DilationContour(CurImage, NewImage, Width, Height);
                default:
                    return Equalization(CurImage, NewImage, Width, Height);
            }
        }
        private double DilationContour(double[,] CurImage, double[,] NewImage, int Width, int Height)
        {
            //по изображению
            double max = 0;
            double min = 255;
            int lHeight = Height - 2;
            int lWidth = Width - 2;
            int llHeight = Height - 1;
            int llWidth = Width - 1;
            if (filterLen == 5)
            {
                for (int y = 2; y < lHeight; y++)
                    for (int x = 2; x < lWidth; x++)
                    {
                        NewImage[y, x] = 0;
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 2, x - 2]) ? NewImage[y, x] : CurImage[y - 2, x - 2];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 2, x - 1]) ? NewImage[y, x] : CurImage[y - 2, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 2, x]) ? NewImage[y, x] : CurImage[y - 2, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 2, x + 1]) ? NewImage[y, x] : CurImage[y - 2, x + 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 2, x + 2]) ? NewImage[y, x] : CurImage[y - 2, x + 2];

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x - 2]) ? NewImage[y, x] : CurImage[y - 1, x - 2];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x - 1]) ? NewImage[y, x] : CurImage[y - 1, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x]) ? NewImage[y, x] : CurImage[y - 1, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x + 1]) ? NewImage[y, x] : CurImage[y - 1, x + 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x + 2]) ? NewImage[y, x] : CurImage[y - 1, x + 2];

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x - 2]) ? NewImage[y, x] : CurImage[y, x - 2];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x - 1]) ? NewImage[y, x] : CurImage[y, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x]) ? NewImage[y, x] : CurImage[y, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x + 1]) ? NewImage[y, x] : CurImage[y, x + 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x + 2]) ? NewImage[y, x] : CurImage[y, x + 2];

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x - 2]) ? NewImage[y, x] : CurImage[y + 1, x - 2];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x - 1]) ? NewImage[y, x] : CurImage[y + 1, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x]) ? NewImage[y, x] : CurImage[y + 1, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x + 1]) ? NewImage[y, x] : CurImage[y + 1, x + 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x + 2]) ? NewImage[y, x] : CurImage[y + 1, x + 2];

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 2, x - 2]) ? NewImage[y, x] : CurImage[y + 2, x - 2];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 2, x - 1]) ? NewImage[y, x] : CurImage[y + 2, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 2, x]) ? NewImage[y, x] : CurImage[y + 2, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 2, x + 1]) ? NewImage[y, x] : CurImage[y + 2, x + 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 2, x + 2]) ? NewImage[y, x] : CurImage[y + 2, x + 2];

                        if (min > NewImage[y, x])
                            min = NewImage[y, x];
                        if (max < NewImage[y, x])
                            max = NewImage[y, x];
                    }
                for (int y = 0; y < Height; y++)
                {
                    NewImage[y, 0] = NewImage[y, 1] = NewImage[y, 2];
                    NewImage[y, (Width - 1)] = NewImage[y, (Width - 2)] = NewImage[y, (Width - 3)];
                }
                for (int x = 0; x < Width; x++)
                {
                    NewImage[0, x] = NewImage[1, x] = NewImage[2, x];
                    NewImage[(Height - 1), x] = NewImage[(Height - 2), x] = NewImage[(Height - 3), x];
                }
            }
            else
            {
                for (int y = 1; y < lHeight; y++)
                    for (int x = 1; x < lWidth; x++)
                    {
                        NewImage[y, x] = 0;

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x - 1]) ? NewImage[y, x] : CurImage[y - 1, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x]) ? NewImage[y, x] : CurImage[y - 1, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x + 1]) ? NewImage[y, x] : CurImage[y - 1, x + 1];

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x - 1]) ? NewImage[y, x] : CurImage[y, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x]) ? NewImage[y, x] : CurImage[y, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x + 1]) ? NewImage[y, x] : CurImage[y, x + 1];

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x - 1]) ? NewImage[y, x] : CurImage[y + 1, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x]) ? NewImage[y, x] : CurImage[y + 1, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x + 1]) ? NewImage[y, x] : CurImage[y + 1, x + 1];

                        if (min > NewImage[y, x])
                            min = NewImage[y, x];
                        if (max < NewImage[y, x])
                            max = NewImage[y, x];
                    }
                for (int y = 0; y < Height; y++)
                {
                    NewImage[y, 0] = NewImage[y, 1];
                    NewImage[y, (Width - 1)] = NewImage[y, (Width - 2)];
                }
                for (int x = 0; x < Width; x++)
                {
                    NewImage[0, x] = NewImage[1, x];
                    NewImage[(Height - 1), x] = NewImage[(Height - 2), x];
                }
                for (int y = 0; y < Height; y++)
                    for (int x = 0; x < Width; x++)
                    {
                        NewImage[y, x] -= CurImage[y, x];
                        if (min > NewImage[y, x])
                            min = NewImage[y, x];
                        if (max < NewImage[y, x])
                            max = NewImage[y, x];
                    }
            }
            return (max + min) / 2;
        }
        private double HitigramMatching(double[,] CurImage, double[,] NewImage, int Width, int Height)
        {
            double[] histogram = new double[256];
            double[] newHistogram = new double[256];
            //по изображению
            double max = 0;
            double min = 255;
            double size = Width * Height;
            for (int i = 0; i < 256; i++)
            {
                histogram[i] = 0;
            }
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    histogram[(int)CurImage[y, x]]++;
                }
            for (int i = 1; i < 256; i++)
            {
                histogram[i] += histogram[i - 1];
                histogram[i - 1] /= size;
            }
            histogram[255] /= size;
            if (histogram[0] < mainHistogram[0])
            {
                int j = 0;
                while (histogram[j] <= mainHistogram[0])
                {
                    newHistogram[j] = 0;
                    j++;
                }
                int k = j;
                j = 1;
                for (; k < 255; k++)
                {
                    while (!((histogram[k] > mainHistogram[j - 1]) && (histogram[k] <= mainHistogram[j])))
                    {
                        if (j == 255)
                            break;
                        j++;
                    }
                    newHistogram[k] = mainHistogram[j] * 255;
                }
                newHistogram[255] = 255;
                for (int y = 0; y < Height; y++)
                    for (int x = 0; x < Width; x++)
                    {
                        NewImage[y, x] = newHistogram[(int)CurImage[y, x]];
                        if (NewImage[y, x] > 255)
                            NewImage[y, x] = 255;
                    }
                min = histogram[0] * 255;
                max = histogram[255] * 255;
            }
            else
            {
                for (int y = 0; y < Height; y++)
                    for (int x = 0; x < Width; x++)
                    {
                        NewImage[y, x] = CurImage[y, x];
                        if (NewImage[y, x] > 255)
                            NewImage[y, x] = 255;
                        if (CurImage[y, x] > max)
                            max = CurImage[y, x];
                        if (min > CurImage[y, x])
                            min = CurImage[y, x];
                    }
            }

            return (max + min) / 2;
        }
        private double LinearTransformation(double[,] CurImage, double[,] NewImage, int Width, int Height)
        {
            //по изображению
            double max = 0;
            double min = 255;
            int lHeight = Height - 2;
            int lWidth = Width - 2;
            int llHeight = Height - 1;
            int llWidth = Width - 1;
            double[] sortArray = new double[9];
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    if (min > CurImage[y, x])
                        min = CurImage[y, x];
                    if (max < CurImage[y, x])
                        max = CurImage[y, x];
                }
            double k = max - min;
            if (k > 0) k = 255 / (max - min);
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    NewImage[y, x] = (CurImage[y, x] - min) * k;
                    if (NewImage[y, x] > 255)
                        NewImage[y, x] = 255;
                }
            return (k > 0) ? (255 / 2) : 0;
        }
        private double Threshold(double[,] CurImage, double[,] NewImage, int Width, int Height)
        {
            //по изображению
            double max = 0;
            double min = 255;
            int lHeight = Height - 2;
            int lWidth = Width - 2;
            int llHeight = Height - 1;
            int llWidth = Width - 1;
            double[] sortArray = new double[9];
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    if (min > CurImage[y, x])
                        min = CurImage[y, x];
                    if (max < CurImage[y, x])
                        max = CurImage[y, x];
                }
            double k = (max + min) / 2;
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    NewImage[y, x] = (CurImage[y, x] > k) ? 255 : 0;
                }
            return 255 / 2;

        }
        private double Median(double[,] CurImage, double[,] NewImage, int Width, int Height)
        {
            //по изображению
            double max = 0;
            double min = 255;
            int lHeight = Height - 2;
            int lWidth = Width - 2;
            int llHeight = Height - 1;
            int llWidth = Width - 1;
            if (filterLen == 5)
            {
                double[] sortArray = new double[25];
                for (int y = 2; y < lHeight; y++)
                    for (int x = 2; x < lWidth; x++)
                    {
                        sortArray[0] = CurImage[y - 2, x - 2];
                        sortArray[1] = CurImage[y - 2, x - 1];
                        sortArray[2] = CurImage[y - 2, x];
                        sortArray[3] = CurImage[y - 2, x + 1];
                        sortArray[4] = CurImage[y - 2, x + 2];

                        sortArray[5] = CurImage[y - 1, x - 2];
                        sortArray[6] = CurImage[y - 1, x - 1];
                        sortArray[7] = CurImage[y - 1, x];
                        sortArray[8] = CurImage[y - 1, x + 1];
                        sortArray[9] = CurImage[y - 1, x + 2];

                        sortArray[10] = CurImage[y, x - 2];
                        sortArray[11] = CurImage[y, x - 1];
                        sortArray[12] = CurImage[y, x];
                        sortArray[13] = CurImage[y, x + 1];
                        sortArray[14] = CurImage[y, x + 2];

                        sortArray[15] = CurImage[y + 1, x - 2];
                        sortArray[16] = CurImage[y + 1, x - 1];
                        sortArray[17] = CurImage[y + 1, x];
                        sortArray[18] = CurImage[y + 1, x + 1];
                        sortArray[19] = CurImage[y + 1, x + 2];

                        sortArray[20] = CurImage[y + 2, x - 2];
                        sortArray[21] = CurImage[y + 2, x - 1];
                        sortArray[22] = CurImage[y + 2, x];
                        sortArray[23] = CurImage[y + 2, x + 1];
                        sortArray[24] = CurImage[y + 2, x + 2];

                        double med = 255;
                        for (int i = 0; i < 13; i++)
                            for (int j = i; j < 25; j++)
                            {
                                if (sortArray[i] < sortArray[j])
                                {
                                    med = sortArray[i];
                                    sortArray[i] = sortArray[j];
                                    sortArray[j] = med;
                                }
                            }
                        NewImage[y, x] = sortArray[12];

                        if (min > NewImage[y, x])
                            min = NewImage[y, x];
                        if (max < NewImage[y, x])
                            max = NewImage[y, x];
                    }
                for (int y = 0; y < Height; y++)
                {
                    NewImage[y, 0] = NewImage[y, 1] = NewImage[y, 2];
                    NewImage[y, (Width - 1)] = NewImage[y, (Width - 2)] = NewImage[y, (Width - 3)];
                }
                for (int x = 0; x < Width; x++)
                {
                    NewImage[0, x] = NewImage[1, x] = NewImage[2, x];
                    NewImage[(Height - 1), x] = NewImage[(Height - 2), x] = NewImage[(Height - 3), x];
                }
            }
            else
            {
                double[] sortArray = new double[9];
                for (int y = 1; y < lHeight; y++)
                    for (int x = 1; x < lWidth; x++)
                    {
                        sortArray[0] = CurImage[y - 1, x - 1];
                        sortArray[1] = CurImage[y - 1, x];
                        sortArray[2] = CurImage[y - 1, x + 1];

                        sortArray[3] = CurImage[y, x - 1];
                        sortArray[4] = CurImage[y, x];
                        sortArray[5] = CurImage[y, x + 1];

                        sortArray[6] = CurImage[y + 1, x - 1];
                        sortArray[7] = CurImage[y + 1, x];
                        sortArray[8] = CurImage[y + 1, x + 1];

                        double med = 255;
                        for (int i = 0; i < 5; i++)
                            for (int j = i; j < 9; j++)
                            {
                                if (sortArray[i] < sortArray[j])
                                {
                                    med = sortArray[i];
                                    sortArray[i] = sortArray[j];
                                    sortArray[j] = med;
                                }
                            }

                        NewImage[y, x] = sortArray[4];

                        if (min > NewImage[y, x])
                            min = NewImage[y, x];
                        if (max < NewImage[y, x])
                            max = NewImage[y, x];
                    }
                for (int y = 0; y < Height; y++)
                {
                    NewImage[y, 0] = NewImage[y, 1];
                    NewImage[y, (Width - 1)] = NewImage[y, (Width - 2)];
                }
                for (int x = 0; x < Width; x++)
                {
                    NewImage[0, x] = NewImage[1, x];
                    NewImage[(Height - 1), x] = NewImage[(Height - 2), x];
                }
            }
            return (max + min) / 2;

        }
        private double Erosion(double[,] CurImage, double[,] NewImage, int Width, int Height)
        {
            //по изображению
            double max = 0;
            double min = 255;
            int lHeight = Height - 2;
            int lWidth = Width - 2;
            int llHeight = Height - 1;
            int llWidth = Width - 1;
            if (filterLen == 5)
            {
                for (int y = 2; y < lHeight; y++)
                    for (int x = 2; x < lWidth; x++)
                    {
                        NewImage[y, x] = 0;
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y - 2, x - 2]) ? NewImage[y, x] : CurImage[y - 2, x - 2];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y - 2, x - 1]) ? NewImage[y, x] : CurImage[y - 2, x - 1];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y - 2, x]) ? NewImage[y, x] : CurImage[y - 2, x];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y - 2, x + 1]) ? NewImage[y, x] : CurImage[y - 2, x + 1];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y - 2, x + 2]) ? NewImage[y, x] : CurImage[y - 2, x + 2];

                        NewImage[y, x] = (NewImage[y, x] < CurImage[y - 1, x - 2]) ? NewImage[y, x] : CurImage[y - 1, x - 2];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y - 1, x - 1]) ? NewImage[y, x] : CurImage[y - 1, x - 1];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y - 1, x]) ? NewImage[y, x] : CurImage[y - 1, x];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y - 1, x + 1]) ? NewImage[y, x] : CurImage[y - 1, x + 1];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y - 1, x + 2]) ? NewImage[y, x] : CurImage[y - 1, x + 2];

                        NewImage[y, x] = (NewImage[y, x] < CurImage[y, x - 2]) ? NewImage[y, x] : CurImage[y, x - 2];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y, x - 1]) ? NewImage[y, x] : CurImage[y, x - 1];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y, x]) ? NewImage[y, x] : CurImage[y, x];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y, x + 1]) ? NewImage[y, x] : CurImage[y, x + 1];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y, x + 2]) ? NewImage[y, x] : CurImage[y, x + 2];

                        NewImage[y, x] = (NewImage[y, x] < CurImage[y + 1, x - 2]) ? NewImage[y, x] : CurImage[y + 1, x - 2];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y + 1, x - 1]) ? NewImage[y, x] : CurImage[y + 1, x - 1];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y + 1, x]) ? NewImage[y, x] : CurImage[y + 1, x];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y + 1, x + 1]) ? NewImage[y, x] : CurImage[y + 1, x + 1];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y + 1, x + 2]) ? NewImage[y, x] : CurImage[y + 1, x + 2];

                        NewImage[y, x] = (NewImage[y, x] < CurImage[y + 2, x - 2]) ? NewImage[y, x] : CurImage[y + 2, x - 2];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y + 2, x - 1]) ? NewImage[y, x] : CurImage[y + 2, x - 1];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y + 2, x]) ? NewImage[y, x] : CurImage[y + 2, x];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y + 2, x + 1]) ? NewImage[y, x] : CurImage[y + 2, x + 1];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y + 2, x + 2]) ? NewImage[y, x] : CurImage[y + 2, x + 2];

                        if (min > NewImage[y, x])
                            min = NewImage[y, x];
                        if (max < NewImage[y, x])
                            max = NewImage[y, x];
                    }
                for (int y = 0; y < Height; y++)
                {
                    NewImage[y, 0] = NewImage[y, 1] = NewImage[y, 2];
                    NewImage[y, (Width - 1)] = NewImage[y, (Width - 2)] = NewImage[y, (Width - 3)];
                }
                for (int x = 0; x < Width; x++)
                {
                    NewImage[0, x] = NewImage[1, x] = NewImage[2, x];
                    NewImage[(Height - 1), x] = NewImage[(Height - 2), x] = NewImage[(Height - 3), x];
                }
            }
            else
            {
                for (int y = 1; y < lHeight; y++)
                    for (int x = 1; x < lWidth; x++)
                    {
                        NewImage[y, x] = 0;


                        NewImage[y, x] = (NewImage[y, x] < CurImage[y - 1, x - 1]) ? NewImage[y, x] : CurImage[y - 1, x - 1];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y - 1, x]) ? NewImage[y, x] : CurImage[y - 1, x];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y - 1, x + 1]) ? NewImage[y, x] : CurImage[y - 1, x + 1];

                        NewImage[y, x] = (NewImage[y, x] < CurImage[y, x - 1]) ? NewImage[y, x] : CurImage[y, x - 1];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y, x]) ? NewImage[y, x] : CurImage[y, x];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y, x + 1]) ? NewImage[y, x] : CurImage[y, x + 1];

                        NewImage[y, x] = (NewImage[y, x] < CurImage[y + 1, x - 1]) ? NewImage[y, x] : CurImage[y + 1, x - 1];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y + 1, x]) ? NewImage[y, x] : CurImage[y + 1, x];
                        NewImage[y, x] = (NewImage[y, x] < CurImage[y + 1, x + 1]) ? NewImage[y, x] : CurImage[y + 1, x + 1];

                        if (min > NewImage[y, x])
                            min = NewImage[y, x];
                        if (max < NewImage[y, x])
                            max = NewImage[y, x];
                    }
                for (int y = 0; y < Height; y++)
                {
                    NewImage[y, 0] = NewImage[y, 1];
                    NewImage[y, (Width - 1)] = NewImage[y, (Width - 2)];
                }
                for (int x = 0; x < Width; x++)
                {
                    NewImage[0, x] = NewImage[1, x];
                    NewImage[(Height - 1), x] = NewImage[(Height - 2), x];
                }
            }
            return (max + min) / 2;

        }
        private double Dilation(double[,] CurImage, double[,] NewImage, int Width, int Height)
        {
            //по изображению
            double max = 0;
            double min = 255;
            int lHeight = Height - 2;
            int lWidth = Width - 2;
            int llHeight = Height - 1;
            int llWidth = Width - 1;
            if (filterLen == 5)
            {
                for (int y = 2; y < lHeight; y++)
                    for (int x = 2; x < lWidth; x++)
                    {
                        NewImage[y, x] = 0;
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 2, x - 2]) ? NewImage[y, x] : CurImage[y - 2, x - 2];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 2, x - 1]) ? NewImage[y, x] : CurImage[y - 2, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 2, x]) ? NewImage[y, x] : CurImage[y - 2, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 2, x + 1]) ? NewImage[y, x] : CurImage[y - 2, x + 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 2, x + 2]) ? NewImage[y, x] : CurImage[y - 2, x + 2];

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x - 2]) ? NewImage[y, x] : CurImage[y - 1, x - 2];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x - 1]) ? NewImage[y, x] : CurImage[y - 1, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x]) ? NewImage[y, x] : CurImage[y - 1, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x + 1]) ? NewImage[y, x] : CurImage[y - 1, x + 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x + 2]) ? NewImage[y, x] : CurImage[y - 1, x + 2];

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x - 2]) ? NewImage[y, x] : CurImage[y, x - 2];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x - 1]) ? NewImage[y, x] : CurImage[y, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x]) ? NewImage[y, x] : CurImage[y, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x + 1]) ? NewImage[y, x] : CurImage[y, x + 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x + 2]) ? NewImage[y, x] : CurImage[y, x + 2];

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x - 2]) ? NewImage[y, x] : CurImage[y + 1, x - 2];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x - 1]) ? NewImage[y, x] : CurImage[y + 1, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x]) ? NewImage[y, x] : CurImage[y + 1, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x + 1]) ? NewImage[y, x] : CurImage[y + 1, x + 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x + 2]) ? NewImage[y, x] : CurImage[y + 1, x + 2];

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 2, x - 2]) ? NewImage[y, x] : CurImage[y + 2, x - 2];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 2, x - 1]) ? NewImage[y, x] : CurImage[y + 2, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 2, x]) ? NewImage[y, x] : CurImage[y + 2, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 2, x + 1]) ? NewImage[y, x] : CurImage[y + 2, x + 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 2, x + 2]) ? NewImage[y, x] : CurImage[y + 2, x + 2];

                        if (min > NewImage[y, x])
                            min = NewImage[y, x];
                        if (max < NewImage[y, x])
                            max = NewImage[y, x];
                    }
                for (int y = 0; y < Height; y++)
                {
                    NewImage[y, 0] = NewImage[y, 1] = NewImage[y, 2];
                    NewImage[y, (Width - 1)] = NewImage[y, (Width - 2)] = NewImage[y, (Width - 3)];
                }
                for (int x = 0; x < Width; x++)
                {
                    NewImage[0, x] = NewImage[1, x] = NewImage[2, x];
                    NewImage[(Height - 1), x] = NewImage[(Height - 2), x] = NewImage[(Height - 3), x];
                }
            }
            else
            {
                for (int y = 1; y < lHeight; y++)
                    for (int x = 1; x < lWidth; x++)
                    {
                        NewImage[y, x] = 0;

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x - 1]) ? NewImage[y, x] : CurImage[y - 1, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x]) ? NewImage[y, x] : CurImage[y - 1, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y - 1, x + 1]) ? NewImage[y, x] : CurImage[y - 1, x + 1];

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x - 1]) ? NewImage[y, x] : CurImage[y, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x]) ? NewImage[y, x] : CurImage[y, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y, x + 1]) ? NewImage[y, x] : CurImage[y, x + 1];

                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x - 1]) ? NewImage[y, x] : CurImage[y + 1, x - 1];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x]) ? NewImage[y, x] : CurImage[y + 1, x];
                        NewImage[y, x] = (NewImage[y, x] > CurImage[y + 1, x + 1]) ? NewImage[y, x] : CurImage[y + 1, x + 1];

                        if (min > NewImage[y, x])
                            min = NewImage[y, x];
                        if (max < NewImage[y, x])
                            max = NewImage[y, x];
                    }
                for (int y = 0; y < Height; y++)
                {
                    NewImage[y, 0] = NewImage[y, 1];
                    NewImage[y, (Width - 1)] = NewImage[y, (Width - 2)];
                }
                for (int x = 0; x < Width; x++)
                {
                    NewImage[0, x] = NewImage[1, x];
                    NewImage[(Height - 1), x] = NewImage[(Height - 2), x];
                }
            }
            return (max + min) / 2;
        }
        private double Equalization(double[,] CurImage, double[,] NewImage, int Width, int Height)
        {
            double[] histogram = new double[256];
            //по изображению
            double max = 0;
            double min = 255;
            double size = Width * Height;
            for (int i = 0; i < 256; i++)
            {
                histogram[i] = 0;
            }
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    histogram[(int)CurImage[y, x]]++;
                }
            for (int i = 1; i < 256; i++)
            {
                histogram[i] += histogram[i - 1];
            }
            for (int i = 0; i < 256; i++)
            {
                histogram[i] *= 255;
                histogram[i] /= size;
            }
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    NewImage[y, x] = histogram[(int)CurImage[y, x]];
                    if (NewImage[y, x] > 255)
                        NewImage[y, x] = 255;
                }
            min = histogram[0];
            max = histogram[255];
            return (max + min) / 2;
        }
        private int numOfSimpleFilters;
        double[] mainHistogram;
    }
}

