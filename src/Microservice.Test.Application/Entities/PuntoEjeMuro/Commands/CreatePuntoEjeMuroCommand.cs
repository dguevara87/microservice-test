
using FluentValidation;
using MediatR;
using Microservice.Test.Application.Common.Interfaces;
using Microservice.Test.Domain.Events;

namespace Microservice.Test.Application.Entities.PuntoEjeMuro.Commands
{
    public class CreatePuntoEjeMuroCommand : IRequest<int>
    {
        public int EjeMuroId { get; set; }

        public string? Etiqueta { get; set; }
        
        public double X { get; set; }
        
        public double Y { get; set; }
    }

    public class CreatePuntoEjeMuroCommandHandler : IRequestHandler<CreatePuntoEjeMuroCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePuntoEjeMuroCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> Handle(CreatePuntoEjeMuroCommand request, CancellationToken cancellationToken)
        {
            var punto = new Domain.Entities.PuntoEjeMuro
            {
                Etiqueta = request.Etiqueta, X = request.X, Y = request.Y, EjeMuroId = request.EjeMuroId,
            };
            
            punto.DomainEvents.Add(new PuntoEjeMuroCreated(punto));

            _context.PuntoEjeMuros.Add(punto);

            await _context.SaveChangesAsync(cancellationToken);

            return punto.Id;
        }
    }

    public class CreatePuntoEjeMuroCommandValidator : AbstractValidator<CreatePuntoEjeMuroCommand>
    {
        public CreatePuntoEjeMuroCommandValidator()
        {
            RuleFor(v => v.Etiqueta)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(v => v.X).NotEmpty();
            RuleFor(v => v.Y).NotEmpty();
        }
    }
}