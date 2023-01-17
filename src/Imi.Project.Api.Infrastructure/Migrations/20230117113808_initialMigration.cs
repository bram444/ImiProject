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
                    { new Guid("00000000-0000-0000-0000-000000000001"), "8c73368e-c4ed-414c-adbf-e317b4940a2a", "Admin", "Admin" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "1a5ec313-4557-4a3b-9d45-fb8a7601cb6d", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ApprovedTerms", "BirthDay", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 0, true, new DateTime(2023, 1, 17, 12, 38, 8, 233, DateTimeKind.Local).AddTicks(5565), "03badd3a-80ac-4434-bc1a-a1a0df749183", "FirstUser@gmail.com", true, "First", "User", false, null, "FirstUser@gmail.com", "FirstGuy", "AQAAAAEAACcQAAAAEHDSxQZGHsJWdmaIMQnw2bw38CsWJV5I+vfjUUAcZVqhCbwZXa2U/gUyk7hhPRkjhQ==", null, false, "f852d686-43e9-4164-89db-9f128fdd7f70", false, "FirstGuy" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 0, true, new DateTime(2000, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "32182d0a-da2e-44b9-bb73-64696205194e", "SecondUser@gmail.com", true, "Second", "User", false, null, "SecondUser@gmail.com", "TimTheDestroyerXx400", "AQAAAAEAACcQAAAAEDBQFb7PZh4kAqZ+gnubkMDhNoDpxt6vnJFkHqIRz7g4LZgvG2n/ePFiWxgFVuGttQ==", null, false, "6ce28d56-b3e2-41f9-bf60-3b706fc0eb24", false, "TimTheDestroyerXx400" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "8b7833c8-4af9-4aaf-931d-37b96fd913c7", "ThirdUser@gmail.com", true, "Third", "User", false, null, "ThirdUser@gmail.com", "UserTheThird", "AQAAAAEAACcQAAAAEA/gOc+KiXxoCinq670/K4f4p88ChdmpaPK3TGwtCzpB6SdVvUbc6kmIS6mfssA/NA==", null, false, "37110702-a3ef-4068-818d-e3f294e2d482", false, "UserTheThird" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "f14b343d-fa64-4a67-9c69-e447c5c09d64", "FourthUser@gmail.com", true, "Fourth", "User", false, null, "FourthUser@gmail.com", "UserTheFourth", "AQAAAAEAACcQAAAAEKfbm6HEEfmVuxJcc3Dw08cu2Dh/gIilzxZwI2mBnwxhOd9oHh5m9KKuwdL3o5Of9Q==", null, false, "257de31b-e938-46e8-af5e-61aa66abc988", false, "UserTheFourth" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "7db47a36-2b59-480b-b908-46d83f57a00b", "FifthUser@gmail.com", true, "Fifth", "User", false, null, "FifthUser@gmail.com", "UserTheFifth", "AQAAAAEAACcQAAAAEFqeqvx/oT38CAFYJmiUzmnhlhTmwtO4slZo7ofQjwxmUdSOwLpK5Tkn6XdcFC4a5g==", null, false, "7312e248-96c6-4aad-8958-84ba95164b91", false, "UserTheFifth" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "0154d657-2206-448f-8fc5-a3862052ff2f", "SixUser@gmail.com", true, "Six", "User", false, null, "SixUser@gmail.com", "UserTheSith", "AQAAAAEAACcQAAAAEGguDoWv12UYLrtdq8VUoZ9bBd9ES0JFLDhX9k+NqpAdpBSRepdqRyljZ9yVh8sMWA==", null, false, "075234c2-d785-40d6-97e5-0afa32e4d1e4", false, "UserTheSith" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "14f4f5f2-be8d-451f-ac85-e56983212a8f", "SevenUser@gmail.com", true, "Seven", "User", false, null, "SevenUser@gmail.com", "UserTheSeven", "AQAAAAEAACcQAAAAENGhRTRGlLe/VX6jg/9nyo4k9P4lKl1ZVf3e4nTTfcU3IDMduwSsIIrDpEHciax4Jg==", null, false, "1e9e5640-8d2c-414d-966c-8290b67d331c", false, "UserTheSeven" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c0ddd710-da6c-417b-8c91-0b908da7c540", "EigthUser@gmail.com", true, "Eigth", "User", false, null, "EigthUser@gmail.com", "UserTheEigth", "AQAAAAEAACcQAAAAEJDI8r9uVaM77DR9PNhI4T8kuHBwFlr1+6cRDQTUiLDe0gq5Cv5CAQIbjR1ZT3YiNw==", null, false, "c22272b1-c6c9-4d58-9651-d64e0f5f0e88", false, "UserTheEigth" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "96a13a93-4a27-415b-a984-7696da73cab9", "NinthUser@gmail.com", true, "Ninth", "User", false, null, "NinthUser@gmail.com", "UserTheNinth", "AQAAAAEAACcQAAAAEJcmDPDb/wwkv2DiI4lrGdWOrJNYFH23c+F3pPTdiV7nRmXfFZPcGLzfIVb2TS2Acg==", null, false, "444c0259-ffe9-4c95-af98-a05a8da9b21a", false, "UserTheNinth" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "3d7e77cc-185f-4920-8ad3-58470ed09a55", "XUser@gmail.com", true, "X", "User", false, null, "XUser@gmail.com", "UserX", "AQAAAAEAACcQAAAAEChe+Gpv3coBS4xNeqAg0n8qf5H6uDcsL451TGcURRAteQp/0XahdaQ4u4nGn9DkdA==", null, false, "8360b438-3dcc-46b5-8d28-348a59648616", false, "UserX" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c22fb781-a6f2-42c9-aca8-d8db8e3b7a4c", "admin@imi.be", true, "ad", "min", false, null, "admin@imi.be", "admin", "AQAAAAEAACcQAAAAEJ+umXHMJnSoIn0cw/l/i8Z6FAFLeG2BfPoHGldqXZb47W9u6WXQX/Ww2pEmTkA6tQ==", null, false, "05ad25f2-5208-40d3-ae41-58920f4bb5c7", false, "admin" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "74011e3f-27f5-4e75-b972-a76f56096ae0", "user@imi.be", true, "us", "er", false, null, "user@imi.be", "user", "AQAAAAEAACcQAAAAEF2qkzHGScVY7u8EnhQIIAGoNteazouhHUNdxHBW36m0RYrNDhM+Bk7CqR30s7CKpw==", null, false, "390c0a7d-d1f8-4f26-aa34-9155deea7c38", false, "user" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), 0, false, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "5d186790-4816-400d-b1de-f90375563a5b", "refuser@imi.be", true, "ref", "user", false, null, "refuser@imi.be", "refuser", "AQAAAAEAACcQAAAAENBBzphzf8eehQDER3Y+yVDIKp3wvX07aPF3VLE3j3k7cjCSsCLUjOFJ76cww1YYqQ==", null, false, "6963940f-56b0-4765-8327-3bb5b976035f", false, "refuser" }
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
                    { 1, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "17/01/2023", new Guid("00000000-0000-0000-0000-000000000001") },
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
