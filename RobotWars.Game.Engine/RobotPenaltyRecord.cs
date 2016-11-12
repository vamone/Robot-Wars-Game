using System.Collections.Generic;
using System.Diagnostics;

namespace RobotWars.Game.Engine
{
    [DebuggerDisplay("PenaltiesCount = {PenaltiesCount}, PositionsCount = {Positions.Count}")]
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