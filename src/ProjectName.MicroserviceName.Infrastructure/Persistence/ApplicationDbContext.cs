using Microsoft.EntityFrameworkCore;
using ProjectName.MicroserviceName.Application.Common.Interfaces;

namespace ProjectName.MicroserviceName.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
