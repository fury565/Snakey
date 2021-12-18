using System;
namespace Snake
{
    public static class GameVariables
    {
        public readonly static int mapSize = 20;
        public readonly static int FPS = 6;
        public readonly static double msRefreshRate = FPS / 60.0 * 1000;
    }
}
