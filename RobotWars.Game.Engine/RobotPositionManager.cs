using System;

namespace RobotWars.Game.Engine
{
    public static class RobotPositionManager
    {
        public static RobotPosition CalculateForwardMove(RobotPosition position, RobotWarsArena fightArena)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            if (fightArena == null)
            {
                throw new ArgumentNullException(nameof(fightArena));
            }

            bool isCompassPointerToNorth = position.CompassPointer == Compass.CompassSides.North;
            bool isCompassPointerToEast = position.CompassPointer == Compass.CompassSides.East;
            bool isCompassPointerToSouth = position.CompassPointer == Compass.CompassSides.South;
            bool isCompassPointerToWest = position.CompassPointer == Compass.CompassSides.West;

            if (isCompassPointerToNorth)
            {
                return CalculateForwardMoveOnNothInternal(position, fightArena);
            }

            if (isCompassPointerToEast)
            {
                return CalculateForvardMoveOnEastInternal(position, fightArena);
            }

            if (isCompassPointerToSouth)
            {
                return CalculateForwardMoveOnSouthInternal(position, fightArena);
            }

            if (isCompassPointerToWest)
            {
                return CalculateForwardMoveOnWestInternal(position, fightArena);
            }

            throw new Exception("Can not solve forward move.");
        }

        public static RobotPosition CalculateLeftTurn(RobotPosition position)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            if (position.CompassPointer == Compass.CompassSides.West)
            {
                position.CompassPointer = Compass.CompassSides.North;

                return position;
            }

            position.CompassPointer = position.CompassPointer + 1;

            return position;
        }

        public static RobotPosition CalculateRightTurn(RobotPosition position)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            if (position.CompassPointer == Compass.CompassSides.North)
            {
                position.CompassPointer = Compass.CompassSides.West;

                return position;
            }

            position.CompassPointer = position.CompassPointer - 1;

            return position;
        }

        internal static RobotPosition CalculateForwardMoveOnNothInternal(RobotPosition position,
            RobotWarsArena fightArena)
        {
            int nextPositionLineY = position.Y + 1;

            bool isNextMoveOutsiteOfArena = nextPositionLineY >= fightArena.MaxY;
            if (isNextMoveOutsiteOfArena)
            {
                position.Y = fightArena.MaxY;

                return position;
            }

            position.Y = nextPositionLineY;

            return position;
        }

        internal static RobotPosition CalculateForvardMoveOnEastInternal(RobotPosition position,
            RobotWarsArena fightArena)
        {
            int nextPositionLineX = position.X + 1;

            bool isNextMoveOutsiteOfArena = nextPositionLineX >= fightArena.MaxX;

            if (isNextMoveOutsiteOfArena)
            {
                position.X = fightArena.MaxX;

                return position;
            }

            position.X = nextPositionLineX;

            return position;
        }

        internal static RobotPosition CalculateForwardMoveOnSouthInternal(RobotPosition position,
            RobotWarsArena fightArena)
        {
            int nextPositionLineY = position.Y - 1;

            bool isNextMoveOutsiteOfArena = nextPositionLineY <= fightArena.MinY;

            if (isNextMoveOutsiteOfArena)
            {
                position.Y = fightArena.MinY;

                return position;
            }

            position.Y = nextPositionLineY;

            return position;
        }

        internal static RobotPosition CalculateForwardMoveOnWestInternal(RobotPosition position,
            RobotWarsArena fightArena)
        {
            int nextPositionLineX = position.X - 1;

            bool isNextMoveOutsiteOfBoundary = nextPositionLineX <= fightArena.MinX;

            if (isNextMoveOutsiteOfBoundary)
            {
                position.X = fightArena.MinX;

                return position;
            }

            position.X = nextPositionLineX;

            return position;
        }
    }
}