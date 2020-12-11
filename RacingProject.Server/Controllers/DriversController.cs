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

    //Wyswietlic wykres w ilu wyscigach kierowca bral udzial

    public class DriversController : ControllerBase
    {
        private const int PAGE_SIZE = 5;
        private readonly RacingProjectContext _db;

        public DriversController(RacingProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IndexPackage<Driver>> Get(int? page)
        {
            int pageNum = page ?? 1;
            if(page < 0)
            {
                pageNum = 1;
            }

            var data = new IndexPackage<Driver>();

            data.Entities = _db.Drivers.Skip(PAGE_SIZE * (pageNum - 1)).Take(PAGE_SIZE).ToList();
            data.ActualPage = pageNum;
            data.HasPreviousPage = pageNum != 1;
            data.HasNextPage = _db.Drivers.Skip(PAGE_SIZE * pageNum).Count() > 0;

            return data;
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
            try
            {
                _db.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }
            

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

            try
            {
                _db.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }


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
