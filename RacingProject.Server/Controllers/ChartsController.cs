using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RacingProject.Server.Data;
using RacingProject.Server.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ChartsController : ControllerBase
    {
        private readonly RacingProjectContext _db;

        public ChartsController(RacingProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<List<ChartElement>> Drivers()
        {
            var chartElements = _db.RaceResults
                                   .Where(rR => rR.FinalPosition == 1)
                                   .GroupBy(rR => rR.DriverId)
                                   .Select(group => new
                                   {
                                       DriverId = group.Key,
                                       NumOfWins = group.Count()
                                   })
                                   .Join(_db.Drivers, x => x.DriverId, driver => driver.Id, (x, driver) =>
                                   new ChartElement(driver.Surname, x.NumOfWins)).ToList();

            return chartElements;
        }

        public ActionResult<List<ChartElement>> RaceResults()
        {
            int raceId = _db.Races.OrderBy(x => x.Date).First().Id; //Austrian GP

            var chartElements = _db.RaceResults
                                   .Where(x => x.RaceId == raceId)
                                   .OrderByDescending(p => p.ScoredPoints)
                                   .Join(_db.Drivers, y => y.DriverId, driver => driver.Id, (y, driver) =>
                                   new ChartElement(driver.Firstname + " " + driver.Surname, y.ScoredPoints)).ToList();
       
            return chartElements;
        }

        public ActionResult<List<ChartElement>> Races()
        {
            var chartElements = new List<ChartElement>();
            
            foreach(var race in _db.Races)
            {
                chartElements.Add(new ChartElement(race.Name, race.NumberOfLaps));
            }

            return chartElements;
        }


        [HttpGet]
        public ActionResult<List<ChartElement>> Teams()
        {
            var chartElements = _db.Drivers
                                   .GroupBy(driver => driver.TeamId)
                                   .Select(group => new
                                   {
                                       TeamId = group.Key,
                                       NumOfDrivers = group.Count()
                                   })
                                   .Join(_db.Teams, x => x.TeamId, team => team.Id, (x, team) =>
                                   new ChartElement(team.Name, x.NumOfDrivers)).ToList();

            return chartElements;
        }

        [HttpGet]
        public ActionResult<List<ChartElement>> RacingSeries()
        {
            var chartElements = _db.Teams
                                   .GroupBy(team => team.RacingSerieId)
                                   .Select(group => new
                                   {
                                       RacingSerieId = group.Key,
                                       NumOfTeams = group.Count()
                                   })
                                   .Join(_db.RacingSeries, x => x.RacingSerieId, rS => rS.Id, (x, rS) =>
                                   new ChartElement(rS.Name, x.NumOfTeams)).ToList();

            return chartElements;
        }
    }
}
