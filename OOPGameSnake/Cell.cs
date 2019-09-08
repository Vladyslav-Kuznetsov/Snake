using System;
using NConsoleGraphics;

namespace OOPGameSnake
{
    public class Cell
    {
        public int _x;
        public int _y;
        public int _size;
        private const uint _color = 0xFF000000;

        public Cell(int x, int y, int size)
        {
            _x = x;
            _y = y;
            _size = size;
        }

        public Cell(Cell c)
        {
            _x = c._x;
            _y = c._y;
            _size = c._size;
        }

        public bool IsHit(Cell c)
        {
            return c._x == _x && c._y == _y;
        }

        public void Move(int offset, Keys direction, int sizeField)
        {
            if (direction == Keys.RIGHT)
            {
                _x += offset;
            }
            else if (direction == Keys.LEFT)
            {
                _x -= offset;
            }
            else if (direction == Keys.UP)
            {
                _y -= offset;
            }
            else if (direction == Keys.DOWN)
            {
                _y += offset;
            }

            if (_x + _size > sizeField)
            {
                _x = 0;
            }
            else if (_x < 0)
            {
                _x = sizeField - _size;
            }

            if (_y + _size > sizeField)
            {
                _y = 0;
            }
            else if (_y < 0)
            {
                _y = sizeField - _size;
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawRectangle(_color, _x, _y, _size, _size);
        }

        public void Render1(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(_color, _x, _y, _size, _size);
            graphics.FlipPages();
        }

        public void Clear(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFFFFFFFF, _x, _y, _size, _size);
            //graphics.FlipPages();
        }
    }
}
