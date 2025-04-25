using Microsoft.EntityFrameworkCore;
using PCoor_Ramos.Domain.Entities;

namespace PCoor_Ramos.Infrastructure.Data
{
    //Datos de inicio se activan en program
    public static class SeedData
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            
            await context.Database.MigrateAsync();

            
            if (!context.Estados.Any())
            {
                context.Estados.AddRange(
                    new Estado { Id = 1, Nombre = "Pendiente de Clasificar" },
                    new Estado { Id = 2, Nombre = "Validado como Reclamo" },
                    new Estado { Id = 3, Nombre = "Clasificado como Asesoría" },
                    new Estado { Id = 4, Nombre = "Clasificado como Aviso de Infracción" }
                );
            }

           
            if (!context.Empleados.Any())
            {
                context.Empleados.AddRange(
                    new Empleado { Nombres = "Carlos", Apellidos = "Morales", Usuario = "cmorales", Clave = "1234", Activo = true },
                    new Empleado { Nombres = "Ana", Apellidos = "Ramírez", Usuario = "aramirez", Clave = "1234", Activo = true },
                    new Empleado { Nombres = "Luis", Apellidos = "Torres", Usuario = "ltorres", Clave = "1234", Activo = true }
                );
            }

            await context.SaveChangesAsync();
        }
    }
}
