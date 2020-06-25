using System;

namespace Snake
{
    class Point
    {
        public byte x;
        public byte y;
        public char symbol;

        public Point(byte x, byte y, char symbol)
        {
            this.x = x;
            this.y = y;
            this.symbol = symbol;
        }

        public void Draw(ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);

            Console.ForegroundColor = color;
            Console.WriteLine(symbol);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Clear()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(' ');
        }
    }
}
