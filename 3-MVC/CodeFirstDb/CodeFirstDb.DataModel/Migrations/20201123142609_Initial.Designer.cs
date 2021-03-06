﻿// <auto-generated />
using System;
using CodeFirstDb.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeFirstDb.DataModel.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201123142609_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CodeFirstDb.DataModel.Coffee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CountryOfOrgin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGround")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Coffees");

                    b.HasCheckConstraint("CK_Coffee_Quantity_Nonnegative", "[Quantity] >= 0");
                });

            modelBuilder.Entity("CodeFirstDb.DataModel.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CoffeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoffeeId");

                    b.HasIndex("StoreId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CodeFirstDb.DataModel.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("CodeFirstDb.DataModel.Coffee", b =>
                {
                    b.HasOne("CodeFirstDb.DataModel.Store", null)
                        .WithMany("Stock")
                        .HasForeignKey("StoreId");
                });

            modelBuilder.Entity("CodeFirstDb.DataModel.Order", b =>
                {
                    b.HasOne("CodeFirstDb.DataModel.Coffee", "Coffee")
                        .WithMany()
                        .HasForeignKey("CoffeeId");

                    b.HasOne("CodeFirstDb.DataModel.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coffee");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("CodeFirstDb.DataModel.Store", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Stock");
                });
#pragma warning restore 612, 618
        }
    }
}
