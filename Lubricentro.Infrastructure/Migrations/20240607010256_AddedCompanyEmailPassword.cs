using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lubricentro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompanyEmailPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Companies");
        }
    }
}
