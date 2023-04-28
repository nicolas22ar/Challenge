﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechnicalExercise.Core.Data;

#nullable disable

namespace TechnicalExercise.Core.Data.Migrations
{
    [DbContext(typeof(TestDataContext))]
    [Migration("20230428024416_TestInitial")]
    partial class TestInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechnicalExercise.Core.Domain.Plate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.HasKey("Id");

                    b.ToTable("Plates");

                    b.HasData(
                        new
                        {
                            Id = new Guid("47e1940b-1ede-4f17-af18-4c01547c718a"),
                            Date = new DateTime(2023, 4, 27, 23, 44, 16, 864, DateTimeKind.Local).AddTicks(4767),
                            Value = "LSK658"
                        },
                        new
                        {
                            Id = new Guid("f8d2692d-3f0f-4d9a-9576-31aa1bf21db8"),
                            Date = new DateTime(2023, 4, 28, 23, 44, 16, 864, DateTimeKind.Local).AddTicks(4767),
                            Value = "KSI695"
                        },
                        new
                        {
                            Id = new Guid("b4040714-aff6-4e9a-98b2-e769f69e74a7"),
                            Date = new DateTime(2023, 4, 29, 23, 44, 16, 864, DateTimeKind.Local).AddTicks(4767),
                            Value = "USJ726"
                        },
                        new
                        {
                            Id = new Guid("424afb80-5e12-4d4c-bb39-2d95e1bec5a4"),
                            Date = new DateTime(2023, 4, 30, 23, 44, 16, 864, DateTimeKind.Local).AddTicks(4767),
                            Value = "IEK659"
                        },
                        new
                        {
                            Id = new Guid("a27df079-c351-4fb8-b5e4-9802d6030ea8"),
                            Date = new DateTime(2023, 5, 1, 23, 44, 16, 864, DateTimeKind.Local).AddTicks(4767),
                            Value = "KSI654"
                        });
                });

            modelBuilder.Entity("TechnicalExercise.Core.Domain.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PlateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("PlateId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0bd43b70-3ba3-41b5-a40c-80b0190fb5be"),
                            Color = "RED",
                            CreationDate = new DateTime(2023, 4, 27, 23, 44, 16, 864, DateTimeKind.Local).AddTicks(4767),
                            PlateId = new Guid("47e1940b-1ede-4f17-af18-4c01547c718a"),
                            Type = "CAR"
                        });
                });

            modelBuilder.Entity("TechnicalExercise.Core.Domain.Vehicle", b =>
                {
                    b.HasOne("TechnicalExercise.Core.Domain.Plate", "Plate")
                        .WithMany()
                        .HasForeignKey("PlateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plate");
                });
#pragma warning restore 612, 618
        }
    }
}