using EmpleadosAPI.Models.DTO;

namespace EmpleadosAPI.Repository.IRepository
{
    public interface IEmpleadoRepository
    {
        EmpleadoDTO NuevoEmpleado(EmpleadoDTO empleado);
        EmpleadoDTO GetById(int id);
        List<EmpleadoDTO> GetAll();
        EmpleadoDTO EditarEmpleado(EmpleadoDTO empleado);
    }
}
