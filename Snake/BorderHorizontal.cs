using System;
using System.Collections.Generic;

namespace Snake
{
    class BorderHorizontal : Figure
    {
        public BorderHorizontal(byte length, byte y)
            : base()
        {
            for (byte i = 1; i < length + 1; i++)
            {
                Point point = new Point(i, y, '_');
                points.Add(point);
            }

            Draw(ConsoleColor.DarkRed);
        }
    }
}
