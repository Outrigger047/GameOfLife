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
        /// Parameterized constructor to instantiate Automaton and initialize 
        /// member fields and properties
        /// </summary>
        /// <param name="sizeXIn">Horizontal dimension of the universe</param>
        /// <param name="sizeYIn">Vertical dimension of the universe</param>
        /// <param name="initLiveCells">List of coordinates indicating which 
        /// cells are alive initially</param>
        public Automaton(int sizeXIn, int sizeYIn, List<CoordSet> initLiveCells)
        {
            // Set size of universe
            sizeX = sizeXIn;
            sizeY = sizeYIn;

            // Create universe and initialize cell states to dead
            universe = new Cell[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    universe[i, j] = new Cell(Cell.CellStateTypes.Dead);
                }
            }

            // Set live cells from argument
            foreach (var coords in initLiveCells)
            {
                universe[coords.X, coords.Y].State = Cell.CellStateTypes.Alive;
            }

            // Set number of live cells in the universe
            NumLiveCells = initLiveCells.Count;

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
        /// Stores, tracks, and returns the current age of the universe
        /// </summary>
        public int Age { get; private set; }
        /// <summary>
        /// Stores and returns the current number of live cells in the universe
        /// </summary>
        public int NumLiveCells { get; private set; }

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
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
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
            // Reset running track of current living cells
            NumLiveCells = 0;
            // Store/initialize data for the next iteration
            Cell[,] nextUniverse = new Cell[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    nextUniverse[i, j] = new Cell(Cell.CellStateTypes.Invalid);
                }
            }

            // Run core game logic
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    CoordSet currentPos = new CoordSet(i, j);
                    int numLiveNeighbors = CountLiveNeighbors(currentPos);
                    switch (numLiveNeighbors)
                    {
                        case 2:
                            // Living cells with 2 adjacent living cells continue living
                            if (universe[i, j].State == Cell.CellStateTypes.Alive)
                            {
                                nextUniverse[i, j].State = Cell.CellStateTypes.Alive;
                                NumLiveCells++;
                            }
                            else
                            {
                                nextUniverse[i, j].State = Cell.CellStateTypes.Dead;
                            }
                            break;
                        case 3:
                            // Living cells with 3 adjacent living cells continue living
                            if (universe[i, j].State == Cell.CellStateTypes.Alive)
                            {
                                nextUniverse[i, j].State = Cell.CellStateTypes.Alive;
                                NumLiveCells++;
                            }
                            // Dead cells with 3 adjacent living cells come to life
                            else if (universe[i, j].State == Cell.CellStateTypes.Dead)
                            {
                                nextUniverse[i, j].State = Cell.CellStateTypes.Alive;
                                NumLiveCells++;
                            }
                            else
                            {
                                nextUniverse[i, j].State = Cell.CellStateTypes.Dead;
                            }
                            break;
                        default:
                            nextUniverse[i, j].State = Cell.CellStateTypes.Dead;
                            break;
                    }
                }
            }
            universe = nextUniverse;
            Age++;
        }

        /// <summary>
        /// Sets the Universe to a forced state
        /// </summary>
        /// <param name="liveCells">List of cells that should be alive</param>
        public void ForceState(List<Automaton.CoordSet> liveCells)
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    // TODO Rewrite this inner loop
                    /*
                    Automaton.CoordSet currentPosition = new CoordSet(i, j);
                    if (liveCells.Contains(currentPosition))
                    {
                        universe[i, j].State = Cell.CellStateTypes.Alive;
                        liveCells.Remove(currentPosition);
                    }
                    else
                    {
                        universe[i, j].State = Cell.CellStateTypes.Dead;
                    }
                    */

                }
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Counts the number of live neighbor cells for a given cell
        /// </summary>
        /// <param name="currentPos">Coordinate set indicating the cell in question</param>
        /// <returns>Number of live cells adjacent to specified cell</returns>
        private int CountLiveNeighbors(CoordSet currentPos)
        {
            int numLiveNeighbors = 0;

            foreach (Cardinals cardinal in Enum.GetValues(typeof(Cardinals)))
            {
                if (GetNeighborState(currentPos, cardinal) == Cell.CellStateTypes.Alive)
                {
                    numLiveNeighbors++;
                }
            }

            return numLiveNeighbors;
        }
        
        /// <summary>
        /// Private method for CountLiveNeighbors to use to find states of nearby cells.
        /// </summary>
        /// <param name="currentPos">Coordinates of current position</param>
        /// <param name="target">Cardinal direction</param>
        /// <returns>Current state of targeted cell</returns>
        private Cell.CellStateTypes GetNeighborState(CoordSet currentPos, Cardinals target)
        {
            switch(target)
            {
                case Cardinals.N:
                    return universe[
                        currentPos.X, 
                        currentPos.Y - 1 < 0 ? 0 : currentPos.Y - 1].State;
                case Cardinals.NE:
                    return universe[
                        currentPos.X + 1 > sizeX - 1 ? sizeX - 1 : currentPos.X + 1, 
                        currentPos.Y - 1 < 0 ? 0 : currentPos.Y - 1].State;
                case Cardinals.E:
                    return universe[
                        currentPos.X + 1 > sizeX - 1 ? sizeX - 1 : currentPos.X + 1, 
                        currentPos.Y].State;
                case Cardinals.SE:
                    return universe[
                        currentPos.X + 1 > sizeX - 1 ? sizeX - 1 : currentPos.X + 1, 
                        currentPos.Y + 1 > sizeY - 1 ? sizeY - 1 : currentPos.Y + 1].State;
                case Cardinals.S:
                    return universe[
                        currentPos.X, 
                        currentPos.Y + 1 > sizeY - 1 ? sizeY - 1 : currentPos.Y + 1].State;
                case Cardinals.SW:
                    return universe[
                        currentPos.X - 1 < 0 ? 0 : currentPos.X - 1, 
                        currentPos.Y + 1 > sizeY - 1 ? sizeY - 1 : currentPos.Y + 1].State;
                case Cardinals.W:
                    return universe[
                        currentPos.X - 1 < 0 ? 0 : currentPos.X - 1, 
                        currentPos.Y].State;
                case Cardinals.NW:
                    return universe[
                        currentPos.X - 1 < 0 ? 0 : currentPos.X - 1, 
                        currentPos.Y - 1 < 0 ? 0 : currentPos.Y - 1].State;
                default:
                    return Cell.CellStateTypes.Invalid;
            }
        }
        #endregion

        #region Nested classes
        /// <summary>
        /// A single cell in the universe
        /// </summary>
        public class Cell
        {
            public CellStateTypes State { get; set; }
            
            public Cell(CellStateTypes state)
            {
                State = state;
            }

            public enum CellStateTypes
            {
                Invalid = -0x1,
                Dead = 0x0,
                Alive = 0x1
            }
        }

        /// <summary>
        /// Ordered pair for 2D coordinates
        /// </summary>
        public class CoordSet
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            public CoordSet(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
        #endregion
    }
}
