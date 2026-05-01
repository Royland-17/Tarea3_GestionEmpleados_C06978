using Tarea3_GestionEmpleados_C06978.Models;

namespace Tarea3_GestionEmpleados_C06978.Repositories
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> ObtenerTodos();
        Task<Empleado?> ObtenerPorId(int id);
        Task<IEnumerable<Empleado>> BuscarPorNombreODepartamento(string termino);
        Task<IEnumerable<Empleado>> ObtenerPaginado(int pagina, int tamano, string? busqueda);
        Task<int> ContarTotal(string? busqueda);
        Task Agregar(Empleado empleado);
        Task Actualizar(Empleado empleado);
        Task Eliminar(int id);
    }
}