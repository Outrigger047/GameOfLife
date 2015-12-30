﻿using System;
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
            List<Automaton.CoordSet> emptyDead = new List<Automaton.CoordSet>();
            Universe = new Automaton(GameUniverseSizeX, GameUniverseSizeY, emptyDead);

            InitializeComponent();
            InitGameGui();
        }

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

        private void startButton_Click(object sender, EventArgs e)
        {
            gameRunning = true;

            // Update GUI elements that the user no longer needs to interact with
            this.startButton.Enabled = false;
            this.incrementButton.Enabled = true;
            foreach (var cb in UniverseGui)
            {
                cb.Enabled = false;
            }

            // Sets state of the universe based on checkboxes
            Universe.ForceState(GetInitLiveCellListFromCheckboxArray());
        }

        private void incrementButton_Click(object sender, EventArgs e)
        {
            if (gameRunning)
            {
                // Increment state of the universe
                Universe.Tick();
                // Update GUI based on new universe state
                SetCheckboxesFromUniverse();
            }
        }
    }
}
