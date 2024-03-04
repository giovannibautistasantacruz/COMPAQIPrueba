using System.Net;

namespace EmpleadosWeb.Models.Response
{
    public class RespuestaAPI
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }

        public RespuestaAPI()
        {

            ErrorMessages = new List<string>();
        }
    }
}
