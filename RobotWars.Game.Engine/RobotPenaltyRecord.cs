using System.Collections.Generic;

namespace RobotWars.Game.Engine
{
    public class RobotPenaltyRecord
    {
        public RobotPenaltyRecord()
        {
            this.Positions = this.Positions ?? new List<RobotPosition>();
        }

        public ICollection<RobotPosition> Positions { get; set; }

        public int PenaltiesCount { get; set; }
    }
}