using Microservice.Test.Application.Common.Mapping;

namespace Microservice.Test.Application.Entities.PuntoEjeMuro.Queries
{
    public class PuntoEjeMuroMap : IMapFrom<Domain.Entities.PuntoEjeMuro>
    {
        public PuntoEjeMuroMap(string etiqueta)
        {
            Etiqueta = etiqueta;
        }

        public string Etiqueta { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}