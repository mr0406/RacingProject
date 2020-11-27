using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public IEnumerable<RaceResult> RaceResults { get; set; }
    }
}
