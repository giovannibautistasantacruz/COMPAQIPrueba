using AutoMapper;
using EmpleadosAPI.Models.DTO;
using EmpleadosAPI.Models.Response;
using EmpleadosAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmpleadosAPI.Controllers
{
    [Route("api/Empleados")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        protected RespuestaAPI respuestaAPI;
        private readonly IMapper _mapper;

        public EmpleadoController(IEmpleadoRepository empleadoRepository,  IMapper mapper)
        {
            this._empleadoRepository = empleadoRepository;
            this.respuestaAPI = new();
            _mapper = mapper;
        }

        [HttpGet("GetEmpleados")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetEmpleados()
        {
            var listaEmpleados = _empleadoRepository.GetAll();
            return Ok(listaEmpleados);
        }

        [HttpPost("CrearEmpleado")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CrearEmpleado([FromBody] EmpleadoDTO empleadoDTO)
        {
            if (!ModelState.IsValid)
            {
                respuestaAPI.StatusCode = HttpStatusCode.BadRequest;
                respuestaAPI.IsSuccess = false;
                respuestaAPI.ErrorMessages.Add("Por favor verifica la información");
                return BadRequest(respuestaAPI);
            }
            var empleado = _empleadoRepository.NuevoEmpleado(empleadoDTO);
            if (empleado == null)
            {
                respuestaAPI.StatusCode = HttpStatusCode.InternalServerError;
                respuestaAPI.IsSuccess = false;
                respuestaAPI.ErrorMessages.Add("Ocurrio un error al crear nuevo alumno");
                return StatusCode(500, respuestaAPI);
            }

            respuestaAPI.StatusCode = HttpStatusCode.OK;
            respuestaAPI.IsSuccess = true;
            respuestaAPI.Result = empleado;
            return StatusCode(201, respuestaAPI);
        }

        [HttpGet("{empleadoId}", Name = "GetEmpleado")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetEmpleado(int empleadoId)
        {
            var empleado = _empleadoRepository.GetById(empleadoId);
            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }

        [HttpPut("UpdateEmpleado")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEmpleado([FromBody] EmpleadoDTO empleadoDTO)
        {
            var empleado = _empleadoRepository.EditarEmpleado(empleadoDTO);
            if (empleado == null)
            {
                respuestaAPI.StatusCode = HttpStatusCode.BadRequest;
                respuestaAPI.IsSuccess = false;
                respuestaAPI.ErrorMessages.Add("Ocurrio un error al actualizar alumno");
                return BadRequest(respuestaAPI);
            }

            respuestaAPI.StatusCode = HttpStatusCode.OK;
            respuestaAPI.IsSuccess = true;
            respuestaAPI.Result = empleado;
            return Ok(respuestaAPI);
        }
    }
}
