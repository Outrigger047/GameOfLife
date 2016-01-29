using GameOfLife;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WinFormsGameOfLife
{
    public partial class LoadingForm : Form
    {
        public LoadingForm(out List<FileReader.FileExtract> loadedFiles)
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
