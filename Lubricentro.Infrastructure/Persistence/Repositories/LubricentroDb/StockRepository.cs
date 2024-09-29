using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

internal class StockRepository(LubricentroDbContext dbContext) : Repository<Stock, StockId>(dbContext), IStockRepository
{
    public async Task<IEnumerable<Stock>> GetStocks()
    {
        return await DbContext.Stocks.Include(s => s.Items).ToListAsync();
    }
}
