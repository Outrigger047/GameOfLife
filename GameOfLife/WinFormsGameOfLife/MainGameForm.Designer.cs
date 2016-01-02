namespace WinFormsGameOfLife
{
    partial class MainGameForm
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
            this.startButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.incrementButton = new System.Windows.Forms.Button();
            this.iterationsLabel = new System.Windows.Forms.Label();
            this.populationLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(250, 12);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(25, 23);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.Text = "❚❚";
            this.pauseButton.UseVisualStyleBackColor = true;
            // 
            // incrementButton
            // 
            this.incrementButton.Enabled = false;
            this.incrementButton.Location = new System.Drawing.Point(93, 12);
            this.incrementButton.Name = "incrementButton";
            this.incrementButton.Size = new System.Drawing.Size(75, 23);
            this.incrementButton.TabIndex = 3;
            this.incrementButton.Text = "Increment";
            this.incrementButton.UseVisualStyleBackColor = true;
            this.incrementButton.Click += new System.EventHandler(this.incrementButton_Click);
            // 
            // iterationsLabel
            // 
            this.iterationsLabel.AutoSize = true;
            this.iterationsLabel.Location = new System.Drawing.Point(351, 9);
            this.iterationsLabel.Name = "iterationsLabel";
            this.iterationsLabel.Size = new System.Drawing.Size(36, 13);
            this.iterationsLabel.TabIndex = 4;
            this.iterationsLabel.Text = "Time: ";
            // 
            // populationLabel
            // 
            this.populationLabel.AutoSize = true;
            this.populationLabel.Location = new System.Drawing.Point(324, 25);
            this.populationLabel.Name = "populationLabel";
            this.populationLabel.Size = new System.Drawing.Size(63, 13);
            this.populationLabel.TabIndex = 5;
            this.populationLabel.Text = "Population: ";
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(219, 12);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(25, 23);
            this.playButton.TabIndex = 6;
            this.playButton.Text = "▶";
            this.playButton.UseVisualStyleBackColor = true;
            // 
            // MainGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 50);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.populationLabel);
            this.Controls.Add(this.iterationsLabel);
            this.Controls.Add(this.incrementButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainGameForm";
            this.ShowIcon = false;
            this.Text = "Game of Life";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button incrementButton;
        private System.Windows.Forms.Label iterationsLabel;
        private System.Windows.Forms.Label populationLabel;
        private System.Windows.Forms.Button playButton;
    }
}