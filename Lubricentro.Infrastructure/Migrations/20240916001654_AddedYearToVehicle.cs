using Lubricentro.Domain.VehicleAggregates.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lubricentro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedYearToVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Vehicles");
        }
    }
}
