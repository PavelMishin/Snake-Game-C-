using System.Collections.Generic;

namespace Snake
{
    class Walls
    {
        List<Figure> walls = new List<Figure>();
        byte width;
        byte height;
        public Walls(byte width, byte height)
        {
            this.width = (byte) (width - 2);
            this.height = (byte) (height - 2);
            CreateWalls();
        }

        public bool CheckHit(Point point)
        {
            foreach(Figure wall in walls)
            {
                if (wall.CheckHit(point))
                {
                    return true;
                }
            }

            return false;
        }

        private void CreateWalls()
        {
            Figure top = new BorderHorizontal(width, 0);
            Figure bottom = new BorderHorizontal(width, height);
            Figure left = new BorderVertical(width, 0);
            Figure right = new BorderVertical(width, height);

            walls.Add(top);
            walls.Add(bottom);
            walls.Add(left);
            walls.Add(right);
        }
    }
}
