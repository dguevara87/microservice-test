using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microservice.Test.Application.Common.Interfaces;
using Microservice.Test.Application.Common.Mapping;
using Microservice.Test.Application.Common.Models;

namespace Microservice.Test.Application.Entities.PuntoEjeMuro.Queries
{
    // Query
    public class GetPuntoEjeMuroWithPaginationQuery : IRequest<PaginatedList<PuntoEjeMuroMap>>
    {
        public int EjeMuroId { get; set; } 
        public int PageNumber { get; set; } 
        public int PageSize { get; set; }
    }
    
    // Handler
    public class GetPuntoEjeMuroWithPaginationQueryHandler : IRequestHandler<GetPuntoEjeMuroWithPaginationQuery, PaginatedList<PuntoEjeMuroMap>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPuntoEjeMuroWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<PuntoEjeMuroMap>> Handle(GetPuntoEjeMuroWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.PuntoEjeMuros
                .Where(x => x.EjeMuroId == request.EjeMuroId)
                .OrderBy(x => x.Etiqueta)
                .ProjectTo<PuntoEjeMuroMap>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
    
    public class GetPuntoEjeMuroWithPaginationQueryValidator : AbstractValidator<GetPuntoEjeMuroWithPaginationQuery>
    {
        public GetPuntoEjeMuroWithPaginationQueryValidator()
        {
            RuleFor(x => x.EjeMuroId)
                .NotEmpty().WithMessage("ListId is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}