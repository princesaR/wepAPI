using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    PhoneMobile = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoronaPatients",
                columns: table => new
                {
                    CoronaPatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    PositiveResult = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecoveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoronaPatients", x => x.CoronaPatientId);
                    table.ForeignKey(
                        name: "FK_CoronaPatients_Members_Id",
                        column: x => x.Id,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    VaccinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccinationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VaccinationManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => new { x.Id, x.VaccinationId });
                    table.ForeignKey(
                        name: "FK_Vaccinations_Members_Id",
                        column: x => x.Id,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoronaPatients_Id",
                table: "CoronaPatients",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoronaPatients");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
