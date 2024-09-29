using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lubricentro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPhoneFormat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "Phones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Phones");
        }
    }
}
