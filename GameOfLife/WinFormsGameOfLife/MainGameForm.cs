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
            List<Automaton.CoordSet> emptyDead = new List<Automaton.CoordSet>();
            Universe = new Automaton(GameUniverseSizeX, GameUniverseSizeY, emptyDead);

            InitializeComponent();
            InitGameGui();
        }

        private List<Automaton.CoordSet> GetInitLiveCellListFromCheckboxArray()
        {
            List<Automaton.CoordSet> liveCells = new List<Automaton.CoordSet>();
            return liveCells;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            gameRunning = true;

            this.startButton.Enabled = false;
            this.incrementButton.Enabled = true;

            // NEED TO ADD METHOD TO AUTOMATON TO TAKE A LIST AND SET THE STATE
            Universe.ForceState(GetInitLiveCellListFromCheckboxArray());
        }
    }
}
