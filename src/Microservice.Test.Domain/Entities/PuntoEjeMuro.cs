

namespace Microservice.Test.Domain.Entities
{
    public class PuntoEjeMuro : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        
        public int EjeMuroId { get; set; }

        public string? Etiqueta { get; set; }

        public double X { get; set; }
        
        public double Y { get; set; }
        
        public EjeMuro EjeMuro { get; set; } = null!;
        
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}