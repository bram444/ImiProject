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
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), null, "Admin", "ADMIN" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ApprovedTerms", "BirthDay", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 0, true, new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5518), "c8554266-b401-4519-9aeb-a9283053fc58", "FirstUser@gmail.com", true, "First", "User", false, null, "FIRSTUSER@GMAIL.COM", "FIRSTGUY", "AQAAAAIAAYagAAAAEMLdOA7e7RW28TGYpNRYlHvtnJR19PXVSwRp1UfWOh8pMqGj3WK1P2AzjyBmwr/2OQ==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA", false, "FirstGuy" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc59", "SecondUser@gmail.com", true, "Second", "User", false, null, "SECONDUSER@GMAIL.COM", "TIMTHEDESTROYERXX400", "AQAAAAIAAYagAAAAEIeykz2GXnah5JSTNnikOof8/53g5wZsRN4yiEaMDHIp0TZxrzaM3CaoNBNKg6J/FA==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINB", false, "TimTheDestroyerXx400" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc50", "ThirdUser@gmail.com", true, "Third", "User", false, null, "THIRDUSER@GMAIL.COM", "USERTHETHIRD", "AQAAAAIAAYagAAAAEKjt/t1jTypoj1/lgTo2IqSM61OgIdIvMeY/T+C/UOIj1DR2UfUc/t9EWp/YqncsIw==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINC", false, "UserTheThird" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc51", "FourthUser@gmail.com", true, "Fourth", "User", false, null, "FOURTHUSER@GMAIL.COM", "USERTHEFOURTH", "AQAAAAIAAYagAAAAENwoJh23NytgaVudcEagRsbUemf03jKivwhSZSBlVHt3sVeSJgD3d30ldZ9z5hexiw==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZIND", false, "UserTheFourth" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc52", "FifthUser@gmail.com", true, "Fifth", "User", false, null, "FIFTHUSER@GMAIL.COM", "USERTHEFIFTH", "AQAAAAIAAYagAAAAEO9C/uL9RDdM8HLIgNadtIKLieR848pu40RfNKibpfzUr367F3h2Ma2jDxl2g7zWFg==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINE", false, "UserTheFifth" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc53", "SixUser@gmail.com", true, "Six", "User", false, null, "SIXUSER@GMAIL.COM", "USERTHESITH", "AQAAAAIAAYagAAAAEFQpJx3s5g9VEr7pztdIm9PTHCYCzpi0qP4Goit5WHscWXaCNjG5X56+nXnYDSzsPw==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINF", false, "UserTheSith" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc54", "SevenUser@gmail.com", true, "Seven", "User", false, null, "SEVENUSER@GMAIL.COM", "USERTHESEVEN", "AQAAAAIAAYagAAAAEKyJuWMjWCqkx0tuzV9dOcfrApz2jCIwJhHGnKnvbSinTEQpfssn+MairG4ykCnQow==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZING", false, "UserTheSeven" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc55", "EigthUser@gmail.com", true, "Eigth", "User", false, null, "EIGTHUSER@GMAIL.COM", "USERTHEEIGTH", "AQAAAAIAAYagAAAAELY618A8BgKYjCRLZAb5wKYHyNFSMs4lJAxT94bWm2GffkB0v8XiJWst4oS1JDi9xw==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINH", false, "UserTheEigth" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc56", "NinthUser@gmail.com", true, "Ninth", "User", false, null, "NINTHUSER@GMAIL.COM", "USERTHENINTH", "AQAAAAIAAYagAAAAEM9Ozib9ItPSY6pZjkZSPHCdvn7Ehfz+pF1wYkzgTKIOb9DO9SkS2N8r58VNn+OOIQ==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINI", false, "UserTheNinth" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc57", "XUser@gmail.com", true, "X", "User", false, null, "XUSER@GMAIL.COM", "USERX", "AQAAAAIAAYagAAAAEMGDHrlQTyk81P+HOEUJv8eFF7Wob5e6vZZqgM4uqtvIQuj8A24o2oOE7jFWYN3LCA==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINJ", false, "UserX" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedOn", "Description", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5176), "Fist person shooter", new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5173), "FPS" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5180), "Fist person shooter but in the third person", new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5179), "Third person shooter" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5184), null, new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5182), "Simulation" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5191), null, new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5190), "Platformer" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5197), null, new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5195), "Party game" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5237), null, new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5235), "Story driven" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5240), null, new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5239), "Open Word" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5244), null, new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5243), "Nonlinear gameplay" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5248), null, new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5246), "Action-adventure" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5252), null, new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5250), "Stealth" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Country", "CreatedOn", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "America", new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5276), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5279), "Bethesda" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Japan", new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5281), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5283), "Nintendo" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "America", new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5285), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5286), "Ubisoft" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Japan", new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5289), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5290), "Square inex" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "America", new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5377), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5379), "Sony" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "America", new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5382), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5383), "Microsoft" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Japan", new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5386), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5387), "The pokemon company" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Sweden", new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5390), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5391), "CD project" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Japan", new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5394), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5395), "Arc System Works" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "America", new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5398), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5399), "Interplay Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "birthday", "18/12/2022 19:02:14", new Guid("00000000-0000-0000-0000-000000000001") },
                    { 2, "approved", "True", new Guid("00000000-0000-0000-0000-000000000001") },
                    { 3, "birthday", "19/08/2010 0:00:00", new Guid("00000000-0000-0000-0000-000000000002") },
                    { 4, "approved", "True", new Guid("00000000-0000-0000-0000-000000000002") },
                    { 5, "birthday", "19/08/2010 0:00:00", new Guid("00000000-0000-0000-0000-000000000003") },
                    { 6, "approved", "True", new Guid("00000000-0000-0000-0000-000000000003") },
                    { 7, "birthday", "19/08/2010 0:00:00", new Guid("00000000-0000-0000-0000-000000000004") },
                    { 8, "approved", "True", new Guid("00000000-0000-0000-0000-000000000004") },
                    { 9, "birthday", "19/08/2010 0:00:00", new Guid("00000000-0000-0000-0000-000000000005") },
                    { 10, "approved", "True", new Guid("00000000-0000-0000-0000-000000000005") },
                    { 11, "birthday", "19/08/2010 0:00:00", new Guid("00000000-0000-0000-0000-000000000006") },
                    { 12, "approved", "True", new Guid("00000000-0000-0000-0000-000000000006") },
                    { 13, "birthday", "19/08/2010 0:00:00", new Guid("00000000-0000-0000-0000-000000000007") },
                    { 14, "approved", "True", new Guid("00000000-0000-0000-0000-000000000007") },
                    { 15, "birthday", "19/08/2010 0:00:00", new Guid("00000000-0000-0000-0000-000000000008") },
                    { 16, "approved", "True", new Guid("00000000-0000-0000-0000-000000000008") },
                    { 17, "birthday", "19/08/2010 0:00:00", new Guid("00000000-0000-0000-0000-000000000009") },
                    { 18, "approved", "True", new Guid("00000000-0000-0000-0000-000000000009") },
                    { 19, "birthday", "19/08/2010 0:00:00", new Guid("00000000-0000-0000-0000-000000000010") },
                    { 20, "approved", "True", new Guid("00000000-0000-0000-0000-000000000010") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000004") },
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
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5014), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5054), "Fallout New Vegas", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5058), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5060), "Splatoon 3", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5063), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5065), "Animal Crossing", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5072), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5073), "Fallout 3", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5093), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5095), "Fallout 4", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5104), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5106), "Splatoon 2", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5109), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5110), "Splatoon", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5113), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5137), "Rabbits", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5141), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5142), "Rayman", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5145), new DateTime(2022, 12, 18, 19, 2, 14, 225, DateTimeKind.Local).AddTicks(5146), "Assassins creed", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") }
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
