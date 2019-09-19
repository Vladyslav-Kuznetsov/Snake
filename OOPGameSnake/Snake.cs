using DataStruct;
using NConsoleGraphics;

namespace OOPGameSnake
{
    public class Snake : IDrawObject
    {
        private readonly List<Cell> _snake;
        private Keys _direction = Keys.UP;

        public Snake(int length)
        {
            _snake = new List<Cell>();
            Cell tail = new Cell(Settings.SizeField / 2, Settings.SizeField / 2);

            for (int i = 0, offset = 0; i < length; i++)
            {
                Cell c = new Cell(tail);
                c.Move(offset, _direction);
                _snake.Add(c);
                offset += Settings.SizeCell;
            }
        }

        public void Update(ConsoleGraphics graphics)
        {
            Cell tail = _snake.First();
            _snake.Remove(tail);
            Cell head = GetNextCell();
            _snake.Add(head);
            Draw(head, graphics);
            Clear(tail, graphics);
        }

        private Cell GetNextCell()
        {
            Cell head = _snake.Last();
            Cell nextCell = new Cell(head);
            nextCell.Move(Settings.SizeCell, _direction);

            return nextCell;
        }

        public bool Eat(Fruit fruit)
        {
            Cell head = GetNextCell();

            if (head.IsHit(fruit))
            {
                _snake.Add(new Cell(fruit));
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

        public void Draw(ConsoleGraphics graphics)
        {
            foreach (var s in _snake)
            {
                Draw(s, graphics);
            }
        }

        public bool FruitInSnake(int x, int y)
        {
            for (int i = 0; i < _snake.Count; i++)
            {
                if (_snake[i].X == x && _snake[i].Y == y)
                {
                    return true;
                }
            }

            return false;
        }

        private void Draw(Cell c, ConsoleGraphics graphics)
        {
            graphics.FillRectangle(Settings.SnakeColor, c.X + 1, c.Y + 1, Settings.SizeCell - 1, Settings.SizeCell - 1);
        }

        private void Clear(Cell c, ConsoleGraphics graphics)
        {
            graphics.FillRectangle(Settings.WhiteColor, c.X + 1, c.Y + 1, Settings.SizeCell - 1, Settings.SizeCell - 1);
        }
    }
}
