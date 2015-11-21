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
            this.floorButton = new System.Windows.Forms.Button();
            this.decorButton = new System.Windows.Forms.Button();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuBar = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuBar = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuBar = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridMenuBar = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuBar = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            // floorButton
            // 
            this.floorButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.floorButton.Location = new System.Drawing.Point(13, 35);
            this.floorButton.Name = "floorButton";
            this.floorButton.Size = new System.Drawing.Size(111, 24);
            this.floorButton.TabIndex = 0;
            this.floorButton.TabStop = false;
            this.floorButton.Text = "Floor";
            this.toolTips.SetToolTip(this.floorButton, "Select a tile for the map floor.");
            this.floorButton.UseVisualStyleBackColor = true;
            this.floorButton.Click += new System.EventHandler(this.floorButton_Click);
            // 
            // decorButton
            // 
            this.decorButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decorButton.Location = new System.Drawing.Point(13, 76);
            this.decorButton.Name = "decorButton";
            this.decorButton.Size = new System.Drawing.Size(111, 25);
            this.decorButton.TabIndex = 0;
            this.decorButton.TabStop = false;
            this.decorButton.Text = "Decor";
            this.toolTips.SetToolTip(this.decorButton, "Select a tile to place on top of the floor.");
            this.decorButton.UseVisualStyleBackColor = true;
            this.decorButton.Click += new System.EventHandler(this.decorButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
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
            this.saveAsMenuBar});
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
            // 
            // openMenuBar
            // 
            this.openMenuBar.Name = "openMenuBar";
            this.openMenuBar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuBar.Size = new System.Drawing.Size(195, 22);
            this.openMenuBar.Text = "Open...";
            // 
            // saveMenuBar
            // 
            this.saveMenuBar.Name = "saveMenuBar";
            this.saveMenuBar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuBar.Size = new System.Drawing.Size(195, 22);
            this.saveMenuBar.Text = "Save...";
            this.saveMenuBar.Click += new System.EventHandler(this.saveMenuBar_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
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
            // saveAsMenuBar
            // 
            this.saveAsMenuBar.Name = "saveAsMenuBar";
            this.saveAsMenuBar.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsMenuBar.Size = new System.Drawing.Size(195, 22);
            this.saveAsMenuBar.Text = "Save As...";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(848, 522);
            this.Controls.Add(this.decorButton);
            this.Controls.Add(this.floorButton);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button floorButton;
        private System.Windows.Forms.Button decorButton;
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

    }
}

