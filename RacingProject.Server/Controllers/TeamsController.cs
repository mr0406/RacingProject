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
    public class TeamsController : ControllerBase
    {
        private const int PAGE_SIZE = 5;
        private readonly RacingProjectContext _db;

        public TeamsController(RacingProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IndexPackage<Team>> Get(int? page)
        {
            int pageNum = page ?? 1;
            if (page < 0)
            {
                pageNum = 1;
            }

            var data = new IndexPackage<Team>();

            data.Entities = _db.Teams.Skip(PAGE_SIZE * (pageNum - 1)).Take(PAGE_SIZE).ToList();
            data.ActualPage = pageNum;
            data.HasPreviousPage = pageNum != 1;
            data.HasNextPage = _db.Teams.Skip(PAGE_SIZE * pageNum).Count() > 0;

            return data;
        }

        [HttpGet("{id}")]
        public ActionResult<Team> GetById(int id)
        {
            var team = _db.Teams.Find(id);

            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [HttpPost]
        public ActionResult<Team> Create(Team team)
        {
            _db.Teams.Add(team);
            _db.SaveChanges();

            return Ok(team);
        }

        [HttpPut("{id}")]
        public ActionResult<Team> Update(int id, Team newTeam)
        {
            var oldTeam = _db.Teams.Find(id);

            if(oldTeam == null)
            {
                return NotFound();
            }

            oldTeam.Name = newTeam.Name;
            oldTeam.RacingSerieId = oldTeam.RacingSerieId;

            _db.SaveChanges();

            return Ok(oldTeam);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var team = _db.Teams.Find(id);

            if(team == null)
            {
                return NotFound();
            }

            _db.Remove(team);
            _db.SaveChanges();

            return Ok();
        }
    }
}
