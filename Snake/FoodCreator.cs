using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodCreator
    {
        byte width;
        byte height;

        char symbol = '@';
        Random random = new Random();

        public FoodCreator(byte width, byte height)
        {
            this.width = width;
            this.height = height;
        }

        public Point Spawn(List<Point> blockedPoints = null)
        {
            byte x = (byte) random.Next(2, width - 2);
            byte y = (byte) random.Next(2, height - 2);

            if (blockedPoints != null)
            {
                foreach (Point point in blockedPoints)
                {
                    if (point.x == x && point.y == y)
                    {
                        return Spawn(blockedPoints);
                    }
                }
            }

            Point food = new Point(x, y, symbol);
            food.Draw(ConsoleColor.DarkYellow);
            return food;
        }
    }
}
