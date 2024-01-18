using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.EmployeeAggregate.Events;

public record EmployeeCreated(Employee Employee) : IDomainEvent;
