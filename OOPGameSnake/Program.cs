using NConsoleGraphics;
using OOPGameSnake.Engine;

namespace OOPGameSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings.SetupDefaultConsoleSettings();
            ConsoleGraphics graphics = new ConsoleGraphics();
            GameEngine game = new GameEngine(graphics);
            Menu.Greeting(graphics);

            do
            {
                game.Start();

            } while (Menu.ContinueGame(graphics));
        }
    }
}
