﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EtcdNet;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ConfigClient.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ILogger logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            this.logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> values = new List<string>();
            values.Add(Startup.Configuration.GetSection("/myapp/hello").Value);
            values.Add(Startup.Configuration.GetSection("/myapp/rate").Value);

            return values;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}