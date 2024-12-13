using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackFlow.Data.Migratations
{
    /// <inheritdoc />
    public partial class Base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Lastname = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Registration = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Capacity = table.Column<double>(type: "float", nullable: false),
                    Fuel = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Registration);
                });

            migrationBuilder.CreateTable(
                name: "Iteneraries",
                columns: table => new
                {
                    VehicleId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 10, nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iteneraries", x => new { x.DriverId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_Iteneraries_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Iteneraries_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Registration",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Iteneraries_VehicleId",
                table: "Iteneraries",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Iteneraries");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
