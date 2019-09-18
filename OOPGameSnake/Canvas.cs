using NConsoleGraphics;

namespace OOPGameSnake
{
    public class Canvas
    {
        private readonly uint _color;
        private readonly int _width;
        private readonly int _height;

        public Canvas(uint color, int width, int height)
        {
            _color = color;
            _width = width;
            _height = height;
        }

        public void Clear(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(_color, 0, 0, _width, _height);
        }
    }
}
