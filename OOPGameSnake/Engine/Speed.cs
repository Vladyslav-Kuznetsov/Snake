using System.Threading;

namespace OOPGameSnake.Engine
{
    public class Speed
    {
        private int _value;

        public Speed()
        {
            _value = Settings.DefaultSpeed;
        }

        public void IncreaseSpeed()
        {
            if (_value > 1 && Menu.Score % 5 == 0)
            {
                _value -= 2;
            }
        }

        public void Apply()
        {
            Thread.Sleep(_value);
        }

        public void Reset()
        {
            _value = Settings.DefaultSpeed;
        }
    }
}
