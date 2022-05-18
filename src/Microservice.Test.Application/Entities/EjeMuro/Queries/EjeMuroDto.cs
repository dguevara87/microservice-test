using Microservice.Test.Application.Common.Mapping;
using Microservice.Test.Application.Entities.PuntoEjeMuro.Queries;

namespace Microservice.Test.Application.Entities.EjeMuro.Queries
{
    public class EjeMuroDto : IMapFrom<Domain.Entities.EjeMuro>
    {
        public EjeMuroDto()
        {
            Puntos =  new List<PuntoEjeMuroDto>();
        }

        public int Id { get; set; }
        
        public string? Nombre { get; set; }

        public IList<PuntoEjeMuroDto> Puntos { get; set; }
    }
    
    public record EjeMuroRecord(int Id, string? Nombre);
}