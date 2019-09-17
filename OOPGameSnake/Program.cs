using System;

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
            GameEngine game = new GameEngine();
            Menu menu = new Menu();
            menu.Greeting();
            Console.ReadLine();

            do
            {
                game.Start();

            } while (menu.ContinueGame());

            
        }
    }
}
