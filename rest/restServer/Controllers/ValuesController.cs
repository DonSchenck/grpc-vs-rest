using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace restServer.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        // GET api/values/name
        [HttpGet("{name}")]
        public JsonResult Get(string name)
        {
            List<Person> Persons = new List<Person>();

            for (int i=0; i < 1000; i++) {
                Person _person = new Person();
                _person.fullname = name;
                _person.phonenbr = "555-867-" + i.ToString();
                _person.userid = name + "@gmail.com";
                Persons.Add(_person);
            }

            return Json(Persons);
        }

    }
}
