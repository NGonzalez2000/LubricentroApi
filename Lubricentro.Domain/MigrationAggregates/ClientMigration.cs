
using Lubricentro.Domain.ClientAggregate.ValueObjects;

namespace Lubricentro.Domain.MigrationAggregates;

public class ClientMigration
{
    public Guid Id { get; set; }
    public string ClientId { get; set; }
    public int Cli_Codigo { get; set; }
    private ClientMigration(Guid id, string clientId, int cli_Codigo)
    {
        Id = id;
        ClientId = clientId;
        Cli_Codigo = cli_Codigo;
    }

    public static ClientMigration Create(string clientId, int cli_Codigo)
    {
        return new(Guid.NewGuid(), clientId, cli_Codigo);
    }
}
