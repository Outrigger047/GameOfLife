// Preprocessor directives
#define DEBUG

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

            Console.WriteLine("Specify live cell coordinate input mode:");
            Console.WriteLine("1   External text file");
            Console.WriteLine("2   Manual list input");
            List<CoordSet> liveCells = new List<CoordSet>();
            ConsoleKeyInfo inputModeKeyPress = Console.ReadKey();
            switch (inputModeKeyPress.ToString())
            {
                case "1":
                    string[] fileData;
                    Console.WriteLine("File path: ");

                    try
                    {
                        fileData = File.ReadAllLines(Console.ReadLine());
                        foreach (var line in fileData)
                        {
                            if (Regex.IsMatch(line, "^[0-9]+,[0-9]+$"))
                            {
                                liveCells.Add(
                                    new CoordSet(
                                        Convert.ToInt32(line.Split(',')[0]), 
                                        Convert.ToInt32(line.Split(',')[1])));
                            }
                        }
                    }
                    catch (IOException ioe)
                    {
                        Console.Write("IO Exception: ", ioe.Message);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    break;
                case "2":
                    ConsoleKeyInfo moreCoordsKeyPress;
                    do
                    {
                        Console.Write("X Coordinate: ");
                        int x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Y Coordinate: ");
                        int y = Convert.ToInt32(Console.ReadLine());
                        liveCells.Add(new CoordSet(x, y));
                        Console.Write("More? (Y/N) ");
                        moreCoordsKeyPress = Console.ReadKey(); 
                    } while (moreCoordsKeyPress.Key == ConsoleKey.Y);
                    
                    break;
                default:
                    break;
            }
            #endregion



            Automaton a = new Automaton(sizeX, sizeY, liveCells);

            Console.WriteLine("Q quits. Press any other key to start/advance the state of the simulation.");
            Console.WriteLine();

            ConsoleKeyInfo advanceKp = Console.ReadKey();
            while (advanceKp.Key != ConsoleKey.Q)
            {
                Console.Clear();

                UniversePrinter.DisplayUniverse(sizeX, sizeY, a.Universe);
            }
        }
    }
}
