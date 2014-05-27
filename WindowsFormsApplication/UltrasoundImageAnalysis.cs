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
        private Point previousPoint;
        private Point endPoint;
        private Pen penRect;
        private Pen penContour;
        private int count = 1;
        //contour building
        //private Processing imProcessing;
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
                    //imProcessing = new Processing(new Bitmap(nameOfFile));
                    //initialisePlan(bitmap.Width, bitmap.Height);
                    pictureBoxMainImage.Image = bitmap;
                    contourFlag = false;
                    movingEditFlag = false;

                    buttonRectangularSelection.Enabled = true;
                    buttonDrawContour.Enabled = false;
                    buttonColoring.Enabled = false;
                    buttonSelectBrightness.Enabled = false;
                    buttonZoomOutImage.Enabled = false;
                    buttonZoomInImage.Enabled = false;
                    //percentageListBox.Items.Clear();
                }
                catch (Exception exc)
                {
                    imName = "";
                }
                imName = openFileDialogImage.FileName;
            }
        }
    }
}
