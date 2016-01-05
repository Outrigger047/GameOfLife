﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using GameOfLife;

namespace WinFormsGameOfLife
{
    public partial class MainGameForm : Form
    {
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

        /// <summary>
        /// Used to control speeds of auto player
        /// </summary>
        private readonly Dictionary<string, int> autoPlaySpeeds = new Dictionary<string, int>
        {
            { "1000 msec", 1000 },
            { "500 msec", 500 },
            { "250 msec", 250 },
            { "30 msec", 30 }
        };

        /// <summary>
        /// Universe
        /// </summary>
        public Automaton Universe { get; private set; }



        /// <summary>
        /// Constructor for generating MainGameForm for use with manual cell states
        /// </summary>
        /// <param name="sizeX">Horizontal size of the universe</param>
        /// <param name="sizeY">Vertical size of the universe</param>
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
        /// Constructor for generating MainGameForm for use with imported cell state
        /// </summary>
        /// <param name="sizeX">Horizontal size of the universe</param>
        /// <param name="sizeY">Vertical size of the universe</param>
        /// <param name="initLiveCells">List of CoordSet objects inidicating initial live cells</param>
        public MainGameForm(int sizeX, int sizeY, List<Automaton.CoordSet> initLiveCells, string importFileName)
        {
            GameUniverseSizeX = sizeX;
            GameUniverseSizeY = sizeY;

            Universe = new Automaton(GameUniverseSizeX, GameUniverseSizeY, initLiveCells);

            autoPlayer = new BackgroundWorker();
            autoPlayer.DoWork += new DoWorkEventHandler(TickBackground);
            autoPlayer.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TickBackgroundUpdate);
            autoPlayer.WorkerSupportsCancellation = true;
            autoPlayerReset = new AutoResetEvent(true);

            InitializeComponent();
            Text = "Game of Life - " + importFileName + " - " + GameUniverseSizeX + "x" + GameUniverseSizeY;
            InitGameGui();
        }

        /// <summary>
        /// Calls the BackgroundWorker when player starts the auto play option
        /// </summary>
        private void StartAutomation(int runSpeed)
        {
            if (autoPlayer.IsBusy)
            {
                autoPlayerReset.WaitOne();
            }
            autoPlayer.RunWorkerAsync(runSpeed);
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
            Thread.Sleep(Convert.ToInt32(e.Argument));
            e.Result = e.Argument;
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
                autoPlayer.RunWorkerAsync(e.Result);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Indicate game has started
            gameRunning = true;

            // Update GUI elements that the user no longer needs to interact with
            SuspendLayout();

            startButton.Enabled = false;
            incrementButton.Enabled = true;
            foreach (var cb in UniverseGui)
            {
                cb.Enabled = false;
            }

            // Sets state of the universe based on checkboxes
            Universe.ForceState(GetInitLiveCellListFromCheckboxArray());

            // Update UI indicating game state
            iterationsLabel.Text = "Time: " + Universe.Age;
            populationLabel.Text = "Population: " + Universe.NumLiveCells;

            playButton.Enabled = true;

            ResumeLayout(false);
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
                    incrementButton.Enabled = false;
                }
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            incrementButton.Enabled = false;
            playButton.Enabled = false;
            pauseButton.Enabled = true;
            autoSpeedComboBox.Enabled = false;
            ResumeLayout(false);
            int speed = 1000;
            autoPlaySpeeds.TryGetValue(autoSpeedComboBox.Text, out speed);

            StartAutomation(speed);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            autoPlayer.CancelAsync();

            SuspendLayout();
            pauseButton.Enabled = false;
            playButton.Enabled = true;
            incrementButton.Enabled = true;
            autoSpeedComboBox.Enabled = true;
            ResumeLayout(false);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            const string titleBarCaption = "Clear All Cells";
            const string confirmationMsg = "Are you sure you want to clear all cells?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            if (MessageBox.Show(confirmationMsg, titleBarCaption, buttons) == DialogResult.Yes)
            {
                ClearAllCheckboxes();
            }
        }
    }
}
