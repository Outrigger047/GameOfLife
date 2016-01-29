namespace WinFormsGameOfLife
{
    partial class LoadingForm
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
            this.loadingStatusLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // loadingStatusLabel
            // 
            this.loadingStatusLabel.AutoSize = true;
            this.loadingStatusLabel.Location = new System.Drawing.Point(28, 21);
            this.loadingStatusLabel.Name = "loadingStatusLabel";
            this.loadingStatusLabel.Size = new System.Drawing.Size(96, 13);
            this.loadingStatusLabel.TabIndex = 0;
            this.loadingStatusLabel.Text = "Loading your shit...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(31, 46);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(353, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 92);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.loadingStatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoadingForm";
            this.Text = "LoadingForm";
            this.Load += new System.EventHandler(this.LoadingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loadingStatusLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}