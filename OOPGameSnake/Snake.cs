using System;
using DataStruct;
using NConsoleGraphics;

namespace OOPGameSnake
{
    public class Snake
    {
        private List<Cell> _snake;
        private readonly uint _color;
        private int _x;
        private int _y;
        private int _size;
        private int _speed;
        private Keys _direction = Keys.UP;

        public Snake(uint color, int x, int y, int size, int speed)
        {
            _snake = new List<Cell>();
            _color = color;
            _x = x;
            _y = y;
            _size = size;
            _speed = speed;
        }

        private void Move()
        {

            switch (_direction)
            {
                case Keys.LEFT:
                case Keys.RIGHT:

                    if (Input.IsKeyDown(Keys.DOWN))
                    {
                        _direction = Keys.DOWN;
                    }
                    else if (Input.IsKeyDown(Keys.UP))
                    {
                        _direction = Keys.UP;
                    }
                    break;

                case Keys.UP:
                case Keys.DOWN:

                    if (Input.IsKeyDown(Keys.LEFT))
                    {
                        _direction = Keys.LEFT;
                    }
                    else if (Input.IsKeyDown(Keys.RIGHT))
                    {
                        _direction = Keys.RIGHT;
                    }

                    break;
            }

        }

        public void Update(PlayingField field)
        {
            Move();

            if (_direction == Keys.LEFT)
            {
                _x -= _speed;
            }
            else if (_direction == Keys.RIGHT)
            {
                _x += _speed;
            }
            else if (_direction == Keys.UP)
            {
                _y -= _speed;
            }
            else if (_direction == Keys.DOWN)
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
