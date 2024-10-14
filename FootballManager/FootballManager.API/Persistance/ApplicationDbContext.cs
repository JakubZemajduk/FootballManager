using FootballManager.API.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.API.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = FootballManagerDb; User = sa; Password = yourStrong(!)Password; Integrated Security = False; Timeout = 30;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team).WithMany(p => p.Players).HasForeignKey(e => e.TeamId);
            modelBuilder.Entity<Player>().Property(e => e.Position).HasConversion<string>();

            modelBuilder.Entity<Transfer>()
                .HasOne(t => t.Player)
                .WithMany(p => p.Transfers)
                .HasForeignKey(t => t.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transfer>()
                .HasOne(t => t.SourceTeam)
                .WithMany(t => t.OutgoingTransfers)
                .HasForeignKey(t => t.SourceTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transfer>()
                .HasOne(t => t.TargetTeam)
                .WithMany(t => t.IncomingTransfers)
                .HasForeignKey(t => t.TargetTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }   
}
