using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RobotWars.Game.Engine
{
    [DebuggerDisplay("MinX = {MinX}, MinY = {MinY}, MaxX = {MaxX}, MaxY = {MaxY}, ParticipatedRobotsCount = {ParticipatedRobots.Count}")]
    public class RobotWarsArena
    {
        const int DefaultX = 5;

        const int DefaultY = 5;

        public RobotWarsArena(int sizeInX = 0, int sizeInY = 0)
        {
            this.MaxX = Math.Max(sizeInX, DefaultX);
            this.MaxY = Math.Max(sizeInY, DefaultY);

            this.ParticipatedRobots = this.ParticipatedRobots ?? new List<RobotBase>();
        }

        public void RobotsEnterArena(params RobotBase[] participatedRobots)
        {
            this.ParticipatedRobots = participatedRobots;

            foreach (var robot in participatedRobots)
            {
                robot.FightArena = this;
            }
        }

        public int MaxX { get; protected set; }

        public int MaxY { get; protected set; }

        public int MinX { get; protected set; }

        public int MinY { get; protected set; }

        internal ICollection<RobotBase> ParticipatedRobots { get; set; }
    }
}