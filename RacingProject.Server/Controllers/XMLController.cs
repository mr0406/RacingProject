using Microsoft.AspNetCore.Mvc;
using RacingProject.Server.Data;
using RacingProject.Server.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RacingProject.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class XMLController : ControllerBase
    {
        private readonly RacingProjectContext _db;
        private readonly XmlSerializer xmlSerializer;
        private readonly string _filePath;

        public XMLController(RacingProjectContext db)
        {
            _db = db;
            xmlSerializer = new XmlSerializer(typeof(List<Driver>));
            _filePath = Environment.CurrentDirectory + "\\XML\\drivers.xml";
        }

        [HttpGet]
        public ActionResult<string> Index()
        {
            string text = "Here you can use XML serialization/deserialization \n" +
                            "To read drivers: XML/Drivers - GET \n" +
                            "To write driver XML/Drivers - POST \n";
            return text;
        }

        [HttpGet]
        public ActionResult<List<Driver>> Drivers()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Driver>));

            List<Driver> drivers = new List<Driver>();
            using (StreamReader stream = new StreamReader(_filePath))
            {
                drivers = (List<Driver>)xmlSerializer.Deserialize(stream);
            }

            return drivers;
        }

        [HttpPost]
        public ActionResult<List<Driver>> Drivers(Driver newDriver)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Driver>));

            List<Driver> drivers = new List<Driver>();
            using (StreamReader stream = new StreamReader(_filePath))
            {
                drivers = (List<Driver>)xmlSerializer.Deserialize(stream);
            }

            drivers.Add(newDriver);

            using (TextWriter textWriter = new StreamWriter(_filePath))
            {
                xmlSerializer.Serialize(textWriter, drivers);
            }

            return drivers;
        }
    }
}
