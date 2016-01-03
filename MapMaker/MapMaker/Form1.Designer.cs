namespace MapMaker
{
    partial class mainForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuBar = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuBar = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuBar = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuBar = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMenuBar = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testButtonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridMenuBar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillFloorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floorRadioButton = new System.Windows.Forms.RadioButton();
            this.wallRadioButton = new System.Windows.Forms.RadioButton();
            this.decorRadioButton = new System.Windows.Forms.RadioButton();
            this.layerGroupBox = new System.Windows.Forms.GroupBox();
            this.eraseButton = new System.Windows.Forms.Button();
            this.currentImageDisplay = new System.Windows.Forms.PictureBox();
            this.recentTileGroupBox = new System.Windows.Forms.GroupBox();
            this.recent9 = new System.Windows.Forms.PictureBox();
            this.recent8 = new System.Windows.Forms.PictureBox();
            this.recent7 = new System.Windows.Forms.PictureBox();
            this.recent6 = new System.Windows.Forms.PictureBox();
            this.recent5 = new System.Windows.Forms.PictureBox();
            this.recent4 = new System.Windows.Forms.PictureBox();
            this.recent3 = new System.Windows.Forms.PictureBox();
            this.recent2 = new System.Windows.Forms.PictureBox();
            this.recent1 = new System.Windows.Forms.PictureBox();
            this.recent0 = new System.Windows.Forms.PictureBox();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.layerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImageDisplay)).BeginInit();
            this.recentTileGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recent9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent0)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(171, 35);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(613, 435);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // loadImageButton
            // 
            this.loadImageButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadImageButton.Location = new System.Drawing.Point(12, 174);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(111, 24);
            this.loadImageButton.TabIndex = 0;
            this.loadImageButton.TabStop = false;
            this.loadImageButton.Text = "Load Image";
            this.toolTips.SetToolTip(this.loadImageButton, "Select a tile for the map floor.");
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenuBar,
            this.openMenuBar,
            this.saveMenuBar,
            this.saveAsMenuBar,
            this.exportMenuBar});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newMenuBar
            // 
            this.newMenuBar.Name = "newMenuBar";
            this.newMenuBar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMenuBar.Size = new System.Drawing.Size(195, 22);
            this.newMenuBar.Text = "New...";
            this.newMenuBar.Click += new System.EventHandler(this.newMenuBar_Click);
            // 
            // openMenuBar
            // 
            this.openMenuBar.Name = "openMenuBar";
            this.openMenuBar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuBar.Size = new System.Drawing.Size(195, 22);
            this.openMenuBar.Text = "Open...";
            this.openMenuBar.Click += new System.EventHandler(this.openMenuBar_Click);
            // 
            // saveMenuBar
            // 
            this.saveMenuBar.Name = "saveMenuBar";
            this.saveMenuBar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuBar.Size = new System.Drawing.Size(195, 22);
            this.saveMenuBar.Text = "Save...";
            this.saveMenuBar.Click += new System.EventHandler(this.saveMenuBar_Click);
            // 
            // saveAsMenuBar
            // 
            this.saveAsMenuBar.Name = "saveAsMenuBar";
            this.saveAsMenuBar.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsMenuBar.Size = new System.Drawing.Size(195, 22);
            this.saveAsMenuBar.Text = "Save As...";
            // 
            // exportMenuBar
            // 
            this.exportMenuBar.Name = "exportMenuBar";
            this.exportMenuBar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportMenuBar.Size = new System.Drawing.Size(195, 22);
            this.exportMenuBar.Text = "Export...";
            this.exportMenuBar.Click += new System.EventHandler(this.exportMenuBar_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testButtonMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // testButtonMenuItem
            // 
            this.testButtonMenuItem.Name = "testButtonMenuItem";
            this.testButtonMenuItem.Size = new System.Drawing.Size(135, 22);
            this.testButtonMenuItem.Text = "Test Button";
            this.testButtonMenuItem.Click += new System.EventHandler(this.testButtonMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridMenuBar,
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // gridMenuBar
            // 
            this.gridMenuBar.Name = "gridMenuBar";
            this.gridMenuBar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.gridMenuBar.Size = new System.Drawing.Size(178, 22);
            this.gridMenuBar.Text = "Toggle Grid";
            this.gridMenuBar.Click += new System.EventHandler(this.gridMenuBar_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillFloorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // fillFloorToolStripMenuItem
            // 
            this.fillFloorToolStripMenuItem.Name = "fillFloorToolStripMenuItem";
            this.fillFloorToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.fillFloorToolStripMenuItem.Text = "Fill Floor...";
            this.fillFloorToolStripMenuItem.Click += new System.EventHandler(this.fillFloorToolStripMenuItem_Click);
            // 
            // floorRadioButton
            // 
            this.floorRadioButton.AutoSize = true;
            this.floorRadioButton.Checked = true;
            this.floorRadioButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.floorRadioButton.Location = new System.Drawing.Point(6, 79);
            this.floorRadioButton.Name = "floorRadioButton";
            this.floorRadioButton.Size = new System.Drawing.Size(53, 19);
            this.floorRadioButton.TabIndex = 4;
            this.floorRadioButton.TabStop = true;
            this.floorRadioButton.Text = "Floor";
            this.floorRadioButton.UseVisualStyleBackColor = true;
            // 
            // wallRadioButton
            // 
            this.wallRadioButton.AutoSize = true;
            this.wallRadioButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallRadioButton.Location = new System.Drawing.Point(6, 54);
            this.wallRadioButton.Name = "wallRadioButton";
            this.wallRadioButton.Size = new System.Drawing.Size(50, 19);
            this.wallRadioButton.TabIndex = 5;
            this.wallRadioButton.Text = "Wall";
            this.wallRadioButton.UseVisualStyleBackColor = true;
            // 
            // decorRadioButton
            // 
            this.decorRadioButton.AutoSize = true;
            this.decorRadioButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decorRadioButton.Location = new System.Drawing.Point(6, 29);
            this.decorRadioButton.Name = "decorRadioButton";
            this.decorRadioButton.Size = new System.Drawing.Size(59, 19);
            this.decorRadioButton.TabIndex = 6;
            this.decorRadioButton.Text = "Decor";
            this.decorRadioButton.UseVisualStyleBackColor = true;
            // 
            // layerGroupBox
            // 
            this.layerGroupBox.Controls.Add(this.floorRadioButton);
            this.layerGroupBox.Controls.Add(this.decorRadioButton);
            this.layerGroupBox.Controls.Add(this.wallRadioButton);
            this.layerGroupBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerGroupBox.Location = new System.Drawing.Point(12, 35);
            this.layerGroupBox.Name = "layerGroupBox";
            this.layerGroupBox.Size = new System.Drawing.Size(111, 112);
            this.layerGroupBox.TabIndex = 7;
            this.layerGroupBox.TabStop = false;
            this.layerGroupBox.Text = "Layer";
            // 
            // eraseButton
            // 
            this.eraseButton.BackColor = System.Drawing.SystemColors.WindowText;
            this.eraseButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eraseButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.eraseButton.Location = new System.Drawing.Point(12, 204);
            this.eraseButton.Name = "eraseButton";
            this.eraseButton.Size = new System.Drawing.Size(111, 23);
            this.eraseButton.TabIndex = 8;
            this.eraseButton.Text = "Erase";
            this.eraseButton.UseVisualStyleBackColor = false;
            this.eraseButton.Click += new System.EventHandler(this.eraseButton_Click);
            // 
            // currentImageDisplay
            // 
            this.currentImageDisplay.BackColor = System.Drawing.SystemColors.Window;
            this.currentImageDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.currentImageDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.currentImageDisplay.Location = new System.Drawing.Point(12, 245);
            this.currentImageDisplay.MaximumSize = new System.Drawing.Size(50, 50);
            this.currentImageDisplay.MinimumSize = new System.Drawing.Size(50, 50);
            this.currentImageDisplay.Name = "currentImageDisplay";
            this.currentImageDisplay.Size = new System.Drawing.Size(50, 50);
            this.currentImageDisplay.TabIndex = 9;
            this.currentImageDisplay.TabStop = false;
            // 
            // recentTileGroupBox
            // 
            this.recentTileGroupBox.Controls.Add(this.recent9);
            this.recentTileGroupBox.Controls.Add(this.recent8);
            this.recentTileGroupBox.Controls.Add(this.recent7);
            this.recentTileGroupBox.Controls.Add(this.recent6);
            this.recentTileGroupBox.Controls.Add(this.recent5);
            this.recentTileGroupBox.Controls.Add(this.recent4);
            this.recentTileGroupBox.Controls.Add(this.recent3);
            this.recentTileGroupBox.Controls.Add(this.recent2);
            this.recentTileGroupBox.Controls.Add(this.recent1);
            this.recentTileGroupBox.Controls.Add(this.recent0);
            this.recentTileGroupBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentTileGroupBox.Location = new System.Drawing.Point(12, 315);
            this.recentTileGroupBox.Name = "recentTileGroupBox";
            this.recentTileGroupBox.Size = new System.Drawing.Size(111, 256);
            this.recentTileGroupBox.TabIndex = 10;
            this.recentTileGroupBox.TabStop = false;
            this.recentTileGroupBox.Text = "Recent Tiles";
            // 
            // recent9
            // 
            this.recent9.BackColor = System.Drawing.SystemColors.Window;
            this.recent9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recent9.Location = new System.Drawing.Point(61, 206);
            this.recent9.Name = "recent9";
            this.recent9.Size = new System.Drawing.Size(40, 40);
            this.recent9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recent9.TabIndex = 9;
            this.recent9.TabStop = false;
            this.recent9.Click += new System.EventHandler(this.recent9_Click);
            // 
            // recent8
            // 
            this.recent8.BackColor = System.Drawing.SystemColors.Window;
            this.recent8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recent8.Location = new System.Drawing.Point(6, 206);
            this.recent8.Name = "recent8";
            this.recent8.Size = new System.Drawing.Size(40, 40);
            this.recent8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recent8.TabIndex = 8;
            this.recent8.TabStop = false;
            this.recent8.Click += new System.EventHandler(this.recent8_Click);
            // 
            // recent7
            // 
            this.recent7.BackColor = System.Drawing.SystemColors.Window;
            this.recent7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recent7.Location = new System.Drawing.Point(61, 160);
            this.recent7.Name = "recent7";
            this.recent7.Size = new System.Drawing.Size(40, 40);
            this.recent7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recent7.TabIndex = 7;
            this.recent7.TabStop = false;
            this.recent7.Click += new System.EventHandler(this.recent7_Click);
            // 
            // recent6
            // 
            this.recent6.BackColor = System.Drawing.SystemColors.Window;
            this.recent6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recent6.Location = new System.Drawing.Point(6, 160);
            this.recent6.Name = "recent6";
            this.recent6.Size = new System.Drawing.Size(40, 40);
            this.recent6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recent6.TabIndex = 6;
            this.recent6.TabStop = false;
            this.recent6.Click += new System.EventHandler(this.recent6_Click);
            // 
            // recent5
            // 
            this.recent5.BackColor = System.Drawing.SystemColors.Window;
            this.recent5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recent5.Location = new System.Drawing.Point(61, 114);
            this.recent5.Name = "recent5";
            this.recent5.Size = new System.Drawing.Size(40, 40);
            this.recent5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recent5.TabIndex = 5;
            this.recent5.TabStop = false;
            this.recent5.Click += new System.EventHandler(this.recent5_Click);
            // 
            // recent4
            // 
            this.recent4.BackColor = System.Drawing.SystemColors.Window;
            this.recent4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recent4.Location = new System.Drawing.Point(6, 114);
            this.recent4.Name = "recent4";
            this.recent4.Size = new System.Drawing.Size(40, 40);
            this.recent4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recent4.TabIndex = 4;
            this.recent4.TabStop = false;
            this.recent4.Click += new System.EventHandler(this.recent4_Click);
            // 
            // recent3
            // 
            this.recent3.BackColor = System.Drawing.SystemColors.Window;
            this.recent3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recent3.Location = new System.Drawing.Point(61, 68);
            this.recent3.Name = "recent3";
            this.recent3.Size = new System.Drawing.Size(40, 40);
            this.recent3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recent3.TabIndex = 3;
            this.recent3.TabStop = false;
            this.recent3.Click += new System.EventHandler(this.recent3_Click);
            // 
            // recent2
            // 
            this.recent2.BackColor = System.Drawing.SystemColors.Window;
            this.recent2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recent2.Location = new System.Drawing.Point(6, 68);
            this.recent2.Name = "recent2";
            this.recent2.Size = new System.Drawing.Size(40, 40);
            this.recent2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recent2.TabIndex = 2;
            this.recent2.TabStop = false;
            this.recent2.Click += new System.EventHandler(this.recent2_Click);
            // 
            // recent1
            // 
            this.recent1.BackColor = System.Drawing.SystemColors.Window;
            this.recent1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recent1.Location = new System.Drawing.Point(61, 22);
            this.recent1.Name = "recent1";
            this.recent1.Size = new System.Drawing.Size(40, 40);
            this.recent1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recent1.TabIndex = 1;
            this.recent1.TabStop = false;
            this.recent1.Click += new System.EventHandler(this.recent1_Click);
            // 
            // recent0
            // 
            this.recent0.BackColor = System.Drawing.SystemColors.Window;
            this.recent0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recent0.Location = new System.Drawing.Point(7, 22);
            this.recent0.Name = "recent0";
            this.recent0.Size = new System.Drawing.Size(40, 40);
            this.recent0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recent0.TabIndex = 0;
            this.recent0.TabStop = false;
            this.recent0.Click += new System.EventHandler(this.recent0_Click);
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(848, 671);
            this.Controls.Add(this.recentTileGroupBox);
            this.Controls.Add(this.currentImageDisplay);
            this.Controls.Add(this.eraseButton);
            this.Controls.Add(this.layerGroupBox);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "Map Maker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.layerGroupBox.ResumeLayout(false);
            this.layerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImageDisplay)).EndInit();
            this.recentTileGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recent9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recent0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenuBar;
        private System.Windows.Forms.ToolStripMenuItem openMenuBar;
        private System.Windows.Forms.ToolStripMenuItem saveMenuBar;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridMenuBar;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuBar;
        private System.Windows.Forms.ToolStripMenuItem testButtonMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMenuBar;
        private System.Windows.Forms.RadioButton floorRadioButton;
        private System.Windows.Forms.RadioButton wallRadioButton;
        private System.Windows.Forms.RadioButton decorRadioButton;
        private System.Windows.Forms.GroupBox layerGroupBox;
        private System.Windows.Forms.Button eraseButton;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillFloorToolStripMenuItem;
        private System.Windows.Forms.PictureBox currentImageDisplay;
        private System.Windows.Forms.GroupBox recentTileGroupBox;
        private System.Windows.Forms.PictureBox recent9;
        private System.Windows.Forms.PictureBox recent8;
        private System.Windows.Forms.PictureBox recent7;
        private System.Windows.Forms.PictureBox recent6;
        private System.Windows.Forms.PictureBox recent5;
        private System.Windows.Forms.PictureBox recent4;
        private System.Windows.Forms.PictureBox recent3;
        private System.Windows.Forms.PictureBox recent2;
        private System.Windows.Forms.PictureBox recent1;
        private System.Windows.Forms.PictureBox recent0;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;

    }
}

