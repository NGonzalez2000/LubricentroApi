using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.ChatMessageAggregate;
using Lubricentro.Domain.ClientAggregate;
using Lubricentro.Domain.CompanyAggregate;
using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.EmployeeAggregate;
using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Domain.RoleAggregate;
using Lubricentro.Domain.TaxConditionAggregate;
using Lubricentro.Domain.UserAggregate;
using Lubricentro.Infrastructure.Persistence.Configurations;
using Lubricentro.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence;

public class LubricentroDbContext(DbContextOptions<LubricentroDbContext> options, PublishDomainEventInterceptor publishDomainEventInterceptor) : DbContext(options), IUnitOfWork
{
    private readonly PublishDomainEventInterceptor _publishDomainEventInterceptor = publishDomainEventInterceptor;
    public DbSet<Address> Addresses { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyService> CompanyServices { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Policy> Policies { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<TaxCondition> TaxConditions { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressConfigurations());
        modelBuilder.ApplyConfiguration(new ChatMessageConfiguration());
        modelBuilder.ApplyConfiguration(new ClientConfigurations());
        modelBuilder.ApplyConfiguration(new CompanyConfigurations());
        modelBuilder.ApplyConfiguration(new CompanyServicesConfigurations());
        modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
        modelBuilder.ApplyConfiguration(new PolicyConfigurations());
        modelBuilder.ApplyConfiguration(new RoleConfigurations());
        modelBuilder.ApplyConfiguration(new TaxConditionConfigurations());
        modelBuilder.ApplyConfiguration(new UserConfigurations());

        //modelBuilder
        //    .Ignore<List<IDomainEvent>>()
        //    .ApplyConfigurationsFromAssembly(typeof(LubricentroDbContext).Assembly);
            
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
