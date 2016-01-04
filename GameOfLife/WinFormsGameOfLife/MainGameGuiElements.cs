using GameOfLife;
using System.Collections.Generic;
using System.ComponentModel;

namespace WinFormsGameOfLife
{
    partial class MainGameForm
    {
        /// <summary>
        /// Used for dynamic checkbox generation
        /// </summary>
        public System.Windows.Forms.CheckBox[,] UniverseGui { get; private set; }
        /// <summary>
        /// Horizontal size of the universe
        /// </summary>
        public int GameUniverseSizeX { get; private set; }
        /// <summary>
        /// Vertical size of the universe
        /// </summary>
        public int GameUniverseSizeY { get; private set; }

        /// <summary>
        /// Initializes game-related GUI elements on the main form
        /// </summary>
        private void InitGameGui()
        {
            this.SuspendLayout();

            int winXSize = (13 * GameUniverseSizeY) + 30;
            int winYSize = (13 * GameUniverseSizeX) + 90;

            // Resize the window to accommodate the grid
            this.ClientSize = new System.Drawing.Size(
                winXSize < 480 ? 480 : winXSize, 
                winYSize);

            // Set up the grid of checkboxes
            UniverseGui = new System.Windows.Forms.CheckBox[GameUniverseSizeX, GameUniverseSizeY];
            int drawPosX = 13;
            int drawPosY = 75;
            for (int i = 0; i < GameUniverseSizeX; i++)
            {
                for (int j = 0; j < GameUniverseSizeY; j++)
                {
                    UniverseGui[i, j] = new System.Windows.Forms.CheckBox();
                    UniverseGui[i, j].Margin = new System.Windows.Forms.Padding(0);
                    UniverseGui[i, j].CheckState = System.Windows.Forms.CheckState.Unchecked;
                    UniverseGui[i, j].Location = new System.Drawing.Point(drawPosX, drawPosY);
                    UniverseGui[i, j].Size = new System.Drawing.Size(13, 13);

                    this.Controls.Add(UniverseGui[i, j]);

                    if (j <= GameUniverseSizeY - 1)
                    {
                        drawPosX += 13; 
                    }
                }
                drawPosX = 13;
                drawPosY += 13;
            }

            this.ResumeLayout(false);
        }

        /// <summary>
        /// Returns a list of checkboxes that are checked
        /// </summary>
        /// <returns>List of coordinates</returns>
        private List<Automaton.CoordSet> GetInitLiveCellListFromCheckboxArray()
        {
            List<Automaton.CoordSet> liveCells = new List<Automaton.CoordSet>();

            for (int i = 0; i < GameUniverseSizeX; i++)
            {
                for (int j = 0; j < GameUniverseSizeY; j++)
                {
                    if (UniverseGui[i, j].Checked)
                    {
                        liveCells.Add(new Automaton.CoordSet(i, j));
                    }
                }
            }

            return liveCells;
        }

        /// <summary>
        /// Sets game GUI elements based on the current state of the universe
        /// </summary>
        private void SetCheckboxesFromUniverse()
        {
            this.SuspendLayout();

            List<Automaton.CoordSet> liveCells = Universe.Universe;
            foreach (var cb in UniverseGui)
            {
                cb.Checked = false;
            }

            foreach (var cell in liveCells)
            {
                UniverseGui[cell.X, cell.Y].Checked = true;
            }

            iterationsLabel.Text = "Time: " + Universe.Age;
            populationLabel.Text = "Population: " + Universe.NumLiveCells;

            this.ResumeLayout(false);
        }
        /// <summary>
        /// Thread-safe: Sets game GUI elements based on the current state of the universe
        /// </summary>
        private void SetCheckboxesFromUniverse(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bg = sender as BackgroundWorker;

            if (!bg.CancellationPending)
            {
                this.SuspendLayout();

                List<Automaton.CoordSet> liveCells = Universe.Universe;
                foreach (var cb in UniverseGui)
                {
                    cb.Checked = false;
                }

                foreach (var cell in liveCells)
                {
                    UniverseGui[cell.X, cell.Y].Checked = true;
                }

                iterationsLabel.Text = "Time: " + Universe.Age;
                populationLabel.Text = "Population: " + Universe.NumLiveCells;

                this.ResumeLayout(false); 
            }
            else
            {
                bg.CancelAsync();
            }
        }
    }
}