using DataStruct;
using NConsoleGraphics;
using OOPGameSnake.Engine;

namespace OOPGameSnake
{
    public class Snake : IGameObject
    {
        private const int CenterFieldX = Settings.FieldWightInPixel / 2;
        private const int CenterFieldY = Settings.FieldHeightInPixel / 2;
        private readonly List<SnakeSegment> _snake;

        public Snake(int length, Keys direction)
        {
            _snake = new List<SnakeSegment>();
            Direction = direction;
            SnakeSegment tail = new SnakeSegment(CenterFieldX, CenterFieldY);

            for (int i = 0; i < length; i++)
            {
                SnakeSegment nextCell = new SnakeSegment(tail, Direction);
                _snake.Add(nextCell);
                tail = nextCell;
            }
        }

        public Keys Direction { get; private set; }

        public bool FruitInSnake(int x, int y)
        {
            return _snake.Contains(new SnakeSegment(x, y));
        }

        public void Update(GameEngine engine)
        {
            if (IsHitTail())
            {
                engine.End();
                return;
            }

            UpdateDirection();
            MoveBody();
            var fruit = engine.GetFirstObjectByType<Fruit>();

            if (fruit != null && Eat(fruit))
            {
                var scoreCounter = engine.GetFirstObjectByType<ScoreCounter>();
                scoreCounter.IncreaseScore();

                engine.DeleteObject(fruit);
                fruit = new Fruit(this);
                engine.AddObject(fruit);

                engine.IncreaseSpeed();
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            foreach (SnakeSegment c in _snake)
            {
                graphics.FillRectangle(Settings.SnakeColor, c.X + 1, c.Y + 1, Settings.SizeCell - 1, Settings.SizeCell - 1);
            }
        }

        private SnakeSegment GetNextCell()
        {
            SnakeSegment head = _snake.Last();
            SnakeSegment nextCell = new SnakeSegment(head);
            nextCell.Move(Settings.SizeCell, Direction);

            return nextCell;
        }

        private bool Eat(Fruit fruit)
        {
            SnakeSegment head = _snake.Last();

            if (head.IsHit(fruit))
            {
                _snake.Add(new SnakeSegment(fruit));
                return true;
            }

            return false;
        }

        private bool IsHitTail()
        {
            SnakeSegment head = _snake.Last();

            for (int i = 0; i < _snake.Count - 2; i++)
            {
                if (head.IsHit(_snake[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private void MoveBody()
        {
            SnakeSegment tail = _snake.First();
            _snake.Remove(tail);
            SnakeSegment head = GetNextCell();
            _snake.Add(head);
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
    }
}
