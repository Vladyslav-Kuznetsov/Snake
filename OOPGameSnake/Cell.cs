using System;
using NConsoleGraphics;

namespace OOPGameSnake
{
    public class Cell
    {
        private int _x;
        private int _y;
        private int _size;
        private const uint _color = 0xFF000000;

        public Cell(int x, int y, int size)
        {
            _x = x;
            _y = y;
            _size = size;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawRectangle(_color, _x, _y, _size, _size);
        }
    }
}
