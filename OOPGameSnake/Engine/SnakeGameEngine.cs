using NConsoleGraphics;

namespace OOPGameSnake.Engine
{
    public class SnakeGameEngine : GameEngine
    {
        public SnakeGameEngine(ConsoleGraphics graphics) : base(graphics)
        {
            InitObjects();
        }

        public override void Reset()
        {
            base.Reset();
            InitObjects();
        }

        private void InitObjects()
        {
            Snake snake = new Snake(Settings.DefaultSnakeLength, Settings.DefaultSnakeDirection);
            AddObject(new PlayingField());
            AddObject(snake);
            AddObject(new Fruit(snake));
        }
    }
}
