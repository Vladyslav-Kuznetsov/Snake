using System;
using DataStruct;
using NConsoleGraphics;

namespace OOPGameSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleGraphics g = new ConsoleGraphics();
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            Cell a = new Cell(0, 0);
            a.Render(g);
            Console.ReadLine();
        }
    }
}
