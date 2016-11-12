using System;

namespace RobotWars.Game.Engine
{
    public static class RobotPenaltiesManager
    {
        public static bool HasPenalty(RobotPosition position, RobotWarsArena fightArena)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            if (fightArena == null)
            {
                throw new ArgumentNullException(nameof(fightArena));
            }

            bool isStartPosition = position.X == fightArena.MinX && position.Y == fightArena.MinY;
            if (isStartPosition)
            {
                return false;
            }

            bool isCompassOnNorth = position.CompassPointer == Compass.CompassSides.North;
            bool isCompassOnEast = position.CompassPointer == Compass.CompassSides.East;
            bool isCompassOnSouth = position.CompassPointer == Compass.CompassSides.South;
            bool isCompassOnWest = position.CompassPointer == Compass.CompassSides.West;

            bool hasHitOnRight = position.X == fightArena.MaxX;
            bool hasHitOnLeft = position.X == fightArena.MinX;
            bool hasHitOnTop = position.Y == fightArena.MaxY;
            bool hasHitOnBottom = position.Y == fightArena.MinY;

            if (hasHitOnTop && isCompassOnNorth)
            {
                return true;
            }

            if (hasHitOnLeft && isCompassOnWest)
            {
                return true;
            }

            if (hasHitOnRight && isCompassOnEast)
            {
                return true;
            }

            if (hasHitOnBottom && isCompassOnSouth)
            {
                return true;
            }

            return false;
        }
    }
}