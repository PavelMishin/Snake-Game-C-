using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static byte width = 40;
        static byte height = 40;
        static Snake snake;
        static FoodCreator foodCreator;
        static Point food;
        static Walls walls;
        
        static void Main(string[] args)
        {
            SetUpConsole();
            CreateGameObjects();
            GameLoop();

            Console.ReadKey();
        }

        private static void GameLoop()
        {
            while (true)
            {
                if (CheckCollide())
                    break;

                if (snake.CheckEat(food))
                {
                    food = foodCreator.Spawn(snake.points);
                    snake.Grow();
                }

                snake.Move();

                CheckCollide();

                Thread.Sleep(100);

                if (!Console.KeyAvailable)
                    continue;

                HandleInput();
            }
        }

        private static bool CheckCollide()
        {
            return walls.CheckHit(snake.GetHead()) || snake.CheckSelfHit();
        }

        static void HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (snake.direction != Direction.RIGHT)
                        snake.SetDirection(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    if (snake.direction != Direction.LEFT)
                        snake.SetDirection(Direction.RIGHT);
                    break;
                case ConsoleKey.UpArrow:
                    if (snake.direction != Direction.DOWN)
                        snake.SetDirection(Direction.UP);
                    break;
                case ConsoleKey.DownArrow:
                    if (snake.direction != Direction.UP)
                        snake.SetDirection(Direction.DOWN);
                    break;
            }
        }

        static void CreateGameObjects()
        {
            snake = new Snake(10, 10, 5, Direction.DOWN);
            foodCreator = new FoodCreator(38, 38);
            food = foodCreator.Spawn(snake.points);
            walls = new Walls(width, height);
        }

        static void SetUpConsole()
        {
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            Console.CursorVisible = false;
        }
    }
}
