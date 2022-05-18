using MediatR;
using Microservice.Test.Application.Common.Exceptions;
using Microservice.Test.Application.Common.Interfaces;
using Microservice.Test.Application.Entities.EjeMuro.Queries;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Test.Application.Entities.EjeMuro.Commands
{
    // COMMAND
    public class DeleteEjeMuroCommand : IRequest<EjeMuroRecord>
    {
        public int Id { get; set; }
    }
    
    // HANDLER
    public class DeleteEjeMuroCommandHandler : IRequestHandler<DeleteEjeMuroCommand, EjeMuroRecord>
    {
        private readonly IApplicationDbContext _context;

        public DeleteEjeMuroCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<EjeMuroRecord> Handle(DeleteEjeMuroCommand request, CancellationToken cancellationToken)
        {
            var eje = await _context.EjeMuros
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (eje == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.EjeMuro), request.Id);
            }

            _context.EjeMuros.Remove(eje);

            await _context.SaveChangesAsync(cancellationToken);

            return new EjeMuroRecord(eje.Id, eje.Nombre);
        }
    }
}