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
    public class RacingSeriesController : ControllerBase
    {
        private readonly RacingProjectContext _context;

        public RacingSeriesController(RacingProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RacingSerie>> Get()
        {
            return _context.RacingSeries;
        }

        [HttpGet("{id}")]
        public ActionResult<RacingSerie> GetById(int id)
        {
            var racingSerie = _context.RacingSeries.Find(id);

            if(racingSerie == null)
            {
                return NotFound();
            }

            return Ok(racingSerie);
        }

        [HttpPost]
        public ActionResult<RacingSerie> Create(RacingSerie racingSerie)
        {
            _context.RacingSeries.Add(racingSerie);
            _context.SaveChanges();

            return Ok(racingSerie);
        }

        [HttpPut("{id}")]
        public ActionResult<RacingSerie> Update(int id, RacingSerie newRacingSerie)
        {
            var oldRacingSerie = _context.RacingSeries.Find(id);

            if(oldRacingSerie == null)
            {
                return NotFound();
            }

            oldRacingSerie.Name = newRacingSerie.Name;
            oldRacingSerie.Races = newRacingSerie.Races;

            _context.SaveChanges();

            return Ok(newRacingSerie);
        }
    }
}
