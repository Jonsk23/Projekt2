using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.Models
{
    public class EshopContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<User> UserAccounts { get; set; }
        public DbSet<BusinessAccount> BusinessAccounts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<User>().ToTable("UserAccounts");
            modelBuilder.Entity<BusinessAccount>().ToTable("BusinessAccounts");
            modelBuilder.Entity<Address>().ToTable("Addresses");
        }
    }
}
