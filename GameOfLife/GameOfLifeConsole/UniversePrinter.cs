using System;
using System.Collections.Generic;

namespace GameOfLife
{
    /// <summary>
    /// Helper class for printing the universe to the console
    /// </summary>
    public static class UniversePrinter
    {
        public static void DisplayUniverse(int sizeX, 
            int sizeY, 
            List<Automaton.CoordSet> liveCells,
            DisplayModes displayMode)
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    bool foundLiveCell = false;
                    foreach (var cell in liveCells)
                    {
                        if (cell.X == y & cell.Y == x)
                        {
                            Console.Write("X");
                            foundLiveCell = true;
                        }
                    }
                    if (!foundLiveCell)
                    {
                        switch (displayMode)
                        {
                            case DisplayModes.Normal:
                                Console.Write(".");
                                break;
                            case DisplayModes.HideDead:
                                Console.Write(" ");
                                break;
                            default:
                                break;
                        }
                    }
                }

                Console.WriteLine();
            }
        }

        public enum DisplayModes
        {
            Normal,
            HideDead
        }
    }
}
