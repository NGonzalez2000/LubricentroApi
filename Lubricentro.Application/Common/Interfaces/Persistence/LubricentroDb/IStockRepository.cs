using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IStockRepository : IRepository<Stock, StockId>
{
    public Task<IEnumerable<Stock>> GetStocks();
}
