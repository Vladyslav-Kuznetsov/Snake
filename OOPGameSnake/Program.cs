using System;
using System.Threading;
using DataStruct;
using NConsoleGraphics;

namespace OOPGameSnake
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WindowHeight = 60;
            Console.WindowWidth = 120;
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();
            GameEngine game = new GameEngine();

            do
            {
                game.Start();

            } while (game.ContinueGame());
        }
    }
}
