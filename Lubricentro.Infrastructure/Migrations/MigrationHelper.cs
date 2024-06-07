using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Domain.RoleAggregate;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lubricentro.Infrastructure.Migrations;

internal class MigrationHelper
{
    internal static readonly string[] UserColumns = ["Id", "UserName", "Password", "RoleId", "Salt"];
    internal static readonly string[] RoleColumns = ["Id", "Name"];
    internal static readonly string[] PolicyColumns = ["Id", "Name"];
    internal static bool IsMasterPolicy(string policyName)
    {
        if (policyName == "ServerPolicy") return false;
        if (policyName == "CompanyPolicy") return false;

        return true;
    }
    internal static void RoleQueryWriter(MigrationBuilder migrationBuilder, Role role)
    {
        migrationBuilder.InsertData(table: "Roles", columns: RoleColumns, values: new object[] { role.Id.Value, role.Name });
    }
    internal static void AddCompanyService(MigrationBuilder migrationBuilder, string name)
    {
        CompanyServiceId id = CompanyServiceId.CreateUnique();
        string query = $"Insert into CompanyServices values('{id.Value}','{name}',NULL)";
        migrationBuilder.Sql(query);
    }
    internal static void AddPolicy(MigrationBuilder migrationBuilder, string name)
    {
        Policy policy = Policy.Create(name);
        string query = $"Declare @PolicyId uniqueidentifier = CONVERT(uniqueidentifier, '{policy.Id.Value.ToString().ToUpper()}');" +
            $"insert into Policies values(@PolicyId,'{policy.Name}');" +
            $"Declare @AdminRoleId uniqueidentifier;" +
            $"Select @AdminRoleId = Id FROM Roles Where [Name] = 'Admin';" +
            $"insert into PolicyRole values(@PolicyId,@AdminRoleId);";

        if (IsMasterPolicy(policy.Name))
        {
            query += $"Declare @MasterRoleId uniqueidentifier;" +
            $"Select @MasterRoleId = Id FROM Roles Where [Name] = 'Master';" +
            $"insert into PolicyRole values(@PolicyId,@MasterRoleId);";
        }

        migrationBuilder.Sql(query);
    }
    internal static void PolicyRemover(MigrationBuilder migrationBuilder, string name)
    {
        string query = $"Delete from Policies where [Name] = '{name}'";
        migrationBuilder.Sql(query);
    }
}
