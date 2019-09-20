using NConsoleGraphics;
using OOPGameSnake.Engine;
using System;

namespace OOPGameSnake
{
    public class Menu
    {
        public static void Greeting(ConsoleGraphics graphics)
        {
            graphics.DrawImagePart(graphics.LoadImage("Images/snake-start.jpg"), 0, 0, graphics.ClientWidth, graphics.ClientHeight, 0, 0);
            graphics.FlipPages();
            Console.ReadLine();
        }
        public static bool ContinueGame(ConsoleGraphics graphics, GameEngine engine)
        {
            var scoreCounter = (ScoreCounter)engine.GetFirstObjectByType(typeof(ScoreCounter));

            graphics.DrawImagePart(graphics.LoadImage("Images/snake-gameover.jpg"), 0, 0, graphics.ClientWidth, graphics.ClientHeight, 0, 0);
            graphics.DrawString($"Current score:{scoreCounter.Score}", Settings.FontName, Settings.WhiteColor, 320, 450, 36);
            graphics.DrawString($"Best score:{scoreCounter.BestScore}", Settings.FontName, Settings.WhiteColor, 350, 520, 36);
            graphics.FlipPages();
            

            while (true)
            {
                if (Input.IsKeyDown(Keys.RETURN))
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
