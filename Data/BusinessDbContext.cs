using HackOHIO2017.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace HackOHIO2017.Data
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext(DbContextOptions options) : base(options)
        {

        }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       

 modelBuilder.Entity<InvestorCategory>()
        .HasKey(bc => new { bc.InvestorId, bc.CategoryId });

    modelBuilder.Entity<InvestorCategory>()
        .HasOne(bc => bc.Investor)
        .WithMany(b => b.InvestorCategories)
        .HasForeignKey(bc => bc.InvestorId);

    modelBuilder.Entity<InvestorCategory>()
        .HasOne(bc => bc.Category)
        .WithMany(c => c.InvestorCategories)
        .HasForeignKey(bc => bc.CategoryId);


        base.OnModelCreating(modelBuilder);
    }


        public DbSet<City> City { get; set; }
        public DbSet<Business> Business { get; set; }
        public DbSet<Investor> Investor { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<InvestorCategory> InvestorCategories { get; set; }
    }
}