using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace HackOHIO2017.Data
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext(DbContextOptions<BusinessDbContext> options) : base(options)
        {

        }

        

    }
}