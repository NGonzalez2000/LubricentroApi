using System;
using Lubricentro.Domain.VehicleAggregates.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lubricentro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedVehicles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleFactories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFactories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleSpecifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleSpecifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLight = table.Column<bool>(type: "bit", nullable: false),
                    VehicleFactoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleFactories_VehicleFactoryId",
                        column: x => x.VehicleFactoryId,
                        principalTable: "VehicleFactories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FactoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleFactories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "VehicleFactories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleSpecifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "VehicleSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleFactoryId",
                table: "VehicleModels",
                column: "VehicleFactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FactoryId",
                table: "Vehicles",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Plate",
                table: "Vehicles",
                column: "Plate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_SpecificationId",
                table: "Vehicles",
                column: "SpecificationId");


            VehicleFactory vehicleFactory = VehicleFactory.Create("SIN FABRICANTE");
            VehicleSpecification vehicleSpecification = VehicleSpecification.Create("SIN ESPECIFICACION");
            migrationBuilder.InsertData("VehicleFactories", columns: ["Id", "Name"], [vehicleFactory.Id.Value, vehicleFactory.Name]);
            migrationBuilder.InsertData("VehicleModels", columns: ["Id", "Name", "VehicleFactoryId", "IsLight"], [vehicleFactory.Models[0].Id.Value, vehicleFactory.Models[0].Name, vehicleFactory.Id.Value, vehicleFactory.Models[0].IsLight]);
            migrationBuilder.InsertData("VehicleSpecifications", columns: ["Id", "Specification"], [vehicleSpecification.Id.Value, vehicleSpecification.Specification]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleSpecifications");

            migrationBuilder.DropTable(
                name: "VehicleFactories");
        }
    }
}
