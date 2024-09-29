using Lubricentro.Domain.ProductAggregate;
using Lubricentro.Domain.ProductAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IProductRepository : IRepository<Product, ProductId>
{
    public Task<IEnumerable<Product>> GetAllAsync();
    public Product? GetById(ProductId productId);
    public bool CheckIfExists(string code, string barCode, ProductId? productId = null);
}
