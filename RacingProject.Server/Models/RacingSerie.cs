using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Models
{
    public class RacingSerie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Season> Seasons { get; set; }
    }
}
