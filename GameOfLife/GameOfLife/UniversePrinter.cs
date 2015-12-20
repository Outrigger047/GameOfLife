using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public static class UniversePrinter
    {
        public static void DisplayUniverse(int sizeX, int sizeY, List<CoordSet> liveCells)
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    bool foundLiveCell = false;
                    foreach (var cell in liveCells)
                    {
                        if (cell.X == i & cell.Y == j)
                        {
                            Console.Write("X");
                            foundLiveCell = true;
                        }
                    }
                    if (!foundLiveCell)
                    {
                        Console.Write(".");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
