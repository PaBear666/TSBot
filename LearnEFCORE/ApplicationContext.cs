using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.IdentityModel.Protocols;

namespace LearnEFCORE
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LearnEFCORE;Trusted_Connection=True;");
        }
    }
}
