using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpponentName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Court = table.Column<string>(nullable: true),
                    GameType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Height = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    StatsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false),
                    Rebounds = table.Column<int>(nullable: false),
                    Steals = table.Column<int>(nullable: false),
                    Blocks = table.Column<int>(nullable: false),
                    Fauls = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Court", "Date", "GameType", "OpponentName" },
                values: new object[,]
                {
                    { 1, "Staples Center", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Los Angeles Lakers" },
                    { 2, "Wells Fargo Center", new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Philadelphia 76ers" },
                    { 3, "New Orleans Arena", new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "New Orleans Pelicans" },
                    { 4, "United Center", new DateTime(2020, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Chicago Bulls" },
                    { 5, "AT&T Center", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "San Antonio Spurs" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "FirstName", "Height", "LastName", "Number", "Position", "StatsId", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(1988, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patrick", 185.0, "Beverley", 21, 0, 0, 81.599999999999994 },
                    { 2, new DateTime(1990, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul", 203.0, "George", 13, 2, 0, 99.799999999999997 },
                    { 3, new DateTime(1991, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kawhi", 201.0, "Leonard", 2, 2, 0, 102.09999999999999 },
                    { 4, new DateTime(1986, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lou", 185.0, "Williams", 23, 1, 0, 79.400000000000006 },
                    { 5, new DateTime(1997, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivica", 213.0, "Zubac", 40, 4, 0, 108.90000000000001 },
                    { 6, new DateTime(1994, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montrezl", 201.0, "Harrell", 5, 3, 0, 108.90000000000001 },
                    { 7, new DateTime(1990, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reggie", 190.0, "Jackson", 1, 1, 0, 94.299999999999997 },
                    { 8, new DateTime(1997, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Landry", 193.0, "Shamet", 20, 1, 0, 86.200000000000003 },
                    { 9, new DateTime(1989, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcus", 203.0, "Morris Sr.", 31, 3, 0, 98.900000000000006 },
                    { 10, new DateTime(1990, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "JaMychal", 203.0, "Green", 4, 2, 0, 103.0 }
                });

            migrationBuilder.InsertData(
                table: "Stats",
                columns: new[] { "Id", "Assists", "Blocks", "Fauls", "GameId", "PlayerId", "Points", "Rebounds", "Steals" },
                values: new object[,]
                {
                    { 1, 3, 0, 2, 1, 1, 5, 2, 0 },
                    { 26, 2, 2, 2, 3, 6, 6, 11, 1 },
                    { 46, 3, 2, 3, 4, 6, 15, 11, 0 },
                    { 56, 3, 2, 2, 5, 6, 15, 8, 4 },
                    { 7, 3, 0, 2, 1, 7, 5, 2, 0 },
                    { 17, 9, 1, 2, 2, 7, 9, 5, 0 },
                    { 27, 5, 0, 2, 3, 7, 4, 3, 1 },
                    { 47, 8, 0, 1, 4, 7, 4, 4, 1 },
                    { 57, 2, 2, 3, 5, 7, 6, 4, 1 },
                    { 8, 2, 0, 2, 1, 8, 14, 2, 0 },
                    { 18, 4, 0, 2, 2, 8, 20, 2, 1 },
                    { 28, 5, 2, 1, 3, 8, 6, 0, 2 },
                    { 48, 1, 0, 2, 4, 8, 13, 5, 1 },
                    { 58, 1, 1, 1, 5, 8, 12, 3, 1 },
                    { 9, 2, 1, 1, 1, 9, 15, 2, 1 },
                    { 19, 3, 3, 2, 2, 9, 10, 6, 0 },
                    { 29, 3, 1, 5, 3, 9, 16, 4, 1 },
                    { 49, 3, 1, 1, 4, 9, 13, 4, 1 },
                    { 59, 4, 0, 2, 5, 9, 10, 4, 0 },
                    { 10, 1, 1, 3, 1, 10, 5, 3, 0 },
                    { 20, 0, 2, 4, 2, 10, 10, 5, 1 },
                    { 30, 1, 2, 2, 3, 10, 11, 4, 0 },
                    { 16, 2, 1, 5, 2, 6, 15, 11, 1 },
                    { 6, 4, 3, 4, 1, 6, 11, 10, 1 },
                    { 55, 4, 2, 4, 5, 5, 9, 13, 2 },
                    { 45, 2, 3, 4, 4, 5, 11, 9, 0 },
                    { 11, 11, 0, 4, 2, 1, 9, 3, 1 },
                    { 21, 11, 0, 3, 3, 1, 7, 4, 1 },
                    { 41, 6, 0, 2, 4, 1, 9, 2, 2 },
                    { 51, 7, 0, 2, 5, 1, 5, 3, 1 },
                    { 2, 3, 1, 3, 1, 2, 25, 6, 1 },
                    { 12, 5, 1, 4, 2, 2, 22, 3, 0 },
                    { 22, 8, 1, 5, 3, 2, 29, 6, 0 },
                    { 42, 5, 0, 2, 4, 2, 23, 4, 1 },
                    { 52, 8, 1, 2, 5, 2, 24, 5, 1 },
                    { 3, 6, 1, 3, 1, 3, 30, 8, 3 },
                    { 50, 2, 1, 2, 4, 10, 8, 3, 0 },
                    { 13, 4, 0, 2, 2, 3, 40, 4, 1 },
                    { 43, 4, 1, 3, 4, 3, 29, 9, 2 },
                    { 53, 5, 2, 2, 5, 3, 32, 6, 1 },
                    { 4, 7, 0, 4, 1, 4, 12, 4, 1 },
                    { 14, 12, 0, 4, 2, 4, 11, 4, 0 },
                    { 24, 4, 1, 2, 3, 4, 18, 3, 1 },
                    { 44, 9, 1, 1, 4, 4, 10, 3, 1 },
                    { 54, 3, 2, 2, 5, 4, 15, 5, 2 },
                    { 5, 2, 4, 5, 1, 5, 5, 11, 1 },
                    { 15, 7, 0, 2, 2, 5, 3, 5, 1 },
                    { 25, 1, 0, 6, 3, 5, 10, 9, 1 },
                    { 23, 5, 1, 5, 3, 3, 37, 5, 3 },
                    { 60, 4, 0, 2, 5, 10, 7, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stats_GameId",
                table: "Stats",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PlayerId",
                table: "Stats",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
