using Microsoft.AspNetCore.Mvc;
using Tarea3_GestionEmpleados_C06978.Models;
using Tarea3_GestionEmpleados_C06978.Repositories;

namespace Tarea3_GestionEmpleados_C06978.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepository _repository;

        // Aquí el constructor recibe el repositorio por inyección de dependencias
        public EmpleadosController(IEmpleadoRepository repository)
        {
            _repository = repository;
        }

        // Acción principal: Lista los empleados con búsqueda y paginación
        public async Task<IActionResult> Index(string buscar, int pagina = 1)
        {
            int tamanoPagina = 5;
            var empleados = await _repository.ObtenerPaginado(pagina, tamanoPagina, buscar);

            // Acá pasamos datos a la vista para la lógica de los botones de página
            ViewBag.TotalRegistros = await _repository.ContarTotal(buscar);
            ViewBag.PaginaActual = pagina;
            ViewBag.TamanoPagina = tamanoPagina;
            ViewBag.BusquedaActual = buscar;

            return View(empleados);
        }

        // Acción crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                await _repository.Agregar(empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }
        // Acción Eliminar
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            // Llamamos al repositorio para borrar el registro físicamente de SQL Server
            await _repository.Eliminar(id);

            // Una vez borrado, recargamos la lista principal
            return RedirectToAction(nameof(Index));
        }

        // Acción Editar
        public async Task<IActionResult> Editar(int id)
        {
            // Buscamos al empleado por su ID para llenar el formulario
            var empleado = await _repository.ObtenerPorId(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            if (ModelState.IsValid)
            {

                await _repository.Actualizar(empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }
    }
}