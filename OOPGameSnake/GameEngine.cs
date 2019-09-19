using NConsoleGraphics;
using System;
using System.Threading;
using DataStruct;

namespace OOPGameSnake
{
    public class GameEngine
    {
        private readonly ConsoleGraphics _graphics;
        private int _speed;
        private const int _snakeLength = 3;

        public GameEngine(ConsoleGraphics graphics)
        {
            _graphics = graphics;
        }

        public void Start()
        {
            PlayingField field = new PlayingField();
            Snake snake = new Snake(_snakeLength);
            Fruit fruit = new Fruit(snake);
            _speed = 40;
            
            while (true)
            {
                _graphics.FillRectangle(Settings.WhiteColor, 0, 0, _graphics.ClientWidth, _graphics.ClientHeight);
                snake.ВefineСlick();
                snake.Draw(_graphics);
                field.Draw(_graphics);
                fruit.Draw(_graphics);
                Menu.ShowScore(_graphics);

                if (snake.IsHitTail())
                {
                    Console.Beep();
                    break;
                }

                if (snake.Eat(fruit))
                {
                    Menu.AddScore();

                    if (_speed > 1 && Menu.Score % 5 == 0)
                    {
                        _speed -= 2;
                    }

                    fruit.Clear(_graphics);
                    fruit = new Fruit(snake);

                }
                else
                {
                    snake.Update(_graphics);
                    Thread.Sleep(_speed);
                }
                
                _graphics.FlipPages();
            }
        }
    }
}
