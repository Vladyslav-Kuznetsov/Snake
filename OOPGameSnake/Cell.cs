using NConsoleGraphics;
using System;

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

        public Cell(ICoordinates obj, Keys direction)
        {
            X = obj.X;
            Y = obj.Y;
            Move(Settings.SizeCell, direction);
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
            graphics.DrawRectangle(Settings.BlackColor, X, Y, Settings.SizeCell, Settings.SizeCell);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Cell);
        }

        public bool Equals(Cell cell)
        {
            if (Object.ReferenceEquals(cell, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, cell))
            {
                return true;
            }

            if (this.GetType() != cell.GetType())
            {
                return false;
            }

            return (X == cell.X) && (Y == cell.Y);
        }
        public override int GetHashCode()
        {
            int hash = 11;
            hash = (hash * 7) + X.GetHashCode();
            hash = (hash * 7) + Y.GetHashCode();
            return hash;
        }
    }
}
