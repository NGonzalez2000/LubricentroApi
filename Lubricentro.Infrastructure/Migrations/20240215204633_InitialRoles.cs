using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Domain.RoleAggregate.ValueObjects;
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
            List<Policy> policies = [];
            RoleQueryWriter(migrationBuilder, adminRole);
            RoleQueryWriter(migrationBuilder, masterRole);
            RoleQueryWriter(migrationBuilder, policylessRole);
            policies.Add(PolicyQueryWriter(migrationBuilder, "ChatPolicy"));
            policies.Add(PolicyQueryWriter(migrationBuilder, "ServerPolicy"));
            policies.Add(PolicyQueryWriter(migrationBuilder, "EmployeeModificationsPolicy"));
            foreach (var policy in policies)
            {
                RolePoliciesQueryWriter(migrationBuilder, adminRole.Id.Value, policy.Id.Value);
                if (IsMasterPolicy(policy.Name))
                {
                    RolePoliciesQueryWriter(migrationBuilder, masterRole.Id.Value, policy.Id.Value);
                }
            }

            User adminUser = User.Create("nico1_a_gonzalez@hotmail.com", "legolas27", adminRole);
            migrationBuilder.InsertData(table: "Users", columns: userColumns, values: new object[] { adminUser.Id.Value, adminUser.UserName, adminUser.Password, adminUser.Role.Id.Value });
        }

        private static bool IsMasterPolicy(string policyName)
        {
            if (policyName == "ServerPolicy") return false;


            return true;
        }


        private static readonly string[] userColumns = ["Id", "UserName", "Password", "RoleId"];
        private static readonly string[] roleColumns = ["Id", "Name"];
        private static readonly string[] policyColumns = ["Id", "Name"];

        private static void RoleQueryWriter(MigrationBuilder migrationBuilder, Role role)
        {
            migrationBuilder.InsertData(table: "Roles", columns: roleColumns, values: new object[] { role.Id.Value, role.Name });
        }
        private static Policy PolicyQueryWriter(MigrationBuilder migrationBuilder, string name)
        {
            Policy policy = Policy.Create(name);
            migrationBuilder.InsertData(table: "Policies", columns: policyColumns, values: new object[] { policy.Id.Value, policy.Name });
            return policy;
        }
        private static void RolePoliciesQueryWriter(MigrationBuilder migrationBuilder, Guid roleId, Guid policyId)
        {
            migrationBuilder.Sql($"INSERT INTO PolicyRole (RolesId, PoliciesId) VALUES ('{roleId}','{policyId}')");
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
