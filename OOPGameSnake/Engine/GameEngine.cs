using NConsoleGraphics;
using DataStruct;
using System.Threading;
using System;

namespace OOPGameSnake.Engine
{
    public abstract class GameEngine
    {
        private readonly ConsoleGraphics _graphics;
        private readonly List<IGameObject> _objects = new List<IGameObject>();
        private readonly List<IGameObject> _tempObjects = new List<IGameObject>();
        private bool _gameOver;

        public GameEngine(ConsoleGraphics graphics)
        {
            _graphics = graphics;
        }

        public void AddObject(IGameObject obj)
        {
            _tempObjects.Add(obj);
        }

        public void DeleteObject(IGameObject obj)
        {
            if (_tempObjects.Contains(obj))
            {
                _tempObjects.Remove(obj);
            }

            if (_objects.Contains(obj))
            {
                _objects.Remove(obj);
            }
        }

        public IGameObject GetFirstObjectByType(Type type)
        {
            foreach (IGameObject obj in _tempObjects)
            {
                if (obj.GetType() == type)
                {
                    return obj;
                }
            }

            foreach (IGameObject obj in _objects)
            {
                if (obj.GetType() == type)
                {
                    return obj;
                }
            }
            return null;
        }

        public void Start()
        {
            Reset();

            while (!_gameOver)
            {
                // Game Loop
                foreach (var obj in _objects)
                {
                    obj.Update(this);
                }


                _objects.AddRange(_tempObjects);
                _tempObjects.Clear();

                // clearing screen before painting new frame
                _graphics.FillRectangle(Settings.WhiteColor, 0, 0, _graphics.ClientWidth, _graphics.ClientHeight);

                foreach (var obj in _objects)
                {
                    obj.Render(_graphics);
                }


                // double buffering technique is used
                _graphics.FlipPages();

                Thread.Sleep(Settings.DefaultSpeed);
            }
        }

        public void End()
        {
            Console.Beep();
            _gameOver = true;
        }

        public virtual void Reset()
        {
            _tempObjects.Clear();
            _objects.Clear();
            _gameOver = false;
        }
    }
}
