using System;

namespace RobotWars.Game
{
    public class RobotWarsArena
    {
        private const int DefaultX = 5;

        private const int DefaultY = 5;

        public RobotWarsArena(int sizeInX = 0, int sizeInY = 0)
        {
            this.MaxX = Math.Max(sizeInX, DefaultX);
            this.MaxY = Math.Max(sizeInY, DefaultY);
        }

        public int MaxX { get; protected set; }

        public int MaxY { get; protected set; }

        public int MinX { get; protected set; }

        public int MinY { get; protected set; }
    }
}