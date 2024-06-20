﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using miniZeiterfassung.Data;

#nullable disable

namespace miniZeiterfassung.Migrations
{
    [DbContext(typeof(TimeRecordingContext))]
    [Migration("20240620080428_addcolumn_EmployeeNumber")]
    partial class addcolumn_EmployeeNumber
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("miniZeiterfassung.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("StartingBalance")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("TimeModelId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("TimeModelId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("miniZeiterfassung.Models.Record", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecordId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("FromTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("ToTime")
                        .HasColumnType("time");

                    b.HasKey("RecordId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("miniZeiterfassung.Models.TimeModel", b =>
                {
                    b.Property<int>("TimeModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeModelId"));

                    b.Property<TimeSpan?>("FromBreak")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("FromTime")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("TargetHours")
                        .HasColumnType("float");

                    b.Property<int>("TimeModelNumber")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("ToBreak")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("ToTime")
                        .HasColumnType("time");

                    b.HasKey("TimeModelId");

                    b.ToTable("TimeModels");
                });

            modelBuilder.Entity("miniZeiterfassung.Models.Employee", b =>
                {
                    b.HasOne("miniZeiterfassung.Models.TimeModel", "TimeModel")
                        .WithMany("Employees")
                        .HasForeignKey("TimeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TimeModel");
                });

            modelBuilder.Entity("miniZeiterfassung.Models.Record", b =>
                {
                    b.HasOne("miniZeiterfassung.Models.Employee", "Employee")
                        .WithMany("Records")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("miniZeiterfassung.Models.Employee", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("miniZeiterfassung.Models.TimeModel", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
