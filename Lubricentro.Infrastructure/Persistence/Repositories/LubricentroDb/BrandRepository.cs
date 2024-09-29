using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.BrandAggregate;
using Lubricentro.Domain.BrandAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

internal class BrandRepository(LubricentroDbContext dbContext) : Repository<Brand, BrandId>(dbContext), IBrandRepository
{
    public async Task<List<Brand>> GetAllAsync()
    {
        return await DbContext.Brands.ToListAsync();
    }

    public async Task<Brand?> GetByIdAsync(BrandId Id)
    {
        return await DbContext.Brands.FirstOrDefaultAsync(b => b.Id == Id);
    }

    public async Task<Brand?> GetByNameAsync(string name)
    {
        return await DbContext.Brands.FirstOrDefaultAsync(b => b.Name == name);
    }
}
