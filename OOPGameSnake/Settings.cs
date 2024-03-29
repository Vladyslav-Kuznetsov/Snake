﻿using NConsoleGraphics;
using System;

namespace OOPGameSnake
{
    public struct Settings
    {
        public const int FieldHeightInPixel = SizeCell * FieldHeightInCell;
        public const int FieldWightInPixel = SizeCell * FieldWightInCell;
        public const int FieldWightInCell = 20;
        public const int FieldHeightInCell = 20;
        public const int SizeCell = 40;
        public const uint SnakeColor = 0xFFFF0000;
        public const uint FruitColor = 0xFFFFFF00;
        public const uint BlackColor = 0xFF000000;
        public const uint WhiteColor = 0xFFFFFFFF;
        public const string FontName = "ISOCPEUR";
        public const Keys DefaultSnakeDirection = Keys.UP;
        public const int DefaultSnakeLength = 3;
        public const int DefaultSpeed = 80;

        public static void SetupDefaultConsoleSettings()
        {
            Console.WindowHeight = 51;
            Console.WindowWidth = 120;
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();
        }
    }
}
