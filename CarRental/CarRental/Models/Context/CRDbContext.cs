using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CarRental.Models.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CarRental.Models.Context
{
    public class CRDbContext : DbContext
    {
        public CRDbContext()
            : base("CarRentalDBContext")
        {
        }

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<RentalInformation> RentalInformation { get; set; }
        public DbSet<DrivingLicense> DrivingLicense { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}