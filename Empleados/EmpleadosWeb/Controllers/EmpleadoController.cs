using AutoMapper;
using EmpleadosWeb.Models.DTO;
using EmpleadosWeb.Models.Response;
using EmpleadosWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadosWeb.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _service;
        private readonly IMapper _mapper;

        public EmpleadoController( IEmpleadoService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        public async Task<IActionResult> Index( List<EmpleadoDTO> busqueda = null)
        {
            if (busqueda.Count>0)
            {
                return View(busqueda);
            }
            List<EmpleadoDTO> empleados = new List<EmpleadoDTO>();

           empleados = await _service.ConsultarTodo<List<EmpleadoDTO>>();
            return View(empleados);
        }
        public async Task<IActionResult> CrearEmpleado()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearEmpleado(EmpleadoDTO nuevoEmpleado)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.Crear<RespuestaAPI>(nuevoEmpleado);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(nuevoEmpleado);
        }

        public async Task<IActionResult> ActualizarEmpleado( int empleadoId)
        {
            var response = await _service.ConsultarPorId<EmpleadoDTO>(empleadoId);
            if (response != null)
            {
                return View(response);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEmpleado(EmpleadoDTO editarEmpleado)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.Actualizar<RespuestaAPI>(editarEmpleado);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(editarEmpleado);
        }

        [HttpPost]
        public async Task<IActionResult> BusquedaEmpleado()
        {
            string nombre = Request.Form["nombre"];
            string RFC = Request.Form["rfc"];
            var response = await _service.ConsultarBusqueda<List<EmpleadoDTO>>(nombre,RFC,null);
            return RedirectToAction("Index", "Empleado",new { busqueda = response});
        }



      
        public async Task<IActionResult> BajaEmpleado(int empleadoid)
        {
                var response = await _service.Remover<RespuestaAPI>(empleadoid);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            return RedirectToAction(nameof(Index));
        }
    }
}
