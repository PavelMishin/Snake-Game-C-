using System;

namespace Snake
{
    class BorderVertical : Figure
    {
        public BorderVertical(byte length, byte x)
            : base()
        {

            for (byte i = 1; i < length + 1; i++)
            {
                Point point = new Point(x, i, '|');
                points.Add(point);
            }

            Draw(ConsoleColor.DarkRed);
        }
    }
}
