﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleWebAPI.Models;

namespace SampleWebAPI.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20220724103741_intialSetup")]
    partial class intialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SampleWebAPI.Models.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1L,
                            DateOfBirth = new DateTime(1990, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Suresh.Dhonikena@gmail.com",
                            FirstName = "Suresh",
                            LastName = "Dhonikena",
                            PhoneNumber = "999-888-7777"
                        },
                        new
                        {
                            EmployeeId = 2L,
                            DateOfBirth = new DateTime(1981, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Naresh.Dhonikena@gmail.com",
                            FirstName = "Naresh",
                            LastName = "Dhonikena",
                            PhoneNumber = "111-222-3333"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
