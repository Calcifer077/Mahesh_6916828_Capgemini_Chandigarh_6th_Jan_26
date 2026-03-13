using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballerMVC.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoundedYear = table.Column<int>(type: "int", nullable: false),
                    StadiumName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StadiumCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "NationalTeam",
                columns: table => new
                {
                    NationalTeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Confederation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadCoach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIFA_Ranking = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalTeam", x => x.NationalTeamId);
                });

            migrationBuilder.CreateTable(
                name: "Footballer",
                columns: table => new
                {
                    FootballerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JerseyNumber = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Appearances = table.Column<int>(type: "int", nullable: false),
                    MarketValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    NationalTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footballer", x => x.FootballerId);
                    table.ForeignKey(
                        name: "FK_Footballer_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Footballer_NationalTeam_NationalTeamId",
                        column: x => x.NationalTeamId,
                        principalTable: "NationalTeam",
                        principalColumn: "NationalTeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Footballer_ClubId",
                table: "Footballer",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Footballer_NationalTeamId",
                table: "Footballer",
                column: "NationalTeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Footballer");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "NationalTeam");
        }
    }
}
