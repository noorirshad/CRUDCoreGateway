using CRUDCoreGateway.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CRUDCoreGateway.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }
        public virtual DbSet<Client> Clients { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");


                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.CompanyName).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Address).HasMaxLength(100);

            });

        }
    }
}
