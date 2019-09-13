using NConsoleGraphics;

namespace OOPGameSnake
{
    public class Menu
    {
        private static ConsoleGraphics _graphics = new ConsoleGraphics();
        public static int Score { get; private set; }
        public static int BestScore { get; private set; }

        public void Greeting()
        {
            _graphics.DrawImagePart(_graphics.LoadImage("Images/snake-start.jpg"), 0, 0, _graphics.ClientWidth, _graphics.ClientHeight, 0, 0);
            _graphics.FlipPages();
        }

        public static void AddScore()
        {
            Score++;
        }

        public bool ContinueGame()
        {
            if (Score > BestScore)
            {
                BestScore = Score;
            }

            _graphics.DrawImagePart(_graphics.LoadImage("Images/snake-gameover.jpg"), 0, 0, _graphics.ClientWidth, _graphics.ClientHeight, 0, 0);
            _graphics.DrawString($"Current score:{Score}", "ISOCPEUR", 0xFFFFFFFF, 320, 450, 36);
            _graphics.DrawString($"Best score:{BestScore}", "ISOCPEUR", 0xFFFFFFFF, 350, 520, 36);
            _graphics.FlipPages();
            Score = 0;

            while (true)
            {
                if (Input.IsKeyDown(Keys.SPACE))
                {
                    
                    return true;
                }
                else if (Input.IsKeyDown(Keys.ESCAPE))
                {
                    return false;

                }
            }
        }
    }
}
