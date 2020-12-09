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
        private const int PAGE_SIZE = 5;
        private readonly RacingProjectContext _db;

        public RacingSeriesController(RacingProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IndexPackage<RacingSerie>> Get(int? page)
        {
            int pageNum = page ?? 1;
            if (page < 0)
            {
                pageNum = 1;
            }

            var data = new IndexPackage<RacingSerie>();

            data.Entities = _db.RacingSeries.Skip(PAGE_SIZE * (pageNum - 1)).Take(PAGE_SIZE).ToList();
            data.ActualPage = pageNum;
            data.HasPreviousPage = pageNum != 1;
            data.HasNextPage = _db.RacingSeries.Skip(PAGE_SIZE * pageNum).Count() > 0;

            return data;
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

            try
            {
                _db.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

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

            try
            {
                _db.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

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

            try
            {
                _db.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
