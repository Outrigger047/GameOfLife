using GameOfLife;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsGameOfLife
{
    public partial class SizeInputForm : Form
    {
        #region Fields
        private List<Automaton.CoordSet> InitLiveCells;
        private string ImportedFileName;
        private int xMin, yMin;
        private readonly Regex extDataFileValidLinePattern = new Regex(@"^[0-9]+\s*\,\s*[0-9]+$");
        private readonly Regex extDataFileXCoord = new Regex(@"^[0-9]+");
        private readonly Regex extDataFileYCoord = new Regex(@"[0-9]+$");
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public SizeInputForm()
        {
            InitializeComponent();

            fileLoadedLabel.Text = "";
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Extracts valid coordinates for live cells from external file data
        /// </summary>
        /// <param name="targetFile">Path of the file</param>
        /// <returns>CoordSet list of cells that should be initialized</returns>
        private List<Automaton.CoordSet> GetInitLiveCellListFromExternalFile(HashSet<string> fileData)
        {
            List<Automaton.CoordSet> liveCellsFromFile = new List<Automaton.CoordSet>();
            List<int> allX = new List<int>();
            List<int> allY = new List<int>();

            foreach (var line in fileData)
            {
                int xCoord = Convert.ToInt32(extDataFileXCoord.Match(line).Value);
                int yCoord = Convert.ToInt32(extDataFileYCoord.Match(line).Value);

                liveCellsFromFile.Add(new Automaton.CoordSet(xCoord, yCoord));
                allX.Add(xCoord);
                allY.Add(yCoord);
            }

            allX.Sort();
            allY.Sort();
            xMin = System.Linq.Enumerable.Last(allX) + 1;
            yMin = System.Linq.Enumerable.Last(allY) + 1;

            return liveCellsFromFile;
        }
        #endregion

        #region Windows Forms event handlers
        private void generateButton_Click(object sender, EventArgs e)
        {
            Form gameForm = new MainGameForm(Convert.ToInt32(this.xUpDown.Value), Convert.ToInt32(this.yUpDown.Value));
            gameForm.Show();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            importDialog.ShowDialog();
        }

        private void importStartButton_Click(object sender, EventArgs e)
        {
            Form gameForm = new MainGameForm(Convert.ToInt32(this.importHorizUpDown.Value),
                                            Convert.ToInt32(this.importVertUpDown.Value),
                                            InitLiveCells,
                                            ImportedFileName);
            gameForm.Show();
        }

        private void importDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Stream s = null;
            HashSet<string> fileData = new HashSet<string>();
            try
            {
                if ((s = importDialog.OpenFile()) != null)
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        while (!sr.EndOfStream)
                        {
                            string currentLine = sr.ReadLine();
                            if (!Regex.IsMatch(currentLine, extDataFileValidLinePattern.ToString()))
                            {
                                throw new Exception("File contains lines that do not match requirements.");
                            }
                            else
                            {
                                fileData.Add(currentLine);
                            }
                        }
                    }
                    s.Close();
                    s.Dispose();

                    ImportedFileName = Path.GetFileName(importDialog.FileName);

                    InitLiveCells = GetInitLiveCellListFromExternalFile(fileData);

                    SuspendLayout();
                    importHorizUpDown.Minimum = xMin;
                    importHorizUpDown.Value = xMin;
                    importVertUpDown.Minimum = yMin;
                    importVertUpDown.Value = yMin;
                    importHorizUpDown.Enabled = true;
                    importHorizLabel.Enabled = true;
                    importVertUpDown.Enabled = true;
                    importVertLabel.Enabled = true;
                    importStartButton.Enabled = true;
                    fileLoadedLabel.Text = "Loaded " + ImportedFileName;
                    importButton.Text = "Import New File";
                    ResumeLayout(false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        } 
        #endregion
    }
}
