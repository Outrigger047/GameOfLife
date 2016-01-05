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
        /// Universe
        /// </summary>
        public Automaton Universe { get; private set; }

        /// <summary>
        /// Set when the player starts the game
        /// </summary>
        private bool gameRunning = false;
        /// <summary>
        /// Handles background updating of the universe so UI doesn't lock up
        /// </summary>
        private BackgroundWorker autoPlayer;
        /// <summary>
        /// Prevents new work being assigned to BackgroundWorker before it's done
        /// </summary>
        private AutoResetEvent autoPlayerReset;

        public MainGameForm(int sizeX, int sizeY)
        {
            GameUniverseSizeX = sizeX;
            GameUniverseSizeY = sizeY;
            
            List<Automaton.CoordSet> emptyDead = new List<Automaton.CoordSet>();
            Universe = new Automaton(GameUniverseSizeX, GameUniverseSizeY, emptyDead);

            autoPlayer = new BackgroundWorker();
            autoPlayer.DoWork += new DoWorkEventHandler(TickBackground);
            autoPlayer.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TickBackgroundUpdate);
            autoPlayer.WorkerSupportsCancellation = true;
            autoPlayerReset = new AutoResetEvent(true);

            InitializeComponent();
            Text = "Game of Life - " + GameUniverseSizeX + "x" + GameUniverseSizeY;
            InitGameGui();
        }

        /// <summary>
        /// Calls the BackgroundWorker when player starts the auto play option
        /// </summary>
        private void StartAutomation()
        {
            if (autoPlayer.IsBusy)
            {
                autoPlayerReset.WaitOne();
            }
            autoPlayer.RunWorkerAsync();
        }

        /// <summary>
        /// Event handler for background universe incrementing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Event arguments</param>
        private void TickBackground(object sender, DoWorkEventArgs e)
        {
            // Increment state of the universe
            Universe.Tick();
            // Wait time before drawing on screen
            Thread.Sleep(350);
            // Pass along cancellation request if player has clicked pause button
            if (autoPlayer.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Event handler for updating GUI when BackgroundWorker is done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Event arguments</param>
        private void TickBackgroundUpdate(object sender, RunWorkerCompletedEventArgs e)
        {
            // Update GUI based on BackgroundWorker
            SetCheckboxesFromUniverse();
            // Indicate background work is done
            autoPlayerReset.Set();
            // Start the worker again if the player hasn't clicked the pause button
            if (!e.Cancelled)
            {
                autoPlayer.RunWorkerAsync();
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Indicate game has started
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

            // Update UI indicating game state
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

            StartAutomation();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            autoPlayer.CancelAsync();

            this.pauseButton.Enabled = false;
            this.playButton.Enabled = true;
            this.incrementButton.Enabled = true;
        }
    }
}
