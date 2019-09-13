using NConsoleGraphics;
using System;
using System.Threading;

namespace OOPGameSnake
{
    public class GameEngine
    {
        private static int _sizeField = 800;
        private static int _sizeCell = 40;
        private Canvas _canvas;
        private ConsoleGraphics _graphics;
        private uint _colorFruit = 0xFFFFFF00;
        private int _speed;

        public GameEngine()
        {
            _graphics = new ConsoleGraphics();
            _canvas = new Canvas(0xFFFFFFFF, _graphics.ClientWidth, _graphics.ClientHeight);
        }

        public void Start()
        {
            PlayingField field;
            FruitCreator fruitCreator;
            Cell tail;
            Snake snake;
            Cell fruit;
            field = new PlayingField(_sizeField, _sizeCell);
            fruitCreator = new FruitCreator(_sizeField, _sizeCell);
            tail = new Cell(_sizeField / 2, _sizeField / 2, _sizeCell);
            snake = new Snake(_graphics, tail, 3, _sizeField);
            fruit = fruitCreator.CreateFruit(snake);
            _canvas.Clear(_graphics);
            _speed = 50;

            while (true)
            {
                field.Draw(_graphics);
                snake.ВefineСlick();
                fruit.Render(_graphics, _colorFruit);
                _graphics.DrawString($"Score:{Menu.Score}", "ISOCPEUR", 0xFF000000, 810, 50);
                _graphics.DrawString($"Best Score:{Menu.BestScore}", "ISOCPEUR", 0xFF000000, 810, 70);

                if (snake.IsHitTail())
                {
                    Console.Beep();
                    break;
                }

                if (snake.Eat(fruit))
                {
                    _graphics.FillRectangle(0xFFFFFFFF, 810, 50, 100, 25);
                    Menu.AddScore();

                    if (_speed > 1 && Menu.Score % 5 == 0)
                    {
                        _speed-=2;
                    }

                    fruit.Clear(_graphics);
                    fruit = fruitCreator.CreateFruit(snake);

                }
                else
                {
                    snake.Move();
                    Thread.Sleep(_speed);
                }

                _graphics.FlipPages();
            }
        }
    }
}
