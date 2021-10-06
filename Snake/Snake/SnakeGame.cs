using System;
using System.Text;
namespace Snake
{
    public static class SnakeGame
    {
        public readonly static Random numGenerator = new Random();
        static StringBuilder stringer=new StringBuilder();
        public static Food yummy = new Food(numGenerator.Next(GameVariables.mapSize), numGenerator.Next(GameVariables.mapSize));
        public static void SetupGame()
        {
            String lilstring = new string(' ', GameVariables.mapSize);
            for (int i = 0; i < GameVariables.mapSize; i++)
            {
                stringer.AppendLine(lilstring);
            }
        }

        internal static void DisplayOther()
        {
            Console.SetCursorPosition(yummy.x,yummy.y);
            Console.Write("X");
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
        }

        internal static void DisplaySnake(Snake snake)
        {
            foreach(SnakeTile tile in snake.snakeParts) { 
                Console.SetCursorPosition(tile.x, tile.y);
                Console.Write("O");
            }
        }
    }
}
