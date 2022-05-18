using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microservice.Test.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Test.Application.Entities.EjeMuro.Queries
{
    public class GetAllEjeMuroQuery : IRequest<TodosEjes>
    {
    }
    
    public class GetAllEjeMuroQueryHandler : IRequestHandler<GetAllEjeMuroQuery, TodosEjes>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllEjeMuroQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<TodosEjes> Handle(GetAllEjeMuroQuery request, CancellationToken cancellationToken)
        {
            return new TodosEjes
            {
                Lists = await _context.EjeMuros
                    .AsNoTracking()
                    .ProjectTo<EjeMuroDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Nombre)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}