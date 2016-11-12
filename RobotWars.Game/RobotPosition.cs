using System.Diagnostics;

namespace RobotWars.Game
{
    [DebuggerDisplay("X = {X}, Y = {Y}, CompassPointer = {CompassPointer}")]
    public class RobotPosition
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Compass.CompassSides CompassPointer { get; set; }
    }
}