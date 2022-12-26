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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "c3c180c0-eb21-412f-a11f-89899a45da8d", "Admin", "ADMIN" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "9d4a51f8-69bd-468e-873f-13b5c81c6fec", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ApprovedTerms", "BirthDay", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 0, true, new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9668), "c8554266-b401-4519-9aeb-a9283053fc58", "FirstUser@gmail.com", true, "First", "User", false, null, "FirstUser@gmail.com", "FirstGuy", "AQAAAAEAACcQAAAAEC90TLDtl3eCgnJgaou2P5jTxGtGoIoQPv5K9Sb1KEZAp9VwDm6ZaqEIxSDsPXTn7g==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA", false, "FirstGuy" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 0, true, new DateTime(2000, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc59", "SecondUser@gmail.com", true, "Second", "User", false, null, "SecondUser@gmail.com", "TimTheDestroyerXx400", "AQAAAAEAACcQAAAAEIZPhVq9dmAGx645jaOvZ2TYfOv9iWBI7d33Rc91qorKFPBij0weSINTSgQ8PGBB7A==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINB", false, "TimTheDestroyerXx400" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc50", "ThirdUser@gmail.com", true, "Third", "User", false, null, "ThirdUser@gmail.com", "UserTheThird", "AQAAAAEAACcQAAAAECita1s45Jm1LABsxvz0j0OygvoFiAHVq1jGRmMY0LDqCSlnmVjEZduLC5XIh80UeQ==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINC", false, "UserTheThird" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc51", "FourthUser@gmail.com", true, "Fourth", "User", false, null, "FourthUser@gmail.com", "UserTheFourth", "AQAAAAEAACcQAAAAELxni8sHbqvP88m6YH9cWgi1pIA1rB+pPJitekvDPv6/l/1HwzY+65MhxEyxEo2esQ==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZIND", false, "UserTheFourth" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc52", "FifthUser@gmail.com", true, "Fifth", "User", false, null, "FifthUser@gmail.com", "UserTheFifth", "AQAAAAEAACcQAAAAEIoHcLEtKqrpusN7fD/O++9AdB5/Vf+tKe9Btq7OaRnJdUK+0sSejqL3mGOtFSET5w==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINE", false, "UserTheFifth" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc53", "SixUser@gmail.com", true, "Six", "User", false, null, "SixUser@gmail.com", "UserTheSith", "AQAAAAEAACcQAAAAEH01IhHVsx+x/PskDC+z9h1yTmUDz6lxpPJMAUvNHoC4MtNrkZav34BFnyNzkA3BTw==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINF", false, "UserTheSith" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc54", "SevenUser@gmail.com", true, "Seven", "User", false, null, "SevenUser@gmail.com", "UserTheSeven", "AQAAAAEAACcQAAAAEDKnMhJ6aVwcEoGNdEPJwGvaizV1jW/vHZNZx3/KPFXCto8ShVn/+sx544AGyMtc0A==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZING", false, "UserTheSeven" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc55", "EigthUser@gmail.com", true, "Eigth", "User", false, null, "EigthUser@gmail.com", "UserTheEigth", "AQAAAAEAACcQAAAAEELTe8WHGIt0ZBRkBMxbY60w0eXtcaCrS9v0EJ35r738p1qebc9mKPR+QSsBqiChkg==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINH", false, "UserTheEigth" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc56", "NinthUser@gmail.com", true, "Ninth", "User", false, null, "NinthUser@gmail.com", "UserTheNinth", "AQAAAAEAACcQAAAAEE6J05McuKIE3bAScFhYT55UF/iBBIG/sgAMQcTk2i+lyanNs2WOlUYPBd/I6bEfIw==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINI", false, "UserTheNinth" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc57", "XUser@gmail.com", true, "X", "User", false, null, "XUser@gmail.com", "UserX", "AQAAAAEAACcQAAAAEKEcItJeCzPKjASygUgcu7Xubu2h76wxxPG/jh0RHjWQl8m2vQ4XwbvurPTw3c+c3Q==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINJ", false, "UserX" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedOn", "Description", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9496), "Fist person shooter", new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9495), "FPS" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9500), "Fist person shooter but in the third person", new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9499), "Third person shooter" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9504), null, new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9503), "Simulation" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9507), null, new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9506), "Platformer" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9511), null, new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9510), "Party game" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9515), null, new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9513), "Story driven" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9518), null, new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9517), "Open Word" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9521), null, new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9520), "Nonlinear gameplay" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9527), null, new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9525), "Action-adventure" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9531), null, new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9530), "Stealth" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Country", "CreatedOn", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "America", new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9550), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9551), "Bethesda" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Japan", new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9554), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9555), "Nintendo" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "America", new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9557), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9559), "Ubisoft" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Japan", new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9561), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9562), "Square inex" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "America", new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9565), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9566), "Sony" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "America", new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9568), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9569), "Microsoft" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Japan", new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9571), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9573), "The pokemon company" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Sweden", new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9575), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9576), "CD project" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Japan", new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9578), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9580), "Arc System Works" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "America", new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9582), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9583), "Interplay Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "26/12/2022", new Guid("00000000-0000-0000-0000-000000000001") },
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
                    { 20, "approved", "True", new Guid("00000000-0000-0000-0000-000000000010") }
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
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000010") }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedOn", "LastEditedOn", "Name", "Price", "PublisherId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9401), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9434), "Fallout New Vegas", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9438), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9440), "Splatoon 3", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9442), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9444), "Animal Crossing", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9446), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9448), "Fallout 3", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9451), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9452), "Fallout 4", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9455), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9457), "Splatoon 2", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9460), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9461), "Splatoon", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9464), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9465), "Rabbits", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9468), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9469), "Rayman", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9472), new DateTime(2022, 12, 26, 16, 0, 37, 774, DateTimeKind.Local).AddTicks(9473), "Assassins creed", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") }
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
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_Name",
                table: "Publishers",
                column: "Name",
                unique: true);

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
