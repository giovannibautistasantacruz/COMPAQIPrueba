using EmpleadosWeb.Models.Response;
using EmpleadosWeb.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace EmpleadosWeb.Services
{
    public class BaseService : IBaseService
    {
        public RespuestaAPI responseModel { get ; set ; }
        private IHttpClientFactory _httpClientFactory { get; set; }

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> SendAsync<T>(APIConfig apirequest)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("EmpleadoAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apirequest.Url);

                if (apirequest.Datos != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apirequest.Datos), Encoding.UTF8, "application/json");
                }

                switch (apirequest.Tipo)
                {
                    case Models.ENUM.APITipo.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case Models.ENUM.APITipo.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case Models.ENUM.APITipo.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case Models.ENUM.APITipo.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiresponse = null;
                apiresponse = await client.SendAsync(message);
                var apiContent = await apiresponse.Content.ReadAsStringAsync();
                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;
            }
            catch (Exception _ex)
            {
                var error = new RespuestaAPI
                {
                    ErrorMessages = new List<string> { Convert.ToString(_ex.Message) }
                };
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(error));
            }
        }
    }
}
