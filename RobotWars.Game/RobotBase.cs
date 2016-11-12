using System;

namespace RobotWars.Game
{
    public class RobotBase
    {
        public RobotBase(RobotWarsArena fightArena, int startPositionLineX, int startPositonLineY,
            Compass.CompassSides startCompassPointer)
        {
            if (fightArena == null)
            {
                throw new ArgumentNullException(nameof(fightArena));
            }

            if (startPositionLineX < 0 || startPositionLineX > fightArena.MaxX)
            {
                throw new ArgumentOutOfRangeException(nameof(startPositionLineX));
            }

            if (startPositonLineY < 0 || startPositonLineY > fightArena.MaxY)
            {
                throw new ArgumentOutOfRangeException(nameof(startPositonLineY));
            }

            this.Position = this.Position ?? new RobotPosition();
            this.PenaltyRecord = this.PenaltyRecord ?? new RobotPenaltyRecord();

            this.Position.X = startPositionLineX;
            this.Position.Y = startPositonLineY;

            this.Position.CompassPointer = startCompassPointer;

            this.FightArena = fightArena;
        }

        public RobotPosition Position { get; protected set; }

        public RobotPenaltyRecord PenaltyRecord { get; protected set; }

        public RobotWarsArena FightArena { get; protected set; }

        public void MoveForvard()
        {
            this.Position = RobotPositionManager.CalculateForwardMove(this.Position, this.FightArena);

            bool hasRobotPenalty = RobotPenaltiesManager.HasPenalty(this.Position, this.FightArena);
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