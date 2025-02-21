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
        /// Stores the state of the previous universe
        /// </summary>
        private Cell[,] previousUniverse;
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
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    universe[x, y] = new Cell(Cell.CellStateTypes.Dead);
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

            // Initialize previous universe
            previousUniverse = new Cell[sizeX, sizeY];
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
                for (int y = 0; y < sizeY; y++)
                {
                    for (int x = 0; x < sizeX; x++)
                    {
                        if (universe[x, y].State == Cell.CellStateTypes.Alive)
                        {
                            universeOut.Add(new CoordSet(x, y));
                        }
                    }
                }
                return universeOut;
            }
        }
        /// <summary>
        /// Returns a list of live cells in the previous universe
        /// </summary>
        public List<CoordSet> PreviousUniverse
        {
            get
            {
                List<CoordSet> universeOut = new List<CoordSet>();
                for (int y = 0; y < sizeY; y++)
                {
                    for (int x = 0; x < sizeX; x++)
                    {
                        if (previousUniverse[x, y].State == Cell.CellStateTypes.Alive)
                        {
                            universeOut.Add(new CoordSet(x, y));
                        }
                    }
                }
                return universeOut;
            }
        }
        /// <summary>
        /// Returns a list of cells that changed from the previous universe to the current one
        /// </summary>
        public List<CoordSet> GetDeltaCells
        {
            get
            {
                List<CoordSet> deltaCells = new List<CoordSet>();

                for (int y = 0; y < sizeY; y++)
                {
                    for (int x = 0; x < sizeX; x++)
                    {
                        if (previousUniverse[x, y].State != universe[x, y].State)
                        {
                            deltaCells.Add(new CoordSet(x, y));
                        }
                    }
                }

                return deltaCells;
            }
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
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    nextUniverse[x, y] = new Cell(Cell.CellStateTypes.Invalid);
                }
            }

            // Run core game logic
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    CoordSet currentPos = new CoordSet(x, y);
                    int numLiveNeighbors = CountLiveNeighbors(currentPos);
                    switch (numLiveNeighbors)
                    {
                        case 2:
                            // Living cells with 2 adjacent living cells continue living
                            if (universe[x, y].State == Cell.CellStateTypes.Alive)
                            {
                                nextUniverse[x, y].State = Cell.CellStateTypes.Alive;
                                NumLiveCells++;
                            }
                            else
                            {
                                nextUniverse[x, y].State = Cell.CellStateTypes.Dead;
                            }
                            break;
                        case 3:
                            // Living cells with 3 adjacent living cells continue living
                            if (universe[x, y].State == Cell.CellStateTypes.Alive)
                            {
                                nextUniverse[x, y].State = Cell.CellStateTypes.Alive;
                                NumLiveCells++;
                            }
                            // Dead cells with 3 adjacent living cells come to life
                            else if (universe[x, y].State == Cell.CellStateTypes.Dead)
                            {
                                nextUniverse[x, y].State = Cell.CellStateTypes.Alive;
                                NumLiveCells++;
                            }
                            else
                            {
                                nextUniverse[x, y].State = Cell.CellStateTypes.Dead;
                            }
                            break;
                        default:
                            nextUniverse[x, y].State = Cell.CellStateTypes.Dead;
                            break;
                    }
                }
            }

            previousUniverse = universe;
            universe = nextUniverse;
            Age++;
        }

        /// <summary>
        /// Sets the Universe to a forced state
        /// </summary>
        /// <param name="liveCells">List of cells that should be alive</param>
        public void ForceState(List<Automaton.CoordSet> liveCells)
        {
            foreach (var cell in universe)
            {
                cell.State = Cell.CellStateTypes.Dead;
            }

            foreach (var cell in liveCells)
            {
                universe[cell.X, cell.Y].State = Cell.CellStateTypes.Alive;
            }

            NumLiveCells = liveCells.Count;
        }

        /// <summary>
        /// Get the current state of a given cell in the universe
        /// </summary>
        /// <param name="target">Coordinates of the target cell</param>
        /// <returns>Current state of the target cell</returns>
        public Automaton.Cell.CellStateTypes GetCellState(Automaton.CoordSet target)
        {
            return universe[target.X, target.Y].State;
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
            Cell.CellStateTypes neighborState = Cell.CellStateTypes.Invalid;

            switch(target)
            {
                case Cardinals.N:
                    if (currentPos.Y - 1 < 0)
                    {
                        neighborState = Cell.CellStateTypes.Invalid;
                    }
                    else
                    {
                        neighborState = universe[currentPos.X, currentPos.Y - 1].State;
                    }
                    break;
                case Cardinals.NE:
                    if (currentPos.X + 1 > sizeX - 1 | currentPos.Y - 1 < 0)
                    {
                        neighborState = Cell.CellStateTypes.Invalid;
                    }
                    else
                    {
                        neighborState = universe[currentPos.X + 1, currentPos.Y - 1].State;
                    }
                    break;
                case Cardinals.E:
                    if (currentPos.X + 1 > sizeX - 1)
                    {
                        neighborState = Cell.CellStateTypes.Invalid;
                    }
                    else
                    {
                        neighborState = universe[currentPos.X + 1, currentPos.Y].State;
                    }
                    break;
                case Cardinals.SE:
                    if (currentPos.X + 1 > sizeX - 1 | currentPos.Y + 1 > sizeY - 1)
                    {
                        neighborState = Cell.CellStateTypes.Invalid;
                    }
                    else
                    {
                        neighborState = universe[currentPos.X + 1, currentPos.Y + 1].State;
                    }
                    break;
                case Cardinals.S:
                    if (currentPos.Y + 1 > sizeY - 1)
                    {
                        neighborState = Cell.CellStateTypes.Invalid;
                    }
                    else
                    {
                        neighborState = universe[currentPos.X, currentPos.Y + 1].State;
                    }
                    break;
                case Cardinals.SW:
                    if (currentPos.Y + 1 > sizeY - 1 | currentPos.X - 1 < 0)
                    {
                        neighborState = Cell.CellStateTypes.Invalid;
                    }
                    else
                    {
                        neighborState = universe[currentPos.X - 1, currentPos.Y + 1].State;
                    }
                    break;
                case Cardinals.W:
                    if (currentPos.X - 1 < 0)
                    {
                        neighborState = Cell.CellStateTypes.Invalid;
                    }
                    else
                    {
                        neighborState = universe[currentPos.X - 1, currentPos.Y].State;
                    }
                    break;
                case Cardinals.NW:
                    if (currentPos.Y - 1 < 0 | currentPos.X - 1 < 0)
                    {
                        neighborState = Cell.CellStateTypes.Invalid;
                    }
                    else
                    {
                        neighborState = universe[currentPos.X - 1, currentPos.Y - 1].State;
                    }
                    break;
                default:
                    neighborState = Cell.CellStateTypes.Invalid;
                    break;
            }

            return neighborState;
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
