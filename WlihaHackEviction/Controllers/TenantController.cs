﻿using System;
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
        public IActionResult Index()
        {
            return View();
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
        public async Task NewTenantAsync([FromBody] CompleteTenantEvictionInfo info)
        {
            TenantInfo tenantInfo = info.TenantInfo;
            AddressInfo addressInfo = info.AddressInfo;
            EvictionInfo evictionInfo = info.EvictionInfo;

            // Null-check for all required fields
            if (tenantInfo == null || addressInfo == null || evictionInfo == null)
            {
                // don't insert anything
            }

            if (tenantInfo.Name == null || tenantInfo.Email == null ||
                addressInfo.StreetAddress == null || addressInfo.City == null || addressInfo.County == null || addressInfo.ZipCode == 0
                || evictionInfo.DateOfEviction == null)
            {
                // don't insert anything
            }
            try
            {
                _dbContext.DBTenantInfo.Add(tenantInfo);
                await _dbContext.SaveChangesAsync();
            }
            // the only exception we should be getting here is the duplicate insertion - on which we just swallow the exception
            // we take care of the nulls above
            // rest we assume that the data is in correct format
            catch (Exception)
            {
                // swallow it
            }
            try
            {
                _dbContext.DBAddressInfo.Add(addressInfo);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            { }
                
            // Get TenantId and AddressId
            var tenantId = _dbContext.DBTenantInfo
                .Where(t => t.Name == tenantInfo.Name && t.Email == tenantInfo.Email)
                .Select(t => t.Id)
                .FirstOrDefault();

            var addressId = _dbContext.DBAddressInfo
                .Where(a => a.StreetAddress == addressInfo.StreetAddress && a.ZipCode == addressInfo.ZipCode)
                .Select(a => a.Id)
                .FirstOrDefault();

            evictionInfo.AddressId = addressId;
            evictionInfo.TenantId = tenantId;
            _dbContext.DBEvictionInfo.Add(evictionInfo);
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
