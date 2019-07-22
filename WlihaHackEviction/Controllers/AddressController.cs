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
    public class AddressController : Controller
    {

        private readonly EvictionDatabaseContext _dbContext;

        public AddressController(EvictionDatabaseContext context)
        {
            _dbContext = context;
        }


        // GET: api/Address
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Address/AddressId
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressInfo>> Get(long id)
        {
            // ToDo: replace with DB query
            var dbAddressInfo = await _dbContext.DBAddressInfo.FindAsync(id);
            if (dbAddressInfo == null)
            {
                return NotFound();
            }
            return dbAddressInfo;
        }

        // POST api/Address
        [HttpPost]
        public async void Post(AddressInfo addressInfo)
        {
            // ToDo: insert into Actual DB
            _dbContext.Add(addressInfo);
            await _dbContext.SaveChangesAsync();
        }

        // PUT api/Address/AddressId
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Address/AddressId
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
