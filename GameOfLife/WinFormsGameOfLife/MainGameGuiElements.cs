using GameOfLife;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsGameOfLife
{
    partial class MainGameForm
    {
        #region Fields
        /// <summary>
        /// Used to determine where to draw game universe checkboxes
        /// </summary>
        private const int ControlPanelVerticalSize = 100;
        /// <summary>
        /// Used to determine how to resize window when drawing game universe checkboxes
        /// </summary>
        private const int ControlPanelHorizontalSize = 421;
        /// <summary>
        /// Stores custom images for checkbox states
        /// </summary>
        private ImageList _customCheckboxImages = new ImageList();
        #endregion

        #region Properties
        /// <summary>
        /// Used for dynamic checkbox generation
        /// </summary>
        public CustomCheckBox[,] UniverseGui { get; private set; }
        /// <summary>
        /// Horizontal size of the universe
        /// </summary>
        public int GameUniverseSizeX { get; private set; }
        /// <summary>
        /// Vertical size of the universe
        /// </summary>
        public int GameUniverseSizeY { get; private set; }
        #endregion

        #region Private methods
        /// <summary>
        /// Initializes game-related GUI elements on the main form
        /// </summary>
        private void InitGameGui()
        {
            const int cellLength = 13;
            const int controlLocDistance = 12;
            const int winMarginX = 30;
            const int winMarginY = 20;
            const int winMinSize = 480;

            SuspendLayout();

            // Load custom checkbox images
            _customCheckboxImages.Images.Add(Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "white.bmp")));
            _customCheckboxImages.Images.Add(Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "black.bmp")));
            _customCheckboxImages.ImageSize = new Size(cellLength, cellLength);

            gameControls.Height = ControlPanelVerticalSize;
            startControls.Height = ControlPanelVerticalSize;
            gameControls.Visible = false;
            startControls.Location = new Point(controlLocDistance, controlLocDistance);

            foreach (var item in autoPlaySpeeds)
            {
                autoSpeedComboBox.Items.Add(item.Key);
            }

            int winXSize = (cellLength * GameUniverseSizeY) + winMarginX;
            int winYSize = (cellLength * GameUniverseSizeX) + ControlPanelVerticalSize + winMarginY;

            // Resize the window to accommodate the grid
            ClientSize = new Size(winXSize < winMinSize ? winMinSize : winXSize, winYSize);

            // Set up the grid of checkboxes
            UniverseGui = new CustomCheckBox[GameUniverseSizeX, GameUniverseSizeY];
            int drawPosX = cellLength;
            int drawPosY = cellLength + ControlPanelVerticalSize;
            for (int i = 0; i < GameUniverseSizeX; i++)
            {
                for (int j = 0; j < GameUniverseSizeY; j++)
                {
                    // Pass the custom image list into checkbox constructor
                    UniverseGui[i, j] = new CustomCheckBox(_customCheckboxImages);
                    UniverseGui[i, j].Margin = new Padding(0);
                    UniverseGui[i, j].CheckState = Universe.GetCellState(new Automaton.CoordSet(i, j)) == 
                        Automaton.Cell.CellStateTypes.Alive ? 
                        CheckState.Checked : 
                        CheckState.Unchecked;
                    UniverseGui[i, j].Location = new Point(drawPosX, drawPosY);
                    UniverseGui[i, j].Size = new Size(cellLength, cellLength);
                    
                    Controls.Add(UniverseGui[i, j]);

                    if (j <= GameUniverseSizeY - 1)
                    {
                        drawPosX += cellLength;
                    }
                }

                drawPosX = cellLength;
                drawPosY += cellLength;
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

            List<Automaton.CoordSet> deltaCells = Universe.GetDeltaCells;

            foreach (var cell in deltaCells)
            {
                if (UniverseGui[cell.X, cell.Y].Checked)
                {
                    UniverseGui[cell.X, cell.Y].Checked = false;
                }
                else
                {
                    UniverseGui[cell.X, cell.Y].Checked = true;
                }
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
        #endregion

    }
}