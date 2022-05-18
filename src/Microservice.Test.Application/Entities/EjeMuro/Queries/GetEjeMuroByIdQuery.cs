using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microservice.Test.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Test.Application.Entities.EjeMuro.Queries
{
    // QUERY
    public class GetEjeMuroByIdQuery : IRequest<EjeMuroRecord>
    {
        public int Id { get; set; }
    }
    
    // HANDLER
    public class GetEjeMuroByIdQueryHandler : IRequestHandler<GetEjeMuroByIdQuery, EjeMuroRecord>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetEjeMuroByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<EjeMuroRecord> Handle(GetEjeMuroByIdQuery request, CancellationToken cancellationToken)
        {
            var eje = await _context.EjeMuros
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
            
            return new EjeMuroRecord(eje.Id, eje.Nombre);
        }
    }
}