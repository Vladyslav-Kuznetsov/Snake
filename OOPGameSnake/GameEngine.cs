using NConsoleGraphics;
using System.Windows.Forms;
using System;

namespace OOPGameSnake
{
    public class GameEngine
    {
        private ConsoleGraphics _graphics;
        private int _score;
        private int _bestScore;
        private uint _colorFruit = 0xFFFFFF00;

        public GameEngine()
        {
            _graphics = new ConsoleGraphics();
            _score = 0;
            _bestScore = 0;
        }

        public void Start(PlayingField field, Snake snake, FruitCreator fruitCreator, Cell fruit)
        {
            while (true)
            {
                field.Draw(_graphics);
                snake.ВefineСlick();
                fruit.Render(_graphics, _colorFruit);
                _graphics.DrawString($"Score:{_score}", "ISOCPEUR", 0xFF000000, 810, 50);

                if (snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(fruit))
                {
                    _score++;
                    fruit.Clear(_graphics);
                    fruit = fruitCreator.CreateFruit(snake);

                }
                else
                {
                    snake.Move();
                }

                _graphics.FlipPages();
            }
        }

        public bool Continue(Canvas c)
        {
            DialogResult result = MessageBox.Show("Start a new game?", "Continue", MessageBoxButtons.YesNo);

            switch (result)
            {
                case DialogResult.Yes:
                    c.Clear(_graphics);
                    return true;
                case DialogResult.No:
                    return false;
                default:
                    return false;

            }

        }
    }
}
