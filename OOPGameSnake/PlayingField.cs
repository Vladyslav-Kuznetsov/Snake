using NConsoleGraphics;
using OOPGameSnake.Engine;

namespace OOPGameSnake
{
    public class PlayingField : IGameObject
    {
        private readonly Cell[,] _field;

        public PlayingField(int height, int widht )
        {
            _field = new Cell[height, widht];

            for (int range = 0, coordinateY = 0; range < height; range++, coordinateY += Settings.SizeCell)
            {
                int coordinateX = 0;

                for (int index = 0; index < widht; index++)
                {
                    _field[range, index] = new Cell(coordinateX, coordinateY);
                    coordinateX += Settings.SizeCell;
                }
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            foreach (Cell c in _field)
            {
                graphics.DrawRectangle(Settings.BlackColor, c.X, c.Y, Settings.SizeCell, Settings.SizeCell);
            }
        }

        public void Update(GameEngine gameEngine)
        {
            // Always static
        }
    }
}
