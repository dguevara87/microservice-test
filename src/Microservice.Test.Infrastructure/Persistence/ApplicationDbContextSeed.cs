using Microservice.Test.Domain.Entities;

namespace Microservice.Test.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.EjeMuros.Any())
            {
                context.EjeMuros.Add(new EjeMuro
                {
                    Nombre = "Test 1",
                    Puntos =
                    {
                        new PuntoEjeMuro { Etiqueta = "Etiqueta 1", X = 2.5, Y = 3.6 },
                        new PuntoEjeMuro { Etiqueta = "Etiqueta 2", X = 2.9, Y = 4.0 },
                        new PuntoEjeMuro { Etiqueta = "Etiqueta 3", X = 3.2, Y = 3.8 },
                        new PuntoEjeMuro { Etiqueta = "Etiqueta 4", X = 3.8, Y = 4.2 },
                    }
                });

                await context.SaveChangesAsync();
            }
        }
    }
}