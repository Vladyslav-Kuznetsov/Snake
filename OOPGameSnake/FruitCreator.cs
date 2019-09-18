using System;

namespace OOPGameSnake
{
    public static class FruitCreator
    {
        public static Fruit CreateFruit(Snake s)
        {
            int x;
            int y;
            Random random = new Random();

            do
            {
                x = random.Next(0, Settings.SizeField);
                y = random.Next(0, Settings.SizeField);
                int tempX = x % Settings.SizeCell;
                x -= tempX;
                int tempY = y % Settings.SizeCell;
                y -= tempY;


            } while (s.FruitInSnake(x, y));

            
            return new Fruit(x, y);
        }
    }
}
