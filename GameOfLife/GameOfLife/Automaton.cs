using System;
using System.Collections.Generic;

namespace GameOfLife
{
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

    public class Automaton
    {
        // Fields
        private Cell[,] universe;
        private int sizeX, sizeY;
        private int age;

        // Constructor
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
            age = 0;
        }

        // Enums
        enum Cardinals
        {
            N, NE, E, SE, S, SW, W, NW
        }

        // Properties
        public int Age { get { return age; } }
        public int SizeX { get { return sizeX; } }
        public int SizeY { get { return sizeY; } }

        // Methods

        // Nested classes
        class Cell
        {
            public CellStateTypes State { get; set; }

            public enum CellStateTypes
            {
                Dead = 0x0,
                Alive = 0x1
            }
        }
    }
}
