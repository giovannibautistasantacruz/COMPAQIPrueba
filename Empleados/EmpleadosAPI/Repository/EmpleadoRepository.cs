using AutoMapper;
using EmpleadosAPI.Data;
using EmpleadosAPI.Models;
using EmpleadosAPI.Models.DTO;
using EmpleadosAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EmpleadosAPI.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ApplicationDbContext _bd;
        private readonly IMapper _mapper;

        public EmpleadoRepository(ApplicationDbContext bd, IMapper mapper)
        {
            _bd = bd;
            _mapper = mapper;
        }
        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
        public EmpleadoDTO NuevoEmpleado(EmpleadoDTO empleado)
        {
            Empleado nuevoEmpleado = new Empleado();
            nuevoEmpleado = _mapper.Map<Empleado>(empleado);
            _bd.Add(nuevoEmpleado);
            if (!Guardar())
            {
                return new EmpleadoDTO();
            }
            return empleado;
        }

        public EmpleadoDTO GetById(int id)
        {
            var empleado = _bd.Empleado.OrderBy(o => o.Nombre).FirstOrDefault(e => e.IdEmpleado == id);

            return _mapper.Map<EmpleadoDTO>(empleado);
        }

        public List<EmpleadoDTO> GetAll()
        {
            var empleados = _bd.Empleado.OrderBy(o => o.Nombre).ToList();

            return _mapper.Map<List<EmpleadoDTO>>(empleados);
        }

        public EmpleadoDTO EditarEmpleado(EmpleadoDTO empleado)
        {
            Empleado empleadoEdit = new Empleado();
            var existe = _bd.Empleado.AsNoTracking().OrderBy(o => o.Nombre).FirstOrDefault(e => e.IdEmpleado == empleado.IdEmpleado);

            if (existe == null)
            {
                return new EmpleadoDTO();

            }
            empleadoEdit = _mapper.Map<Empleado>(empleado);
            _bd.Update(empleadoEdit);
            if (!Guardar())
            {
                return new EmpleadoDTO();
            }
            return empleado;
        }

    }
}
