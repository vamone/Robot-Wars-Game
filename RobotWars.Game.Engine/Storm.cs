namespace RobotWars.Game.Engine
{
    public class Storm : RobotBase
    {
        public Storm(int startPositionLineX, int startPositonLineY,
            Compass.CompassSides startCompassPointer, RobotWarsArena fightArena = null)
            : base(startPositionLineX, startPositonLineY, startCompassPointer, fightArena)
        {
        }
    }
}