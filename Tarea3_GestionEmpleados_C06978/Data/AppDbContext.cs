using Microsoft.EntityFrameworkCore;
using Tarea3_GestionEmpleados_C06978.Models;

namespace Tarea3_GestionEmpleados_C06978.Data
{ 
   
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Esta propiedad crea la tabla "Empleados" basada en el modelo
        public DbSet<Empleado> Empleados { get; set; }
    }
}