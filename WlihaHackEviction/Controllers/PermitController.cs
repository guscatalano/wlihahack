using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using WlihaHackEviction.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WlihaHackPermit.Controllers
{
    [Route("api/[controller]")]
    public class PermitController : Controller
    {
        public PermitController()
        {
        }

        // GET: api/Permit
        [HttpGet]
        public List<TenantInfo> GetTenantsEvictedWithoutPermit()
        {
            string query = @"SELECT *
            FROM [dbo].[TenantsInfo]
            WHERE [dbo].[TenantsInfo].[Id] =
            (SELECT [dbo].[EvictionInfo].[TenantId]
            FROM [dbo].[EvictionInfo]
            WHERE 
	        NOT EXISTS(
	        SELECT* 
	        FROM [dbo].[AddressInfo]
	        LEFT JOIN [dbo].[PermitInfo]
	        ON [dbo].[AddressInfo].[StreetAddress] like [dbo].[PermitInfo].[OriginalAddress1]))";

            SqlConnection connection = new SqlConnection("connectionString");
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<TenantInfo> tenantInfo = new List<TenantInfo>();

            while (reader.Read())
            {
                TenantInfo t = new TenantInfo();
                t.Name = reader["Name"].ToString();
                t.Email = reader["Email"].ToString();
                t.Id = (int)reader["Id"];
                t.NumberOfPpl = (int)reader["NumberOfPpl"];
                t.Phone = reader["Phone"].ToString();
                tenantInfo.Add(t);
            }
            return tenantInfo;
        }

        [HttpGet]
        public IEnumerable<string> GetTenantsEvictedWithExpiredPermit()
        {
            throw new NotImplementedException();
        }

        // GET api/Permit/Id
        [HttpGet("{ id}")]
        public string Get(int tenantId)
        {
            // Get PermitInfo
            return "not implemented yet";
        }

        // GET api/Permit/Refresh
        [HttpGet]
        public void Get([FromBody]string value)
        {
            // refreshes the permit info table by downloading the csv and importing it to the table
        }
    }
}
