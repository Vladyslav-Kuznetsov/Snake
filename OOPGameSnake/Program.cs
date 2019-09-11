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

            PlayingField field;
            FruitCreator fruitCreator;
            Cell tail;
            Snake snake;
            Cell fruit;
            GameEngine game = new GameEngine();
            Canvas c = new Canvas(0xFFFFFFFF, g.ClientWidth, g.ClientHeight);


            do
            {
                field = new PlayingField(_sizeField, _sizeCell);
                fruitCreator = new FruitCreator(_sizeField, _sizeCell);
                tail = new Cell(_sizeField / 2, _sizeField / 2, _sizeCell);
                snake = new Snake(tail, 3, _sizeField);
                fruit = fruitCreator.CreateFruit(snake);

                game.Start(field, snake, fruitCreator, fruit);

            } while (game.Continue(c));




            //Canvas c = new Canvas(0xFFFFFFFF, 800, 800);
            //snake.DrawSnake();


            //while (true)
            //{
            //    field.Draw(g);
            //    snake.ВefineСlick();
            //    fruit.Render1(g);

            //    if (snake.IsHitTail())
            //    {
            //        break;
            //    }

            //    if (snake.Eat(fruit))
            //    {
            //        fruit.Clear(g);
            //        fruit = fruitCreator.CreateFruit(snake);

            //    }
            //    else
            //    {
            //        snake.Move();
            //    }



            //    g.FlipPages();
            //}


            Console.ReadLine();
        }
    }
}
