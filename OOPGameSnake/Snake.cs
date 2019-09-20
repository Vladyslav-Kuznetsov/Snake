using DataStruct;
using NConsoleGraphics;
using OOPGameSnake.Engine;

namespace OOPGameSnake
{
    public class Snake : IGameObject
    {
        private readonly List<Cell> _snake;
        private const int CenterField = Settings.SizeField / 2;
        public Keys Direction { get; private set; }

        public Snake(int length, Keys direction)
        {
            _snake = new List<Cell>();
            Direction = direction;
            Cell tail = new Cell(CenterField, CenterField);

            for (int i = 0; i < length; i++)
            {
                Cell nextCell = new Cell(tail, Direction);
                _snake.Add(nextCell);
                tail = nextCell;
            }
        }

        public bool Eat(Fruit fruit)
        {
            Cell head = _snake.Last();

            if (head.IsHit(fruit))
            {
                _snake.Add(new Cell(fruit));
                return true;
            }

            return false;
        }

        public bool IsHitTail()
        {
            Cell head = _snake.Last();

            for (int i = 0; i < _snake.Count - 2; i++)
            {
                if (head.IsHit(_snake[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public bool FruitInSnake(int x, int y)
        {
            return _snake.Contains(new Cell(x, y));
        }

        public void Update(GameEngine engine)
        {
            if (IsHitTail())
            {
                engine.End();
                return;
            }

            UpdateDirection();
            Cell tail = _snake.First();
            _snake.Remove(tail);
            Cell head = GetNextCell();
            _snake.Add(head);

            var fruit = engine.GetFirstObjectByType<Fruit>();

            if (fruit != null && Eat(fruit))
            {
                engine.IncreaseSpeed();
                var scoreCounter = engine.GetFirstObjectByType<ScoreCounter>();
                scoreCounter.IncreaseScore();
                engine.DeleteObject(fruit);
                fruit = new Fruit(this);
                engine.AddObject(fruit);
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            foreach (Cell c in _snake)
            {
                Draw(c, graphics);
            }
        }

        private Cell GetNextCell()
        {
            Cell head = _snake.Last();
            Cell nextCell = new Cell(head);
            nextCell.Move(Settings.SizeCell, Direction);

            return nextCell;
        }

        private void UpdateDirection()
        {
            switch (Direction)
            {
                case Keys.LEFT:
                case Keys.RIGHT:

                    if (Input.IsKeyDown(Keys.DOWN))
                    {
                        Direction = Keys.DOWN;
                    }
                    else if (Input.IsKeyDown(Keys.UP))
                    {
                        Direction = Keys.UP;
                    }
                    break;

                case Keys.UP:
                case Keys.DOWN:

                    if (Input.IsKeyDown(Keys.LEFT))
                    {
                        Direction = Keys.LEFT;
                    }
                    else if (Input.IsKeyDown(Keys.RIGHT))
                    {
                        Direction = Keys.RIGHT;
                    }

                    break;
            }
        }

        private void Draw(Cell c, ConsoleGraphics graphics)
        {
            graphics.FillRectangle(Settings.SnakeColor, c.X + 1, c.Y + 1, Settings.SizeCell - 1, Settings.SizeCell - 1);
        }
    }
}
