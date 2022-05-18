using MediatR;
using Microservice.Test.Application.Common.Models;
using Microservice.Test.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Microservice.Test.Application.Entities.PuntoEjeMuro.EventHandlers
{
    public class PuntoEjeMuroCreatedEventHandler : INotificationHandler<DomainEventNotification<PuntoEjeMuroCreated>>
    {
        private readonly ILogger<PuntoEjeMuroCreatedEventHandler> _logger;

        public PuntoEjeMuroCreatedEventHandler(ILogger<PuntoEjeMuroCreatedEventHandler> logger)
        {
            _logger = logger;
        }
        
        public Task Handle(DomainEventNotification<PuntoEjeMuroCreated> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Microservice.Test Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}