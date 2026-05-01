using Microsoft.EntityFrameworkCore;
using Tarea3_GestionEmpleados_C06978.Data;
using Tarea3_GestionEmpleados_C06978.Models;

namespace Tarea3_GestionEmpleados_C06978.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext _context;
        public EmpleadoRepository(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<Empleado>> ObtenerTodos() => await _context.Empleados.ToListAsync();
        public async Task<Empleado?> ObtenerPorId(int id) => await _context.Empleados.FindAsync(id);

        public async Task<IEnumerable<Empleado>> ObtenerPaginado(int pagina, int tamano, string? busqueda)
        {
            var query = _context.Empleados.AsQueryable();
            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(e => e.Nombre.Contains(busqueda) || e.Apellidos.Contains(busqueda) || e.Departamento.Contains(busqueda));
            }
            return await query.Skip((pagina - 1) * tamano).Take(tamano).ToListAsync(); // Lógica de paginación
        }

        public async Task<int> ContarTotal(string? busqueda)
        {
            var query = _context.Empleados.AsQueryable();
            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(e => e.Nombre.Contains(busqueda) || e.Apellidos.Contains(busqueda) || e.Departamento.Contains(busqueda));
            }
            return await query.CountAsync();
        }

        public async Task<IEnumerable<Empleado>> BuscarPorNombreODepartamento(string termino) =>
            await _context.Empleados.Where(e => e.Nombre.Contains(termino) || e.Departamento.Contains(termino)).ToListAsync();

        public async Task Agregar(Empleado empleado) { _context.Empleados.Add(empleado); await _context.SaveChangesAsync(); }
        public async Task Actualizar(Empleado empleado) { _context.Entry(empleado).State = EntityState.Modified; await _context.SaveChangesAsync(); }
        public async Task Eliminar(int id) { /* Lógica de eliminación física si fuera necesaria */ }
    }
}
