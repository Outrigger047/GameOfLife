namespace WinFormsGameOfLife
{
    partial class SizeInputForm
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
            this.xLabel = new System.Windows.Forms.Label();
            this.xUpDown = new System.Windows.Forms.NumericUpDown();
            this.yLabel = new System.Windows.Forms.Label();
            this.yUpDown = new System.Windows.Forms.NumericUpDown();
            this.generateButton = new System.Windows.Forms.Button();
            this.generateGroupBox = new System.Windows.Forms.GroupBox();
            this.importGroupBox = new System.Windows.Forms.GroupBox();
            this.generateInfoLabel = new System.Windows.Forms.Label();
            this.importInfoLabel = new System.Windows.Forms.Label();
            this.importVertLabel = new System.Windows.Forms.Label();
            this.importHorizUpDown = new System.Windows.Forms.NumericUpDown();
            this.importVertUpDown = new System.Windows.Forms.NumericUpDown();
            this.importHorizLabel = new System.Windows.Forms.Label();
            this.importButton = new System.Windows.Forms.Button();
            this.importStartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).BeginInit();
            this.generateGroupBox.SuspendLayout();
            this.importGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.importHorizUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importVertUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(29, 92);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(42, 13);
            this.xLabel.TabIndex = 0;
            this.xLabel.Text = "Vertical";
            // 
            // xUpDown
            // 
            this.xUpDown.Location = new System.Drawing.Point(77, 90);
            this.xUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.xUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.xUpDown.Name = "xUpDown";
            this.xUpDown.Size = new System.Drawing.Size(41, 20);
            this.xUpDown.TabIndex = 1;
            this.xUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(17, 66);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(54, 13);
            this.yLabel.TabIndex = 2;
            this.yLabel.Text = "Horizontal";
            // 
            // yUpDown
            // 
            this.yUpDown.Location = new System.Drawing.Point(77, 64);
            this.yUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.yUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.yUpDown.Name = "yUpDown";
            this.yUpDown.Size = new System.Drawing.Size(41, 20);
            this.yUpDown.TabIndex = 3;
            this.yUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(142, 75);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 4;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // generateGroupBox
            // 
            this.generateGroupBox.Controls.Add(this.generateInfoLabel);
            this.generateGroupBox.Controls.Add(this.generateButton);
            this.generateGroupBox.Controls.Add(this.xLabel);
            this.generateGroupBox.Controls.Add(this.yUpDown);
            this.generateGroupBox.Controls.Add(this.xUpDown);
            this.generateGroupBox.Controls.Add(this.yLabel);
            this.generateGroupBox.Location = new System.Drawing.Point(12, 12);
            this.generateGroupBox.Name = "generateGroupBox";
            this.generateGroupBox.Size = new System.Drawing.Size(237, 140);
            this.generateGroupBox.TabIndex = 5;
            this.generateGroupBox.TabStop = false;
            this.generateGroupBox.Text = "Generate New Game";
            // 
            // importGroupBox
            // 
            this.importGroupBox.Controls.Add(this.importStartButton);
            this.importGroupBox.Controls.Add(this.importButton);
            this.importGroupBox.Controls.Add(this.importVertLabel);
            this.importGroupBox.Controls.Add(this.importInfoLabel);
            this.importGroupBox.Controls.Add(this.importHorizUpDown);
            this.importGroupBox.Controls.Add(this.importHorizLabel);
            this.importGroupBox.Controls.Add(this.importVertUpDown);
            this.importGroupBox.Location = new System.Drawing.Point(13, 158);
            this.importGroupBox.Name = "importGroupBox";
            this.importGroupBox.Size = new System.Drawing.Size(236, 163);
            this.importGroupBox.TabIndex = 6;
            this.importGroupBox.TabStop = false;
            this.importGroupBox.Text = "Import Game State";
            // 
            // generateInfoLabel
            // 
            this.generateInfoLabel.AutoSize = true;
            this.generateInfoLabel.Location = new System.Drawing.Point(17, 26);
            this.generateInfoLabel.MaximumSize = new System.Drawing.Size(210, 30);
            this.generateInfoLabel.Name = "generateInfoLabel";
            this.generateInfoLabel.Size = new System.Drawing.Size(208, 26);
            this.generateInfoLabel.TabIndex = 5;
            this.generateInfoLabel.Text = "Generate a game from scratch by manually specifying live cells";
            // 
            // importInfoLabel
            // 
            this.importInfoLabel.AutoSize = true;
            this.importInfoLabel.Location = new System.Drawing.Point(16, 30);
            this.importInfoLabel.MaximumSize = new System.Drawing.Size(210, 30);
            this.importInfoLabel.Name = "importInfoLabel";
            this.importInfoLabel.Size = new System.Drawing.Size(209, 13);
            this.importInfoLabel.TabIndex = 6;
            this.importInfoLabel.Text = "Import a list of live cells from an external file";
            // 
            // importVertLabel
            // 
            this.importVertLabel.AutoSize = true;
            this.importVertLabel.Enabled = false;
            this.importVertLabel.Location = new System.Drawing.Point(28, 127);
            this.importVertLabel.Name = "importVertLabel";
            this.importVertLabel.Size = new System.Drawing.Size(42, 13);
            this.importVertLabel.TabIndex = 6;
            this.importVertLabel.Text = "Vertical";
            // 
            // importHorizUpDown
            // 
            this.importHorizUpDown.Enabled = false;
            this.importHorizUpDown.Location = new System.Drawing.Point(76, 99);
            this.importHorizUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.importHorizUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.importHorizUpDown.Name = "importHorizUpDown";
            this.importHorizUpDown.Size = new System.Drawing.Size(41, 20);
            this.importHorizUpDown.TabIndex = 9;
            this.importHorizUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // importVertUpDown
            // 
            this.importVertUpDown.Enabled = false;
            this.importVertUpDown.Location = new System.Drawing.Point(76, 125);
            this.importVertUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.importVertUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.importVertUpDown.Name = "importVertUpDown";
            this.importVertUpDown.Size = new System.Drawing.Size(41, 20);
            this.importVertUpDown.TabIndex = 7;
            this.importVertUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // importHorizLabel
            // 
            this.importHorizLabel.AutoSize = true;
            this.importHorizLabel.Enabled = false;
            this.importHorizLabel.Location = new System.Drawing.Point(16, 101);
            this.importHorizLabel.Name = "importHorizLabel";
            this.importHorizLabel.Size = new System.Drawing.Size(54, 13);
            this.importHorizLabel.TabIndex = 8;
            this.importHorizLabel.Text = "Horizontal";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(76, 57);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 10;
            this.importButton.Text = "Import...";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // importStartButton
            // 
            this.importStartButton.Enabled = false;
            this.importStartButton.Location = new System.Drawing.Point(141, 111);
            this.importStartButton.Name = "importStartButton";
            this.importStartButton.Size = new System.Drawing.Size(75, 23);
            this.importStartButton.TabIndex = 11;
            this.importStartButton.Text = "button1";
            this.importStartButton.UseVisualStyleBackColor = true;
            // 
            // SizeInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 333);
            this.Controls.Add(this.importGroupBox);
            this.Controls.Add(this.generateGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SizeInputForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Game of Life";
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).EndInit();
            this.generateGroupBox.ResumeLayout(false);
            this.generateGroupBox.PerformLayout();
            this.importGroupBox.ResumeLayout(false);
            this.importGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.importHorizUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importVertUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.NumericUpDown xUpDown;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.NumericUpDown yUpDown;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.GroupBox generateGroupBox;
        private System.Windows.Forms.Label generateInfoLabel;
        private System.Windows.Forms.GroupBox importGroupBox;
        private System.Windows.Forms.Button importStartButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Label importVertLabel;
        private System.Windows.Forms.Label importInfoLabel;
        private System.Windows.Forms.NumericUpDown importHorizUpDown;
        private System.Windows.Forms.Label importHorizLabel;
        private System.Windows.Forms.NumericUpDown importVertUpDown;
    }
}

