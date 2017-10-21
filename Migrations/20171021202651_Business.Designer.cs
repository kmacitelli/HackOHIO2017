﻿// <auto-generated />
using HackOHIO2017.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HackOHIO.Migrations
{
    [DbContext(typeof(BusinessDbContext))]
    [Migration("20171021202651_Business")]
    partial class Business
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("HackOHIO2017.Models.Business", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.Property<int>("Zip");

                    b.HasKey("Id");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("HackOHIO2017.Models.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
