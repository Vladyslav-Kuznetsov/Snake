using NConsoleGraphics;

namespace OOPGameSnake.Engine
{
    public class SnakeGameEngine : GameEngine
    {
        public SnakeGameEngine(ConsoleGraphics graphics) : base(graphics)
        {
            AddObject(new PlayingField(Settings.FieldHeightInCell,Settings.FieldWightInCell));
            var snake = new Snake(Settings.DefaultSnakeLength, Settings.DefaultSnakeDirection);
            AddObject(snake);
            AddObject(new Fruit(snake));
            AddObject(new ScoreCounter());
        }

        public override void Reset()
        {
            var scoreCounter = GetFirstObjectByType<ScoreCounter>();

            base.Reset();

            AddObject(new PlayingField(Settings.FieldHeightInCell, Settings.FieldWightInCell));
            var snake = new Snake(Settings.DefaultSnakeLength, Settings.DefaultSnakeDirection);
            AddObject(snake);
            AddObject(new Fruit(snake));

            scoreCounter.Reset();
            AddObject(scoreCounter);
        }
    }
}
