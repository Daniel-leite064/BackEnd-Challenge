﻿// <auto-generated />
using System;
using BackEnd.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackEnd.Infra.Migrations
{
    [DbContext(typeof(PgContext))]
    [Migration("20240330232010_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("328c241a-8d0b-44ba-828d-1a242e47c434"),
                            LicensePlate = "JTY-1906",
                            Model = "CB 300F Twister",
                            Year = 2022
                        },
                        new
                        {
                            Id = new Guid("43ff68cc-79cc-4bd0-b191-5528741098f9"),
                            LicensePlate = "MNF-3564",
                            Model = "CB 500F",
                            Year = 2015
                        },
                        new
                        {
                            Id = new Guid("ca0c47f2-a0e0-42c8-8eb9-800fb834832f"),
                            LicensePlate = "KKH-9067",
                            Model = "Forza 350",
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
