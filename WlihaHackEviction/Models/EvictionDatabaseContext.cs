using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WlihaHackEviction.Models
{
    public class EvictionDatabaseContext : DbContext
    {
        public EvictionDatabaseContext(
            DbContextOptions<EvictionDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<TenantInfo> DBTenantInfo { get; set; }
        public DbSet<AddressInfo> DBAddressInfo{ get; set; }
        public DbSet<EvictionInfo> DBEvictionInfo { get; set; }
        public DbSet<PreparerInfo> DBPreparerInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenantInfo>().ToTable("TenantsInfo");
            modelBuilder.Entity<AddressInfo>().ToTable("AddressInfo");
            modelBuilder.Entity<EvictionInfo>().ToTable("EvictionInfo");
            modelBuilder.Entity<PreparerInfo>().ToTable("PreparerInfo");
        }
    }
}
