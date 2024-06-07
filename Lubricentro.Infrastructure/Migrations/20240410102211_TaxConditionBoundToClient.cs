using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lubricentro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TaxConditionBoundToClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TaxConditionId",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TaxConditionId",
                table: "Clients",
                column: "TaxConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_TaxConditions_TaxConditionId",
                table: "Clients",
                column: "TaxConditionId",
                principalTable: "TaxConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_TaxConditions_TaxConditionId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_TaxConditionId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TaxConditionId",
                table: "Clients");
        }
    }
}
