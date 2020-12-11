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
    }
}
