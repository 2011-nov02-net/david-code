using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.DataModel.Model
{
    public class AppDbContext : DbContext
    {
        // constructors

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        // dbsets for my tables
        //  (if there's some dbset you won't use directly you can leave it out here)

        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }

        // onModelcreating override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(80);

                entity.HasCheckConstraint(name: "CK_Location_Stock_Nonnegative", sql: "[Stock] >= 0");
            });

            modelBuilder.Entity<Order>(entity => {
                entity.HasOne(o => o.Location)
                    .WithMany(l => l.Orders)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
        }
    }
}
