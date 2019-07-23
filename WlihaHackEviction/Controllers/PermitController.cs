using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WlihaHackPermit.Controllers
{
    [Route("api/[controller]")]
    public class PermitController : Controller
    {
        private PermitDatabaseContext _dbContext;

        public PermitController(PermitDatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: api/Permit
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Permit/Id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            // Get PermitInfo
            return "Hello World";
        }

        // POST api/Permit
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/Permit/Id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Permit/Id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
