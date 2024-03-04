using EmpleadosWeb.Models.ENUM;

namespace EmpleadosWeb.Models.Response
{
    public class APIConfig
    {
        public APITipo Tipo { get; set; }
        public string Url { get; set; }
        public object Datos { get; set; }
    }
}
