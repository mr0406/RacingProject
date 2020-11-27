using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Models
{
    public class RaceResult
    {
        public int Id { get; set; }

        [Required]
        public int DriverId { get; set; }
        [Required]
        public int RaceId { get; set; }

        public int StartingPosition { get; set; }
        public int FinalPosition { get; set; }
        public int ScoredPoints { get; set; }

        public Driver Driver { get; set; }
        public Race Race { get; set; }
    }
}
