using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Domain.RoleAggregate;
using Microsoft.EntityFrameworkCore.Migrations;
using Lubricentro.Domain.UserAggregate;

#nullable disable

namespace Lubricentro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Role adminRole = Role.Create("Admin");
            Role masterRole = Role.Create("Master");
            Role policylessRole = Role.Create("Sin Permisos");

            MigrationHelper.RoleQueryWriter(migrationBuilder, adminRole);
            MigrationHelper.RoleQueryWriter(migrationBuilder, masterRole);
            MigrationHelper.RoleQueryWriter(migrationBuilder, policylessRole);

            MigrationHelper.PolicyQueryWriter(migrationBuilder, "ChatPolicy");
            MigrationHelper.PolicyQueryWriter(migrationBuilder, "ServerPolicy");
            MigrationHelper.PolicyQueryWriter(migrationBuilder, "EmployeeModificationsPolicy");
            

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
