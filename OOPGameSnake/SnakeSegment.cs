using NConsoleGraphics;
using System;

namespace OOPGameSnake
{
    public class SnakeSegment : ICoordinates
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public SnakeSegment(int x, int y)
        {
            X = x;
            Y = y;
        }

        public SnakeSegment(ICoordinates obj)
        {
            X = obj.X;
            Y = obj.Y;
        }

        public SnakeSegment(ICoordinates obj, Keys direction)
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
            switch (direction)
            {
                case Keys.RIGHT:
                    X = (X + Settings.SizeCell >= Settings.FieldWightInPixel) ? X = 0 : X += offset;
                    break;

                case Keys.LEFT:
                    X = (X <= 0) ? X = Settings.FieldWightInPixel - Settings.SizeCell : X -= offset;
                    break;

                case Keys.UP:
                    Y = (Y <= 0) ? Y = Settings.FieldHeightInPixel - Settings.SizeCell : Y -= offset;
                    break;

                case Keys.DOWN:
                    Y = (Y + Settings.SizeCell >= Settings.FieldHeightInPixel) ? Y = 0 : Y += offset;
                    break;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as SnakeSegment);
        }

        public bool Equals(SnakeSegment cell)
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
