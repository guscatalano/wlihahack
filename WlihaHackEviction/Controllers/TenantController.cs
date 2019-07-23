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
    [Route("api/Tenant")]
    public class TenantController : Controller
    {
        private readonly EvictionDatabaseContext _dbContext;

        public TenantController(EvictionDatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: api/Tenant
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // ToDo: Return all Tenants
            return new string[] { "tenant1", "tenant2" };
        }

        // GET api/Tenant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TenantInfo>> GetTenantAsync(int id)
        {
            // ToDo: replace with DB query
            var dbTenantInfo = await _dbContext.DBTenantInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (dbTenantInfo == null)
            {
                return NotFound();
            }
            return dbTenantInfo;
        }

        // POST api/Tenant
        [HttpPost]
        public async Task NewTenantAsync([FromBody] TenantInfo tenantInfo)
        {
            // ToDo: insert into Actual DB
             _dbContext.DBTenantInfo.Add(tenantInfo);
            await _dbContext.SaveChangesAsync();
        }

        // PUT api/Tenant/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Tenant/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
