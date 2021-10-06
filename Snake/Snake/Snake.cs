using System.Collections.Generic;
namespace Snake
{
    public class Snake
    {
        public List<SnakeTile> snakeParts;
        public Snake()
        {
            snakeParts = new List<SnakeTile>();
            snakeParts.Add(new SnakeTile(SnakeGame.numGenerator.Next(GameVariables.mapSize), SnakeGame.numGenerator.Next(GameVariables.mapSize),0));
        }
        public void Move()
        {
            UpdateConnectedTiles();
            if (snakeParts[0].direction == 0)
                snakeParts[0].y -= 1;
            else if (snakeParts[0].direction == 2)
                snakeParts[0].y += 1;
            else if (snakeParts[0].direction == 1)
                snakeParts[0].x += 1;
            else
                snakeParts[0].x -= 1;
            if (snakeParts[0].x < 0)
                snakeParts[0].x = GameVariables.mapSize - 1;
            else if(snakeParts[0].x > GameVariables.mapSize - 1)
                snakeParts[0].x = 0;
            else if (snakeParts[0].y < 0)
                snakeParts[0].y = GameVariables.mapSize - 1;
            else if (snakeParts[0].y > GameVariables.mapSize - 1)
                snakeParts[0].y = 0;
            TryEat(SnakeGame.yummy);
        }
        public void ChangeDirection(int direction)
        {
            snakeParts[0].direction = direction;
        }
        public void TryEat(Food food)
        {
            if (snakeParts[0].x == food.x && snakeParts[0].y == food.y)
            {
                SnakeGame.SpawnFood();
                Grow();
            }
        }
        public void Grow()
        {
            int direction = snakeParts[snakeParts.Count - 1].direction-2;
            if (direction == -2)
                direction = 2;
            else if (direction == -1)
                direction = 3;
            int newX=0,newY = 0;
            if (direction == 0)
                newY -= 1;
            else if (direction == 2)
                newY+= 1;
            else if (direction == 1)
                newX+= 1;
            else
                newX -= 1;
            snakeParts.Add(new SnakeTile(snakeParts[snakeParts.Count - 1].x + newX, snakeParts[snakeParts.Count - 1].y + newY, snakeParts[snakeParts.Count - 1].direction));
        }
        public void UpdateConnectedTiles()
        {
            for (int i = snakeParts.Count - 1; i >0 ; i--)
            {
                snakeParts[i].x = snakeParts[i-1].x;
                snakeParts[i].y = snakeParts[i-1].y;
                snakeParts[i].direction = snakeParts[i-1].direction;
            }

        }
    }
}
