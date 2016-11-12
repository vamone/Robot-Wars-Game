namespace RobotWars.Game.Engine
{
    public class Razer : RobotBase
    {
        public Razer(RobotWarsArena fightArena, int startPositionLineX, int startPositonLineY,
            Compass.CompassSides startCompassPointer)
            : base(fightArena, startPositionLineX, startPositonLineY, startCompassPointer)
        {
        }
    }
}