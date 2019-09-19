using NConsoleGraphics;
using System;

namespace OOPGameSnake.Engine
{
    public class GameEngine
    {
        private readonly ConsoleGraphics _graphics;
        private readonly PlayingField _field;
        private readonly Speed _speed;
        private Snake _snake;
        private Fruit _fruit;

        public GameEngine(ConsoleGraphics graphics)
        {
            _graphics = graphics;
            _field = new PlayingField();
            _snake = new Snake(Settings.DefaultSnakeLength);
            _fruit = new Fruit(_snake);
            _speed = new Speed();
        }

        public void Start()
        {
            ResetGame();

            while (true)
            {
                ClearScene();
                HandleClick(_snake);
                _snake.Draw(_graphics);
                _field.Draw(_graphics);
                _fruit.Draw(_graphics);
                Menu.ShowScore(_graphics);

                if (_snake.IsHitTail())
                {
                    Console.Beep();
                    break;
                }

                if (_snake.Eat(_fruit))
                {
                    Menu.AddScore();
                    _speed.IncreaseSpeed();
                    _fruit.Clear(_graphics);
                    _fruit = new Fruit(_snake);
                }
                else
                {
                    _snake.Update(_graphics);
                }

                _speed.Apply();
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

        private void ResetGame()
        {
            _snake = new Snake(Settings.DefaultSnakeLength);
            _fruit = new Fruit(_snake);
            _speed.Reset();
        }

        private void ClearScene()
        {
            _graphics.FillRectangle(Settings.WhiteColor, 0, 0, _graphics.ClientWidth, _graphics.ClientHeight);
        }
    }
}
