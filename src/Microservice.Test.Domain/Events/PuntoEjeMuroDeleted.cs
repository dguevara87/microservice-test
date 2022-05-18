using Microservice.Test.Domain.Common;
using Microservice.Test.Domain.Entities;

namespace Microservice.Test.Domain.Events
{
    public class PuntoEjeMuroDeleted : DomainEvent
    {
        public PuntoEjeMuroDeleted(PuntoEjeMuro punto)
        {
            Punto = punto;
        }

        public PuntoEjeMuro Punto { get; }
    }
}