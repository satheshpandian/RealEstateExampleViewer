using RealEstateExampleViewer.Models;
using System.Data.Entity;
using RealEstateExampleViewer.Models.Views;

namespace RealEstateExampleViewer.Repository
{
    public class DataContext : DbContext
    {
        public DataContext() : base("RealEstateExampleEntities")
        {
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Suite> Suites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ignore a type that is not mapped to a database table
            modelBuilder.Ignore<ViewBuilding>();
        }
    }
}
