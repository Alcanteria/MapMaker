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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
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
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(807, 482);
            this.Controls.Add(this.decorButton);
            this.Controls.Add(this.floorButton);
            this.Controls.Add(this.pictureBox);
            this.KeyPreview = true;
            this.Name = "mainForm";
            this.Text = "Map Maker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button floorButton;
        private System.Windows.Forms.Button decorButton;
        private System.Windows.Forms.ToolTip toolTips;

    }
}

