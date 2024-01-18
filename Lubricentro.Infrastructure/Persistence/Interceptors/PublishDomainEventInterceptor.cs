using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Domain.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Lubricentro.Infrastructure.Persistence.Interceptors;

public class PublishDomainEventInterceptor(IPublisher mediator) : SaveChangesInterceptor
{
    private readonly IPublisher _mediator = mediator;

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
        return base.SavedChanges(eventData, result);
    }
    public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        await PublishDomainEvents(eventData.Context);
        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private async Task PublishDomainEvents(DbContext? dbContext)
    {
        if (dbContext is null)
        {
            return;
        }

        //Get hold of all various entities
        var entitiesWithDomainEvents = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
            .Where(entry => entry.Entity.DomainEvents.Any())
            .Select(entry => entry.Entity)
            .ToList();
        //Get hold of all various domain events
        var domainEvents = entitiesWithDomainEvents.SelectMany(entry => entry.DomainEvents).ToList();

        //Clear domain events
        entitiesWithDomainEvents.ForEach(entity => entity.ClearDomainEvents());
        
        //Publish domain events
        foreach ( var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent);
        }
    }
}
