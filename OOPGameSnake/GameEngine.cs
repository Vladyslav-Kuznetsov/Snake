using NConsoleGraphics;
using System;
using System.Threading;

namespace OOPGameSnake
{
    public class GameEngine
    {
        private readonly ConsoleGraphics _graphics;
        private int _speed;

        public GameEngine(ConsoleGraphics graphics)
        {
            _graphics = graphics;
        }

        public void Start()
        {
            PlayingField field = new PlayingField();
            Snake snake = new Snake(Settings.DefaultSnakeLength);
            Fruit fruit = new Fruit(snake);
            _speed = 40;
            
            while (true)
            {
                _graphics.FillRectangle(Settings.WhiteColor, 0, 0, _graphics.ClientWidth, _graphics.ClientHeight);
                HandleClick(snake);
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

        public void HandleClick(Snake snake)
        {
            switch (snake.Direction)
            {
                case Keys.LEFT:
                case Keys.RIGHT:

                    if (Input.IsKeyDown(Keys.DOWN))
                    {
                        snake.Direction = Keys.DOWN;
                    }
                    else if (Input.IsKeyDown(Keys.UP))
                    {
                        snake.Direction = Keys.UP;
                    }
                    break;

                case Keys.UP:
                case Keys.DOWN:

                    if (Input.IsKeyDown(Keys.LEFT))
                    {
                        snake.Direction = Keys.LEFT;
                    }
                    else if (Input.IsKeyDown(Keys.RIGHT))
                    {
                        snake.Direction = Keys.RIGHT;
                    }

                    break;
            }

        }
    }
}
