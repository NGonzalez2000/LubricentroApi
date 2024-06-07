using Lubricentro.Domain.ClientAggregate;
using Lubricentro.Domain.ClientAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IClientRepository : IRepository<Client, ClientId>
{
    public Client? GetClientByCuil(string cuil);
    public Client? GetClientById(ClientId Id);
    public Task<List<Client>> GetAllAsync();
}
