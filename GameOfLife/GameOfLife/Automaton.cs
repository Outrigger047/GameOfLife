using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Automaton
    {
        #region Fields
        /// <summary>
        /// Stores the current state of the universe
        /// </summary>
        private Cell[,] universe;
        /// <summary>
        /// Dimensions of the universe
        /// </summary>
        private int sizeX, sizeY;
        #endregion

        #region Constructor
        /// <summary>
        /// Parameterized constructor to instantiate Automaton and initialize member fields and properties
        /// </summary>
        /// <param name="sizeXIn">Horizontal dimension of the universe</param>
        /// <param name="sizeYIn">Vertical dimension of the universe</param>
        /// <param name="initLiveCells">List of coordinates indicating which cells are alive initially</param>
        public Automaton(int sizeXIn, int sizeYIn, List<CoordSet> initLiveCells)
        {
            // Set size of universe
            sizeX = sizeXIn;
            sizeY = sizeYIn;

            // Create universe and initialize cell states to dead
            universe = new Cell[sizeX, sizeY];
            foreach (var cell in universe)
            {
                cell.State = Cell.CellStateTypes.Dead;
            }

            // Set live cells from argument
            foreach (var coords in initLiveCells)
            {
                universe[coords.X, coords.Y].State = Cell.CellStateTypes.Alive;
            }

            // Initialize age of universe
            Age = 0;
        }
        #endregion

        #region Enums
        /// <summary>
        /// Used for neighbor-finding
        /// </summary>
        enum Cardinals
        {
            N, NE, E, SE, S, SW, W, NW
        }
        #endregion

        #region Properties
        /// <summary>
        /// Auto-implemented property to store, track, and return the current age of the universe
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// Returns horizontal dimension of the universe
        /// </summary>
        public int SizeX { get { return sizeX; } }
        /// <summary>
        /// Returns vertical dimension of the universe
        /// </summary>
        public int SizeY { get { return sizeY; } }

        /// <summary>
        /// Returns a list of live cells in the universe
        /// </summary>
        public List<CoordSet> Universe
        {
            get
            {
                List<CoordSet> uOut = new List<CoordSet>();

                // TODO Implement universe conversion to list of live cells

                return uOut;
            }
        }
        #endregion

        #region Methods
        #endregion


        #region Nested classes
        class Cell
        {
            public CellStateTypes State { get; set; }

            public enum CellStateTypes
            {
                Dead = 0x0,
                Alive = 0x1
            }
        }
        #endregion
    }

    public struct CoordSet
    {
        public int X { get; }
        public int Y { get; }

        public CoordSet(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
