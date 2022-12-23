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
                    { new Guid("00000000-0000-0000-0000-000000000001"), 0, true, new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7716), "c8554266-b401-4519-9aeb-a9283053fc58", "FirstUser@gmail.com", true, "First", "User", false, null, "FIRSTUSER@GMAIL.COM", "FIRSTGUY", "AQAAAAIAAYagAAAAEN9xEedrdJgV3ElBmhrHAe5qLECTlGKQod1hFXo9etb5Qa/fgyhwfUPn8e2cfweiNw==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA", false, "FirstGuy" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc59", "SecondUser@gmail.com", true, "Second", "User", false, null, "SECONDUSER@GMAIL.COM", "TIMTHEDESTROYERXX400", "AQAAAAIAAYagAAAAEFyIylZNsRS2XWlnfZYhICG8gkh6saCuOTvQdi2KAWQrqzgG4hFIrrmkZ08AfGfuDw==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINB", false, "TimTheDestroyerXx400" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc50", "ThirdUser@gmail.com", true, "Third", "User", false, null, "THIRDUSER@GMAIL.COM", "USERTHETHIRD", "AQAAAAIAAYagAAAAEKS+wlcVW0P7ztz6R11UFs+DgOSBQCp1mp8RZiiCpJWWEjttM7Z6WETFASLTbOm20g==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINC", false, "UserTheThird" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc51", "FourthUser@gmail.com", true, "Fourth", "User", false, null, "FOURTHUSER@GMAIL.COM", "USERTHEFOURTH", "AQAAAAIAAYagAAAAEHgL1qfOaNGTmMGFVgM/kCHFKdWrHHzG0i5/EtWwv9r/FtgkydO8WtgcWDCBxV0QzA==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZIND", false, "UserTheFourth" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc52", "FifthUser@gmail.com", true, "Fifth", "User", false, null, "FIFTHUSER@GMAIL.COM", "USERTHEFIFTH", "AQAAAAIAAYagAAAAEMOliz4lCaioM6s8pctj4jbL/jWNQkH1KrvPEtUvBFpIp9lpDOEKLMPcAKnyESypww==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINE", false, "UserTheFifth" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc53", "SixUser@gmail.com", true, "Six", "User", false, null, "SIXUSER@GMAIL.COM", "USERTHESITH", "AQAAAAIAAYagAAAAEHT5vb1Q/5hXndWzpHsG3CSjprruFazIhW1Y0TZ8KLDW8udDa7k0PAML9nnMOPDHkw==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINF", false, "UserTheSith" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc54", "SevenUser@gmail.com", true, "Seven", "User", false, null, "SEVENUSER@GMAIL.COM", "USERTHESEVEN", "AQAAAAIAAYagAAAAEMkqcj3LmfzDySlIBKg+zreR81uzPPYHuldeo7N4izh+or8j8twpck0jY1Baj4CkEQ==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZING", false, "UserTheSeven" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc55", "EigthUser@gmail.com", true, "Eigth", "User", false, null, "EIGTHUSER@GMAIL.COM", "USERTHEEIGTH", "AQAAAAIAAYagAAAAEFCoxdhA1+TlhWAp0M9Owp7gkk9T8QAKkUPMJ+fQjZGQCiBOfhXo7TTc3WwFkWWzpA==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINH", false, "UserTheEigth" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc56", "NinthUser@gmail.com", true, "Ninth", "User", false, null, "NINTHUSER@GMAIL.COM", "USERTHENINTH", "AQAAAAIAAYagAAAAEKebHUpzHuvoFcvHgmR87kGzpQoRXVIp5cLdSBsbNizFXdMYeZ0ztawoycPY/AG9bw==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINI", false, "UserTheNinth" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), 0, true, new DateTime(2010, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8554266-b401-4519-9aeb-a9283053fc57", "XUser@gmail.com", true, "X", "User", false, null, "XUSER@GMAIL.COM", "USERX", "AQAAAAIAAYagAAAAEHhcuJhRpOcrNHKqA/JYBU3JLB+QPBLAgEeRGSvRNpHYE3/MuycRUrm5aMDouqSjwg==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINJ", false, "UserX" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedOn", "Description", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7427), "Fist person shooter", new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7424), "FPS" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7431), "Fist person shooter but in the third person", new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7429), "Third person shooter" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7435), null, new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7433), "Simulation" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7442), null, new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7441), "Platformer" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7448), null, new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7445), "Party game" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7485), null, new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7483), "Story driven" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7489), null, new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7487), "Open Word" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7493), null, new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7491), "Nonlinear gameplay" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7497), null, new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7495), "Action-adventure" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7501), null, new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7499), "Stealth" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Country", "CreatedOn", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "America", new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7524), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7526), "Bethesda" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Japan", new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7529), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7531), "Nintendo" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "America", new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7533), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7535), "Ubisoft" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Japan", new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7537), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7538), "Square inex" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "America", new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7581), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7583), "Sony" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "America", new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7586), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7587), "Microsoft" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Japan", new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7590), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7591), "The pokemon company" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Sweden", new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7594), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7595), "CD project" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Japan", new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7597), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7599), "Arc System Works" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "America", new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7601), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7603), "Interplay Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "birthday", "23/12/2022 12:33:29", new Guid("00000000-0000-0000-0000-000000000001") },
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
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7259), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7299), "Fallout New Vegas", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7305), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7306), "Splatoon 3", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7310), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7312), "Animal Crossing", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7319), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7321), "Fallout 3", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7339), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7341), "Fallout 4", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7350), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7351), "Splatoon 2", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7354), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7356), "Splatoon", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7359), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7385), "Rabbits", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7389), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7391), "Rayman", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7393), new DateTime(2022, 12, 23, 12, 33, 29, 309, DateTimeKind.Local).AddTicks(7395), "Assassins creed", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") }
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
