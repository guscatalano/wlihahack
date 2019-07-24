using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<AddressInfo>> GetAddressAsync(int addressId)
        {
            // ToDo: replace with DB query
            var dbAddressInfo = await _dbContext.DBAddressInfo.FirstOrDefaultAsync(m => m.Id == addressId);
            if (dbAddressInfo == null)
            {
                return NotFound();
            }
            return dbAddressInfo;
        }

        // POST api/Address
        [HttpPost]
        public async Task NewAddressAsync([FromBody] AddressInfo addressInfo)
        {
            try
            {
                _dbContext.DBAddressInfo.Add(addressInfo);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

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
