using System;
using System.Collections.Generic;


namespace Snake
{
    class Figure
    {
        public List<Point> points;

        public Figure()
        {
            points = new List<Point>();
        }

        public void Draw(ConsoleColor color = ConsoleColor.White)
        {
            foreach (Point point in points)
            {
                point.Draw(color);
            }
        }

        internal bool CheckHit(Point checkingPoint)
        {
            foreach(Point point in points)
            {
                if (point.x == checkingPoint.x && point.y == checkingPoint.y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
