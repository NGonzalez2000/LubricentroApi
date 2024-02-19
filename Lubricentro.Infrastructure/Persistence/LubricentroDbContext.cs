using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.EmployeeAggregate;
using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Domain.RoleAggregate;
using Lubricentro.Domain.UserAggregate;
using Lubricentro.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence;

public class LubricentroDbContext(DbContextOptions<LubricentroDbContext> options, PublishDomainEventInterceptor publishDomainEventInterceptor) : DbContext(options), IUnitOfWork
{
    private readonly PublishDomainEventInterceptor _publishDomainEventInterceptor = publishDomainEventInterceptor;
    public DbSet<Employee> Employees { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Policy> Policies { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(LubricentroDbContext).Assembly);
            
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
