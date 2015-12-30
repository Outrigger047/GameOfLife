﻿using GameOfLife;

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
                winXSize < 280 ? 280 : winXSize, 
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
    }
}