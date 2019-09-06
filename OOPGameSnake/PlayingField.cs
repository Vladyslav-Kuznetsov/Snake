using System;
using NConsoleGraphics;
using DataStruct;

namespace OOPGameSnake
{
    public class PlayingField
    {
        private Cell[,] _field;
        private int _sizeField;
        private int _sizeCell;
        private ConsoleGraphics _grapgics;

        public PlayingField(int sizeField, int sizeCell)
        {
            _sizeField = sizeField;
            _sizeCell = sizeCell;
            _field = new Cell[_sizeField, _sizeField];
            _grapgics = new ConsoleGraphics();
            CreatePlayingField();
        }

        private void CreatePlayingField()
        {
            for (int i = 0, x = 0; x < _sizeField; i++, x += _sizeCell)
            {
                int y = 0;

                for (int j = 0; y < _sizeField; j++)
                {
                    _field[i, j] = new Cell(x, y,_sizeCell);
                    _field[i, j].Render(_grapgics);
                    y += _sizeCell;
                }
            }

            _grapgics.FlipPages();
        }
    }
}
