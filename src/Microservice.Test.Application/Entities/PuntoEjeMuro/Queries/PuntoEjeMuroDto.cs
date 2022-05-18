using Microservice.Test.Application.Common.Mapping;

namespace Microservice.Test.Application.Entities.PuntoEjeMuro.Queries
{
    public class PuntoEjeMuroDto : IMapFrom<Domain.Entities.PuntoEjeMuro>
    {
        public string? Etiqueta { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }

    public record PuntoEjeMuroRecord(int Id, string? Etiqueta, int entityEjeMuroId, double X, double Y);
}