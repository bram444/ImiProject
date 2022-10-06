using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    PublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesGenre",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesGenre", x => new { x.GenreId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GamesGenre_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersGames",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGames", x => new { x.UserId, x.GameId });
                    table.ForeignKey(
                        name: "FK_UsersGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersGames_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedOn", "Description", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(224), "Fist person shooter", new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(222), "FPS" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(228), "Fist person shooter but in the third person", new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(227), "Third person shooter" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(232), null, new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(231), "Simulation" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Country", "CreatedOn", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "America", new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(245), new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(247), "Bethesda" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Japan", new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(250), new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(251), "Nintendo" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "FirstName", "LastEditedOn", "LastName", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(282), "FirstUser@gmail.com", "First", new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(280), "User", "FirstUser" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(286), "SecondUser@gmail.com", "Second", new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(285), "User", "TimTheDestroyerXx400" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedOn", "LastEditedOn", "Name", "Price", "PublisherId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(166), new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(196), "Fallout New Vegas", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedOn", "LastEditedOn", "Name", "Price", "PublisherId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(200), new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(202), "Splatoon 3", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedOn", "LastEditedOn", "Name", "Price", "PublisherId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(204), new DateTime(2022, 10, 6, 11, 44, 16, 522, DateTimeKind.Local).AddTicks(206), "Animal Crossing", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.InsertData(
                table: "GamesGenre",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003") }
                });

            migrationBuilder.InsertData(
                table: "UsersGames",
                columns: new[] { "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesGenre_GameId",
                table: "GamesGenre",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGames_GameId",
                table: "UsersGames",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamesGenre");

            migrationBuilder.DropTable(
                name: "UsersGames");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
