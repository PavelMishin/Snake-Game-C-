using System;
using System.Linq;

namespace Snake
{
    class Snake : Figure
    {
        public Direction direction;
        private char symbol = '#';
        private ConsoleColor color = ConsoleColor.DarkGreen;

        public Snake (byte x, byte y, byte length, Direction direction)
        {
            this.direction = direction;

            CreateBody(x, y, length);
            Draw(color);
        }

        private void CreateBody(byte _x, byte _y, byte length)
        {
            for (byte i = 0; i < length; i++)
            {
                (byte x, byte y) = GetOffset(_x, _y, i);

                Point point = new Point(x, y, symbol);
                points.Add(point);
            }
        }

        public void Move()
        {
            Point tail = points.First();
            Point head = points.Last();

            tail.Clear();
            points.Remove(tail);
            points.Add(tail);

            (byte newX, byte newY) = GetOffset(head.x, head.y, 1);
            tail.x = newX;
            tail.y = newY;

            tail.Draw(color);
        }

        internal void Grow()
        {
            Point head = GetHead();
            (byte x, byte y) = GetOffset(head.x, head.y, 1);
            Point newHead = new Point(x, y, symbol);
            newHead.Draw(color);
            points.Add(newHead);
        }

        public bool CheckSelfHit()
        {
            Point head = GetHead();

            for (byte i = 0; i < points.Count - 2; i++)
            {
                Point point = points[i];
                if (head.x == point.x && head.y == point.y)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckEat(Point food)
        {
            Point head = GetHead();
            return food.x == head.x && food.y == head.y;
        }

        public Point GetHead() => points.Last();

        private (byte, byte) GetOffset(byte x, byte y, byte offset)
        {
            switch (direction)
            {
                case Direction.RIGHT:
                    x += offset;
                    break;
                case Direction.LEFT:
                    x -= offset;
                    break;
                case Direction.DOWN:
                    y += offset;
                    break;
                case Direction.UP:
                    y -= offset;
                    break;
            }

            return (x, y);
        }

        public void SetDirection(Direction direction)
        {
            this.direction = direction;
        }
    }
}
