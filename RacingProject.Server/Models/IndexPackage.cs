using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Models
{
    public class IndexPackage<T> where T : class
    {
        public List<T> Entities { get; set; }
        public int ActualPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}
