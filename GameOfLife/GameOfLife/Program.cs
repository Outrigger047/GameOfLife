using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Get console input
            Console.Write("Horiz size of universe: ");
            int sizeX = Convert.ToInt32(Console.ReadLine());

            Console.Write("Vert size of universe: ");
            int sizeY = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input max age: ");
            int maxAge = Convert.ToInt32(Console.ReadLine());

            #endregion

            List<CoordSet> liveCells = new List<CoordSet>
            {
                new CoordSet(2, 2),
                new CoordSet(3, 2),
                new CoordSet(2, 3),
                new CoordSet(3, 3),
                new CoordSet(4, 3),
                new CoordSet(4, 4),
                new CoordSet(4, 5),
                new CoordSet(6, 2),
                new CoordSet(6, 3),
                new CoordSet(6, 4),
                new CoordSet(6, 5),
                new CoordSet(6, 6),
                new CoordSet(6, 7),
                new CoordSet(6, 8),
                new CoordSet(7, 6),
                new CoordSet(7, 7),
                new CoordSet(7, 8)
            };

            Automaton a = new Automaton(sizeX, sizeY, liveCells);

            Console.WriteLine("Q quits. Press any other key to start/advance the state of the simulation.");
            Console.WriteLine();

            ConsoleKeyInfo advanceKp = new ConsoleKeyInfo();
            while (a.NumLiveCells > 0 && advanceKp.Key != ConsoleKey.Q)
            {
                ConsoleKeyInfo newAdvanceKp = Console.ReadKey();
                Console.Clear();

                a.Tick();
                UniversePrinter.DisplayUniverse(sizeX, sizeY, a.Universe);
                Console.WriteLine();
                Console.WriteLine(string.Concat("Iteration: ", a.Age));
                advanceKp = newAdvanceKp;
            }
        }
    }
}
