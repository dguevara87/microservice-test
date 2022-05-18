using FluentValidation;
using MediatR;
using Microservice.Test.Application.Common.Exceptions;
using Microservice.Test.Application.Common.Interfaces;
using Microservice.Test.Application.Entities.PuntoEjeMuro.Queries;

namespace Microservice.Test.Application.Entities.PuntoEjeMuro.Commands
{
    public class UpdatePuntoEjeMuroCommand : IRequest<PuntoEjeMuroRecord>
    {
        public int Id { get; set; }
        
        public int EjeMuroId { get; set; }

        public string? Etiqueta { get; set; }

        public double X { get; set; }

        public double Y { get; set; }
    }
    
    public class UpdatePuntoEjeMuroCommandHandler : IRequestHandler<UpdatePuntoEjeMuroCommand, PuntoEjeMuroRecord>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePuntoEjeMuroCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<PuntoEjeMuroRecord> Handle(UpdatePuntoEjeMuroCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PuntoEjeMuros
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.PuntoEjeMuro), request.Id);
            }

            entity.Etiqueta = request.Etiqueta;
            entity.EjeMuroId = request.EjeMuroId;
            entity.X = request.X;
            entity.Y = request.Y;

            await _context.SaveChangesAsync(cancellationToken);

            return new PuntoEjeMuroRecord(entity.Id, entity.Etiqueta, entity.EjeMuroId, entity.X, entity.Y);
        }
    }
    
    public class UpdatePuntoEjeMuroCommandValidator : AbstractValidator<UpdatePuntoEjeMuroCommand>
    {
        public UpdatePuntoEjeMuroCommandValidator()
        {
            RuleFor(v => v.Etiqueta)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}