using Microservice.Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Test.Infrastructure.Persistence.Configurations
{
    public class EjeMuroConfiguration : IEntityTypeConfiguration<EjeMuro>
    {
        public void Configure(EntityTypeBuilder<EjeMuro> builder)
        {
            builder.Property(t => t.Nombre)
                .HasMaxLength(200)
                .IsRequired();

            // builder.HasMany<PuntoEjeMuro>();
        }
    }
}