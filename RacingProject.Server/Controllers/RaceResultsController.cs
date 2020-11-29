using Microsoft.AspNetCore.Mvc;
using RacingProject.Server.Data;
using RacingProject.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaceResultsController : ControllerBase
    {
        private const int PAGE_SIZE = 5;
        private readonly RacingProjectContext _db;

        public RaceResultsController(RacingProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RaceResult>> Get(int? page)
        {
            int pageNum = page ?? 1;

            return _db.RaceResults.Skip(PAGE_SIZE * (pageNum - 1)).Take(PAGE_SIZE).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<RaceResult> GetById(int id)
        {
            var raceResult = _db.RaceResults.Find(id);

            if (raceResult == null)
            {
                return NotFound();
            }

            return Ok(raceResult);
        }

        [HttpPost]
        public ActionResult<RaceResult> Create(RaceResult raceResult)
        {
            _db.RaceResults.Add(raceResult);
            _db.SaveChanges();

            return Ok(raceResult);
        }

        [HttpPut("{id}")]
        public ActionResult<RaceResult> Update(int id, RaceResult newRaceResult)
        {
            var oldRaceResult = _db.RaceResults.Find(id);

            if (oldRaceResult == null)
            {
                return NotFound();
            }

            oldRaceResult.DriverId = newRaceResult.DriverId;
            oldRaceResult.RaceId = newRaceResult.RaceId;
            oldRaceResult.StartingPosition = newRaceResult.StartingPosition;
            oldRaceResult.FinalPosition = newRaceResult.FinalPosition;
            oldRaceResult.ScoredPoints = newRaceResult.ScoredPoints;

            _db.SaveChanges();

            return Ok(oldRaceResult);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var raceResult = _db.RaceResults.Find(id);

            if (raceResult == null)
            {
                return NotFound();
            }

            _db.RaceResults.Remove(raceResult);
            _db.SaveChanges();

            return Ok();
        }
    }
}
