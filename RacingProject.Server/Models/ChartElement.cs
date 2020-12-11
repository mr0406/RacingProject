using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Models
{
    public class ChartElement
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public ChartElement()
        {

        }

        public ChartElement(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
