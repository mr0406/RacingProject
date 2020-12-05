using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RacingProject.Server.Data;
using RacingProject.Server.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RacingProject.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class JSONController : ControllerBase
    {
        private readonly RacingProjectContext _db;
        private readonly string _filePath;

        public JSONController(RacingProjectContext db)
        {
            _db = db;
            _filePath = Environment.CurrentDirectory + "\\XML\\drivers.xml";
        }

        [HttpGet]
        public ActionResult<string> Index()
        {
            string text = "Here you can use JSON serialization/deserialization \n" +
                            "To read drivers: JSON/Drivers - GET \n" +
                            "To write driver JSON/Drivers - POST \n";
            return text;
        }

        [HttpGet]
        public ActionResult<List<Driver>> Drivers()
        {
            List<Driver> drivers = new List<Driver>();
            using(StreamReader reader = new StreamReader(_filePath))
            {
                string readText = reader.ReadToEnd();
                Debug.WriteLine(readText);
                drivers = JsonConvert.DeserializeObject<List<Driver>>(readText);
            }

            return drivers;      
        }

        [HttpPost]
        public ActionResult<List<Driver>> Drivers(Driver newDriver)
        {
            List<Driver> drivers = new List<Driver>();
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string readText = reader.ReadToEnd();
                if(readText != null)
                {
                    drivers = JsonConvert.DeserializeObject<List<Driver>>(readText);
                }
            }

            drivers.Add(newDriver);

            string jsonData = JsonConvert.SerializeObject(drivers, Formatting.Indented);

            using(StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.Write(jsonData);
            }

            return drivers;
        }
    }
}
