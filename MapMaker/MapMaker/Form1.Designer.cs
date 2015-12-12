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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.layerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImageDisplay)).BeginInit();
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
            this.gridMenuBar});
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
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(848, 522);
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

    }
}

