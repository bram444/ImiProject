using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class GameGenreSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameGenre>().HasData(
                new[]
                {
                     new GameGenre
                     {
                          GameId=Guid.Parse("00000000-0000-0000-0000-000000000001"),
                          GenreId=Guid.Parse("00000000-0000-0000-0000-000000000001")
                     },
                     new GameGenre
                     {
                          GameId=Guid.Parse("00000000-0000-0000-0000-000000000001"),
                          GenreId=Guid.Parse("00000000-0000-0000-0000-000000000002")
                     },
                     new GameGenre
                     {
                          GameId=Guid.Parse("00000000-0000-0000-0000-000000000002"),
                          GenreId=Guid.Parse("00000000-0000-0000-0000-000000000002")
                     },
                     new GameGenre
                     {
                          GameId=Guid.Parse("00000000-0000-0000-0000-000000000003"),
                          GenreId=Guid.Parse("00000000-0000-0000-0000-000000000003")
                     },
                }
                );
        }
    }
}
