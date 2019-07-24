using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WlihaHackEviction.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WlihaHackPermit.Controllers
{
    [Route("api/[controller]")]
    public class PermitController : Controller
    {
        private EvictionDatabaseContext _dbContext;
        public PermitController(EvictionDatabaseContext context)
        {
            _dbContext = context;
        }

        // GET api/Permit/Address
        [HttpGet("{address}")]
        public List<PermitInfo> GetPermitInfoForAddress(string address)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.Value = address;
            parameter.ParameterName = "address";
            parameter.Direction = System.Data.ParameterDirection.Input;

            string query = @"
            SELECT *
            FROM [dbo].[PermitInfo]
            WHERE LOWER(@address) = LOWER([dbo].[PermitInfo].[OriginalAddress])";

            List<PermitInfo> permitInfo = _dbContext.DBPermitInfo.FromSql(query, parameter).ToListAsync().Result;
            if (permitInfo == null)
            {
                return new List<PermitInfo>();
            }
            return permitInfo;
        }


        // GET api/Permit/Tenants/EvictedWithoutPermit
        [HttpGet]
        public List<TenantInfo> GetTenantsEvictedWithoutPermit()
        {
            string query = @"
            SELECT *
            FROM [dbo].[TenantsInfo]
            WHERE [dbo].[TenantsInfo].[Id] =
	            (SELECT [dbo].[EvictionInfo].[TenantId]
	            FROM [dbo].[EvictionInfo]
	            WHERE 
		        NOT EXISTS(
			        SELECT* 
			        FROM [dbo].[AddressInfo]
			        LEFT JOIN [dbo].[PermitInfo]
			        ON ((LOWER([dbo].[AddressInfo].[StreetAddress]) like LOWER([dbo].[PermitInfo].[OriginalAddress1]))) 
				        and ([dbo].[AddressInfo].[ZipCode] = [dbo].[PermitInfo].[OriginalZip])))";
           
            List<TenantInfo> tenantInfo =  _dbContext.DBTenantInfo.FromSql(query).ToListAsync().Result;
            if(tenantInfo == null)
            {
                return new List<TenantInfo>();
            }
            return tenantInfo;
        }

        // GET api/Permit/Tenants/EvictedWithPermit
        [HttpGet]
        public List<TenantInfo> GetTenantsEvictedWithPermit()
        {
            string query = @"
            SELECT *
            FROM [dbo].[TenantsInfo]
            WHERE [dbo].[TenantsInfo].[Id] =
	            (SELECT [dbo].[EvictionInfo].[TenantId]
	            FROM [dbo].[EvictionInfo]
	            WHERE 
			        SELECT* 
			        FROM [dbo].[AddressInfo]
			        LEFT JOIN [dbo].[PermitInfo]
			        ON ((LOWER([dbo].[AddressInfo].[StreetAddress]) like LOWER([dbo].[PermitInfo].[OriginalAddress1]))) 
				        and ([dbo].[AddressInfo].[ZipCode] = [dbo].[PermitInfo].[OriginalZip])))";
            List<TenantInfo> tenantInfo = _dbContext.DBTenantInfo.FromSql(query).ToListAsync().Result;
            if (tenantInfo == null)
            {
                return new List<TenantInfo>();
            }
            return tenantInfo;
        }

        // GET api/Permit/Evictions
        [HttpGet()]
        public List<PermitInfo> GetPermitInfoForAddressesWithEvictions()
        {
            string query = @"
            SELECT *
            FROM [dbo].[PermitInfo]
            LEFT JOIN [dbo].[AddressInfo]
            ON ((@address (LOWER([dbo].[PermitInfo].[OriginalAddress1]) = LOWER([dbo].[AddressInfo].[StreetAddress])
                 and ([dbo].[AddressInfo].[ZipCode] = [dbo].[PermitInfo].[OriginalZip])))
            WHERE
            EXISTS
                (SELECT[dbo].[AddressInfo].[StreetAddress]
                FROM [dbo].[AddressInfo]
                    LEFT JOIN [dbo].[EvictionInfo]
                    ON (LOWER([dbo].[EvictionInfo].[AddressId]) = LOWER([dbo].[AddressInfo].[Id])))";

            List<PermitInfo> permitInfo = _dbContext.DBPermitInfo.FromSql(query).ToListAsync().Result;
            if (permitInfo == null)
            {
                return new List<PermitInfo>();
            }
            return permitInfo;
        }

        // GET api/PermitLinks/Evictions
        [HttpGet()]
        public List<string> GetPermitLinksForAddressesWithEvictions()
        {
            List<PermitInfo> permits = GetPermitInfoForAddressesWithEvictions();
            List<string> links = new List<string>();
            permits.ForEach(permit => links.Add(permit.Link.ToString()));
            return links;
        }
    }
}
