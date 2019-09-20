using NConsoleGraphics;
using OOPGameSnake.Engine;
using System;

namespace OOPGameSnake
{
    public class Fruit : IGameObject, ICoordinates
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Fruit(Snake snake)
        {
            int x;
            int y;
            Random random = new Random();

            do
            {
                x = random.Next(0, Settings.SizeField);
                y = random.Next(0, Settings.SizeField);
                int tempX = x % Settings.SizeCell;
                x -= tempX;
                int tempY = y % Settings.SizeCell;
                y -= tempY;


            } while (snake.FruitInSnake(x, y));

            X = x;
            Y = y;
        }

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
