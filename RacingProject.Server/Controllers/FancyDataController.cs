using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RacingProject.Server.Data;
using RacingProject.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FancyDataController : ControllerBase
    {
        private readonly RacingProjectContext _db;

        public FancyDataController(RacingProjectContext db)
        {
            _db = db;
        }


        [HttpGet]
        public ActionResult<string> Index()
        {
            string text = "Here you can see FancyData \n \n" +

                          "FancyData/TeamWithMostDrivers - GET \n" +
                          "FancyData/DriversWithTeamsWithRacingSeries - GET \n" +
                          "FancyData/RaceResultsWithInfo - GET \n;
            return text;
        }

        [HttpGet]
        public ActionResult<dynamic> TeamWithMostDrivers()
        {
            //var query = _db.Drivers.GroupBy(x => x.TeamId).Select(y => new { TeamName = y.Key, Number = y.Count()});
            var teamId_numOfDrivers = _db.Drivers.Include(z => z.Team)
                                  .GroupBy(x => x.TeamId)
                                  .Select(y => new { TeamId = y.Key, NumberOfDrivers = y.Count() })
                                  .OrderByDescending(k => k.NumberOfDrivers)
                                  .First();

            var team = _db.Teams.Find(teamId_numOfDrivers.TeamId);

            return new { team.Name, teamId_numOfDrivers.NumberOfDrivers };
        }

        [HttpGet]
        public ActionResult<dynamic> DriversWithTeamsWithRacingSeries()
        {
            var drivers = _db.Drivers.Include(x => x.Team).ThenInclude(y => y.RacingSerie);

            return (dynamic)drivers;
        }

        [HttpGet]
        public ActionResult<dynamic> RaceResultsWithInfo()
        {
            var raceResults = _db.RaceResults.Include(x => x.Race).Include(y => y.Driver);

            return (dynamic)raceResults;
        }
    }

}
