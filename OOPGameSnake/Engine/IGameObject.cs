using NConsoleGraphics;

namespace OOPGameSnake.Engine
{
    public interface IGameObject
    {
        void Update(GameEngine gameEngine);
        void Render(ConsoleGraphics graphics);
    }
}
