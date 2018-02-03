using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public string Get(string name)
        {
            return "Hello " + name;
        }

    }
}
