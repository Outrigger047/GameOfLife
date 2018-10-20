using GameOfLife;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsGameOfLife
{
    public partial class SizeInputForm : Form
    {
        #region Fields
        private bool fileLoaded;
        private List<Automaton.CoordSet> ImportedLiveCells;
        private List<Automaton.CoordSet> ImportedLiveCellsNoAdjust;
        private List<Automaton.CoordSet> InitLiveCells;
        private string ImportedFileName;
        private int xMinSize, yMinSize;
        private readonly Regex extDataFileValidLinePattern = new Regex(@"^[0-9]+\s*\,\s*[0-9]+$");
        private readonly Regex extDataFileValidHeaderPattern = new Regex(@"^#.*$+");
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
            rotationComboBox.SelectedIndex = 0;

            importDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "Assets", "Patterns");
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Rotates the list of initial live cells based on the value in the UI dropdown
        /// </summary>
        private void DoRotation()
        {
            List<Automaton.CoordSet> rotatedInitCells = new List<Automaton.CoordSet>();

            // Rotate unadjusted coordinates
            switch (rotationComboBox.SelectedIndex)
            {
                // No rotation
                case 0:
                    foreach (var coord in ImportedLiveCellsNoAdjust)
                    {
                        rotatedInitCells.Add(new Automaton.CoordSet(coord.X, coord.Y));
                    }

                    break;

                // 90 deg CW
                case 1:
                    foreach (var coord in ImportedLiveCellsNoAdjust)
                    {
                        rotatedInitCells.Add(new Automaton.CoordSet(coord.Y, -coord.X));
                    }

                    break;

                // 180 deg CW
                case 2:
                    foreach (var coord in ImportedLiveCellsNoAdjust)
                    {
                        rotatedInitCells.Add(new Automaton.CoordSet(-coord.X, -coord.Y));
                    }

                    break;

                // 270 deg CW
                case 3:
                    foreach (var coord in ImportedLiveCellsNoAdjust)
                    {
                        rotatedInitCells.Add(new Automaton.CoordSet(-coord.Y, coord.X));
                    }

                    break;
            }

            // Adjust uniformly so top left is 0,0
            List<int> allXCoordsPreShift = new List<int>();
            List<int> allYCoordsPreShift = new List<int>();

            foreach (var coordSet in rotatedInitCells)
            {
                allXCoordsPreShift.Add(coordSet.X);
                allYCoordsPreShift.Add(coordSet.Y);
            }

            allXCoordsPreShift.Sort();
            allYCoordsPreShift.Sort();

            int shiftDistanceX = Math.Abs(allXCoordsPreShift.First());
            int shiftDistanceY = Math.Abs(allYCoordsPreShift.First());

            List<Automaton.CoordSet> rotatedShifted = new List<Automaton.CoordSet>();

            foreach (var coordSet in rotatedInitCells)
            {
                rotatedShifted.Add(
                    new Automaton.CoordSet(coordSet.X + shiftDistanceX, coordSet.Y + shiftDistanceY));
            }

            // Copy rotated and scaled set into InitLiveCells
            InitLiveCells = rotatedShifted;
        }
        #endregion

        #region Windows Forms event handlers
        private void generateButton_Click(object sender, EventArgs e)
        {
            Form gameForm = new MainGameForm(Convert.ToInt32(this.xUpDown.Value), 
                Convert.ToInt32(this.yUpDown.Value));
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

        private void yUpDown_Enter(object sender, EventArgs e)
        {
            yUpDown.Select(0, yUpDown.Value.ToString().Length);
        }

        private void xUpDown_Enter(object sender, EventArgs e)
        {
            xUpDown.Select(0, xUpDown.Value.ToString().Length);
        }

        private void importHorizUpDown_Enter(object sender, EventArgs e)
        {
            importHorizUpDown.Select(0, importHorizUpDown.Value.ToString().Length);
        }

        private void importVertUpDown_Enter(object sender, EventArgs e)
        {
            importVertUpDown.Select(0, importVertUpDown.Value.ToString().Length);
        }

        private void yUpDown_Click(object sender, EventArgs e)
        {
            yUpDown.Select(0, yUpDown.Value.ToString().Length);
        }

        private void xUpDown_Click(object sender, EventArgs e)
        {
            xUpDown.Select(0, xUpDown.Value.ToString().Length);
        }

        private void importHorizUpDown_Click(object sender, EventArgs e)
        {
            importHorizUpDown.Select(0, importHorizUpDown.Value.ToString().Length);
        }

        private void importVertUpDown_Click(object sender, EventArgs e)
        {
            importVertUpDown.Select(0, importVertUpDown.Value.ToString().Length);
        }

        private void rotationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileLoaded)
            {
                // Do actual rotation of InitLiveCells
                DoRotation();

                // Update width and height values in UI elements if necessary
                if (rotationComboBox.SelectedIndex == 1 || rotationComboBox.SelectedIndex == 3)
                {
                    importHorizUpDown.Minimum = yMinSize;
                    importHorizUpDown.Value = yMinSize;
                    importVertUpDown.Minimum = xMinSize;
                    importVertUpDown.Value = xMinSize;
                }
                else
                {
                    importHorizUpDown.Minimum = xMinSize;
                    importHorizUpDown.Value = xMinSize;
                    importVertUpDown.Minimum = yMinSize;
                    importVertUpDown.Value = yMinSize;
                } 
            }
        }

        private void importDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Stream s = null;
            List<string> fileData = new List<string>();
            try
            {
                if ((s = importDialog.OpenFile()) != null)
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        while (!sr.EndOfStream)
                        {
                            string currentLine = sr.ReadLine();
                            fileData.Add(currentLine);
                        }
                    }

                    ImportedFileName = Path.GetFileName(importDialog.FileName);

                    FileReader fr = new FileReader(fileData, 
                        FileReader.CoordExtractionOffsetModes.ScaleToZero);      
                    ImportedLiveCells = fr.Extract.LiveCells;

                    FileReader frns = new FileReader(fileData, 
                        FileReader.CoordExtractionOffsetModes.RelativeToOrigin);
                    ImportedLiveCellsNoAdjust = frns.Extract.LiveCells;

                    InitLiveCells = ImportedLiveCells;

                    SuspendLayout();
                    xMinSize = (int)fr.Extract.XMin + 1;
                    yMinSize = (int)fr.Extract.YMin + 1;
                    importHorizUpDown.Minimum = xMinSize;
                    importHorizUpDown.Value = xMinSize;
                    importVertUpDown.Minimum = yMinSize;
                    importVertUpDown.Value = yMinSize;
                    importHorizUpDown.Enabled = true;
                    importHorizLabel.Enabled = true;
                    importVertUpDown.Enabled = true;
                    importVertLabel.Enabled = true;
                    importStartButton.Enabled = true;
                    rotationComboBox.Enabled = true;
                    fileLoaded = true;
                    fileLoadedLabel.Text = "Loaded " + ImportedFileName;
                    importButton.Text = "Import New File";
                    ResumeLayout(false);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("not match requirements"))
                {
                    string extraInfo = "\n\n" + 
                        "Each line must be in the format: X,Y" + "\n\n" + "Positive values only";
                    MessageBox.Show(ex.Message + extraInfo, 
                        "File Import Error", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else if (ex.Message.Contains("unknown or invalid"))
                {
                    MessageBox.Show(ex.Message,
                        "File Import Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    throw; 
                }
            }
            finally
            {
                s.Close();
                s.Dispose();
            }
        } 
        #endregion
    }
}
