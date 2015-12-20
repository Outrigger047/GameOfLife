using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static List<object> CheckArgs(string[] args)
        {
            List<object> argsGeneric = new List<object>();

            if (args.Length > 1)
            {
                string arg1 = args[1];
                switch (arg1)
                {
                    case "-h":
                        argsGeneric.Add()
                        break;
                    default:
                        break;
                }
            }

            return argsGeneric;
        }

        static void Main(string[] args)
        {
            #region Get console input
            Console.Write("Horizontal size of universe: ");
            int sizeX = Convert.ToInt32(Console.ReadLine());

            Console.Write("Vertical size of universe: ");
            int sizeY = Convert.ToInt32(Console.ReadLine());
            #endregion

            #region Initialize simulation
            List<Automaton.CoordSet> liveCells = new List<Automaton.CoordSet>
            {
                //Cool infinite loop at end
                new Automaton.CoordSet(2, 2),
                new Automaton.CoordSet(3, 2),
                new Automaton.CoordSet(2, 3),
                new Automaton.CoordSet(3, 3),
                new Automaton.CoordSet(4, 3),
                new Automaton.CoordSet(4, 4),
                new Automaton.CoordSet(4, 5),
                new Automaton.CoordSet(6, 2),
                new Automaton.CoordSet(6, 3),
                new Automaton.CoordSet(6, 4),
                new Automaton.CoordSet(6, 5),
                new Automaton.CoordSet(6, 6),
                new Automaton.CoordSet(6, 7),
                new Automaton.CoordSet(6, 8),
                new Automaton.CoordSet(7, 6),
                new Automaton.CoordSet(7, 7),
                new Automaton.CoordSet(7, 8)
                

            };

            Automaton a = new Automaton(sizeX, sizeY, liveCells);

            Console.Clear();
            UniversePrinter.DisplayUniverse(sizeX, 
                sizeY, 
                a.Universe, 
                UniversePrinter.DisplayModes.Normal);
            Console.WriteLine();
            Console.WriteLine(string.Concat("Population: ", a.NumLiveCells));
            Console.WriteLine();
            Console.WriteLine("Press any key to start simulation. Q quits.");

            ConsoleKeyInfo advanceKp = new ConsoleKeyInfo();
            while (a.NumLiveCells > 0 && advanceKp.Key != ConsoleKey.Q)
            {
                ConsoleKeyInfo newAdvanceKp = Console.ReadKey();
                if (newAdvanceKp.Key == ConsoleKey.Q)
                {
                    Console.WriteLine();
                    break;
                }
                Console.Clear();

                a.Tick();
                UniversePrinter.DisplayUniverse(sizeX, 
                    sizeY, 
                    a.Universe, 
                    UniversePrinter.DisplayModes.Normal);
                Console.WriteLine();
                Console.WriteLine(string.Concat("Population: ", a.NumLiveCells));
                Console.WriteLine(string.Concat("Iteration: ", a.Age));
                Console.WriteLine();
                Console.WriteLine("Press any key to advance simulation. Q quits.");
                advanceKp = newAdvanceKp;
            }
            #endregion
        }
    }
}
