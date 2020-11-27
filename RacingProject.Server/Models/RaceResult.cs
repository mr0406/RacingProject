using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Models
{
    public class RaceResult
    {
        //Key: RaceId,DriverId

        public int DriverId { get; set; }
        public int RaceId { get; set; }

        public int StartingPosition { get; set; }
        public int FinalPosition { get; set; }
        public int ScoredPoints { get; set; }

        public Driver Driver { get; set; }
        public Race Race { get; set; }
    }
}
