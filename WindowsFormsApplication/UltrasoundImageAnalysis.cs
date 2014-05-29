using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class UltrasoundImageAnalysis : Form
    {
        /// <summary>
        /// for current single image
        /// </summary>
        private Bitmap bitmap;
        private String imName;
        private bool extractionPaintFlag = false;
        private bool extractionFlag = false;
        private bool contourEnteredFlag = false;
        private Point previousPoint;
        private Point endPoint;
        private Pen penRect;
        private Pen penContour;
        private int count = 1;
        //contour building
        private Processing imProcessing;
        private Contour plContour;
        private bool contourFlag;
        private bool editContourFlag;
        //edit contour
        private int[,] plan;
        private Point edPoint;
        private int movIndex;
        private bool movingEditFlag;
        private Coloring coloring;
        private int numOfContourPoints = 10;
        //histograms
        private double[] hist;
        private double maxHistValue = 0;
        private Bitmap histMainBitmap;
        private Bitmap subImageRectSelection;
        private double[] histRectSelection;
        private double maxRectSelectionHistValue = 0;
        private Bitmap histMainBitmapRectSelection;

        public UltrasoundImageAnalysis()
        {
            InitializeComponent();
            penRect = new Pen(new SolidBrush(Color.Black));
            penContour = new Pen(new SolidBrush(Color.DarkRed));
            contourFlag = false;
            movingEditFlag = false;
            saveImageToolStripMenuItem.Enabled = false;
            saveImageWithAllDataToolStripMenuItem.Enabled = false;
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                string nameOfFile = openFileDialogImage.FileName;
                try
                {
                    bitmap = new Bitmap(nameOfFile);
                    imProcessing = new Processing(new Bitmap(nameOfFile));
                    initialisePlan(bitmap.Width, bitmap.Height);
                    pictureBoxMainImage.Image = bitmap;
                    contourFlag = false;
                    movingEditFlag = false;

                    buttonRectangularSelection.Enabled = true;
                    buttonDrawContour.Enabled = false;
                    buttonColoring.Enabled = false;
                    buttonSelectBrightness.Enabled = false;
                    buttonZoomOutImage.Enabled = false;
                    buttonZoomInImage.Enabled = false;
                    listBoxPercentage.Items.Clear();
                    labelHistogramOfCurrentImage.Visible = true;
                    panelHistogrammOfCurrentImage.Visible = true;
                    labelHistogramOfSelectedFragment.Visible = false;
                    panelHistogramOfSelectedFragment.Visible = false;
                    labelPercentage.Visible = false;
                    listBoxPercentage.Visible = false;
                    paintHistogram(Coloring.calculateHistogram(bitmap), 
                        Coloring.calculateMaxHistogramValue(Coloring.calculateHistogram(bitmap)),
                        pictureBoxCurrentImageHistogram, histMainBitmap);
                    pictureBoxCurrentImageHistogram.Invalidate();
                }
                catch (Exception exc)
                {
                    imName = "";
                }
                imName = openFileDialogImage.FileName;
            }
        }

        private void buttonRectangularSelection_Click(object sender, EventArgs e)
        {
            extractionFlag = true;
            buttonDrawContour.Enabled = false;
            if (!labelHistogramOfSelectedFragment.Visible)
                pictureBoxRectangularFragmentHistogram.Image = null;
            labelHistogramOfSelectedFragment.Visible = true;
            panelHistogramOfSelectedFragment.Visible = true;
        }

        private void buttonDrawContour_Click(object sender, EventArgs e)
        {
            extractionFlag = false;
            buttonDrawContour.Enabled = false;
            buttonRectangularSelection.Enabled = false;
            imProcessing.AddFilterToList(23);
            imProcessing.AddFilterToList(17);
            imProcessing.AddFilterToList(29);
            imProcessing.AddFilterToList(33);
            imProcessing.AddFilterToList(30);
            imProcessing.AddFilterToList(23);
            imProcessing.AddFilterToList(31);
            imProcessing.AddFilterToList(25);
            bitmap = imProcessing.ApplyChain();
            pictureBoxMainImage.Load(imName);
            plContour = imProcessing.SelectContour(numOfContourPoints);
            contourFlag = true;
            pictureBoxMainImage.Refresh();
            Graphics gr = pictureBoxMainImage.CreateGraphics();
            for (int i = (plContour.GetNumOfPoint() - 1); i > 0; i--)
                gr.DrawLine(penContour, plContour.GetPointByIndex(i), plContour.GetPointByIndex(i - 1));
            gr.DrawLine(penContour, plContour.GetPointByIndex(0), plContour.GetPointByIndex(plContour.GetNumOfPoint() - 1));

            editContourFlag = true;
            int x, y;
            for (int i = (plContour.GetNumOfPoint() - 1); i >= 0; i--)
            {
                x = plContour.GetPointByIndex(i).X;
                y = plContour.GetPointByIndex(i).Y;
                gr.DrawRectangle(penContour, x - 2, y - 2, 4, 4);
                plan[x - 2, y - 2] = i;
                plan[x - 1, y - 2] = i;
                plan[x, y - 2] = i;
                plan[x + 1, y - 2] = i;
                plan[x - 2, y - 1] = i;
                plan[x - 1, y - 1] = i;
                plan[x, y - 1] = i;
                plan[x + 1, y - 1] = i;
                plan[x - 2, y] = i;
                plan[x - 1, y] = i;
                plan[x, y] = i;
                plan[x + 1, y] = i;
                plan[x - 2, y + 1] = i;
                plan[x - 1, y + 1] = i;
                plan[x, y + 1] = i;
                plan[x + 1, y + 1] = i;
            }
            buttonColoring.Enabled = true;
        }

        private void buttonColoring_Click(object sender, EventArgs e)
        {
            buttonDrawContour.Enabled = false;
            editContourFlag = false;
            coloring = new Coloring(bitmap, plContour);
            bitmap = coloring.ColoringBitmap();
            pictureBoxMainImage.Image = bitmap;
    //        coloring.CalculateHistogramAndPercents((int)numericUpDown.Value);
            buttonColoring.Enabled = false;
   //         calculateButton.Enabled = true;
   //         saveToolStripMenuItem.Enabled = true;
            listBoxPercentage.Items.Clear();
            coloring.CalculateHistogramAndPercents(4);
            for (int i = 0; i < coloring.GetPercentsPartsNum(); i++)
                listBoxPercentage.Items.Add("        " + coloring.GetIntervalOfPart(i) + " - " + (Math.Round(coloring.GetPercents(i) * 100) / 100).ToString() + "%");
            //savePercentageToolStripMenuItem.Enabled = true;
            //saveAllToolStripMenuItem.Enabled = true;
            labelPercentage.Visible = true;
            listBoxPercentage.Visible = true;
            tabControlParameters.Update();
            this.Refresh();
            this.Invalidate();
        }

        private void buttonSelectBrightness_Click(object sender, EventArgs e)
        {

        }

        private void buttonZoomOutImage_Click(object sender, EventArgs e)
        {

        }

        private void buttonZoomInImage_Click(object sender, EventArgs e)
        {
            ///Graphics gr = Graphics.FromImage(pictureBox1.Image);
            //увеличиваем в 4 раза
            ///gr.ScaleTransform(1 * 4, 1 * 4);
        }
        //backgroung plan for contour, if plan value > 0
        //it indicates dot of contour
        private void initialisePlan(int width, int height)
        {
            plan = new int[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    plan[i, j] = -1;
        }

        private bool updatePlan(Point prevPoint, Point newPoint)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if ((plan[newPoint.X - 2 + i, newPoint.Y - 2 + j] > 0) && (plan[newPoint.X - 2 + i, newPoint.Y - 2 + j] != movIndex))
                    {
                        this.pictureBoxMainImage.Refresh();
                        return false;
                    }
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    plan[previousPoint.X - 2 + i, previousPoint.Y - 2 + j] = -1;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    plan[newPoint.X - 2 + i, newPoint.Y - 2 + j] = movIndex;
            return true;
        }

        private void pictureBoxMainImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (extractionFlag)
            {
                pictureBoxMainImage.Invalidate();
                previousPoint = e.Location;
                extractionPaintFlag = true;
            }
            if (editContourFlag)
            {
                if (plan[e.X, e.Y] >= 0)
                {
                    movingEditFlag = true;
                    movIndex = plan[e.X, e.Y];
                }
            }
        }

        private void pictureBoxMainImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (extractionFlag)
            {
                if ((e.X < bitmap.Width) && (e.X > 0) && (e.Y > 0) && (e.Y < bitmap.Height))
                {
                    Graphics gr = pictureBoxMainImage.CreateGraphics();
                    if ((previousPoint.X < e.X) && (e.Y > previousPoint.Y))
                    {
                        gr.DrawRectangle(penRect, previousPoint.X, previousPoint.Y, e.X - previousPoint.X, e.Y - previousPoint.Y);
                        subImageRectSelection = Coloring.RectangleCut(previousPoint.X, previousPoint.Y, 
                            e.X - previousPoint.X, e.Y - previousPoint.Y, bitmap);
                        paintHistogram(Coloring.calculateHistogram(subImageRectSelection),
                        Coloring.calculateMaxHistogramValue(Coloring.calculateHistogram(subImageRectSelection)),
                        pictureBoxRectangularFragmentHistogram, histMainBitmapRectSelection);
                    }
                    else
                        if ((previousPoint.X < e.X) && (e.Y < previousPoint.Y))
                        {
                            gr.DrawRectangle(penRect, previousPoint.X, e.Y, e.X - previousPoint.X, previousPoint.Y - e.Y);
                            subImageRectSelection = Coloring.RectangleCut(previousPoint.X, e.Y,
                                e.X - previousPoint.X, previousPoint.Y - e.Y, bitmap);
                            paintHistogram(Coloring.calculateHistogram(subImageRectSelection),
                            Coloring.calculateMaxHistogramValue(Coloring.calculateHistogram(subImageRectSelection)),
                            pictureBoxRectangularFragmentHistogram, histMainBitmapRectSelection);
                        }
                        else
                            if ((previousPoint.X > e.X) && (e.Y < previousPoint.Y))
                            {
                                gr.DrawRectangle(penRect, e.X, e.Y, previousPoint.X - e.X, previousPoint.Y - e.Y);
                                subImageRectSelection = Coloring.RectangleCut(e.X, e.Y, previousPoint.X - e.X,
                                    previousPoint.Y - e.Y, bitmap);
                                paintHistogram(Coloring.calculateHistogram(subImageRectSelection),
                                Coloring.calculateMaxHistogramValue(Coloring.calculateHistogram(subImageRectSelection)),
                                pictureBoxRectangularFragmentHistogram, histMainBitmapRectSelection);
                            }
                            else
                            {
                                gr.DrawRectangle(penRect, e.X, previousPoint.Y, previousPoint.X - e.X, e.Y - previousPoint.Y);
                                subImageRectSelection = Coloring.RectangleCut(e.X, previousPoint.Y,
                                    previousPoint.X - e.X, e.Y - previousPoint.Y, bitmap);
                                paintHistogram(Coloring.calculateHistogram(subImageRectSelection),
                                Coloring.calculateMaxHistogramValue(Coloring.calculateHistogram(subImageRectSelection)),
                                pictureBoxRectangularFragmentHistogram, histMainBitmapRectSelection);
                            }
                    gr.Dispose();
                    endPoint = e.Location;
                    contourEnteredFlag = true;
                    extractionPaintFlag = false;
                    buttonRectangularSelection.Focus();
                    count = 1;
                }
                else
                {
                    Graphics gr = pictureBoxMainImage.CreateGraphics();
                    if ((previousPoint.X < endPoint.X) && (endPoint.Y > previousPoint.Y))
                    {
                        gr.DrawRectangle(penRect, previousPoint.X, previousPoint.Y, endPoint.X - previousPoint.X, endPoint.Y - previousPoint.Y);
                        subImageRectSelection = Coloring.RectangleCut(previousPoint.X, previousPoint.Y,
                            endPoint.X - previousPoint.X, endPoint.Y - previousPoint.Y, bitmap);
                        paintHistogram(Coloring.calculateHistogram(subImageRectSelection),
                        Coloring.calculateMaxHistogramValue(Coloring.calculateHistogram(subImageRectSelection)),
                        pictureBoxRectangularFragmentHistogram, histMainBitmapRectSelection);
                    }
                    else
                        if ((previousPoint.X < endPoint.X) && (endPoint.Y < previousPoint.Y))
                        {
                            gr.DrawRectangle(penRect, previousPoint.X, endPoint.Y, endPoint.X - previousPoint.X, previousPoint.Y - endPoint.Y);
                            subImageRectSelection = Coloring.RectangleCut(previousPoint.X, endPoint.Y,
                                endPoint.X - previousPoint.X, previousPoint.Y - endPoint.Y, bitmap);
                            paintHistogram(Coloring.calculateHistogram(subImageRectSelection),
                            Coloring.calculateMaxHistogramValue(Coloring.calculateHistogram(subImageRectSelection)),
                            pictureBoxRectangularFragmentHistogram, histMainBitmapRectSelection);
                        }
                        else
                            if ((previousPoint.X > endPoint.X) && (endPoint.Y < previousPoint.Y))
                            {
                                gr.DrawRectangle(penRect, endPoint.X, endPoint.Y, previousPoint.X - endPoint.X, previousPoint.Y - endPoint.Y);
                                subImageRectSelection = Coloring.RectangleCut(endPoint.X, endPoint.Y,
                                    previousPoint.X - endPoint.X, previousPoint.Y - endPoint.Y, bitmap);
                                paintHistogram(Coloring.calculateHistogram(subImageRectSelection),
                                Coloring.calculateMaxHistogramValue(Coloring.calculateHistogram(subImageRectSelection)),
                                pictureBoxRectangularFragmentHistogram, histMainBitmapRectSelection);
                            }
                            else
                            {
                                gr.DrawRectangle(penRect, endPoint.X, previousPoint.Y, previousPoint.X - endPoint.X, endPoint.Y - previousPoint.Y);
                                subImageRectSelection = Coloring.RectangleCut(endPoint.X, previousPoint.Y,
                                    previousPoint.X - endPoint.X, endPoint.Y - previousPoint.Y, bitmap);
                                paintHistogram(Coloring.calculateHistogram(subImageRectSelection),
                                Coloring.calculateMaxHistogramValue(Coloring.calculateHistogram(subImageRectSelection)),
                                pictureBoxRectangularFragmentHistogram, histMainBitmapRectSelection);
                            }
                    gr.Dispose();
                    contourEnteredFlag = true;
                    extractionPaintFlag = false;
                    count = 1;
                    buttonRectangularSelection.Focus();
                }
            }
            if (movingEditFlag)
            {
                if (updatePlan(plContour.GetPointByIndex(movIndex), edPoint))
                {
                    plContour.ChangePointByIndex(movIndex, edPoint);
                }
                else
                {
                    updateConourEdit();
                }
                contourFlag = true;
                movingEditFlag = false;
            }
        }

        private void pictureBoxMainImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (extractionFlag && extractionPaintFlag && (e.Button == MouseButtons.Left) && ((e.X < bitmap.Width) && (e.X > 0) && (e.Y > 0) && (e.Y < bitmap.Height)))
            {
                pictureBoxMainImage.Refresh();
                Graphics gr = pictureBoxMainImage.CreateGraphics();
                if ((previousPoint.X < e.X) && (e.Y > previousPoint.Y))
                    gr.DrawRectangle(penRect, previousPoint.X, previousPoint.Y, e.X - previousPoint.X, e.Y - previousPoint.Y);
                else
                    if ((previousPoint.X < e.X) && (e.Y < previousPoint.Y))
                        gr.DrawRectangle(penRect, previousPoint.X, e.Y, e.X - previousPoint.X, previousPoint.Y - e.Y);
                    else
                        if ((previousPoint.X > e.X) && (e.Y < previousPoint.Y))
                            gr.DrawRectangle(penRect, e.X, e.Y, previousPoint.X - e.X, previousPoint.Y - e.Y);
                        else
                            gr.DrawRectangle(penRect, e.X, previousPoint.Y, previousPoint.X - e.X, e.Y - previousPoint.Y);
                endPoint = e.Location;
            }
            if (movingEditFlag && (e.Button == MouseButtons.Left) && ((e.X < bitmap.Width) && (e.X > 0) && (e.Y > 0) && (e.Y < bitmap.Height)))
            {
                edPoint = e.Location;
                pictureBoxMainImage.Refresh();
                Graphics gr = pictureBoxMainImage.CreateGraphics();
                for (int i = (plContour.GetNumOfPoint() - 1); i > (movIndex + 1); i--)
                {
                    gr.DrawLine(penContour, plContour.GetPointByIndex(i), plContour.GetPointByIndex(i - 1));
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(i).X - 2, plContour.GetPointByIndex(i).Y - 2, 4, 4);
                }
                for (int i = (movIndex - 1); i > 0; i--)
                {
                    gr.DrawLine(penContour, plContour.GetPointByIndex(i), plContour.GetPointByIndex(i - 1));
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(i).X - 2, plContour.GetPointByIndex(i).Y - 2, 4, 4);
                }
                if (movIndex > 0 && movIndex < (plContour.GetNumOfPoint() - 1))
                {
                    gr.DrawLine(penContour, plContour.GetPointByIndex(0), plContour.GetPointByIndex(plContour.GetNumOfPoint() - 1));
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(0).X - 2, plContour.GetPointByIndex(0).Y - 2, 4, 4);
                }
                if (movIndex > 0)
                {
                    gr.DrawLine(penContour, plContour.GetPointByIndex(movIndex - 1), edPoint);
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(movIndex - 1).X - 2, plContour.GetPointByIndex(movIndex - 1).Y - 2, 4, 4);
                }
                else
                {
                    gr.DrawLine(penContour, plContour.GetPointByIndex(plContour.GetNumOfPoint() - 1), edPoint);
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(plContour.GetNumOfPoint() - 1).X - 2, plContour.GetPointByIndex(plContour.GetNumOfPoint() - 1).Y - 2, 4, 4);
                }
                if (movIndex == (plContour.GetNumOfPoint() - 1))
                {
                    gr.DrawLine(penContour, edPoint, plContour.GetPointByIndex(0));
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(0).X - 2, plContour.GetPointByIndex(0).Y - 2, 4, 4);
                }
                else
                {
                    gr.DrawLine(penContour, edPoint, plContour.GetPointByIndex(movIndex + 1));
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(movIndex + 1).X - 2, plContour.GetPointByIndex(movIndex + 1).Y - 2, 4, 4);
                }
                gr.DrawRectangle(penContour, edPoint.X - 2, edPoint.Y - 2, 4, 4);
                //pictureBoxMainImage.Refresh();
            }
        }

        private void pictureBoxMainImage_Paint(object sender, PaintEventArgs e)
        {
            if (extractionFlag)
            {

            }
            if (contourFlag && (!movingEditFlag))
            {
                Graphics gr = pictureBoxMainImage.CreateGraphics();
                for (int i = (plContour.GetNumOfPoint() - 1); i > 0; i--)
                    gr.DrawLine(penContour, plContour.GetPointByIndex(i), plContour.GetPointByIndex(i - 1));
                gr.DrawLine(penContour, plContour.GetPointByIndex(0), plContour.GetPointByIndex(plContour.GetNumOfPoint() - 1));
                if (editContourFlag)
                    for (int i = plContour.GetNumOfPoint(); i >= 0; i--)
                        gr.DrawRectangle(penContour, plContour.GetPointByIndex(i).X - 2, plContour.GetPointByIndex(i).Y - 2, 4, 4);

            }
            if (movingEditFlag)
            {
                Graphics gr = pictureBoxMainImage.CreateGraphics();
                for (int i = (plContour.GetNumOfPoint() - 1); i > (movIndex + 1); i--)
                {
                    gr.DrawLine(penContour, plContour.GetPointByIndex(i), plContour.GetPointByIndex(i - 1));
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(i).X - 2, plContour.GetPointByIndex(i).Y - 2, 4, 4);
                }
                for (int i = (movIndex - 1); i > 0; i--)
                {
                    gr.DrawLine(penContour, plContour.GetPointByIndex(i), plContour.GetPointByIndex(i - 1));
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(i).X - 2, plContour.GetPointByIndex(i).Y - 2, 4, 4);
                }
                if (movIndex > 0 && (movIndex < (plContour.GetNumOfPoint() - 1)))
                {
                    gr.DrawLine(penContour, plContour.GetPointByIndex(0), plContour.GetPointByIndex(plContour.GetNumOfPoint() - 1));
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(0).X - 2, plContour.GetPointByIndex(0).Y - 2, 4, 4);
                }
                if (movIndex > 0)
                {
                    gr.DrawLine(penContour, plContour.GetPointByIndex(movIndex - 1), edPoint);
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(movIndex - 1).X - 2, plContour.GetPointByIndex(movIndex - 1).Y - 2, 4, 4);
                }
                else
                {
                    gr.DrawLine(penContour, plContour.GetPointByIndex(plContour.GetNumOfPoint() - 1), edPoint);
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(plContour.GetNumOfPoint() - 1).X - 2, plContour.GetPointByIndex(plContour.GetNumOfPoint() - 1).Y - 2, 4, 4);
                }
                if (movIndex == (plContour.GetNumOfPoint() - 1))
                {
                    gr.DrawLine(penContour, edPoint, plContour.GetPointByIndex(0));
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(0).X - 2, plContour.GetPointByIndex(0).Y - 2, 4, 4);
                }
                else
                {
                    gr.DrawLine(penContour, edPoint, plContour.GetPointByIndex(movIndex + 1));
                    gr.DrawRectangle(penContour, plContour.GetPointByIndex(movIndex + 1).X - 2, plContour.GetPointByIndex(movIndex + 1).Y - 2, 4, 4);
                }
                gr.DrawRectangle(penContour, edPoint.X - 2, edPoint.Y - 2, 4, 4);
            }
        }
        
        private void updateConourEdit()
        {
            Graphics gr = pictureBoxMainImage.CreateGraphics();
            int x, y;
            for (int i = (plContour.GetNumOfPoint() - 1); i > 0; i--)
                gr.DrawLine(penContour, plContour.GetPointByIndex(i), plContour.GetPointByIndex(i - 1));
            gr.DrawLine(penContour, plContour.GetPointByIndex(0), plContour.GetPointByIndex(plContour.GetNumOfPoint() - 1));
            for (int i = (plContour.GetNumOfPoint() - 1); i >= 0; i--)
            {
                x = plContour.GetPointByIndex(i).X;
                y = plContour.GetPointByIndex(i).Y;
                gr.DrawRectangle(penContour, x - 2, y - 2, 4, 4);
                plan[x - 2, y - 2] = i;
                plan[x - 1, y - 2] = i;
                plan[x, y - 2] = i;
                plan[x + 1, y - 2] = i;
                plan[x - 2, y - 1] = i;
                plan[x - 1, y - 1] = i;
                plan[x, y - 1] = i;
                plan[x + 1, y - 1] = i;
                plan[x - 2, y] = i;
                plan[x - 1, y] = i;
                plan[x, y] = i;
                plan[x + 1, y] = i;
                plan[x - 2, y + 1] = i;
                plan[x - 1, y + 1] = i;
                plan[x, y + 1] = i;
                plan[x + 1, y + 1] = i;
            }
        }

        private void buttonRectangularSelection_KeyUp(object sender, KeyEventArgs e)
        {
            if (contourEnteredFlag && e.KeyCode == Keys.Enter)
            {
                buttonRectangularSelection.Enabled = false;
                extractionFlag = false;
                if ((previousPoint.X < endPoint.X) && (endPoint.Y > previousPoint.Y))
                    bitmap = imProcessing.RectangleCut(previousPoint.X, previousPoint.Y, endPoint.X - previousPoint.X, endPoint.Y - previousPoint.Y, bitmap);

                else
                    if ((previousPoint.X < endPoint.X) && (endPoint.Y < previousPoint.Y))
                    {
                        bitmap = imProcessing.RectangleCut(previousPoint.X, endPoint.Y, endPoint.X - previousPoint.X, previousPoint.Y - endPoint.Y, bitmap);
                    }
                    else
                    {
                        if ((previousPoint.X > endPoint.X) && (endPoint.Y < previousPoint.Y))
                            bitmap = imProcessing.RectangleCut(endPoint.X, endPoint.Y, previousPoint.X - endPoint.X, previousPoint.Y - endPoint.Y, bitmap);
                        else
                            bitmap = imProcessing.RectangleCut(endPoint.X, previousPoint.Y, previousPoint.X - endPoint.X, endPoint.Y - previousPoint.Y, bitmap);
                    }
                buttonDrawContour.Enabled = true;
                buttonRectangularSelection.Enabled = false;
                contourEnteredFlag = false;
            }
        }

        private void paintHistogram(double[] Histogram, double maxHistogramValue, PictureBox PicBox, Bitmap histBitmap)
        {
            histBitmap = new Bitmap(PicBox.Width, PicBox.Height);
            Graphics g = Graphics.FromImage(histBitmap);
            //Graphics g = PicBox.CreateGraphics();
            int histLen = Histogram.Length;
            int xAxesLength = PicBox.Width;
            int yAxesLength = PicBox.Height;
            int xField = xAxesLength / 20;
            int yField = yAxesLength / 20;
            int histXAxesLength = xAxesLength - xField - xField;
            int histYAxesLength = yAxesLength - yField - yField;
            double proportionInX = (double)(histLen) / (double)(histXAxesLength);
            double proportionInY;
            proportionInY = (maxHistogramValue > 0) ? ((1.0) / maxHistogramValue) : 0;
            Color color = Color.Black;
            Pen pen = new Pen(color, 1);
            for (int i = 0; i < histXAxesLength; i++)
            {
                g.DrawLine(pen, new Point(i + xField, 
                    yAxesLength - yField - (int)(proportionInY * histYAxesLength * Histogram[(int)(i * proportionInX)])),
                    new Point(i + xField, yAxesLength - yField));
            }
            g.DrawLine(pen, new Point(xField - 2, yField), new Point(xField - 2, yAxesLength - yField + 2));
            g.DrawLine(pen, new Point(xField - 2, yAxesLength - yField + 2), 
                new Point(histXAxesLength + xField - 2, yAxesLength - yField + 2));
            PicBox.Image = histBitmap;
        }
        
        private void pictureBoxCurrentImageHistogram_Paint(object sender, PaintEventArgs e)
        {/*
            if (hist != null)
            {
                pictureBoxCurrentImageHistogram.Image = histMainBitmap;
                //paintHistogram(hist, maxHistValue, pictureBoxCurrentImageHistogram);
            }
            else
            {
                hist = Coloring.calculateHistogram(bitmap);
                maxHistValue = Coloring.calculateMaxHistogramValue(hist);
                paintHistogram(hist, maxHistValue, pictureBoxCurrentImageHistogram, histMainBitmap);
            }*/
        }
    }
}
