using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class Increaseseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(536), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(569) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(577), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(579) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(582), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(583) });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedOn", "LastEditedOn", "Name", "Price", "PublisherId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(586), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(588), "Fallout 3", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(592), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(593), "Fallout 4", 14.99f, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(596), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(598), "Splatoon 2", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(600), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(602), "Splatoon", 59.99f, new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(637), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(635) });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(641), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(640) });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(645), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(644) });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedOn", "Description", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(649), null, new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(648), "Platformer" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(653), null, new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(651), "Party game" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(657), null, new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(655), "Story driven" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(661), null, new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(659), "Open Word" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(664), null, new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(663), "Nonlinear gameplay" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(668), null, new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(666), "Action-adventure" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(672), null, new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(670), "Stealth" }
                });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(689), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(691) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(694), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(696) });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Country", "CreatedOn", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000003"), "America", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(698), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(699), "Ubisoft" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Japan", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(702), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(703), "Square inex" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "America", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(706), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(707), "Sony" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "America", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(710), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(711), "Microsoft" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Japan", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(713), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(715), "The pokemon company" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Sweden", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(717), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(719), "CD project" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Japan", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(721), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(722), "Arc System Works" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "America", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(725), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(726), "Interplay Entertainment" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(775), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(773) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(779), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(777) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "FirstName", "LastEditedOn", "LastName", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(783), "ThirdUser@gmail.com", "Third", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(781), "User", "UserTheThird" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(826), "FourthUser@gmail.com", "Fourth", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(824), "User", "UserTheFourth" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(830), "FifthUser@gmail.com", "Fifth", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(828), "User", "UserTheFifth" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(834), "SixUser@gmail.com", "Six", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(832), "User", "UserTheSith" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(838), "SevenUser@gmail.com", "Seven", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(836), "User", "UserTheSeven" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(842), "EigthUser@gmail.com", "Eigth", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(840), "User", "UserTheEigth" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(846), "NinthUser@gmail.com", "Ninth", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(845), "User", "UserTheNinth" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(850), "XUser@gmail.com", "X", new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(848), "User", "UserX" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedOn", "LastEditedOn", "Name", "Price", "PublisherId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(605), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(606), "Rabbits", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(609), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(611), "Rayman", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(613), new DateTime(2022, 10, 13, 9, 16, 2, 548, DateTimeKind.Local).AddTicks(615), "Assassins creed", 59.99f, new Guid("00000000-0000-0000-0000-000000000003") }
                });

            migrationBuilder.InsertData(
                table: "GamesGenre",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000008") }
                });

            migrationBuilder.InsertData(
                table: "UsersGames",
                columns: new[] { "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000007") }
                });

            migrationBuilder.InsertData(
                table: "GamesGenre",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000010") }
                });

            migrationBuilder.InsertData(
                table: "UsersGames",
                columns: new[] { "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000009") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GamesGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "GamesGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "GamesGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "GamesGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "GamesGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "GamesGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000010") });

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "UsersGames",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "UsersGames",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.DeleteData(
                table: "UsersGames",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "UsersGames",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "UsersGames",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "UsersGames",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "UsersGames",
                keyColumns: new[] { "GameId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8811), new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8844) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8848), new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8853), new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8855) });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8871), new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8869) });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8875), new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8874) });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8879), new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8877) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8892), new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8893) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8896), new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8898) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8973), new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8971) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedOn", "LastEditedOn" },
                values: new object[] { new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8978), new DateTime(2022, 10, 13, 8, 45, 24, 0, DateTimeKind.Local).AddTicks(8976) });
        }
    }
}
