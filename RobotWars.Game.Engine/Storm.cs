namespace RobotWars.Game.Engine
{
    public class Storm : RobotBase
    {
        public Storm(RobotWarsArena fightArena, int startPositionLineX, int startPositonLineY,
            Compass.CompassSides startCompassPointer)
            : base(fightArena, startPositionLineX, startPositonLineY, startCompassPointer)
        {
        }
    }
}