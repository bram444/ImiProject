using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class GenreSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new[]
                {
                    new Genre
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name="FPS",
                        Description="Fist person shooter"
                    },
                    new Genre
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name="Third person shooter",
                        Description="Fist person shooter but in the third person"
                    },
                    new Genre
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name="Simulation"
                    },
                    new Genre
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name="Platformer"
                    },
                    new Genre
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name="Party game"
                    },
                    new Genre
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Name="Story driven"
                    },
                    new Genre
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Name="Open Word"
                    },
                    new Genre
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Name="Nonlinear gameplay"
                    },
                    new Genre
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        Name="Action-adventure"
                    },
                    new Genre
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        Name="Stealth"
                    },
                });
        }
    }
}