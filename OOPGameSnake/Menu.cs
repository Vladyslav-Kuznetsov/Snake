using NConsoleGraphics;

namespace OOPGameSnake
{
    public static class Menu
    {
        public static int Score { get; private set; }
        public static int BestScore { get; private set; }

        public static void Greeting(ConsoleGraphics graphics)
        {
            graphics.DrawImagePart(graphics.LoadImage("Images/snake-start.jpg"), 0, 0, graphics.ClientWidth, graphics.ClientHeight, 0, 0);
            graphics.FlipPages();
        }

        public static void AddScore()
        {
            Score++;
        }

        public static void ShowScore(ConsoleGraphics graphics)
        {
            graphics.DrawString($"Score:{Score}", Settings.FontName, Settings.BlackColor, 810, 0);
            graphics.DrawString($"Best Score:{BestScore}", Settings.FontName, Settings.BlackColor, 810, 20);
        }

        public static bool ContinueGame(ConsoleGraphics graphics)
        {
            if (Score > BestScore)
            {
                BestScore = Score;
            }

            graphics.DrawImagePart(graphics.LoadImage("Images/snake-gameover.jpg"), 0, 0, graphics.ClientWidth, graphics.ClientHeight, 0, 0);
            graphics.DrawString($"Current score:{Score}", Settings.FontName, Settings.WhiteColor, 320, 450, 36);
            graphics.DrawString($"Best score:{BestScore}", Settings.FontName, Settings.WhiteColor, 350, 520, 36);
            graphics.FlipPages();
            Score = 0;

            while (true)
            {
                if (Input.IsKeyDown(Keys.SPACE))
                {
                    return true;
                }

                if (Input.IsKeyDown(Keys.ESCAPE))
                {
                    return false;
                }
            }
        }
    }
}
