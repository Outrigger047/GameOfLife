using GameOfLife;

namespace WinFormsGameOfLife
{
    partial class MainGameForm
    {
        /// <summary>
        /// Used for dynamic checkbox generation
        /// </summary>
        public System.Windows.Forms.CheckBox[,] UniverseGui { get; private set; }

        public int GameUniverseSizeX { get; private set; }
        public int GameUniverseSizeY { get; private set; }
        public Automaton Universe { get; private set; }

        private void InitGameGui()
        {
            this.SuspendLayout();

            // Resize the window to accommodate the grid
            this.ClientSize = new System.Drawing.Size((15 * GameUniverseSizeX) + 30, (14 * GameUniverseSizeY) + 30);


            // Set up the grid of checkboxes
            UniverseGui = new System.Windows.Forms.CheckBox[GameUniverseSizeX, GameUniverseSizeY];
            int drawPosX = 15;
            int drawPosY = 15;
            for (int i = 0; i < GameUniverseSizeX; i++)
            {
                for (int j = 0; j < GameUniverseSizeY; j++)
                {
                    UniverseGui[i, j] = new System.Windows.Forms.CheckBox();
                    UniverseGui[i, j].CheckState = System.Windows.Forms.CheckState.Unchecked;
                    UniverseGui[i, j].Location = new System.Drawing.Point(drawPosX, drawPosY);
                    UniverseGui[i, j].Size = new System.Drawing.Size(15, 14);

                    this.Controls.Add(UniverseGui[i, j]);

                    if (j <= GameUniverseSizeY - 1)
                    {
                        drawPosX += 15; 
                    }
                }

                drawPosX = 15;
                drawPosY += 14;
            }

            this.ResumeLayout(false);
        }
    }
}