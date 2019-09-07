using System;
using NConsoleGraphics;

namespace OOPGameSnake
{
    public class Fruit
    {
        private int _x;
        private int _y;
        private int _size;

        public Fruit(int sizeField, int size)
        {
            CreateFruit(sizeField, size);
            _size = size;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFFFFFF00, _x, _y, _size, _size);
            graphics.FlipPages();
        }

        public void CreateFruit(int sizeField, int size)
        {
            Random random = new Random();
            _x = random.Next(0, sizeField - size);
            int tempX = _x % size;
            _x -= tempX;
            _y = random.Next(0, sizeField - size);
            int tempY = _y % size;
            _y -= tempY;
        }
    }
}
