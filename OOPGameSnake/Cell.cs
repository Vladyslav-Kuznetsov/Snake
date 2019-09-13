using System;
using NConsoleGraphics;

namespace OOPGameSnake
{
    public class Cell
    {
        public int X;
        public int Y;
        public int Size;
        private const uint _color = 0xFF000000;

        public Cell(int x, int y, int size)
        {
            X = x;
            Y = y;
            Size = size;
        }

        public Cell(Cell c)
        {
            X = c.X;
            Y = c.Y;
            Size = c.Size;
        }

        public bool IsHit(Cell c)
        {
            return c.X == X && c.Y == Y;
        }

        public void Move(int offset, Keys direction, int sizeField)
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

            if (X + Size > sizeField)
            {
                X = 0;
            }
            else if (X < 0)
            {
                X = sizeField - Size;
            }

            if (Y + Size > sizeField)
            {
                Y = 0;
            }
            else if (Y < 0)
            {
                Y = sizeField - Size;
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawRectangle(_color, X + 1, Y + 1, Size - 1, Size - 1);
        }

        public void Render(ConsoleGraphics graphics, uint color)
        {
            graphics.FillRectangle(color, X + 1, Y + 1, Size - 1, Size - 1);

        }

        public void Clear(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFFFF0000, X + 1, Y + 1, Size - 1, Size - 1);
        }
    }
}
