using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.ProductAggregate;
using Lubricentro.Domain.ProductAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

internal class ProductRepository(LubricentroDbContext dbContext) : Repository<Product, ProductId>(dbContext), IProductRepository
{
    public bool CheckIfExists(string code, string barCode, ProductId? productId = null)
    {
        if(productId is not null)
            return DbContext.Products.Any(p => p.Code == code || p.Barcode == barCode || productId == p.Id);

        return DbContext.Products.Any(p => p.Code == code || p.Barcode == barCode);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await DbContext.Products.Include(p => p.Brand)
            .Include(p => p.Provider).ToListAsync();
    }

    public Product? GetById(ProductId productId)
    {
        return DbContext.Products.Include(p => p.Brand)
            .Include(p => p.Provider).FirstOrDefault(p => p.Id == productId);
    }
}
