using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cars.Models
{
    public partial class CarsAndManufacturesContext : DbContext
    {
        public CarsAndManufacturesContext()
        {
        }

        public CarsAndManufacturesContext(DbContextOptions<CarsAndManufacturesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Manufacture> Manufactures { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=TROYSPC;Initial Catalog=CarsAndManufactures; Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Horsepower).HasMaxLength(20);

                entity.Property(e => e.Model).HasMaxLength(20);

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.Property(e => e.Vin)
                    .HasMaxLength(17)
                    .HasColumnName("VIN");

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.MakeId)
                    .HasConstraintName("FK__Cars__MakeId__267ABA7A");
            });

            modelBuilder.Entity<Manufacture>(entity =>
            {
                entity.Property(e => e.Company).HasMaxLength(20);

                entity.Property(e => e.Country).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
