using FootballManager.API.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.API.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = FootballManagerDb; User = sa; Password = yourStrong(!)Password; Integrated Security = False; Timeout = 30;");
        }
    }
}
