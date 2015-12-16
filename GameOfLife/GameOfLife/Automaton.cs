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
        private readonly int sizeX, sizeY;
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
                List<CoordSet> universeOut = new List<CoordSet>();

                for (int i = 0; i < sizeX - 1; i++)
                {
                    for (int j = 0; j < sizeY - 1; j++)
                    {
                        if (universe[i,j].State == Cell.CellStateTypes.Alive)
                        {
                            universeOut.Add(new CoordSet(i, j));
                        }
                    }
                }

                return universeOut;
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Advances the age of the universe by 1
        /// </summary>
        public void Tick()
        {
            Cell[,] nextUniverse = new Cell[sizeX, sizeY];
            foreach (var cell in nextUniverse)
            {
                cell.State = Cell.CellStateTypes.Invalid;
            }

        }
        #endregion

        #region Private methods
        /// <summary>
        /// Private method for Tick to use to find states of nearby cells.
        /// </summary>
        /// <param name="currentPos">Coordinates of current position</param>
        /// <param name="target">Cardinal direction</param>
        /// <returns>Current state of targeted cell</returns>
        private Cell.CellStateTypes GetNeighborState(CoordSet currentPos, Cardinals target)
        {
            switch(target)
            {
                case Cardinals.N:
                    return universe[currentPos.X, currentPos.Y - 1].State;
                case Cardinals.NE:
                    return universe[currentPos.X + 1, currentPos.Y - 1].State;
                case Cardinals.E:
                    return universe[currentPos.X + 1, currentPos.Y].State;
                case Cardinals.SE:
                    return universe[currentPos.X + 1, currentPos.Y + 1].State;
                case Cardinals.S:
                    return universe[currentPos.X, currentPos.Y + 1].State;
                case Cardinals.SW:
                    return universe[currentPos.X - 1, currentPos.Y + 1].State;
                case Cardinals.W:
                    return universe[currentPos.X - 1, currentPos.Y].State;
                case Cardinals.NW:
                    return universe[currentPos.X - 1, currentPos.Y - 1].State;
                default:
                    return Cell.CellStateTypes.Invalid;
            }
        }

        /// <summary>
        /// Counts the number of live neighbor cells for a given cell
        /// </summary>
        /// <param name="currentPos">Coordinate set indicating the cell in question</param>
        /// <returns>Number of live cells adjacent to specified cell</returns>
        private int CountLiveNeighbors(CoordSet currentPos)
        {
            int numLiveCells = 0;



            return numLiveCells;
        }
        #endregion


        #region Nested classes
        class Cell
        {
            public CellStateTypes State { get; set; }

            public enum CellStateTypes
            {
                Invalid = -0x1,
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
