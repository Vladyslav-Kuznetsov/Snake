using System;
using NConsoleGraphics;
using System.Threading;

namespace OOPGameSnake
{
    public class Snake
    {
        private readonly uint _color;
        private int _x;
        private int _y;
        private int _size;
        private int _speed;

        public Snake(uint color, int x, int y, int size, int speed)
        {
            _color = color;
            _x = x;
            _y = y;
            _size = size;
            _speed = speed;
        }

        public void Update(PlayingField field)
        {
            if (Input.IsKeyDown(Keys.LEFT))
            {
                _x -= _speed;
            }
            else if (Input.IsKeyDown(Keys.RIGHT))
            {
                _x += _speed;
            }
            else if (Input.IsKeyDown(Keys.UP))
            {
                _y -= _speed;
            }
            else if (Input.IsKeyDown(Keys.DOWN))
            {
                _y += _speed;
            }

            if (_x + _size > field._sizeField)
            {
                _x = 0;
            }
            else if (_x < 0)
            {
                _x = field._sizeField - _size;
            }

            if (_y + _size > field._sizeField)
            {
                _y = 0;
            }
            else if (_y < 0)
            {
                _y = field._sizeField - _size;
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(_color, _x, _y, _size, _size);
            graphics.FlipPages();
        }
    }
}
