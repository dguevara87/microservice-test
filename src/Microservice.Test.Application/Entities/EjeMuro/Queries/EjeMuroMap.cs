using Microservice.Test.Application.Common.Mapping;
using Microservice.Test.Application.Entities.PuntoEjeMuro.Queries;

namespace Microservice.Test.Application.Entities.EjeMuro.Queries
{
    public class EjeMuroMap : IMapFrom<Domain.Entities.EjeMuro>
    {
        public EjeMuroMap()
        {
            Puntos =  new List<PuntoEjeMuroMap>();
        }

        public int Id { get; set; }
        
        public string? Nombre { get; set; }

        public IList<PuntoEjeMuroMap> Puntos { get; set; }
    }
}