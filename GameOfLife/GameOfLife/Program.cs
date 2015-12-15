using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
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
            ConsoleKeyInfo keyPress = Console.ReadKey();
            switch (keyPress.ToString())
            {
                case "1":
                    string[] fileData;
                    Console.WriteLine("File path: ");

                    try
                    {
                        fileData = File.ReadAllLines(Console.ReadLine());
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
                    break;
                default:
                    break;
            }
        }
    }
}
