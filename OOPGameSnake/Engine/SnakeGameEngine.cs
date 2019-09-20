using System;
using NConsoleGraphics;

namespace OOPGameSnake.Engine
{
    public class SnakeGameEngine : GameEngine
    {
        public SnakeGameEngine(ConsoleGraphics graphics) : base(graphics)
        {
            AddObject(new Snake(Settings.DefaultSnakeLength));
        }
    }
}
