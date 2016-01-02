using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameOfLife;

namespace WinFormsGameOfLife
{
    public partial class MainGameForm : Form
    {
        private bool gameRunning = false;

        /// <summary>
        /// Universe
        /// </summary>
        public Automaton Universe { get; private set; }

        public MainGameForm(int sizeX, int sizeY)
        {
            GameUniverseSizeX = sizeX;
            GameUniverseSizeY = sizeY;
            this.Text = "Game of Life - " + GameUniverseSizeX + "x" + GameUniverseSizeY;
            List<Automaton.CoordSet> emptyDead = new List<Automaton.CoordSet>();
            Universe = new Automaton(GameUniverseSizeX, GameUniverseSizeY, emptyDead);

            InitializeComponent();
            InitGameGui();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            gameRunning = true;

            // Update GUI elements that the user no longer needs to interact with
            this.SuspendLayout();

            this.startButton.Enabled = false;
            this.incrementButton.Enabled = true;
            foreach (var cb in UniverseGui)
            {
                cb.Enabled = false;
            }

            // Sets state of the universe based on checkboxes
            Universe.ForceState(GetInitLiveCellListFromCheckboxArray());

            iterationsLabel.Text = "Time: " + Universe.Age;
            populationLabel.Text = "Population: " + Universe.NumLiveCells;

            this.playButton.Enabled = true;

            this.ResumeLayout(false);
        }

        private void incrementButton_Click(object sender, EventArgs e)
        {
            if (gameRunning)
            {
                // Capture universe state prior to incrementing
                List<Automaton.CoordSet> currentUniverse = Universe.Universe;
                // Increment state of the universe
                Universe.Tick();
                // Update GUI based on new universe state
                SetCheckboxesFromUniverse();

                // End game if everything is dead or stuck
                // TODO Need to sort for comparison first...
                if (Universe.NumLiveCells == 0 || currentUniverse == Universe.Universe)
                {
                    this.incrementButton.Enabled = false;
                }
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            this.incrementButton.Enabled = false;
            this.playButton.Enabled = false;
            this.pauseButton.Enabled = true;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            this.pauseButton.Enabled = false;
            this.playButton.Enabled = true;
            this.incrementButton.Enabled = true;
        }
    }
}
