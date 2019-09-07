using System;
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
            ConsoleGraphics g = new ConsoleGraphics();
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            PlayingField a = new PlayingField(800, 40);
            Snake s = new Snake(0xFFFF0000, 800 / 2, 800 / 2, 40, 40);
            Canvas c = new Canvas(0xFFFFFFFF, 800, 800);

            while (true)
            {
                a.DrawField();
                s.Render(g);
                s.Update(a);
                c.Render(g);
            }
            Console.ReadLine();
        }
    }
}
