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
            this.autoSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.gameControls = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.startControls = new System.Windows.Forms.Panel();
            this.speedLabel = new System.Windows.Forms.Label();
            this.gameControls.SuspendLayout();
            this.startControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(19, 38);
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
            this.pauseButton.Location = new System.Drawing.Point(59, 32);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(47, 23);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.Text = "❚❚";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // incrementButton
            // 
            this.incrementButton.Enabled = false;
            this.incrementButton.Location = new System.Drawing.Point(112, 32);
            this.incrementButton.Name = "incrementButton";
            this.incrementButton.Size = new System.Drawing.Size(73, 23);
            this.incrementButton.TabIndex = 3;
            this.incrementButton.Text = "Increment";
            this.incrementButton.UseVisualStyleBackColor = true;
            this.incrementButton.Click += new System.EventHandler(this.incrementButton_Click);
            // 
            // iterationsLabel
            // 
            this.iterationsLabel.AutoSize = true;
            this.iterationsLabel.Location = new System.Drawing.Point(3, 73);
            this.iterationsLabel.Name = "iterationsLabel";
            this.iterationsLabel.Size = new System.Drawing.Size(36, 13);
            this.iterationsLabel.TabIndex = 4;
            this.iterationsLabel.Text = "Time: ";
            // 
            // populationLabel
            // 
            this.populationLabel.AutoSize = true;
            this.populationLabel.Location = new System.Drawing.Point(79, 73);
            this.populationLabel.Name = "populationLabel";
            this.populationLabel.Size = new System.Drawing.Size(63, 13);
            this.populationLabel.TabIndex = 5;
            this.populationLabel.Text = "Population: ";
            this.populationLabel.Click += new System.EventHandler(this.populationLabel_Click);
            // 
            // playButton
            // 
            this.playButton.Enabled = false;
            this.playButton.Location = new System.Drawing.Point(6, 32);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(47, 23);
            this.playButton.TabIndex = 6;
            this.playButton.Text = "▶";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // autoSpeedComboBox
            // 
            this.autoSpeedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autoSpeedComboBox.FormattingEnabled = true;
            this.autoSpeedComboBox.Items.AddRange(new object[] {
            "1 sec",
            "500 msec",
            "250 msec",
            "Fuck you"});
            this.autoSpeedComboBox.Location = new System.Drawing.Point(47, 5);
            this.autoSpeedComboBox.Name = "autoSpeedComboBox";
            this.autoSpeedComboBox.Size = new System.Drawing.Size(138, 21);
            this.autoSpeedComboBox.TabIndex = 7;
            // 
            // gameControls
            // 
            this.gameControls.Controls.Add(this.speedLabel);
            this.gameControls.Controls.Add(this.autoSpeedComboBox);
            this.gameControls.Controls.Add(this.playButton);
            this.gameControls.Controls.Add(this.pauseButton);
            this.gameControls.Controls.Add(this.populationLabel);
            this.gameControls.Controls.Add(this.incrementButton);
            this.gameControls.Controls.Add(this.iterationsLabel);
            this.gameControls.Location = new System.Drawing.Point(12, 12);
            this.gameControls.Name = "gameControls";
            this.gameControls.Size = new System.Drawing.Size(421, 100);
            this.gameControls.TabIndex = 8;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(119, 38);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(55, 20);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // startControls
            // 
            this.startControls.Controls.Add(this.clearButton);
            this.startControls.Controls.Add(this.startButton);
            this.startControls.Location = new System.Drawing.Point(12, 118);
            this.startControls.Name = "startControls";
            this.startControls.Size = new System.Drawing.Size(421, 100);
            this.startControls.TabIndex = 9;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(6, 8);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.speedLabel.Size = new System.Drawing.Size(38, 13);
            this.speedLabel.TabIndex = 8;
            this.speedLabel.Text = "Speed";
            // 
            // MainGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 229);
            this.Controls.Add(this.startControls);
            this.Controls.Add(this.gameControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainGameForm";
            this.ShowIcon = false;
            this.Text = "Game of Life";
            this.gameControls.ResumeLayout(false);
            this.gameControls.PerformLayout();
            this.startControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button incrementButton;
        private System.Windows.Forms.Label iterationsLabel;
        private System.Windows.Forms.Label populationLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.ComboBox autoSpeedComboBox;
        private System.Windows.Forms.Panel gameControls;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Panel startControls;
        private System.Windows.Forms.Label speedLabel;
    }
}