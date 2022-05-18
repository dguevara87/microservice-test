using Microservice.Test.Domain.Common;

namespace Microservice.Test.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}