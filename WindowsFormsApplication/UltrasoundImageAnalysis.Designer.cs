namespace WindowsFormsApplication
{
    partial class UltrasoundImageAnalysis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UltrasoundImageAnalysis));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSelectBrightness = new System.Windows.Forms.Button();
            this.buttonZoomOutImage = new System.Windows.Forms.Button();
            this.buttonZoomInImage = new System.Windows.Forms.Button();
            this.buttonRectangularSelection = new System.Windows.Forms.Button();
            this.buttonColoring = new System.Windows.Forms.Button();
            this.buttonDrawContour = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageWithAllDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControlParameters = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelHistogramOfSelectedFragment = new System.Windows.Forms.Label();
            this.labelHistogramOfCurrentImage = new System.Windows.Forms.Label();
            this.panelHistogramOfSelectedFragment = new System.Windows.Forms.Panel();
            this.listBoxPercentage = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelPercentage = new System.Windows.Forms.Label();
            this.panelHistogrammOfCurrentImage = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.tabControlMainImage = new System.Windows.Forms.TabControl();
            this.tabPageCurrentImage = new System.Windows.Forms.TabPage();
            this.pictureBoxMainImage = new System.Windows.Forms.PictureBox();
            this.tabPageImagesList = new System.Windows.Forms.TabPage();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBoxCurrentImageHistogram = new System.Windows.Forms.PictureBox();
            this.pictureBoxRectangularFragmentHistogram = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabControlParameters.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelHistogramOfSelectedFragment.SuspendLayout();
            this.panelHistogrammOfCurrentImage.SuspendLayout();
            this.tabControlMainImage.SuspendLayout();
            this.tabPageCurrentImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentImageHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRectangularFragmentHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.buttonSelectBrightness);
            this.panel1.Controls.Add(this.buttonZoomOutImage);
            this.panel1.Controls.Add(this.buttonZoomInImage);
            this.panel1.Controls.Add(this.buttonRectangularSelection);
            this.panel1.Controls.Add(this.buttonColoring);
            this.panel1.Controls.Add(this.buttonDrawContour);
            this.panel1.Location = new System.Drawing.Point(4, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(47, 262);
            this.panel1.TabIndex = 0;
            // 
            // buttonSelectBrightness
            // 
            this.buttonSelectBrightness.BackColor = System.Drawing.Color.Transparent;
            this.buttonSelectBrightness.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSelectBrightness.BackgroundImage")));
            this.buttonSelectBrightness.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSelectBrightness.Enabled = false;
            this.buttonSelectBrightness.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSelectBrightness.Location = new System.Drawing.Point(2, 130);
            this.buttonSelectBrightness.Name = "buttonSelectBrightness";
            this.buttonSelectBrightness.Size = new System.Drawing.Size(36, 36);
            this.buttonSelectBrightness.TabIndex = 4;
            this.toolTip.SetToolTip(this.buttonSelectBrightness, "Select brightness");
            this.buttonSelectBrightness.UseVisualStyleBackColor = false;
            this.buttonSelectBrightness.Click += new System.EventHandler(this.buttonSelectBrightness_Click);
            // 
            // buttonZoomOutImage
            // 
            this.buttonZoomOutImage.BackColor = System.Drawing.Color.Transparent;
            this.buttonZoomOutImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonZoomOutImage.BackgroundImage")));
            this.buttonZoomOutImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonZoomOutImage.Enabled = false;
            this.buttonZoomOutImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonZoomOutImage.Location = new System.Drawing.Point(2, 172);
            this.buttonZoomOutImage.Name = "buttonZoomOutImage";
            this.buttonZoomOutImage.Size = new System.Drawing.Size(36, 36);
            this.buttonZoomOutImage.TabIndex = 5;
            this.toolTip.SetToolTip(this.buttonZoomOutImage, "Zoom out");
            this.buttonZoomOutImage.UseVisualStyleBackColor = false;
            this.buttonZoomOutImage.Click += new System.EventHandler(this.buttonZoomOutImage_Click);
            // 
            // buttonZoomInImage
            // 
            this.buttonZoomInImage.AccessibleDescription = "";
            this.buttonZoomInImage.BackColor = System.Drawing.Color.Transparent;
            this.buttonZoomInImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonZoomInImage.BackgroundImage")));
            this.buttonZoomInImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonZoomInImage.Enabled = false;
            this.buttonZoomInImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonZoomInImage.Location = new System.Drawing.Point(2, 214);
            this.buttonZoomInImage.Name = "buttonZoomInImage";
            this.buttonZoomInImage.Size = new System.Drawing.Size(36, 36);
            this.buttonZoomInImage.TabIndex = 6;
            this.buttonZoomInImage.Tag = "";
            this.buttonZoomInImage.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonZoomInImage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip.SetToolTip(this.buttonZoomInImage, "Zoom in");
            this.buttonZoomInImage.UseCompatibleTextRendering = true;
            this.buttonZoomInImage.UseVisualStyleBackColor = true;
            this.buttonZoomInImage.Click += new System.EventHandler(this.buttonZoomInImage_Click);
            // 
            // buttonRectangularSelection
            // 
            this.buttonRectangularSelection.BackColor = System.Drawing.Color.Transparent;
            this.buttonRectangularSelection.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRectangularSelection.BackgroundImage")));
            this.buttonRectangularSelection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonRectangularSelection.Enabled = false;
            this.buttonRectangularSelection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRectangularSelection.Location = new System.Drawing.Point(2, 3);
            this.buttonRectangularSelection.Name = "buttonRectangularSelection";
            this.buttonRectangularSelection.Size = new System.Drawing.Size(36, 36);
            this.buttonRectangularSelection.TabIndex = 1;
            this.toolTip.SetToolTip(this.buttonRectangularSelection, "Rectangular selection");
            this.buttonRectangularSelection.UseVisualStyleBackColor = false;
            this.buttonRectangularSelection.Click += new System.EventHandler(this.buttonRectangularSelection_Click);
            this.buttonRectangularSelection.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonRectangularSelection_KeyUp);
            // 
            // buttonColoring
            // 
            this.buttonColoring.BackColor = System.Drawing.Color.Transparent;
            this.buttonColoring.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonColoring.BackgroundImage")));
            this.buttonColoring.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonColoring.Enabled = false;
            this.buttonColoring.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonColoring.Location = new System.Drawing.Point(2, 87);
            this.buttonColoring.Name = "buttonColoring";
            this.buttonColoring.Size = new System.Drawing.Size(36, 36);
            this.buttonColoring.TabIndex = 3;
            this.toolTip.SetToolTip(this.buttonColoring, "View in colors");
            this.buttonColoring.UseVisualStyleBackColor = false;
            this.buttonColoring.Click += new System.EventHandler(this.buttonColoring_Click);
            // 
            // buttonDrawContour
            // 
            this.buttonDrawContour.BackColor = System.Drawing.Color.Transparent;
            this.buttonDrawContour.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDrawContour.BackgroundImage")));
            this.buttonDrawContour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDrawContour.Enabled = false;
            this.buttonDrawContour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDrawContour.Location = new System.Drawing.Point(2, 45);
            this.buttonDrawContour.Name = "buttonDrawContour";
            this.buttonDrawContour.Size = new System.Drawing.Size(36, 36);
            this.buttonDrawContour.TabIndex = 2;
            this.buttonDrawContour.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonDrawContour.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolTip.SetToolTip(this.buttonDrawContour, "Draw contour");
            this.buttonDrawContour.UseVisualStyleBackColor = false;
            this.buttonDrawContour.Click += new System.EventHandler(this.buttonDrawContour_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(679, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.saveImageWithAllDataToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openImageToolStripMenuItem.Text = "Open image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openToolStripMenuItem.Text = "Open video";
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveImageToolStripMenuItem.Text = "Save image";
            // 
            // saveImageWithAllDataToolStripMenuItem
            // 
            this.saveImageWithAllDataToolStripMenuItem.Name = "saveImageWithAllDataToolStripMenuItem";
            this.saveImageWithAllDataToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveImageWithAllDataToolStripMenuItem.Text = "Save image with all data";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.helpToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip.Location = new System.Drawing.Point(0, 462);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(679, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel1.Text = "                ";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // tabControlParameters
            // 
            this.tabControlParameters.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.tabControlParameters.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlParameters.Controls.Add(this.tabPage1);
            this.tabControlParameters.Controls.Add(this.tabPage2);
            this.tabControlParameters.Location = new System.Drawing.Point(500, 27);
            this.tabControlParameters.Multiline = true;
            this.tabControlParameters.Name = "tabControlParameters";
            this.tabControlParameters.SelectedIndex = 0;
            this.tabControlParameters.Size = new System.Drawing.Size(179, 432);
            this.tabControlParameters.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.labelHistogramOfSelectedFragment);
            this.tabPage1.Controls.Add(this.labelPercentage);
            this.tabPage1.Controls.Add(this.labelHistogramOfCurrentImage);
            this.tabPage1.Controls.Add(this.panelHistogramOfSelectedFragment);
            this.tabPage1.Controls.Add(this.listBoxPercentage);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panelHistogrammOfCurrentImage);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(171, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Histograms";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelHistogramOfSelectedFragment
            // 
            this.labelHistogramOfSelectedFragment.BackColor = System.Drawing.Color.Transparent;
            this.labelHistogramOfSelectedFragment.Font = new System.Drawing.Font("Monotype Corsiva", 10F, System.Drawing.FontStyle.Italic);
            this.labelHistogramOfSelectedFragment.Location = new System.Drawing.Point(11, 146);
            this.labelHistogramOfSelectedFragment.Name = "labelHistogramOfSelectedFragment";
            this.labelHistogramOfSelectedFragment.Size = new System.Drawing.Size(151, 21);
            this.labelHistogramOfSelectedFragment.TabIndex = 14;
            this.labelHistogramOfSelectedFragment.Text = "Histogram of selected region";
            this.labelHistogramOfSelectedFragment.Visible = false;
            // 
            // labelHistogramOfCurrentImage
            // 
            this.labelHistogramOfCurrentImage.BackColor = System.Drawing.Color.Transparent;
            this.labelHistogramOfCurrentImage.Font = new System.Drawing.Font("Monotype Corsiva", 10F, System.Drawing.FontStyle.Italic);
            this.labelHistogramOfCurrentImage.Location = new System.Drawing.Point(11, 6);
            this.labelHistogramOfCurrentImage.Name = "labelHistogramOfCurrentImage";
            this.labelHistogramOfCurrentImage.Size = new System.Drawing.Size(151, 20);
            this.labelHistogramOfCurrentImage.TabIndex = 13;
            this.labelHistogramOfCurrentImage.Text = "Histogram of current image";
            this.labelHistogramOfCurrentImage.Visible = false;
            // 
            // panelHistogramOfSelectedFragment
            // 
            this.panelHistogramOfSelectedFragment.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelHistogramOfSelectedFragment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelHistogramOfSelectedFragment.Controls.Add(this.pictureBoxRectangularFragmentHistogram);
            this.panelHistogramOfSelectedFragment.Location = new System.Drawing.Point(7, 167);
            this.panelHistogramOfSelectedFragment.Name = "panelHistogramOfSelectedFragment";
            this.panelHistogramOfSelectedFragment.Size = new System.Drawing.Size(157, 108);
            this.panelHistogramOfSelectedFragment.TabIndex = 1;
            this.panelHistogramOfSelectedFragment.Visible = false;
            // 
            // listBoxPercentage
            // 
            this.listBoxPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxPercentage.Font = new System.Drawing.Font("Monotype Corsiva", 10F, System.Drawing.FontStyle.Italic);
            this.listBoxPercentage.FormattingEnabled = true;
            this.listBoxPercentage.ItemHeight = 15;
            this.listBoxPercentage.Location = new System.Drawing.Point(7, 308);
            this.listBoxPercentage.Name = "listBoxPercentage";
            this.listBoxPercentage.Size = new System.Drawing.Size(157, 77);
            this.listBoxPercentage.TabIndex = 10;
            this.toolTip.SetToolTip(this.listBoxPercentage, "100% - it\'s total area of selected fragment. \r\nFragments are colored according to" +
                    " their \r\nechogenicity.");
            this.listBoxPercentage.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(7, 369);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(136, 26);
            this.panel2.TabIndex = 2;
            this.panel2.Visible = false;
            // 
            // labelPercentage
            // 
            this.labelPercentage.BackColor = System.Drawing.Color.Transparent;
            this.labelPercentage.Font = new System.Drawing.Font("Monotype Corsiva", 10F, System.Drawing.FontStyle.Italic);
            this.labelPercentage.Location = new System.Drawing.Point(11, 286);
            this.labelPercentage.Name = "labelPercentage";
            this.labelPercentage.Size = new System.Drawing.Size(152, 19);
            this.labelPercentage.TabIndex = 12;
            this.labelPercentage.Text = "Area of each region occupies:";
            this.toolTip.SetToolTip(this.labelPercentage, "100% - it\'s total area of selected fragment. \r\nFragments are colored according to" +
                    " their \r\nechogenicity. See help for more information.");
            this.labelPercentage.Visible = false;
            // 
            // panelHistogrammOfCurrentImage
            // 
            this.panelHistogrammOfCurrentImage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelHistogrammOfCurrentImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelHistogrammOfCurrentImage.Controls.Add(this.pictureBoxCurrentImageHistogram);
            this.panelHistogrammOfCurrentImage.Location = new System.Drawing.Point(7, 28);
            this.panelHistogrammOfCurrentImage.Name = "panelHistogrammOfCurrentImage";
            this.panelHistogrammOfCurrentImage.Size = new System.Drawing.Size(157, 108);
            this.panelHistogrammOfCurrentImage.TabIndex = 0;
            this.panelHistogrammOfCurrentImage.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(171, 406);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contours";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(4, 326);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(47, 133);
            this.panel3.TabIndex = 5;
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.FileName = "ultrasound_image";
            this.openFileDialogImage.Filter = "\"JPG files (*.jpg)|*.jpg|All files (*.*)|*.*\"";
            this.openFileDialogImage.Title = "Open image";
            // 
            // tabControlMainImage
            // 
            this.tabControlMainImage.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlMainImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMainImage.Controls.Add(this.tabPageCurrentImage);
            this.tabControlMainImage.Controls.Add(this.tabPageImagesList);
            this.tabControlMainImage.Location = new System.Drawing.Point(57, 27);
            this.tabControlMainImage.Name = "tabControlMainImage";
            this.tabControlMainImage.SelectedIndex = 0;
            this.tabControlMainImage.Size = new System.Drawing.Size(437, 432);
            this.tabControlMainImage.TabIndex = 7;
            // 
            // tabPageCurrentImage
            // 
            this.tabPageCurrentImage.AutoScroll = true;
            this.tabPageCurrentImage.Controls.Add(this.pictureBoxMainImage);
            this.tabPageCurrentImage.Location = new System.Drawing.Point(4, 4);
            this.tabPageCurrentImage.Name = "tabPageCurrentImage";
            this.tabPageCurrentImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCurrentImage.Size = new System.Drawing.Size(429, 406);
            this.tabPageCurrentImage.TabIndex = 0;
            this.tabPageCurrentImage.Text = "Current Image";
            this.tabPageCurrentImage.UseVisualStyleBackColor = true;
            // 
            // pictureBoxMainImage
            // 
            this.pictureBoxMainImage.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxMainImage.Name = "pictureBoxMainImage";
            this.pictureBoxMainImage.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxMainImage.TabIndex = 0;
            this.pictureBoxMainImage.TabStop = false;
            this.pictureBoxMainImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMainImage_MouseMove);
            this.pictureBoxMainImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMainImage_MouseDown);
            this.pictureBoxMainImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMainImage_Paint);
            this.pictureBoxMainImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMainImage_MouseUp);
            // 
            // tabPageImagesList
            // 
            this.tabPageImagesList.AutoScroll = true;
            this.tabPageImagesList.Location = new System.Drawing.Point(4, 4);
            this.tabPageImagesList.Name = "tabPageImagesList";
            this.tabPageImagesList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImagesList.Size = new System.Drawing.Size(429, 406);
            this.tabPageImagesList.TabIndex = 1;
            this.tabPageImagesList.Text = "Images List";
            this.tabPageImagesList.UseVisualStyleBackColor = true;
            // 
            // pictureBoxCurrentImageHistogram
            // 
            this.pictureBoxCurrentImageHistogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCurrentImageHistogram.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCurrentImageHistogram.Name = "pictureBoxCurrentImageHistogram";
            this.pictureBoxCurrentImageHistogram.Size = new System.Drawing.Size(153, 104);
            this.pictureBoxCurrentImageHistogram.TabIndex = 0;
            this.pictureBoxCurrentImageHistogram.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBoxCurrentImageHistogram, "Histogram of current image");
            this.pictureBoxCurrentImageHistogram.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCurrentImageHistogram_Paint);
            // 
            // pictureBoxRectangularFragmentHistogram
            // 
            this.pictureBoxRectangularFragmentHistogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRectangularFragmentHistogram.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxRectangularFragmentHistogram.Name = "pictureBoxRectangularFragmentHistogram";
            this.pictureBoxRectangularFragmentHistogram.Size = new System.Drawing.Size(153, 104);
            this.pictureBoxRectangularFragmentHistogram.TabIndex = 0;
            this.pictureBoxRectangularFragmentHistogram.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBoxRectangularFragmentHistogram, "Histogram of selected region");
            // 
            // UltrasoundImageAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 484);
            this.Controls.Add(this.tabControlMainImage);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tabControlParameters);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(600, 522);
            this.Name = "UltrasoundImageAnalysis";
            this.Text = "UltrasoundImageAnalysis";
            this.panel1.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControlParameters.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelHistogramOfSelectedFragment.ResumeLayout(false);
            this.panelHistogrammOfCurrentImage.ResumeLayout(false);
            this.tabControlMainImage.ResumeLayout(false);
            this.tabPageCurrentImage.ResumeLayout(false);
            this.tabPageCurrentImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentImageHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRectangularFragmentHistogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageWithAllDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlParameters;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonColoring;
        private System.Windows.Forms.Button buttonDrawContour;
        private System.Windows.Forms.Panel panelHistogrammOfCurrentImage;
        private System.Windows.Forms.Panel panelHistogramOfSelectedFragment;
        private System.Windows.Forms.Button buttonRectangularSelection;
        private System.Windows.Forms.Button buttonSelectBrightness;
        private System.Windows.Forms.Button buttonZoomOutImage;
        private System.Windows.Forms.Button buttonZoomInImage;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControlMainImage;
        private System.Windows.Forms.TabPage tabPageCurrentImage;
        private System.Windows.Forms.TabPage tabPageImagesList;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox pictureBoxMainImage;
        private System.Windows.Forms.Label labelPercentage;
        private System.Windows.Forms.ListBox listBoxPercentage;
        private System.Windows.Forms.Label labelHistogramOfCurrentImage;
        private System.Windows.Forms.Label labelHistogramOfSelectedFragment;
        private System.Windows.Forms.PictureBox pictureBoxCurrentImageHistogram;
        private System.Windows.Forms.PictureBox pictureBoxRectangularFragmentHistogram;
    }
}

