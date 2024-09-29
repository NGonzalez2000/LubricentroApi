using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lubricentro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedProviderInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Providers");

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "Phones",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "Emails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ProviderId",
                table: "Phones",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ProviderId",
                table: "Emails",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Providers_ProviderId",
                table: "Emails",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Providers_ProviderId",
                table: "Phones",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Providers_ProviderId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Providers_ProviderId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_ProviderId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Emails_ProviderId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Emails");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
