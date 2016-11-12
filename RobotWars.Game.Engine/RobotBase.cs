using System;
using System.Linq;

namespace RobotWars.Game.Engine
{
    public class RobotBase
    {
        public RobotBase(int startPositionLineX, int startPositonLineY,
            Compass.CompassSides startCompassPointer, RobotWarsArena fightArena = null)
        {
            if (startPositionLineX < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startPositionLineX));
            }

            if (startPositonLineY < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startPositonLineY));
            }

            this.RobotId = Guid.NewGuid();

            this.Position = this.Position ?? new RobotPosition();
            this.PenaltyRecord = this.PenaltyRecord ?? new RobotPenaltyRecord();

            this.Position.X = startPositionLineX;
            this.Position.Y = startPositonLineY;

            this.Position.CompassPointer = startCompassPointer;

            this.FightArena = this.FightArena ?? fightArena;
        }

        public Guid RobotId { get; protected set; }

        public RobotPosition Position { get; protected set; }

        public RobotPenaltyRecord PenaltyRecord { get; protected set; }

        public RobotWarsArena FightArena { get; internal set; }

        public int HitCount { get; protected set; }

        public void MoveForvard()
        {
            var position = new RobotPosition
            {
                X = this.Position.X,
                Y = this.Position.Y,
                CompassPointer = this.Position.CompassPointer
            };

            var nextPosition = RobotPositionManager.CalculateForwardMove(position, this.FightArena);

            bool isPositionInUserByOtherRobot =
                this.FightArena.ParticipatedRobots.Any(
                    x => x.Position.X == nextPosition.X && x.Position.Y == nextPosition.Y && x.RobotId != this.RobotId);

            if (isPositionInUserByOtherRobot)
            {
                this.HitCount++;

                return;
            }

            this.Position = nextPosition;

            bool hasRobotPenalty = RobotPenaltiesManager.HasPenalty(position, this.FightArena);
            if (hasRobotPenalty)
            {
                var penaltyPosition = new RobotPosition
                {
                    X = this.Position.X,
                    Y = this.Position.Y,
                    CompassPointer = this.Position.CompassPointer
                };

                this.PenaltyRecord.Positions.Add(penaltyPosition);
                this.PenaltyRecord.PenaltiesCount = this.PenaltyRecord.PenaltiesCount + 1;
            }
        }

        public void TurnRight()
        {
            this.Position = RobotPositionManager.CalculateLeftTurn(this.Position);
        }

        public void TurnLeft()
        {
            this.Position = RobotPositionManager.CalculateRightTurn(this.Position);
        }
    }
}