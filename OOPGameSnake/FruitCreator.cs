using System;
using NConsoleGraphics;

namespace OOPGameSnake
{
    public class FruitCreator
    {
        private int _fieldSize;
        private int _size;
        private Random _random;
        public FruitCreator(int fieldSize, int size)
        {
            _fieldSize = fieldSize;
            _size = size;
            _random = new Random();
        }

        public Cell CreateFruit(Snake s)
        {
            int x;
            int y;

            while (true)
            {
                int equally = 0;
                x = _random.Next(0, _fieldSize - _size);
                y = _random.Next(0, _fieldSize - _size);
                int tempX = x % _size;
                x -= tempX;
                int tempY = y % _size;
                y -= tempY;

                for (int i = 0; i < s._snake.Count; i++)
                {
                    if (s._snake[i].X == x && s._snake[i].Y == y)
                    {
                        equally++;
                        break;
                    }
                }

                if (equally == 0)
                {
                    break;
                }
            }

            return new Cell(x, y, _size);
        }
    }
}
