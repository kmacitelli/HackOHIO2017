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
    partial class BusinessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid>("CategoryId");

                    b.Property<Guid>("CityId");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Site");

                    b.Property<string>("State");

                    b.Property<int>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CityId");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("HackOHIO2017.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
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

            modelBuilder.Entity("HackOHIO2017.Models.Investor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<Guid>("CityId");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Site");

                    b.Property<int>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Investors");
                });

            modelBuilder.Entity("HackOHIO2017.Models.InvestorCategory", b =>
                {
                    b.Property<Guid>("InvestorId");

                    b.Property<Guid>("CategoryId");

                    b.HasKey("InvestorId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("InvestorCategories");
                });

            modelBuilder.Entity("HackOHIO2017.Models.Business", b =>
                {
                    b.HasOne("HackOHIO2017.Models.Category", "Category")
                        .WithMany("Businesses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HackOHIO2017.Models.City", "City")
                        .WithMany("Businesses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HackOHIO2017.Models.Investor", b =>
                {
                    b.HasOne("HackOHIO2017.Models.City", "City")
                        .WithMany("Investors")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HackOHIO2017.Models.InvestorCategory", b =>
                {
                    b.HasOne("HackOHIO2017.Models.Category", "Category")
                        .WithMany("InvestorCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HackOHIO2017.Models.Investor", "Investor")
                        .WithMany("InvestorCategories")
                        .HasForeignKey("InvestorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
