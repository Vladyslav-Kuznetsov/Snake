using System;
using DataStruct;
using NConsoleGraphics;

namespace OOPGameSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>();
            a.Add(1);
            a.Add(2);
            a.Add(3);

            var b = a.ToArray();

            foreach (var c in b )
            {
                Console.WriteLine(c);
            }

            Console.ReadLine();
        }
    }
}
