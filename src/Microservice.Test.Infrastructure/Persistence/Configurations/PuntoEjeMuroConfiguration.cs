using Microservice.Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Test.Infrastructure.Persistence.Configurations
{
    public class PuntoEjeMuroConfiguration : IEntityTypeConfiguration<PuntoEjeMuro>
    {
        public void Configure(EntityTypeBuilder<PuntoEjeMuro> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Etiqueta)
                .HasMaxLength(200)
                .IsRequired();
            
            builder.Property(t => t.X)
                .IsRequired();
            
            builder.Property(t => t.Y)
                .IsRequired();
        }
    }
}