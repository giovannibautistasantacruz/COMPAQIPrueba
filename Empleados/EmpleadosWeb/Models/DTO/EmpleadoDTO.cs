using System.ComponentModel.DataAnnotations;

namespace EmpleadosAPI.Models.DTO
{
    public class EmpleadoDTO
    {
        public int? IdEmpleado { get; set; }

        public string Nombre { get; set; }

        public string APaterno { get; set; }

        public string AMaterno { get; set; }

        public int Edad { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Genero { get; set; }

        public string EstadoCivil { get; set; }

        public string RFC { get; set; }

        public string Direccion { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Telefono { get; set; }

        public string Puesto { get; set; }

        public bool IsActivo { get; set; } = true;

        public DateTime? FechaAlta { get; set; } = DateTime.Now;
        public DateTime? FechaBaja { get; set; }
    }
}
