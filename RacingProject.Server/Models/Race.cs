using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Models
{
    public class Race
    {
        [Key] 
        public int Id { get; set; }
        [Required, ForeignKey("Team")]
        public int RacingSeriesId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int NumberOfLaps { get; set; }

        public DateTime Date { get; set; }

        public RacingSerie RacingSerie { get; set; }
    }
}
