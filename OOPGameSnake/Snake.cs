using System;
using DataStruct;
using NConsoleGraphics;

namespace OOPGameSnake
{
    public class Snake
    {
        private static ConsoleGraphics g = new ConsoleGraphics();
        public readonly List<Cell> _snake;
        private Keys _direction = Keys.UP;
        private int _sizeField;

        public Snake(Cell tail, int length, int sizeField)
        {
            _snake = new List<Cell>();
            _sizeField = sizeField;

            for (int i = 0, offset = 0; i < length; i++)
            {
                Cell c = new Cell(tail);
                c.Move(offset, _direction, _sizeField);
                _snake.Add(c);
                offset += tail._size;
            }
        }

        public void Move()
        {
            Cell tail = _snake.First();
            _snake.Remove(tail);
            Cell head = GetNextCell();
            _snake.Add(head);
            Clear(tail);
            Draw(head);
        }

        private Cell GetNextCell()
        {
            Cell head = _snake.Last();
            Cell nextCell = new Cell(head);
            nextCell.Move(head._size, _direction, _sizeField);

            return nextCell;
        }

        public bool Eat(Cell fruit)
        {
            Cell head = GetNextCell();

            if (head.IsHit(fruit))
            {
                _snake.Add(fruit);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHitTail()
        {
            Cell head = GetNextCell();

            for (int i = 0; i < _snake.Count; i++)
            {
                if (head.IsHit(_snake[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public void ВefineСlick()
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
        public void DrawSnake()
        {
            for (int i = 0; i < _snake.Count; i++)
            {
                Draw(_snake[i]);
            }
        }

        private static void Draw(Cell c)
        {
            g.FillRectangle(0xFFFF0000, c._x, c._y, c._size, c._size);
            g.FlipPages();
        }

        private static void Clear(Cell c)
        {
            g.FillRectangle(0xFFFFFFFF, c._x, c._y, c._size, c._size);

        }
    }
}
