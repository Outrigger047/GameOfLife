using GameOfLife;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WinFormsGameOfLife
{
    public partial class SizeInputForm : Form
    {
        public SizeInputForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets a list of live cells for an initial state from an external text file
        /// </summary>
        /// <param name="targetFile">Path of the file</param>
        /// <returns>CoordSet list of cells that should be initialized</returns>
        private List<Automaton.CoordSet> GetInitLiveCellListFromExternalFile(string targetFile)
        {
            List<Automaton.CoordSet> liveCellsFromFile = new List<Automaton.CoordSet>();

            return liveCellsFromFile;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Form gameForm = new MainGameForm(Convert.ToInt32(this.xUpDown.Value), Convert.ToInt32(this.yUpDown.Value));
            gameForm.Show();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            importDialog.ShowDialog();
        }

        private void importDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // TODO Validate external file here
            Stream s = null;
            List<string> fileData = new List<string>();
            try
            {
                if ((s = importDialog.OpenFile()) != null)
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
