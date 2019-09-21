using NConsoleGraphics;
using OOPGameSnake.Engine;

namespace OOPGameSnake
{
    public class ScoreCounter : IGameObject
    {
        public int Score { get; private set; }
        public int BestScore { get; private set; }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawString($"Score:{Score}", Settings.FontName, Settings.BlackColor, Settings.FieldWightInPixel + 10, 0);
            graphics.DrawString($"Best Score:{BestScore}", Settings.FontName, Settings.BlackColor, Settings.FieldWightInPixel + 10, 20);
        }

        public void IncreaseScore()
        {
            Score++;
        }

        public void Update(GameEngine gameEngine)
        {
            // Always static
        }

        public void Reset()
        {
            if (Score > BestScore)
            {
                BestScore = Score;
            }

            Score = 0;
        }
    }
}
