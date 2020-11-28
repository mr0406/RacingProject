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
    [Route("[controller]")]
    public class RacingSeriesController : ControllerBase
    {
        private readonly RacingProjectContext _db;

        public RacingSeriesController(RacingProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RacingSerie>> GetAll()
        {
            return _db.RacingSeries;
        }

        [HttpGet("{id}")]
        public ActionResult<RacingSerie> GetById(int id)
        {
            var racingSerie = _db.RacingSeries.Find(id);

            if(racingSerie == null)
            {
                return NotFound();
            }

            return Ok(racingSerie);
        }

        [HttpPost]
        public ActionResult<RacingSerie> Create(RacingSerie racingSerie)
        {
            _db.RacingSeries.Add(racingSerie);
            _db.SaveChanges();

            return Ok(racingSerie);
        }

        [HttpPut("{id}")]
        public ActionResult<RacingSerie> Update(int id, RacingSerie newRacingSerie)
        {
            var oldRacingSerie = _db.RacingSeries.Find(id);

            if(oldRacingSerie == null)
            {
                return NotFound();
            }

            oldRacingSerie.Name = newRacingSerie.Name;

            _db.SaveChanges();

            return Ok(oldRacingSerie);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var racingSerie = _db.RacingSeries.Find(id);

            if(racingSerie == null)
            {
                return NotFound();
            }

            _db.Remove(racingSerie);
            _db.SaveChanges();

            return Ok();
        }

    }
}
