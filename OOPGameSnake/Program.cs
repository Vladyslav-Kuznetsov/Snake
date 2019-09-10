using System;
using System.Threading;
using DataStruct;
using NConsoleGraphics;

namespace OOPGameSnake
{
    class Program
    {
        private static int _sizeField = 800;
        private static int _sizeCell = 40;
        static void Main(string[] args)
        {
            Console.WindowHeight = 60;
            Console.WindowWidth = 120;
            ConsoleGraphics g = new ConsoleGraphics();
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            PlayingField a = new PlayingField(_sizeField, _sizeCell);
            FruitCreator f = new FruitCreator(_sizeField, _sizeCell);
            Cell tail = new Cell(_sizeField / 2, _sizeField / 2, _sizeCell);
            Snake snake = new Snake(tail, 5, _sizeField);
            Cell fruit = f.CreateFruit(snake);
            
            
            
            
            Canvas c = new Canvas(0xFFFFFFFF, 800, 800);
            snake.DrawSnake();
            
            a.DrawField(g);
            while (true)
            {
                a.DrawField(g);
                snake.ВefineСlick();
                fruit.Render1(g);

                if (snake.IsHitTail())
                {
                    break;
                }
                
                if (snake.Eat(fruit))
                {
                    fruit.Clear(g);
                    fruit = f.CreateFruit(snake);
                    
                }
                else
                {
                    snake.Move();
                }
                
                
                snake.ВefineСlick();
                fruit.Render1(g);
                g.FlipPages();
            }


            Console.ReadLine();
        }
    }
}
