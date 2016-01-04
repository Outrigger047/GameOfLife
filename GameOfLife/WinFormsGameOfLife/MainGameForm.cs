using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using GameOfLife;

namespace WinFormsGameOfLife
{
    public partial class MainGameForm : Form
    {
        /// <summary>
        /// Used to track whether or not the user has clicked the Start button
        /// </summary>
        private bool gameRunning = false;
        /// <summary>
        /// Universe
        /// </summary>
        public Automaton Universe { get; private set; }

        private bool autoPlay = false;
        //private BackgroundWorker uiUpdater;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sizeX">Horizontal number of cells in the universe</param>
        /// <param name="sizeY">Vertical number of cells in the universe</param>
        public MainGameForm(int sizeX, int sizeY)
        {
            GameUniverseSizeX = sizeX;
            GameUniverseSizeY = sizeY;

            List<Automaton.CoordSet> emptyDead = new List<Automaton.CoordSet>();
            Universe = new Automaton(GameUniverseSizeX, GameUniverseSizeY, emptyDead);

            InitializeComponent();
            this.Text = "Game of Life - " + GameUniverseSizeX + "x" + GameUniverseSizeY;



            InitGameGui();
        }

        private void StartAutomation()
        {
            while (autoPlay)
            {
                BackgroundWorker uiUpdater = new BackgroundWorker();
                uiUpdater.DoWork += new DoWorkEventHandler(AutoIterate);
                uiUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(SetCheckboxesFromUniverse_Async);
                var workerDone = new AutoResetEvent(false);
                uiUpdater.RunWorkerAsync(workerDone);
                workerDone.WaitOne();
            }
        }

        /// <summary>
        /// Automatically runs the game
        /// </summary>
        private void AutoIterate(object sender, DoWorkEventArgs e)
        {
            // Wait
            System.Threading.Thread.Sleep(500);
            // Increment state of the universe
            Universe.Tick();
            (e.Argument as AutoResetEvent).Set();
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
            this.SuspendLayout();
            this.incrementButton.Enabled = false;
            this.playButton.Enabled = false;
            this.pauseButton.Enabled = true;
            this.ResumeLayout(false);

            autoPlay = true;
            StartAutomation();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            autoPlay = false;

            this.SuspendLayout();
            this.incrementButton.Enabled = true;
            this.playButton.Enabled = true;
            this.pauseButton.Enabled = false;
            this.ResumeLayout(false);
        }
    }
}
