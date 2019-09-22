using NConsoleGraphics;
using OOPGameSnake.Engine;
using System;

namespace OOPGameSnake
{
    public class Fruit : IGameObject, ICoordinates
    {
        public Fruit(Snake snake)
        {
            int x;
            int y;
            Random random = new Random();

            do
            {
                x = random.Next(0, Settings.FieldWightInPixel);
                y = random.Next(0, Settings.FieldHeightInPixel);
                int tempX = x % Settings.SizeCell;
                x -= tempX;
                int tempY = y % Settings.SizeCell;
                y -= tempY;
            }
            while (snake.FruitInSnake(x, y));

            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public void Update(GameEngine gameEngine)
        {
            // Always static
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(Settings.FruitColor, X + 1, Y + 1, Settings.SizeCell - 1, Settings.SizeCell - 1);
        }
    }
}
