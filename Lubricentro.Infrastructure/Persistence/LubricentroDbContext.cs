using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.BrandAggregate;
using Lubricentro.Domain.ChatMessageAggregate;
using Lubricentro.Domain.ClientAggregate;
using Lubricentro.Domain.CompanyAggregate;
using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.EmployeeAggregate;
using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Domain.ProductAggregate;
using Lubricentro.Domain.ProviderAggregate;
using Lubricentro.Domain.RoleAggregate;
using Lubricentro.Domain.TaxConditionAggregate;
using Lubricentro.Domain.UserAggregate;
using Lubricentro.Domain.VehicleAggregates;
using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Infrastructure.Persistence.Configurations;
using Lubricentro.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence;

public class LubricentroDbContext(DbContextOptions<LubricentroDbContext> options, PublishDomainEventInterceptor publishDomainEventInterceptor) : DbContext(options), IUnitOfWork
{
    private readonly PublishDomainEventInterceptor _publishDomainEventInterceptor = publishDomainEventInterceptor;
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyService> CompanyServices { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Policy> Policies { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<StockItem> StockItems { get; set; }
    public DbSet<TaxCondition> TaxConditions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleFactory> VehicleFactories { get; set; }
    public DbSet<VehicleModel> VehicleModels { get; set; }
    public DbSet<VehicleSpecification> VehicleSpecifications { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressConfigurations());
        modelBuilder.ApplyConfiguration(new BrandConfigurations());
        modelBuilder.ApplyConfiguration(new BranchConfigurations());
        modelBuilder.ApplyConfiguration(new ChatMessageConfiguration());
        modelBuilder.ApplyConfiguration(new ClientConfigurations());
        modelBuilder.ApplyConfiguration(new CompanyConfigurations());
        modelBuilder.ApplyConfiguration(new CompanyServicesConfigurations());
        modelBuilder.ApplyConfiguration(new EmailConfigurations());
        modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
        modelBuilder.ApplyConfiguration(new PhoneConfigurations());
        modelBuilder.ApplyConfiguration(new PolicyConfigurations());
        modelBuilder.ApplyConfiguration(new ProviderConfigurations());
        modelBuilder.ApplyConfiguration(new ProductConfigurations());
        modelBuilder.ApplyConfiguration(new RoleConfigurations());
        modelBuilder.ApplyConfiguration(new StockConfigurations());
        modelBuilder.ApplyConfiguration(new StockItemConfigurations());
        modelBuilder.ApplyConfiguration(new StockItemLocationConfigurations());
        modelBuilder.ApplyConfiguration(new TaxConditionConfigurations());
        modelBuilder.ApplyConfiguration(new UserConfigurations());
        modelBuilder.ApplyConfiguration(new VehicleConfigurations());
        modelBuilder.ApplyConfiguration(new VehicleFactoryConfigurations());
        modelBuilder.ApplyConfiguration(new VehicleModelConfigurations());
        modelBuilder.ApplyConfiguration(new VehicleSpecificationConfigurations());

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
