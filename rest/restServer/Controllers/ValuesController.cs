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
            Person _person = new Person();
            _person.fullname = name;
            _person.phonenbr = "555-867-3509";
            _person.userid = name + "@gmail.com";
            return Json(_person);
        }

    }
}
