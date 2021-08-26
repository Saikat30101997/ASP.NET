using InventorySystem.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Inventory.Contexts
{
    public class InventoryDbContext : DbContext ,IInventoryDbContext
    {

        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InventoryDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  //fluent api
        {
            modelBuilder.Entity<Product>()
                 .HasOne<Stock>(p => p.Stock)
                 .WithOne(s => s.Product)
                 .HasForeignKey<Stock>(s => s.ProductId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }

    }
}
