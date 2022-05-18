using Microservice.Test.Domain.Common;

namespace Microservice.Test.Domain.Entities
{
    public class EjeMuro : AuditableEntity
    {
        public int Id { get; set; }
        
        public string? Nombre { get; set; }

        public IList<PuntoEjeMuro> Puntos { get; } = new List<PuntoEjeMuro>();
    }
}