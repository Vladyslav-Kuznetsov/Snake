using NConsoleGraphics;
using System;
using System.Threading;
using DataStruct;

namespace OOPGameSnake
{
    public class GameEngine
    {
        private readonly Canvas _canvas;
        private readonly ConsoleGraphics _graphics;
        private int _speed;
        private const int _snakeLength = 3;

        public GameEngine(ConsoleGraphics graphics)
        {
            _graphics = graphics;
            _canvas = new Canvas(Settings.WhiteColor, _graphics.ClientWidth, _graphics.ClientHeight);
        }

        public void Start()
        {
            PlayingField field = new PlayingField();
            Snake snake = new Snake(_snakeLength);
            Fruit fruit = FruitCreator.CreateFruit(snake);
            _speed = 40;
            
            while (true)
            {
                _canvas.Clear(_graphics);
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
                    fruit.Update(FruitCreator.CreateFruit(snake));

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
