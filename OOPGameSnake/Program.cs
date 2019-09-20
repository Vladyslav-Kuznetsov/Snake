using NConsoleGraphics;
using OOPGameSnake.Engine;

namespace OOPGameSnake
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Settings.SetupDefaultConsoleSettings();
            ConsoleGraphics graphics = new ConsoleGraphics();
            SnakeGameEngine game = new SnakeGameEngine(graphics);
            Menu.Greeting(graphics);

            do
            {
                game.Start();

            } while (Menu.ContinueGame(graphics));
        }
    }
}
