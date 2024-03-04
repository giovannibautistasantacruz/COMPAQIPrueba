using EmpleadosWeb.Models.Response;

namespace EmpleadosWeb.Services.IServices
{
    public interface IBaseService
    {
        public RespuestaAPI responseModel { get; set; }
        Task<T> SendAsync<T>(APIConfig apirequest);
    }
}
