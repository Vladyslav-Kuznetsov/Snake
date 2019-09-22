using NConsoleGraphics;
using OOPGameSnake.Engine;

namespace OOPGameSnake
{
    public class PlayingField : IGameObject
    {
        private readonly (int x, int y)[,] _field;

        public PlayingField(int height, int widht)
        {
            _field = new (int x, int y)[height, widht];

            for (int range = 0, coordinateY = 0; range < height; range++, coordinateY += Settings.SizeCell)
            {
                int coordinateX = 0;

                for (int index = 0; index < widht; index++)
                {
                    _field[range, index] = (x: coordinateX, y: coordinateY);
                    coordinateX += Settings.SizeCell;
                }
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            foreach ((int x, int y) c in _field)
            {
                graphics.DrawRectangle(Settings.BlackColor, c.x, c.y, Settings.SizeCell, Settings.SizeCell);
            }
        }

        public void Update(GameEngine gameEngine)
        {
            // Always static
        }
    }
}
