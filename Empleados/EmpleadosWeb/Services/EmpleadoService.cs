using EmpleadosWeb.Models.DTO;
using EmpleadosWeb.Models.ENUM;
using EmpleadosWeb.Models.Response;
using EmpleadosWeb.Services.IServices;
using Humanizer;

namespace EmpleadosWeb.Services
{
    public class EmpleadoService : BaseService, IEmpleadoService
    {
        private readonly IHttpClientFactory _httpClient;
        private string _url;

        public EmpleadoService( IHttpClientFactory httpClient, IConfiguration configuration ) : base(httpClient)
        {
            _httpClient = httpClient;
            _url = configuration.GetValue<string>("ServiceUrl:API_URL");
        }

        public Task<T> Actualizar<T>(EmpleadoDTO dto)
        {
            return SendAsync<T>(new APIConfig()
            {
                Tipo = APITipo.PUT,
                Datos = dto,
                Url = $"{_url}UpdateEmpleado"
            });
        }

        public Task<T> ConsultarBusqueda<T>(string? nombre, string? rfc, bool? estatus)
        {
            return SendAsync<T>(new APIConfig()
            {
                Tipo = APITipo.POST,
                Datos = new EmpleadoBusquedaDTO() { Nombre = nombre, RFC = rfc, Status = estatus},
                Url = $"{_url}BuscarEmpleado"
            });
        }


        public Task<T> ConsultarPorId<T>(int id)
        {
            return SendAsync<T>(new APIConfig()
            {
                Tipo = APITipo.GET,
                Url = $"{_url}{id}"
            });
        }

        public Task<T> ConsultarTodo<T>()
        {
            return SendAsync<T>(new APIConfig()
            {
                Tipo = APITipo.GET,
                Url = $"{_url}GetEmpleados"
            });
        }

        public Task<T> Crear<T>(EmpleadoDTO dto)
        {
            return SendAsync<T>(new APIConfig()
            {
                Tipo = APITipo.POST,
                Datos = dto,
                Url = $"{_url}CrearEmpleado"
            });
        }

        public Task<T> Remover<T>(int id)
        {
            return SendAsync<T>(new APIConfig()
            {
                Tipo = APITipo.PUT,
                Url = $"{_url}DeleteEmpleado/{id}"
            });
        }
    }
}
