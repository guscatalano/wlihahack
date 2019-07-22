using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WlihaHackEviction.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WlihaHackEviction.Controllers
{
    [Route("api/[controller]")]
    public class EvictionController : Controller
    {
        private readonly EvictionDatabaseContext _dbContext;

        public EvictionController(EvictionDatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: api/Eviction
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Eviction/Id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            // Get EvictionInfo
            return "Hello World";
        }

        // POST api/Eviction
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/Eviction/Id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Eviction/Id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
