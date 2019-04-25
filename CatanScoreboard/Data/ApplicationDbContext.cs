using System;
using System.Collections.Generic;
using System.Text;
using CatanScoreboard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatanScoreboard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerScore>()
                .HasOne(i => i.FinishedGame)
                .WithMany(c => c.PlayerScores)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<FinishedGame> FinishedGames { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerScore> PlayerScores { get; set; }
    }
}
