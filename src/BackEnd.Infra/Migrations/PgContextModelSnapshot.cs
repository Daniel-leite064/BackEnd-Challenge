﻿// <auto-generated />
using System;
using BackEnd.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackEnd.Infra.Migrations
{
    [DbContext(typeof(PgContext))]
    partial class PgContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("challengedb")
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BackEnd.Domain.Entities.Couriers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("date");

                    b.Property<Guid?>("IdRental")
                        .HasColumnType("uuid");

                    b.Property<string>("LicenseDriverNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("LicenseDriverType")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.HasIndex("IdRental");

                    b.HasIndex("LicenseDriverNumber")
                        .IsUnique();

                    b.ToTable("Couriers", "challengedb");
                });

            modelBuilder.Entity("BackEnd.Domain.Entities.Motorcycle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("IdRental")
                        .HasColumnType("uuid");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool?>("Status")
                        .HasColumnType("boolean");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdRental");

                    b.HasIndex("LicensePlate")
                        .IsUnique();

                    b.ToTable("Motorcycle", "challengedb");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c4e4612c-e118-4a8c-a1ad-792a1a01065e"),
                            LicensePlate = "JTY-1906",
                            Model = "CB 300F Twister",
                            Status = true,
                            Year = 2022
                        },
                        new
                        {
                            Id = new Guid("c30c3216-1ced-45fc-8faf-b4303d81ac80"),
                            LicensePlate = "MNF-3564",
                            Model = "CB 500F",
                            Status = true,
                            Year = 2015
                        },
                        new
                        {
                            Id = new Guid("48851998-0452-45ab-b394-75aa4f27f35d"),
                            LicensePlate = "KKH-9067",
                            Model = "Forza 350",
                            Status = true,
                            Year = 2022
                        });
                });

            modelBuilder.Entity("BackEnd.Domain.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateNotification")
                        .HasColumnType("date");

                    b.Property<Guid>("IdCourier")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdOrder")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Notification", "challengedb");
                });

            modelBuilder.Entity("BackEnd.Domain.Entities.Orders", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date");

                    b.Property<Guid>("IdCourier")
                        .HasColumnType("uuid");

                    b.Property<decimal>("RideCost")
                        .HasColumnType("numeric");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Orders", "challengedb");
                });

            modelBuilder.Entity("BackEnd.Domain.Entities.Rental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("ExpectedEndDate")
                        .HasColumnType("date");

                    b.Property<Guid?>("IdCourier")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("IdMotorcycle")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("IdRentalPlans")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("RentalPlanId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("RentalPlanId");

                    b.ToTable("Rental", "challengedb");
                });

            modelBuilder.Entity("BackEnd.Domain.Entities.RentalPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("CostPerDay")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Plan")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Plan")
                        .IsUnique();

                    b.ToTable("Rental_Plan", "challengedb");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ac843545-072b-43a1-86b5-0bd92a4d43a9"),
                            CostPerDay = 30m,
                            Description = "7 days",
                            Plan = 1
                        },
                        new
                        {
                            Id = new Guid("bfd1ecee-951f-4caa-83ff-4388f4faa811"),
                            CostPerDay = 28m,
                            Description = "15 days",
                            Plan = 2
                        },
                        new
                        {
                            Id = new Guid("83c363dc-3a02-44bd-b9f6-b081258dac72"),
                            CostPerDay = 22m,
                            Description = "30 days",
                            Plan = 3
                        });
                });

            modelBuilder.Entity("BackEnd.Domain.Entities.Couriers", b =>
                {
                    b.HasOne("BackEnd.Domain.Entities.Rental", "Rental")
                        .WithMany("Couriers")
                        .HasForeignKey("IdRental")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("BackEnd.Domain.Entities.Motorcycle", b =>
                {
                    b.HasOne("BackEnd.Domain.Entities.Rental", "Rental")
                        .WithMany("Motorcycles")
                        .HasForeignKey("IdRental")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("BackEnd.Domain.Entities.Rental", b =>
                {
                    b.HasOne("BackEnd.Domain.Entities.RentalPlan", "RentalPlan")
                        .WithMany()
                        .HasForeignKey("RentalPlanId");

                    b.Navigation("RentalPlan");
                });

            modelBuilder.Entity("BackEnd.Domain.Entities.Rental", b =>
                {
                    b.Navigation("Couriers");

                    b.Navigation("Motorcycles");
                });
#pragma warning restore 612, 618
        }
    }
}
