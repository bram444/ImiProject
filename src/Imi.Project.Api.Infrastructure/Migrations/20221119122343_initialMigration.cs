using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_UsersGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 0, "c8554266-b401-4519-9aeb-a9283053fc58", "FirstUser@gmail.com", true, "First", "User", false, null, "FIRSTUSER@GMAIL.COM", "FIRSTGUY", "AQAAAAIAAYagAAAAEF9LWVyNjgdTRKLpa41oZT1u6mXsWcehL/9FobM6ObUeb6hUQOdkF8DP6HxUMm2JoQ==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA", false, "FirstGuy" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 0, "c8554266-b401-4519-9aeb-a9283053fc59", "SecondUser@gmail.com", true, "Second", "User", false, null, "SECONDUSER@GMAIL.COM", "TIMTHEDESTROYERXX400", "AQAAAAIAAYagAAAAEHoT7ddMX2eP08ADT/qVyH07gpiAGdqtAQsOd9sSAXgyXynsRlZC3NkZtsD5vUyAdg==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINB", false, "TimTheDestroyerXx400" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 0, "c8554266-b401-4519-9aeb-a9283053fc50", "ThirdUser@gmail.com", true, "Third", "User", false, null, "THIRDUSER@GMAIL.COM", "USERTHETHIRD", "AQAAAAIAAYagAAAAEFqgsfkTPGH3IFiY/YxfH2DJD2OUE1oTHKBvBnoVL+16ctamZDkziJB7QqqkUto7mA==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINC", false, "UserTheThird" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 0, "c8554266-b401-4519-9aeb-a9283053fc51", "FourthUser@gmail.com", true, "Fourth", "User", false, null, "FOURTHUSER@GMAIL.COM", "USERTHEFOURTH", "AQAAAAIAAYagAAAAEHIgACn99gbqn1oJJY0RA2qH7YiAJ8t5ykpj4hwJpZv9akUwi4kO/oue4fBfztBGOw==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZIND", false, "UserTheFourth" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 0, "c8554266-b401-4519-9aeb-a9283053fc52", "FifthUser@gmail.com", true, "Fifth", "User", false, null, "FIFTHUSER@GMAIL.COM", "USERTHEFIFTH", "AQAAAAIAAYagAAAAEJzIMZ7+PuwJH4n/HlS64NtVeLM9mIamY6rY7266LFtJW+cVQtUtG89uAKy4bYMrrg==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINE", false, "UserTheFifth" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 0, "c8554266-b401-4519-9aeb-a9283053fc53", "SixUser@gmail.com", true, "Six", "User", false, null, "SIXUSER@GMAIL.COM", "USERTHESITH", "AQAAAAIAAYagAAAAEO/C3unPrVxnl+DTmh6n5oydfKPLcYoerdUAdO7cXeZhBD8Sibwd67na9SnqajNRwg==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINF", false, "UserTheSith" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 0, "c8554266-b401-4519-9aeb-a9283053fc54", "SevenUser@gmail.com", true, "Seven", "User", false, null, "SEVENUSER@GMAIL.COM", "USERTHESEVEN", "AQAAAAIAAYagAAAAEJH50qqVl6NZYAv2cJ+PFwLD3HULOA8V1nKJI4c8mGf2w9ILDa2X2+XKI6Mk4miEXA==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZING", false, "UserTheSeven" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 0, "c8554266-b401-4519-9aeb-a9283053fc55", "EigthUser@gmail.com", true, "Eigth", "User", false, null, "EIGTHUSER@GMAIL.COM", "USERTHEEIGTH", "AQAAAAIAAYagAAAAEND4S6e2/NKM/sbHfEC+ici/d96Z7JTlm5iC0aT4rom0Jtvpn+Krbpyb7X/3cixsgA==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINH", false, "UserTheEigth" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 0, "c8554266-b401-4519-9aeb-a9283053fc56", "NinthUser@gmail.com", true, "Ninth", "User", false, null, "NINTHUSER@GMAIL.COM", "USERTHENINTH", "AQAAAAIAAYagAAAAEOPHrSulki2OJwjyX1oxaWskM5dedzZpBloc34o/q1zjW1oeksqZDMZTbynz84FWaA==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINI", false, "UserTheNinth" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), 0, "c8554266-b401-4519-9aeb-a9283053fc57", "XUser@gmail.com", true, "X", "User", false, null, "XUSER@GMAIL.COM", "USERX", "AQAAAAIAAYagAAAAEMTsksRucBFWuoyn58/X/ZLZ2AoLPSm7zg8EdnxodIPb1+iv+brksgXkBaQD9htbmQ==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINJ", false, "UserX" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedOn", "Description", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1657), "Fist person shooter", new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1654), "FPS" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1661), "Fist person shooter but in the third person", new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1659), "Third person shooter" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1665), null, new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1663), "Simulation" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1671), null, new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1670), "Platformer" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1677), null, new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1674), "Party game" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1704), null, new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1702), "Story driven" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1708), null, new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1706), "Open Word" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1712), null, new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1710), "Nonlinear gameplay" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1715), null, new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1714), "Action-adventure" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1719), null, new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1718), "Stealth" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Country", "CreatedOn", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "America", new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1743), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1746), "Bethesda" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Japan", new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1748), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1750), "Nintendo" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "America", new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1752), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1754), "Ubisoft" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Japan", new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1756), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1758), "Square inex" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "America", new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1760), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1762), "Sony" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "America", new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1764), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1765), "Microsoft" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Japan", new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1768), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1769), "The pokemon company" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Sweden", new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1772), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1773), "CD project" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Japan", new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1775), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1777), "Arc System Works" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "America", new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1779), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1781), "Interplay Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005") }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedOn", "LastEditedOn", "Name", "Price", "PublisherId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1459), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1495), "Fallout New Vegas", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1499), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1501), "Splatoon 3", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1504), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1505), "Animal Crossing", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1513), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1515), "Fallout 3", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1534), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1536), "Fallout 4", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1545), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1547), "Splatoon 2", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1550), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1551), "Splatoon", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1594), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1620), "Rabbits", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1623), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1625), "Rayman", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1628), new DateTime(2022, 11, 19, 13, 23, 42, 309, DateTimeKind.Local).AddTicks(1629), "Assassins creed", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") }
                });

            migrationBuilder.InsertData(
                table: "GamesGenre",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000010") }
                });

            migrationBuilder.InsertData(
                table: "UsersGames",
                columns: new[] { "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000009") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GamesGenre");

            migrationBuilder.DropTable(
                name: "UsersGames");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
