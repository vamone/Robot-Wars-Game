namespace RobotWars.Game.Engine
{
    public class Razer : RobotBase
    {
        public Razer(int startPositionLineX, int startPositonLineY,
            Compass.CompassSides startCompassPointer, RobotWarsArena fightArena = null)
            : base(startPositionLineX, startPositonLineY, startCompassPointer, fightArena)
        {
        }
    }
}