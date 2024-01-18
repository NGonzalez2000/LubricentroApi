using Lubricentro.Domain.EmployeeAggregate.Events;
using MediatR;

namespace Lubricentro.Application.EmployeeMediator.Events;

public class EmployeeCreatedHandler : INotificationHandler<EmployeeCreated>
{
    public Task Handle(EmployeeCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
