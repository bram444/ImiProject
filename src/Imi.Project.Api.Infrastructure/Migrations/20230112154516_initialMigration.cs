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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedTerms = table.Column<bool>(type: "bit", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
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
                    Price = table.Column<float>(type: "real", nullable: false),
                    PublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "a42df2f0-283d-4ea7-89b2-9fb26b26207a", "Admin", "Admin" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "d29ce038-5e43-428f-ade2-69822ff3d045", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ApprovedTerms", "BirthDay", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 0, true, new DateTime(2023, 1, 12, 16, 45, 15, 706, DateTimeKind.Local).AddTicks(240), "9b079be3-a76a-424b-b623-f8569803b9c9", "FirstUser@gmail.com", true, "First", "User", false, null, "FirstUser@gmail.com", "FirstGuy", "AQAAAAEAACcQAAAAEPlj62M7z88QEsBt2lMXAmNUVMZcxsk2diiBNshkS+J3ktWqWIxnrcJwahodQbS9Zw==", null, false, "375cfc97-2196-42a8-9ae6-b72e693690ae", false, "FirstGuy" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 0, true, new DateTime(2000, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "7a0bda3a-f0bb-4c4d-b4a4-fc9533e9d294", "SecondUser@gmail.com", true, "Second", "User", false, null, "SecondUser@gmail.com", "TimTheDestroyerXx400", "AQAAAAEAACcQAAAAEJKYLHoGP1WsCMel3/OV9t6aURughdZ8H9W5VbXjenbPYDNhEy08xaz7EjbhrZmshw==", null, false, "37c88383-73c0-453f-a9f5-74f0727c1087", false, "TimTheDestroyerXx400" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "3dc66ad3-cc5b-483f-b957-59cbb1dfaa12", "ThirdUser@gmail.com", true, "Third", "User", false, null, "ThirdUser@gmail.com", "UserTheThird", "AQAAAAEAACcQAAAAEPYbayP1m1yWGCeyNAUGHx839S3XWLek4yhZjw57v/U8DDnYrF5PRsMA6K4j0QF8Ug==", null, false, "30c24e87-2662-4cd3-98c1-5e714cf9de93", false, "UserTheThird" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "8688fc12-4905-4e1d-8aa4-d58e9188601e", "FourthUser@gmail.com", true, "Fourth", "User", false, null, "FourthUser@gmail.com", "UserTheFourth", "AQAAAAEAACcQAAAAED11wD/LkBTlDH0l7DRQCJDnxZVhujSwObWfo13noB1SDoTjGxBzL2KixhDltCwnVw==", null, false, "7948acbd-997b-4c8d-a7e6-790951ec0700", false, "UserTheFourth" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "80b96a62-8410-46d0-b395-a988c090bb2c", "FifthUser@gmail.com", true, "Fifth", "User", false, null, "FifthUser@gmail.com", "UserTheFifth", "AQAAAAEAACcQAAAAEPVpCLtj0vtacBWB0y1ho1Y+PhYmyewCDGw5tcZOUsGosJG0itK2x4bhlyAFhJ+D4Q==", null, false, "0b146fc2-77a2-4327-a019-62ef57d889f3", false, "UserTheFifth" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "20cb60ed-b490-4825-b2f4-c3d4996a6d35", "SixUser@gmail.com", true, "Six", "User", false, null, "SixUser@gmail.com", "UserTheSith", "AQAAAAEAACcQAAAAEP+F6xDuAygBa70UeiCPQHoAKO6oxSrNUKncSgqj1UBlQRO8kPIMRybUv0FN2eHAjg==", null, false, "a159573c-0c25-4639-a163-3540a1c1d026", false, "UserTheSith" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "22936fd6-00a0-41ba-89a1-a779ace837c6", "SevenUser@gmail.com", true, "Seven", "User", false, null, "SevenUser@gmail.com", "UserTheSeven", "AQAAAAEAACcQAAAAEOz3HUsGbU8Aywbsi7YFlbN3iB+xBEX0KxMKRK0OyCGcj39vON40cNKbn+YYHYu+8A==", null, false, "0a162951-c3d5-4e25-8ef0-80d2e3ad250a", false, "UserTheSeven" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "54608937-0153-4658-8528-c2ccfd380839", "EigthUser@gmail.com", true, "Eigth", "User", false, null, "EigthUser@gmail.com", "UserTheEigth", "AQAAAAEAACcQAAAAEMCXJeHDesfnyvhr4y7hALgRogOEaV5sb2wH01ytnqUk+rViuXuohVkomuSj0LE67w==", null, false, "565cf2dd-ac0b-4151-91d4-70e3642941db", false, "UserTheEigth" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "cdf6cc0f-9ff5-4d33-b05d-f66a4a6969b0", "NinthUser@gmail.com", true, "Ninth", "User", false, null, "NinthUser@gmail.com", "UserTheNinth", "AQAAAAEAACcQAAAAEALzKkGE4j4LE7sdYOWNzbQdQJk5XTk1qiYGoSBPv6F5bZ+Bov7Swc7XzSiYvBjvzQ==", null, false, "91309b8c-54be-4572-b79d-87100ed19e30", false, "UserTheNinth" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "2708897e-c46b-48e9-bb1d-88426b2b46e5", "XUser@gmail.com", true, "X", "User", false, null, "XUser@gmail.com", "UserX", "AQAAAAEAACcQAAAAELI5A0+NvUYqrfiag3UZMh2xvK9jW8KNsZ3gaPMeOWkKFxWGZB9cpOHHI0QtfaVo0Q==", null, false, "b5aaaa42-d6a5-4f31-9411-fedc1dc8c51c", false, "UserX" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "a2021090-1737-4693-8c08-f173e540ebaa", "admin@imi.be", true, "ad", "min", false, null, "admin@imi.be", "admin", "AQAAAAEAACcQAAAAEBe1TdBLpgRA9vgPRhYikPAt4ZPH92AcwJp9vqMCYMr1IZkOyhCrGQXO/glgw3/bBg==", null, false, "9d8a609e-b141-4afa-a99f-1374c26bf807", false, "admin" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "039e9f25-1a71-4980-a40c-142b914d384e", "user@imi.be", true, "us", "er", false, null, "user@imi.be", "user", "AQAAAAEAACcQAAAAEAl1tVxWxXkQe/zJkdsyVZCsfw9zbXFDKyefo6C5p4PSTKc0mJYWuL8rgMv3zj3HuA==", null, false, "6459704b-a7b3-4c93-8731-d669b3833672", false, "user" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), 0, false, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "039c9b51-0319-4822-83df-aec66178eb4f", "refuser@imi.be", true, "ref", "user", false, null, "refuser@imi.be", "refuser", "AQAAAAEAACcQAAAAEMxAcCgQqj7c52/h/dFaccL1mgLty4fY+dA8RBjH1j0QXng3ITYSOigcm15zF7Xm6g==", null, false, "57c0e518-8af8-469e-a707-af3f5466b5e4", false, "refuser" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Fist person shooter", "FPS" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Fist person shooter but in the third person", "Third person shooter" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), null, "Simulation" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), null, "Platformer" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), null, "Party game" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), null, "Story driven" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), null, "Open Word" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), null, "Nonlinear gameplay" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), null, "Action-adventure" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), null, "Stealth" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "America", "Bethesda" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Japan", "Nintendo" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "America", "Ubisoft" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Japan", "Square inex" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "America", "Sony" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "America", "Microsoft" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Japan", "The pokemon company" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Sweden", "CD project" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Japan", "Arc System Works" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "America", "Interplay Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "12/01/2023", new Guid("00000000-0000-0000-0000-000000000001") },
                    { 2, "approved", "True", new Guid("00000000-0000-0000-0000-000000000001") },
                    { 3, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "19/08/2000", new Guid("00000000-0000-0000-0000-000000000002") },
                    { 4, "approved", "True", new Guid("00000000-0000-0000-0000-000000000002") },
                    { 5, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "19/08/2010", new Guid("00000000-0000-0000-0000-000000000003") },
                    { 6, "approved", "True", new Guid("00000000-0000-0000-0000-000000000003") },
                    { 7, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "19/08/2010", new Guid("00000000-0000-0000-0000-000000000004") },
                    { 8, "approved", "True", new Guid("00000000-0000-0000-0000-000000000004") },
                    { 9, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "19/08/2010", new Guid("00000000-0000-0000-0000-000000000005") },
                    { 10, "approved", "True", new Guid("00000000-0000-0000-0000-000000000005") },
                    { 11, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "19/08/2010", new Guid("00000000-0000-0000-0000-000000000006") },
                    { 12, "approved", "True", new Guid("00000000-0000-0000-0000-000000000006") },
                    { 13, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "19/08/2010", new Guid("00000000-0000-0000-0000-000000000007") },
                    { 14, "approved", "True", new Guid("00000000-0000-0000-0000-000000000007") },
                    { 15, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "19/08/2010", new Guid("00000000-0000-0000-0000-000000000008") },
                    { 16, "approved", "True", new Guid("00000000-0000-0000-0000-000000000008") },
                    { 17, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "19/08/2010", new Guid("00000000-0000-0000-0000-000000000009") },
                    { 18, "approved", "True", new Guid("00000000-0000-0000-0000-000000000009") },
                    { 19, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "19/08/2010", new Guid("00000000-0000-0000-0000-000000000010") },
                    { 20, "approved", "True", new Guid("00000000-0000-0000-0000-000000000010") },
                    { 21, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "19/08/2010", new Guid("00000000-0000-0000-0000-000000000011") },
                    { 22, "approved", "True", new Guid("00000000-0000-0000-0000-000000000011") },
                    { 23, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "19/08/2010", new Guid("00000000-0000-0000-0000-000000000012") },
                    { 24, "approved", "True", new Guid("00000000-0000-0000-0000-000000000012") },
                    { 25, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "19/08/2010", new Guid("00000000-0000-0000-0000-000000000013") },
                    { 26, "approved", "True", new Guid("00000000-0000-0000-0000-000000000013") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000013") }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "Price", "PublisherId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Fallout New Vegas", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Splatoon 3", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Animal Crossing", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "Price", "PublisherId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Fallout 3", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Fallout 4", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Splatoon 2", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Splatoon", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Rabbits", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Rayman", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Assassins creed", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") }
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
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Name",
                table: "Games",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesGenre_GameId",
                table: "GamesGenre",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_Name",
                table: "Publishers",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

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
