using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Automaton
    {
        // Fields
        private Cell[,] universe;
        private int sizeX, sizeY;

        // Constructor
        public Automaton(int sizeX, int sizeY, List<CoordSet> initLiveCells)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }

        // Enums
        public enum Cardinals
        {
            N, NE, E, SE, S, SW, W, NW
        }

        // Properties

        // Methods

        // Structs
        public struct CoordSet
        {
            int X;
            int Y;
        }

        // Nested classes
        class Cell
        {
            public CellStateTypes State { get; private set; }

            public enum CellStateTypes
            {
                Dead = 0x0,
                Alive = 0x1
            }
        }
    }
}
