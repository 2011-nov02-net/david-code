using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDb.DataModel
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // dbsets for tables
        public DbSet<Store> Stores { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Order> Orders { get; set; }

        // OnModelCreating Override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Coffee>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.HasCheckConstraint(
                    name: "CK_Coffee_Quantity_Nonnegative",
                    sql: "[Quantity] >= 0");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(o => o.Store)
                    .WithMany(s => s.Orders)
                    .IsRequired();

                entity.Property(o => o.Date).ValueGeneratedOnAdd();
            });
        }
    }
}
