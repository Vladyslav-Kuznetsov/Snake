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
            _graphics.DrawImagePart(_graphics.LoadImage("Images/snake-game.jpg"), 0, 0, _graphics.ClientWidth, _graphics.ClientHeight, 0, 0);
            _graphics.FlipPages();
        }

        public static void AddScore()
        {
            Score++;
        }

        public static void ShowScore()
        {
            
            
        }

        public bool ContinueGame()
        {
            if (Score > BestScore)
            {
                BestScore = Score;
            }

            Score = 0;
            _graphics.DrawImagePart(_graphics.LoadImage("Images/snake-game.jpg"), 0, 0, _graphics.ClientWidth, _graphics.ClientHeight, 0, 0);
            _graphics.FlipPages();

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
