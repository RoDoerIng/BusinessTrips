﻿// <auto-generated />
using BusinessTrips.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusinessTrips.WebApp.Migrations
{
    [DbContext(typeof(BusinessTripsContext))]
    [Migration("20191123160443_DataSeeding")]
    partial class DataSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1");

            modelBuilder.Entity("BusinessTrips.Model.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            City = "FooCity",
                            PostCode = "12345",
                            Street = "FooStreet",
                            StreetNumber = "42"
                        },
                        new
                        {
                            AddressId = 2,
                            City = "BarTown",
                            PostCode = "99999",
                            Street = "BarAvenue",
                            StreetNumber = "0"
                        },
                        new
                        {
                            AddressId = 3,
                            City = "BazVillage",
                            PostCode = "00000",
                            Street = "BazWay",
                            StreetNumber = "99"
                        });
                });

            modelBuilder.Entity("BusinessTrips.Model.Name", b =>
                {
                    b.Property<int>("NameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("NameId");

                    b.ToTable("Names");

                    b.HasData(
                        new
                        {
                            NameId = 1,
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            NameId = 2,
                            FirstName = "Jane",
                            LastName = "Doe"
                        },
                        new
                        {
                            NameId = 3,
                            FirstName = "FooBert",
                            LastName = "BazMan"
                        });
                });

            modelBuilder.Entity("BusinessTrips.Model.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NameId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PersonId");

                    b.HasIndex("AddressId");

                    b.HasIndex("NameId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            AddressId = 1,
                            NameId = 1
                        },
                        new
                        {
                            PersonId = 2,
                            AddressId = 2,
                            NameId = 2
                        },
                        new
                        {
                            PersonId = 3,
                            AddressId = 3,
                            NameId = 3
                        });
                });

            modelBuilder.Entity("BusinessTrips.Model.Person", b =>
                {
                    b.HasOne("BusinessTrips.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessTrips.Model.Name", "Name")
                        .WithMany()
                        .HasForeignKey("NameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}