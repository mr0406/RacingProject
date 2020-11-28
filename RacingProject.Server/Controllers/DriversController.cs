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
    public class DriversController : ControllerBase
    {
        private readonly RacingProjectContext _db;

        public DriversController(RacingProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Driver>> GetAll()
        {
            return _db.Drivers;
        }

        [HttpGet("{id}")]
        public ActionResult<Driver> GetById(int id)
        {
            var driver = _db.Drivers.Find(id);

            if(driver == null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        [HttpPost]
        public ActionResult<Driver> Create(Driver driver)
        {
            _db.Drivers.Add(driver);
            _db.SaveChanges();

            return Ok(driver);
        }

        [HttpPut("{id}")]
        public ActionResult<Driver> Update(int id, Driver newDriver)
        {
            var oldDriver = _db.Drivers.Find(id);

            if(oldDriver == null)
            {
                return NotFound();
            }

            oldDriver.Firstname = newDriver.Firstname;
            oldDriver.Surname = newDriver.Surname;
            oldDriver.TeamId = newDriver.TeamId;

            _db.SaveChanges();

            return Ok(oldDriver);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var driver = _db.Drivers.Find(id);

            if(driver == null)
            {
                return NotFound();
            }

            _db.Drivers.Remove(driver);
            _db.SaveChanges();

            return Ok();
        }
    }
}
