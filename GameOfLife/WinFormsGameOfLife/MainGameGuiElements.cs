using System.Collections.Generic;
using GameOfLife;

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
        /// Used to determine where to draw game universe checkboxes
        /// </summary>
        private const int ControlPanelVerticalSize = 100;
        /// <summary>
        /// Used to determine how to resize window when drawing game universe checkboxes
        /// </summary>
        private const int ControlPanelHorizontalSize = 421;

        /// <summary>
        /// Initializes game-related GUI elements on the main form
        /// </summary>
        private void InitGameGui()
        {
            SuspendLayout();

            gameControls.Visible = false;
            startControls.Location = new System.Drawing.Point(12, 12);

            foreach (var item in autoPlaySpeeds)
            {
                autoSpeedComboBox.Items.Add(item.Key);
            }

            int winXSize = (13 * GameUniverseSizeY) + 30;
            int winYSize = (13 * GameUniverseSizeX) + ControlPanelVerticalSize + 10;

            // Resize the window to accommodate the grid
            ClientSize = new System.Drawing.Size(
                winXSize < 480 ? 480 : winXSize, 
                winYSize);

            // Set up the grid of checkboxes
            UniverseGui = new System.Windows.Forms.CheckBox[GameUniverseSizeX, GameUniverseSizeY];
            int drawPosX = 13;
            int drawPosY = 13 + ControlPanelVerticalSize;
            for (int i = 0; i < GameUniverseSizeX; i++)
            {
                for (int j = 0; j < GameUniverseSizeY; j++)
                {
                    UniverseGui[i, j] = new System.Windows.Forms.CheckBox();
                    UniverseGui[i, j].Margin = new System.Windows.Forms.Padding(0);
                    UniverseGui[i, j].CheckState = System.Windows.Forms.CheckState.Unchecked;
                    UniverseGui[i, j].Location = new System.Drawing.Point(drawPosX, drawPosY);
                    UniverseGui[i, j].Size = new System.Drawing.Size(13, 13);

                    Controls.Add(UniverseGui[i, j]);

                    if (j <= GameUniverseSizeY - 1)
                    {
                        drawPosX += 13; 
                    }
                }
                drawPosX = 13;
                drawPosY += 13;
            }

            ResumeLayout(false);
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
            SuspendLayout();

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

            ResumeLayout(false);
        }

        /// <summary>
        /// Wipes all live checkboxes
        /// </summary>
        private void ClearAllCheckboxes()
        {
            if (!gameRunning)
            {
                SuspendLayout();
                foreach (var cb in UniverseGui)
                {
                    cb.Checked = false;
                }
                ResumeLayout(false); 
            }
        }

    }
}