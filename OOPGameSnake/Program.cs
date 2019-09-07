using System;
using DataStruct;
using NConsoleGraphics;

namespace OOPGameSnake
{
    class Program
    {
        private static int _sizeField = 800;
        private static int _sizeCell = 40;
        private static int _speed = 40;
        static void Main(string[] args)
        {
            Console.WindowHeight = 60;
            Console.WindowWidth = 120;
            ConsoleGraphics g = new ConsoleGraphics();
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            PlayingField a = new PlayingField(_sizeField, _sizeCell);
            Fruit f = new Fruit(_sizeField, _sizeCell);
            Snake s = new Snake(0xFFFF0000, _sizeField / 2, _sizeField / 2, _sizeCell, _speed);
            Canvas c = new Canvas(0xFFFFFFFF, 800, 800);

            while (true)
            {
                a.DrawField(g);
                //f.Render(g);
                s.Render(g);
                s.Update(a);
                c.Render(g);

            }


            Console.ReadLine();
        }
    }
}
