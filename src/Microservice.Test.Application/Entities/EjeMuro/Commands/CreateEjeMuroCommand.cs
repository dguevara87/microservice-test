using FluentValidation;
using MediatR;
using Microservice.Test.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Test.Application.Entities.EjeMuro.Commands
{
    // COMMAND
    public class CreateEjeMuroCommand : IRequest<int>
    {
        public string? Nombre { get; set; }
    }
    
    // HANDLER
    public class CreateEjeMuroCommandHandler : IRequestHandler<CreateEjeMuroCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateEjeMuroCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> Handle(CreateEjeMuroCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.EjeMuro();

            entity.Nombre = request.Nombre;

            _context.EjeMuros.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }

    // VALIDATOR
    public class CreateEjeMuroCommandValidator : AbstractValidator<CreateEjeMuroCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateEjeMuroCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Nombre)
                .NotEmpty().WithMessage("El Nombre es Requerido.")
                .MaximumLength(200).WithMessage("El Nombre no debe tener mas de 200 caracteres.")
                .MustAsync(BeUniqueTitle).WithMessage("El Nombre especificado ya existe.");
        }
        
        public async Task<bool> BeUniqueTitle(string nombre, CancellationToken cancellationToken)
        {
            return await _context.EjeMuros
                .AllAsync(l => l.Nombre != nombre, cancellationToken);
        }
    }
}