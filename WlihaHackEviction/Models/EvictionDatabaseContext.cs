using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WlihaHackEviction.Models
{
    public class EvictionDatabaseContext : DbContext
    {
        public EvictionDatabaseContext(DbContextOptions<EvictionDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<TenantInfo> DBTenantInfo { get; set; }
        public DbSet<AddressInfo> DBAddressInfo{ get; set; }
    }
}
