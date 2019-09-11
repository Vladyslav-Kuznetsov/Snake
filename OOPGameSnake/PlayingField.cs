using System;
using NConsoleGraphics;
using DataStruct;

namespace OOPGameSnake
{
    public class PlayingField
    {
        private Cell[,] _field;
        private int _sizeCell;
        public readonly int _sizeField;

        public PlayingField(int sizeField, int sizeCell)
        {
            _sizeField = sizeField;
            _sizeCell = sizeCell;
            _field = new Cell[_sizeField / _sizeCell, _sizeField / _sizeCell];
            CreatePlayingField();
        }

        private void CreatePlayingField()
        {
            for (int i = 0, x = 0; x < _sizeField; i++, x += _sizeCell)
            {
                int y = 0;

                for (int j = 0; y < _sizeField; j++)
                {
                    _field[i, j] = new Cell(x, y, _sizeCell);
                    y += _sizeCell;
                }
            }
        }

        public void Draw(ConsoleGraphics graphics)
        {
            foreach (Cell c in _field)
            {
                c.Render(graphics);
            }
        }
    }
}
