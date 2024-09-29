using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lubricentro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedProviderToBrands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "Brands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Brands_ProviderId",
                table: "Brands",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Providers_ProviderId",
                table: "Brands",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Providers_ProviderId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_ProviderId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Brands");
        }
    }
}
