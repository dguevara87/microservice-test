using Microservice.Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Test.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<EjeMuro> EjeMuros { get; }
        
        DbSet<PuntoEjeMuro> PuntoEjeMuros { get; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}