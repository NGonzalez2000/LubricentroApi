using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.ClientAggregate;
using Lubricentro.Domain.ClientAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

internal class ClientRepository(LubricentroDbContext dbContext) : Repository<Client, ClientId>(dbContext), IClientRepository
{
    public Task<List<Client>> GetAllAsync()
    {
        return DbContext.Clients.Include(c => c.Address).Include(c => c.TaxCondition).ToListAsync();
    }


    public Client? GetClientByCuil(string cuil)
    {
        return DbContext.Clients.FirstOrDefault(c => c.Cuil == cuil);
    }

    public Client? GetClientById(ClientId Id)
    {
        return DbContext.Clients.Include(c => c.Address).FirstOrDefault(c => c.Id == Id);
    }
}
