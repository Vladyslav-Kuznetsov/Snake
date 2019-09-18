using NConsoleGraphics;
using System;
using System.Threading;

namespace OOPGameSnake
{
    public class GameEngine
    {
        private const int _sizeField = 800;
        private const int _sizeCell = 40;
        private readonly Canvas _canvas;
        private readonly ConsoleGraphics _graphics;
        private const uint _colorFruit = 0xFFFFFF00;
        private int _speed;

        public GameEngine(ConsoleGraphics graphics)
        {
            _graphics = graphics;
            _canvas = new Canvas(0xFFFFFFFF, _graphics.ClientWidth, _graphics.ClientHeight);
        }

        public void Start()
        {
            PlayingField field = new PlayingField(_sizeField, _sizeCell);
            FruitCreator fruitCreator = new FruitCreator(_sizeField, _sizeCell); ;
            Cell tail = new Cell(_sizeField / 2, _sizeField / 2, _sizeCell);
            Snake snake = new Snake(tail, 3, _sizeField);
            Cell fruit = fruitCreator.CreateFruit(snake);
            _canvas.Clear(_graphics);
            _speed = 40;

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
                        _speed -= 2;
                    }

                    fruit.Clear(_graphics);
                    fruit = fruitCreator.CreateFruit(snake);

                }
                else
                {
                    snake.Move(_graphics);
                    Thread.Sleep(_speed);
                }

                _graphics.FlipPages();
            }
        }
    }
}
