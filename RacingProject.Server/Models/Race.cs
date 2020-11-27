using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int NumberOfLaps { get; set; }

        //dd--MM-yyyy
        public DateTime Date { get; set; }

        public int RacingSeriesId { get; set; }
        public int SeasonId { get; set; }

        public Season Season { get; set; }
        public RacingSerie RacingSerie { get; set; }

        public IEnumerable<RaceResult> RaceResults { get; set; }
    }
}
