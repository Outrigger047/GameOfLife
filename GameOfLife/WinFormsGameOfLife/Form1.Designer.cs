﻿namespace WinFormsGameOfLife
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
            this.generateInfoLabel = new System.Windows.Forms.Label();
            this.importGroupBox = new System.Windows.Forms.GroupBox();
            this.rotationLabel = new System.Windows.Forms.Label();
            this.rotationComboBox = new System.Windows.Forms.ComboBox();
            this.fileLoadedLabel = new System.Windows.Forms.Label();
            this.importStartButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.importVertLabel = new System.Windows.Forms.Label();
            this.importInfoLabel = new System.Windows.Forms.Label();
            this.importHorizUpDown = new System.Windows.Forms.NumericUpDown();
            this.importHorizLabel = new System.Windows.Forms.Label();
            this.importVertUpDown = new System.Windows.Forms.NumericUpDown();
            this.importDialog = new System.Windows.Forms.OpenFileDialog();
            this.randomizeCheckbox = new System.Windows.Forms.CheckBox();
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
            this.xUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.xUpDown.Name = "xUpDown";
            this.xUpDown.Size = new System.Drawing.Size(41, 20);
            this.xUpDown.TabIndex = 2;
            this.xUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.xUpDown.Click += new System.EventHandler(this.xUpDown_Click);
            this.xUpDown.Enter += new System.EventHandler(this.xUpDown_Enter);
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
            this.yUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.yUpDown.Name = "yUpDown";
            this.yUpDown.Size = new System.Drawing.Size(41, 20);
            this.yUpDown.TabIndex = 1;
            this.yUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.yUpDown.Click += new System.EventHandler(this.yUpDown_Click);
            this.yUpDown.Enter += new System.EventHandler(this.yUpDown_Enter);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(142, 75);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // generateGroupBox
            // 
            this.generateGroupBox.Controls.Add(this.randomizeCheckbox);
            this.generateGroupBox.Controls.Add(this.generateInfoLabel);
            this.generateGroupBox.Controls.Add(this.generateButton);
            this.generateGroupBox.Controls.Add(this.xLabel);
            this.generateGroupBox.Controls.Add(this.yUpDown);
            this.generateGroupBox.Controls.Add(this.xUpDown);
            this.generateGroupBox.Controls.Add(this.yLabel);
            this.generateGroupBox.Location = new System.Drawing.Point(12, 12);
            this.generateGroupBox.Name = "generateGroupBox";
            this.generateGroupBox.Size = new System.Drawing.Size(237, 161);
            this.generateGroupBox.TabIndex = 5;
            this.generateGroupBox.TabStop = false;
            this.generateGroupBox.Text = "Generate New Game";
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
            // importGroupBox
            // 
            this.importGroupBox.Controls.Add(this.rotationLabel);
            this.importGroupBox.Controls.Add(this.rotationComboBox);
            this.importGroupBox.Controls.Add(this.fileLoadedLabel);
            this.importGroupBox.Controls.Add(this.importStartButton);
            this.importGroupBox.Controls.Add(this.importButton);
            this.importGroupBox.Controls.Add(this.importVertLabel);
            this.importGroupBox.Controls.Add(this.importInfoLabel);
            this.importGroupBox.Controls.Add(this.importHorizUpDown);
            this.importGroupBox.Controls.Add(this.importHorizLabel);
            this.importGroupBox.Controls.Add(this.importVertUpDown);
            this.importGroupBox.Location = new System.Drawing.Point(12, 179);
            this.importGroupBox.Name = "importGroupBox";
            this.importGroupBox.Size = new System.Drawing.Size(236, 205);
            this.importGroupBox.TabIndex = 6;
            this.importGroupBox.TabStop = false;
            this.importGroupBox.Text = "Import Game State";
            // 
            // rotationLabel
            // 
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.Location = new System.Drawing.Point(23, 166);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(47, 13);
            this.rotationLabel.TabIndex = 14;
            this.rotationLabel.Text = "Rotation";
            // 
            // rotationComboBox
            // 
            this.rotationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rotationComboBox.Enabled = false;
            this.rotationComboBox.FormattingEnabled = true;
            this.rotationComboBox.Items.AddRange(new object[] {
            "None",
            "90 deg CW",
            "180 deg CW",
            "270 deg CW"});
            this.rotationComboBox.Location = new System.Drawing.Point(76, 163);
            this.rotationComboBox.Name = "rotationComboBox";
            this.rotationComboBox.Size = new System.Drawing.Size(93, 21);
            this.rotationComboBox.TabIndex = 7;
            this.rotationComboBox.SelectedIndexChanged += new System.EventHandler(this.rotationComboBox_SelectedIndexChanged);
            // 
            // fileLoadedLabel
            // 
            this.fileLoadedLabel.AutoSize = true;
            this.fileLoadedLabel.Location = new System.Drawing.Point(16, 88);
            this.fileLoadedLabel.Name = "fileLoadedLabel";
            this.fileLoadedLabel.Size = new System.Drawing.Size(20, 13);
            this.fileLoadedLabel.TabIndex = 12;
            this.fileLoadedLabel.Text = "init";
            // 
            // importStartButton
            // 
            this.importStartButton.Enabled = false;
            this.importStartButton.Location = new System.Drawing.Point(141, 123);
            this.importStartButton.Name = "importStartButton";
            this.importStartButton.Size = new System.Drawing.Size(75, 23);
            this.importStartButton.TabIndex = 8;
            this.importStartButton.Text = "Generate";
            this.importStartButton.UseVisualStyleBackColor = true;
            this.importStartButton.Click += new System.EventHandler(this.importStartButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(19, 52);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 4;
            this.importButton.Text = "Import File";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // importVertLabel
            // 
            this.importVertLabel.AutoSize = true;
            this.importVertLabel.Enabled = false;
            this.importVertLabel.Location = new System.Drawing.Point(16, 113);
            this.importVertLabel.Name = "importVertLabel";
            this.importVertLabel.Size = new System.Drawing.Size(54, 13);
            this.importVertLabel.TabIndex = 6;
            this.importVertLabel.Text = "Horizontal";
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
            // importHorizUpDown
            // 
            this.importHorizUpDown.Enabled = false;
            this.importHorizUpDown.Location = new System.Drawing.Point(76, 137);
            this.importHorizUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.importHorizUpDown.Name = "importHorizUpDown";
            this.importHorizUpDown.Size = new System.Drawing.Size(41, 20);
            this.importHorizUpDown.TabIndex = 6;
            this.importHorizUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.importHorizUpDown.Click += new System.EventHandler(this.importHorizUpDown_Click);
            this.importHorizUpDown.Enter += new System.EventHandler(this.importHorizUpDown_Enter);
            // 
            // importHorizLabel
            // 
            this.importHorizLabel.AutoSize = true;
            this.importHorizLabel.Enabled = false;
            this.importHorizLabel.Location = new System.Drawing.Point(28, 139);
            this.importHorizLabel.Name = "importHorizLabel";
            this.importHorizLabel.Size = new System.Drawing.Size(42, 13);
            this.importHorizLabel.TabIndex = 8;
            this.importHorizLabel.Text = "Vertical";
            // 
            // importVertUpDown
            // 
            this.importVertUpDown.Enabled = false;
            this.importVertUpDown.Location = new System.Drawing.Point(76, 111);
            this.importVertUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.importVertUpDown.Name = "importVertUpDown";
            this.importVertUpDown.Size = new System.Drawing.Size(41, 20);
            this.importVertUpDown.TabIndex = 5;
            this.importVertUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.importVertUpDown.Click += new System.EventHandler(this.importVertUpDown_Click);
            this.importVertUpDown.Enter += new System.EventHandler(this.importVertUpDown_Enter);
            // 
            // importDialog
            // 
            this.importDialog.DefaultExt = "txt";
            this.importDialog.Filter = "Lif files (*.lif)|*.lif|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.importDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.importDialog_FileOk);
            // 
            // randomizeCheckbox
            // 
            this.randomizeCheckbox.AutoSize = true;
            this.randomizeCheckbox.Location = new System.Drawing.Point(38, 125);
            this.randomizeCheckbox.Name = "randomizeCheckbox";
            this.randomizeCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.randomizeCheckbox.Size = new System.Drawing.Size(79, 17);
            this.randomizeCheckbox.TabIndex = 6;
            this.randomizeCheckbox.Text = "Randomize";
            this.randomizeCheckbox.UseVisualStyleBackColor = true;
            // 
            // SizeInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 396);
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
        private System.Windows.Forms.OpenFileDialog importDialog;
        private System.Windows.Forms.Label fileLoadedLabel;
        private System.Windows.Forms.Label rotationLabel;
        private System.Windows.Forms.ComboBox rotationComboBox;
        private System.Windows.Forms.CheckBox randomizeCheckbox;
    }
}

