using DataStruct;
using NConsoleGraphics;

namespace OOPGameSnake
{
    public class Snake : IDrawObject
    {
        private readonly List<Cell> _snake;
        private const int CenterField = Settings.SizeField / 2;
        public Keys Direction { get; set; } = Settings.DefaultSnakeDirection;

        public Snake(int length)
        {
            _snake = new List<Cell>();
            Cell tail = new Cell(CenterField, CenterField);

            for (int i = 0; i < length; i++)
            {
                Cell nextCell = new Cell(tail, Direction);
                _snake.Add(nextCell);
                tail = nextCell;
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
            nextCell.Move(Settings.SizeCell, Direction);

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

            return false;
        }

        public bool IsHitTail()
        {
            Cell head = GetNextCell();

            foreach (Cell c in _snake)
            {
                if (head.IsHit(c))
                {
                    return true;
                }
            }

            return false;
        }

        public void Draw(ConsoleGraphics graphics)
        {
            foreach (Cell c in _snake)
            {
                Draw(c, graphics);
            }
        }

        public bool FruitInSnake(int x, int y)
        {
            return _snake.Contains(new Cell(x, y));
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
