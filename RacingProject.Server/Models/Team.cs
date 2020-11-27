using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RacingSerieId { get; set; }
        public int SeasonId { get; set; }

        public RacingSerie RacingSerie { get; set; }
        public Season Season { get; set; }

        public IEnumerable<Driver> Drivers { get; set; }
    }
}
