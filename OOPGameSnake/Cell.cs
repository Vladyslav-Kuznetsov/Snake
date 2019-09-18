using NConsoleGraphics;

namespace OOPGameSnake
{
    public class Cell : ICoordinates, IDrawObject
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Cell(ICoordinates obj)
        {
            X = obj.X;
            Y = obj.Y;
        }

        public bool IsHit(ICoordinates obj)
        {
            return obj.X == X && obj.Y == Y;
        }

        public void Move(int offset, Keys direction)
        {
            if (direction == Keys.RIGHT)
            {
                X += offset;
            }
            else if (direction == Keys.LEFT)
            {
                X -= offset;
            }
            else if (direction == Keys.UP)
            {
                Y -= offset;
            }
            else if (direction == Keys.DOWN)
            {
                Y += offset;
            }

            if (X + Settings.SizeCell > Settings.SizeField)
            {
                X = 0;
            }
            else if (X < 0)
            {
                X = Settings.SizeField - Settings.SizeCell;
            }

            if (Y + Settings.SizeCell > Settings.SizeField)
            {
                Y = 0;
            }
            else if (Y < 0)
            {
                Y = Settings.SizeField - Settings.SizeCell;
            }
        }

        public void Draw(ConsoleGraphics graphics)
        {
            graphics.DrawRectangle(Settings.BlackColor, X + 1, Y + 1, Settings.SizeCell - 1, Settings.SizeCell - 1);
        }
    }
}
