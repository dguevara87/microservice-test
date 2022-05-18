using FluentValidation;
using MediatR;
using Microservice.Test.Application.Common.Exceptions;
using Microservice.Test.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Test.Application.Entities.EjeMuro.Commands
{
    // COMMAND
    public class UpdateEjeMuroCommand : IRequest
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }
    }
    
    // HANDLER
    public class UpdateEjeMuroCommandHandler : IRequestHandler<UpdateEjeMuroCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEjeMuroCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(UpdateEjeMuroCommand request, CancellationToken cancellationToken)
        {
            var eje = await _context.EjeMuros.FindAsync(new object[] {request.Id}, cancellationToken);

            if (eje == null)
                throw new NotFoundException(nameof(Domain.Entities.EjeMuro), request.Id);

            eje.Nombre = request.Nombre;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
    
    // VALIDATOR
    public class UpdateEjeMuroCommandValidator : AbstractValidator<UpdateEjeMuroCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEjeMuroCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            
            RuleFor(v => v.Nombre)
                .NotEmpty().WithMessage("El Nombre es Requerido.")
                .MaximumLength(200).WithMessage("El Nombre no debe tener mas de 200 caracteres.")
                .MustAsync(BeUniqueTitle).WithMessage("El Nombre especificado ya existe.");
        }
        
        public async Task<bool> BeUniqueTitle(UpdateEjeMuroCommand model, string nombre, CancellationToken cancellationToken)
        {
            return await _context.EjeMuros
                .Where(l => l.Id != model.Id)
                .AllAsync(l => l.Nombre != nombre, cancellationToken);
        }
    }
}