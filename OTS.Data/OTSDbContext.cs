using Microsoft.EntityFrameworkCore;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OTS.Data
{
    public class OTSDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.;Database=SipDB;Trusted_Connection=True;");
        //}

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        public OTSDbContext(DbContextOptions<OTSDbContext> options)
            : base(options)
        { }
    }
}
