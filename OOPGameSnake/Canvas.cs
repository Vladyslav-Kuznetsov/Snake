using System;
using NConsoleGraphics;
using System.Threading;

namespace OOPGameSnake
{
    public class Canvas
    {
        private uint _color;
        private int _width;
        private int _height;

        public Canvas(uint color, int width, int height)
        {
            _color = color;
            _width = width;
            _height = height;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(_color, 0, 0, _width, _height);
        }
    }
}
