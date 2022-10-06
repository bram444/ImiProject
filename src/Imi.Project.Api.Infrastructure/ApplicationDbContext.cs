using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Infrastructure.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using System;

namespace Imi.Project.Api.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserGame> UsersGames { get; set; }

        public DbSet<GameGenre> GamesGenre { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasKey(g => g.Id);
    

            modelBuilder.Entity<Genre>().HasKey(g => g.Id);

            modelBuilder.Entity<Publisher>().HasKey(p => p.Id);

            modelBuilder.Entity<Publisher>().HasMany(p => p.Games)
                .WithOne(g => g.Publisher).HasForeignKey(g => g.PublisherId);

            modelBuilder.Entity<User>().HasKey(p => p.Id);


            modelBuilder.Entity<GameGenre>()
                .HasKey(gg => new { gg.GenreId,gg.GameId});

            modelBuilder.Entity<UserGame>()
                .HasKey(ug => new { ug.UserId, ug.GameId });

            GameGenreSeeder.Seed(modelBuilder);
            GameSeeder.Seed(modelBuilder);
            GenreSeeder.Seed(modelBuilder);
            PublisherSeeder.Seed(modelBuilder);
            UserGameSeeder.Seed(modelBuilder);
            UserSeeder.Seed(modelBuilder);
        }
    }
}
