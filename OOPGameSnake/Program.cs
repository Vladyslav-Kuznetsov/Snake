using System;
using DataStruct;
using NConsoleGraphics;

namespace OOPGameSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 32;
            Console.WindowWidth = 120;
            ConsoleGraphics g = new ConsoleGraphics();
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            PlayingField a = new PlayingField(500, 50);
            Console.ReadLine();
        }
    }
}
