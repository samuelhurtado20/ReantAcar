using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace WebAPi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .Property(i => i.Price)
                .HasPrecision(18, 4); // Precision: 18, Scale: 4

            modelBuilder.Entity<InvoiceDetail>()
                .Property(i => i.Price)
                .HasPrecision(18, 4); // Precision: 18, Scale: 4

            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Vehicle> Vehicles { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }
    }
}