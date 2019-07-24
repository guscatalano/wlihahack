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
    [Route("api/permit")]
    public class PermitController : Controller
    {
        private SqlConnection connection;
        public PermitController()
        {
            this.connection = new SqlConnection(new SqlConnectionStringBuilder()
            {
                DataSource = "ijfods31344.database.windows.net",
                InitialCatalog = "wliha",
                UserID = "wliha",
                Password = "***REMOVED***",
                MultipleActiveResultSets = true
            }.ConnectionString);
        }

        // GET: api/Permit
        [HttpGet]
        [Route("api/permit/tenantsevictedwithoutpermit/")]
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
        [Route("api/permit/tenantsevictedwithpermit/")]
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

        // GET api/Permit/address
        [HttpGet("{address}")]
        [Route("api/permit/{address}/")]
        public List<PermitInfo> GetPermitInfoForAddress(string address)
        {
            string query = @"
            SELECT *
            FROM [dbo].[PermitInfo]
            LEFT JOIN [dbo].[AddressInfo]
            ON ((LOWER([dbo].[PermitInfo].[OriginalAddress1]) = LOWER([dbo].[AddressInfo].[StreetAddress])
                 and ([dbo].[AddressInfo].[ZipCode] = [dbo].[PermitInfo].[OriginalZip])))
            WHERE
            EXISTS
                (SELECT[dbo].[AddressInfo].[StreetAddress]
                FROM [dbo].[AddressInfo]
                    LEFT JOIN [dbo].[EvictionInfo]
                    ON (LOWER([dbo].[EvictionInfo].[AddressId]) = LOWER([dbo].[AddressInfo].[Id])))";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<PermitInfo> permitInfo = new List<PermitInfo>();

            while (reader.Read())
            {
                PermitInfo p = new PermitInfo();
                
                permitInfo.Add(p);
            }
            return permitInfo;
        }

        // GET api/PermitLinks/address
        [HttpGet("{address}")]
        [Route("api/permitlinks/{address}/")]
        public List<string> GetPermitLinksForAddress(string address)
        {
            List<PermitInfo> permits = GetPermitInfoForAddress(address);
            
            //TODO: sort permits first

            List<string> links = new List<string>();

            foreach(PermitInfo p in permits){
                links.Add(p.Link);
            }
            return links;
        }
    }
}
