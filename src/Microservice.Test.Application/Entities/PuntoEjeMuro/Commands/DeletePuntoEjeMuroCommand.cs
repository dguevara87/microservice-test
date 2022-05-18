using MediatR;
using Microservice.Test.Application.Common.Exceptions;
using Microservice.Test.Application.Common.Interfaces;
using Microservice.Test.Application.Entities.PuntoEjeMuro.Queries;
using Microservice.Test.Domain.Events;

namespace Microservice.Test.Application.Entities.PuntoEjeMuro.Commands
{
    public class DeletePuntoEjeMuroCommand : IRequest<PuntoEjeMuroRecord>
    {
        public int Id { get; set; }
    }
    
    public class DeletePuntoEjeMuroCommandHandler : IRequestHandler<DeletePuntoEjeMuroCommand, PuntoEjeMuroRecord>
    {
        private readonly IApplicationDbContext _context;

        public DeletePuntoEjeMuroCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<PuntoEjeMuroRecord> Handle(DeletePuntoEjeMuroCommand request, CancellationToken cancellationToken)
        {
            var punto = await _context.PuntoEjeMuros
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (punto == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.PuntoEjeMuro), request.Id);
            }

            _context.PuntoEjeMuros.Remove(punto);

            punto.DomainEvents.Add(new PuntoEjeMuroDeleted(punto));

            await _context.SaveChangesAsync(cancellationToken);

            return new PuntoEjeMuroRecord(punto.Id, punto.Etiqueta, punto.EjeMuroId, punto.X, punto.Y);
        }
    }
}