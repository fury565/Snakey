using System;
using System.Text;
namespace Snake
{
    public static class SnakeGame
    {
        public readonly static Random numGenerator = new Random();
        static StringBuilder stringer=new StringBuilder();
        public static Food yummy = new Food(numGenerator.Next(GameVariables.mapSize), numGenerator.Next(GameVariables.mapSize));
        private static int score = -1;
        public static bool gameLost = false;
        public static void SetupGame()
        {
            Console.SetWindowSize(GameVariables.mapSize+5, GameVariables.mapSize+5);
            Console.SetBufferSize(GameVariables.mapSize+5, GameVariables.mapSize+5);
            String lilstring = new string(' ', GameVariables.mapSize);
            for (int i = 0; i < GameVariables.mapSize; i++)
            {
                stringer.Append(lilstring);
                stringer.AppendLine("#");
            }
            stringer.Append(new string('#', GameVariables.mapSize + 1));
        }

        internal static void DisplayOther()
        {
            Console.SetCursorPosition(yummy.x,yummy.y);
            Console.Write("X");
            Console.SetCursorPosition(0, GameVariables.mapSize + 2);
            Console.Write("Score: " + score);
        }

        public static void DisplayMap()
        {
            //Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write(stringer);
        }

        internal static void SpawnFood()
        {
            yummy = new Food(numGenerator.Next(GameVariables.mapSize), numGenerator.Next(GameVariables.mapSize));
            score++;
        }

        internal static void DisplaySnake(Snake snake)
        {
            foreach(SnakeTile tile in snake.snakeParts) { 
                Console.SetCursorPosition(tile.x, tile.y);
                Console.Write("O");
            }
        }
        internal static void GameOver()
        {
            Console.SetCursorPosition(0, GameVariables.mapSize + 3);
            Console.Write("Game Over");
        }
    }
}
