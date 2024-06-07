using Lubricentro.Domain.RoleAggregate;
using Lubricentro.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lubricentro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Role adminRole = Role.Create("Admin");
            Role masterRole = Role.Create("Master");
            Role policylessRole = Role.Create("Sin Permisos");

            MigrationHelper.RoleQueryWriter(migrationBuilder, adminRole);
            MigrationHelper.RoleQueryWriter(migrationBuilder, masterRole);
            MigrationHelper.RoleQueryWriter(migrationBuilder, policylessRole);

            MigrationHelper.AddPolicy(migrationBuilder, "ChatPolicy");
            MigrationHelper.AddPolicy(migrationBuilder, "ServerPolicy");
            MigrationHelper.AddPolicy(migrationBuilder, "EmployeeModificationsPolicy");


            User adminUser = User.Create("nico1_a_gonzalez@hotmail.com", "legolas27", adminRole);
            migrationBuilder.InsertData(table: "Users", columns: MigrationHelper.UserColumns, values: new object[] { adminUser.Id.Value, adminUser.UserName, adminUser.Password, adminUser.Role.Id.Value, adminUser.Salt });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"Delete from PolicyRole");
            migrationBuilder.Sql($"Delete from Policies");
            migrationBuilder.Sql($"Delete from Roles");
            migrationBuilder.Sql($"Delete from Users");
        }
    }
}
