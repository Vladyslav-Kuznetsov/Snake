﻿using NConsoleGraphics;

namespace OOPGameSnake
{
    public class Fruit : ICoordinates, IDrawObject
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Fruit(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Draw(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(Settings.FruitColor, X + 1, Y + 1, Settings.SizeCell - 1, Settings.SizeCell - 1);
        }

        public void Clear(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(Settings.SnakeColor, X + 1, Y + 1, Settings.SizeCell - 1, Settings.SizeCell - 1);
        }

        public void Update (Fruit fruit)
        {
            X = fruit.X;
            Y = fruit.Y;
        }
    }
}
