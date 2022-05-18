using MediatR;
using Microservice.Test.Application.Common.Interfaces;

namespace Microservice.Test.Application.Entities.EjeMuro.Commands
{
    // COMMAND
    public class PurgeEjeMuroCommand : IRequest
    {
    }
    
    // HANDLER
    public class PurgeEjeMuroCommandHandler : IRequestHandler<PurgeEjeMuroCommand>
    {
        private readonly IApplicationDbContext _context;

        public PurgeEjeMuroCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(PurgeEjeMuroCommand request, CancellationToken cancellationToken)
        {
            _context.EjeMuros.RemoveRange(_context.EjeMuros);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }   
}