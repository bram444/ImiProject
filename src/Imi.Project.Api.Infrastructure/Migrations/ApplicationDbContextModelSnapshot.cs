﻿// <auto-generated />
using System;
using Imi.Project.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Imi.Project.Api.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEditedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            CreatedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(166),
                            LastEditedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(196),
                            Name = "Fallout New Vegas",
                            Price = 14.99f,
                            PublisherId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            CreatedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(200),
                            LastEditedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(202),
                            Name = "Splatoon 3",
                            Price = 59.99f,
                            PublisherId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            CreatedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(204),
                            LastEditedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(206),
                            Name = "Animal Crossing",
                            Price = 59.99f,
                            PublisherId = new Guid("00000000-0000-0000-0000-000000000002")
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.GameGenre", b =>
                {
                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GenreId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GamesGenre");

                    b.HasData(
                        new
                        {
                            GenreId = new Guid("00000000-0000-0000-0000-000000000001"),
                            GameId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            GenreId = new Guid("00000000-0000-0000-0000-000000000002"),
                            GameId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            GenreId = new Guid("00000000-0000-0000-0000-000000000002"),
                            GameId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            GenreId = new Guid("00000000-0000-0000-0000-000000000003"),
                            GameId = new Guid("00000000-0000-0000-0000-000000000003")
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastEditedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            CreatedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(224),
                            Description = "Fist person shooter",
                            LastEditedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(222),
                            Name = "FPS"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            CreatedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(228),
                            Description = "Fist person shooter but in the third person",
                            LastEditedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(227),
                            Name = "Third person shooter"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            CreatedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(232),
                            LastEditedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(231),
                            Name = "Simulation"
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEditedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            Country = "America",
                            CreatedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(245),
                            LastEditedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(247),
                            Name = "Bethesda"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            Country = "Japan",
                            CreatedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(250),
                            LastEditedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(251),
                            Name = "Nintendo"
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastEditedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            CreatedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(282),
                            Email = "FirstUser@gmail.com",
                            FirstName = "First",
                            LastEditedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(280),
                            LastName = "User",
                            UserName = "FirstUser"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            CreatedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(286),
                            Email = "SecondUser@gmail.com",
                            FirstName = "Second",
                            LastEditedOn = new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(285),
                            LastName = "User",
                            UserName = "TimTheDestroyerXx400"
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.UserGame", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("UsersGames");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("00000000-0000-0000-0000-000000000002"),
                            GameId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            UserId = new Guid("00000000-0000-0000-0000-000000000002"),
                            GameId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            UserId = new Guid("00000000-0000-0000-0000-000000000002"),
                            GameId = new Guid("00000000-0000-0000-0000-000000000003")
                        },
                        new
                        {
                            UserId = new Guid("00000000-0000-0000-0000-000000000001"),
                            GameId = new Guid("00000000-0000-0000-0000-000000000003")
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Game", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.Publisher", "Publisher")
                        .WithMany("Games")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.GameGenre", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imi.Project.Api.Core.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.UserGame", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imi.Project.Api.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Publisher", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
