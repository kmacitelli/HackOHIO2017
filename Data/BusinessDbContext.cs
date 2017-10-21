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
        public DbSet<HackOHIO2017.Models.City> City { get; set; }
        public DbSet<HackOHIO2017.Models.Business> Business { get; set; }


    }
}