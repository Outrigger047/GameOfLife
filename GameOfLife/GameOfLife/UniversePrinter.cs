using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class UniversePrinter
    {
        public static void DisplayUniverse(int sizeX, int sizeY, List<CoordSet> liveCells)
        {
            for (int i = 0; i < sizeX - 1; i++)
            {
                for (int j = 0; j < sizeY - 1; j++)
                {
                    foreach (var cell in liveCells)
                    {
                        if (cell.X == i & cell.Y == j)
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
