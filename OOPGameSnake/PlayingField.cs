using NConsoleGraphics;
using OOPGameSnake.Engine;

namespace OOPGameSnake
{
    public class PlayingField : IGameObject
    {
        private readonly Cell[,] _field;

        public PlayingField()
        {
            _field = new Cell[Settings.SizeField / Settings.SizeCell, Settings.SizeField / Settings.SizeCell];

            for (int range = 0, coordinateX = 0; coordinateX < Settings.SizeField; range++, coordinateX += Settings.SizeCell)
            {
                int coordinateY = 0;

                for (int index = 0; coordinateY < Settings.SizeField; index++)
                {
                    _field[range, index] = new Cell(coordinateX, coordinateY);
                    coordinateY += Settings.SizeCell;
                }
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            foreach (Cell c in _field)
            {
                c.Draw(graphics);
            }
        }

        public void Update(GameEngine gameEngine)
        {
            // Always static
        }
    }
}
