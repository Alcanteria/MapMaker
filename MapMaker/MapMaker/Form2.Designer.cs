namespace MapMaker
{
    partial class newMapDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.arrowSelectColumns = new System.Windows.Forms.NumericUpDown();
            this.arrowSelectRows = new System.Windows.Forms.NumericUpDown();
            this.createButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.arrowSelectColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowSelectRows)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Columns";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rows";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(136, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Set Map Size";
            // 
            // arrowSelectColumns
            // 
            this.arrowSelectColumns.BackColor = System.Drawing.SystemColors.Info;
            this.arrowSelectColumns.Location = new System.Drawing.Point(151, 83);
            this.arrowSelectColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.arrowSelectColumns.Name = "arrowSelectColumns";
            this.arrowSelectColumns.Size = new System.Drawing.Size(51, 21);
            this.arrowSelectColumns.TabIndex = 3;
            this.arrowSelectColumns.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // arrowSelectRows
            // 
            this.arrowSelectRows.BackColor = System.Drawing.SystemColors.Info;
            this.arrowSelectRows.Location = new System.Drawing.Point(151, 124);
            this.arrowSelectRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.arrowSelectRows.Name = "arrowSelectRows";
            this.arrowSelectRows.Size = new System.Drawing.Size(51, 21);
            this.arrowSelectRows.TabIndex = 4;
            this.arrowSelectRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // createButton
            // 
            this.createButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(80, 275);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(88, 29);
            this.createButton.TabIndex = 5;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(220, 275);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 29);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // newMapDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.arrowSelectRows);
            this.Controls.Add(this.arrowSelectColumns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "newMapDialog";
            this.ShowIcon = false;
            this.Text = "Create New Map";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.arrowSelectColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowSelectRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown arrowSelectColumns;
        private System.Windows.Forms.NumericUpDown arrowSelectRows;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button cancelButton;
    }
}