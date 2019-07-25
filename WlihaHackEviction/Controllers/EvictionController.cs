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
        public List<EvictionResult> GetAllEvictions()
        {
            List<EvictionResult> result = null;
            result = _dbContext.DBEvictionInfo.Join(_dbContext.DBTenantInfo,
                evictionInfo => evictionInfo.TenantId,
                tenantInfo => tenantInfo.Id,
                (evictionInfo, tenantInfo) => new { tenantInfo, evictionInfo }
                )
                .Join(_dbContext.DBAddressInfo,
                combinedInfo => combinedInfo.evictionInfo.AddressId,
                addressInfo => addressInfo.Id,
                (combinedInfo, addressInfo) => new EvictionResult { AddressInfo = addressInfo, DateOfEviction = combinedInfo.evictionInfo.DateOfEviction, NumberOfPpl = combinedInfo.tenantInfo.NumberOfPpl }
                ).ToList();
            return result;
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
        // this can be used to verify the eviction and add some notes
        // the eviction info object needs to be passed as json
        // make sure that non-null fields of EvictionInfo are populated in the object sent to this call
        [HttpPut("{id}")]
        public async Task UpdateEviction([FromBody] EvictionInfo info)
        {
            _dbContext.DBEvictionInfo.Update(info);
            await _dbContext.SaveChangesAsync();
        }

        // DELETE api/Eviction/Id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
