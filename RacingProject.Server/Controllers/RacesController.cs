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
    public class RacesController : ControllerBase
    {
        private readonly RacingProjectContext _db;

        public RacesController(RacingProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Race>> GetAll()
        {
            return _db.Races;
        }

        [HttpGet("{id}")]
        public ActionResult<Race> GetById(int id)
        {
            var race = _db.Races.Find(id);

            if(race == null)
            {
                return NotFound();
            }

            return Ok(race);
        }

        [HttpPost]
        public ActionResult<Race> Create(Race race)
        {
            _db.Races.Add(race);
            _db.SaveChanges();

            return Ok(race);
        }

        [HttpPut("{id}")]
        public ActionResult<Race> Update(int id, Race newRace)
        {
            var oldRace = _db.Races.Find(id);

            if (oldRace == null)
            {
                return NotFound();
            }

            oldRace.RacingSeriesId = newRace.RacingSeriesId;
            oldRace.Country = newRace.Country;
            oldRace.City = newRace.City;
            oldRace.NumberOfLaps = newRace.NumberOfLaps;
            oldRace.Date = newRace.Date;
            oldRace.RacingSerie = newRace.RacingSerie;

            _db.SaveChanges();

            return Ok(newRace);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var race = _db.Races.Find(id);

            if (race == null)
            {
                return NotFound();
            }

            _db.Remove(race);
            _db.SaveChanges();

            return Ok();
        }
    }
}
