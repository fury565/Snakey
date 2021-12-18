using System;
using System.Threading;
namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            SnakeGame.SetupGame();
            Console.CursorVisible = false;
            SnakeGame.DisplayMap();
            Snake snake = new Snake();
            SnakeGame.SpawnFood();
            var thread = new Thread(() => {
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (ConsoleKey.UpArrow == key.Key)
                    {
                        snake.ChangeDirection(0);
                    }
                    else if (ConsoleKey.RightArrow == key.Key)
                        snake.ChangeDirection(1);
                    else if (ConsoleKey.DownArrow == key.Key)
                        snake.ChangeDirection(2);
                    else if (ConsoleKey.LeftArrow == key.Key)
                        snake.ChangeDirection(3);
                }
            });

            thread.IsBackground = true;
            thread.Start();
            while (true)
            {
                SnakeGame.DisplayMap();
                SnakeGame.DisplaySnake(snake);
                SnakeGame.DisplayOther();
                snake.Move();
                Thread.Sleep((int)GameVariables.msRefreshRate);
                if (SnakeGame.gameLost)
                {
                    thread.Interrupt();
                    break;
                }
            }
            SnakeGame.GameOver();
            Console.ReadKey();
        }
    }
}
