using Microsoft.EntityFrameworkCore;
using RacingProject.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Data
{
    public class RacingProjectContext : DbContext
    {
        public DbSet<RacingSerie> RacingSeries { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<RaceResult> RaceResults { get; set; }

        public RacingProjectContext(DbContextOptions<RacingProjectContext> options) : base(options)
        {

        }
    }
}
