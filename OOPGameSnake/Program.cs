using System;
using NConsoleGraphics;

namespace OOPGameSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 51;
            Console.WindowWidth = 120;
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();
            ConsoleGraphics graphics = new ConsoleGraphics();
            GameEngine game = new GameEngine(graphics);
            Menu.Greeting(graphics);
            Console.ReadLine();

            do
            {
                game.Start();

            } while (Menu.ContinueGame(graphics));
        }
    }
}
