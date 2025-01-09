﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ParkingFlow.WebApi.Persistence.Database;

#nullable disable

namespace ParkingFlow.WebApi.Migrations
{
    [DbContext(typeof(ParkingFlowDbContext))]
    [Migration("20250109035934_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ParkingFlow.WebApi.Domain.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("brand");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("color");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("model");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("ParkingFlow.WebApi.Domain.Vehicles.Vehicle", b =>
                {
                    b.OwnsOne("ParkingFlow.WebApi.Domain.Vehicles.Plate", "Plate", b1 =>
                        {
                            b1.Property<Guid>("VehicleId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("character varying(10)")
                                .HasColumnName("plate");

                            b1.HasKey("VehicleId");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .HasDatabaseName("IX_Vehicle_Plate");

                            b1.ToTable("Vehicles");

                            b1.WithOwner()
                                .HasForeignKey("VehicleId");
                        });

                    b.Navigation("Plate")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}