using EmpleadosWeb.Models.DTO;

namespace EmpleadosWeb.Services.IServices
{
    public interface IEmpleadoService
    {
        Task<T> ConsultarTodo<T>();
        Task<T> ConsultarPorId<T>(int id);
        Task<T> ConsultarBusqueda<T>(string? nombre, string? rfc, bool? estatus);
        Task<T> Crear<T>(EmpleadoDTO dto);
        Task<T> Actualizar<T>(EmpleadoDTO dto);
        Task<T> Remover<T>(int id);
    }
}
