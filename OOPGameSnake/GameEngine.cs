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
        private int _score;
        private int _bestScore;
        private uint _colorFruit = 0xFFFFFF00;
        private int _speed = 25;

        public GameEngine()
        {
            _graphics = new ConsoleGraphics();
            _score = 0;
            _bestScore = 0;
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

            while (true)
            {
                field.Draw(_graphics);
                snake.ВefineСlick();
                fruit.Render(_graphics, _colorFruit);
                _graphics.DrawString($"Score:{_score}", "ISOCPEUR", 0xFF000000, _sizeField + 10, 50);
                _graphics.DrawString($"Best Score:{_bestScore}", "ISOCPEUR", 0xFF000000, _sizeField + 10, 70);

                if (snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(fruit))
                {
                    _graphics.FillRectangle(0xFFFFFFFF, 810, 50, 100, 25);
                    _score++;
                    if (_speed > 1 && _score % 5 == 0)
                        _speed--;
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

        public bool ContinueGame()
        {
            if (_score > _bestScore)
            {
                _bestScore = _score;
            }

            _score = 0;
            _speed = 25;

            do
            {
                Console.WriteLine("Start a new game? (Yes/No)");
                string command = Console.ReadLine();

                if (command.ToLower() == "yes")
                {
                    Console.Clear();
                    return true;
                }
                else if (command.ToLower() == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Incorrect data");
                }
            } while (true);
        }
    }
}
