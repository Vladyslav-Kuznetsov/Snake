using NConsoleGraphics;

namespace OOPGameSnake.Engine
{
    public class SnakeGameEngine : GameEngine
    {
        public SnakeGameEngine(ConsoleGraphics graphics) : base(graphics)
        {
            Snake snake = new Snake(Settings.DefaultSnakeLength, Settings.DefaultSnakeDirection);
            AddObject(new PlayingField());
            AddObject(snake);
            AddObject(new Fruit(snake));
            AddObject(new ScoreCounter());
        }

        public override void Reset()
        {
            ScoreCounter scoreCounter = (ScoreCounter)GetFirstObjectByType(typeof(ScoreCounter));

            base.Reset();

            Snake snake = new Snake(Settings.DefaultSnakeLength, Settings.DefaultSnakeDirection);
            AddObject(new PlayingField());
            AddObject(snake);
            AddObject(new Fruit(snake));

            scoreCounter.Reset();
            AddObject(scoreCounter);
        }
    }
}
