using System.ComponentModel.DataAnnotations;

namespace EmpleadosWeb.Models.DTO
{
    public class EmpleadoDTO
    {
        public int? IdEmpleado { get; set; }

        [Required(ErrorMessage ="Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido Paterno es requerido")]

        public string APaterno { get; set; }

        [Required(ErrorMessage = "Apellido Materno es requerido")]

        public string AMaterno { get; set; }

        [Required(ErrorMessage = "Edad es requerida")]

        public int Edad { get; set; }

        [Required(ErrorMessage = "La Fecha de Nacimiento es requerida")]

        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El Genero es requerido")]

        public string Genero { get; set; }

        [Required(ErrorMessage = "El Estado civil es requerido")]

        public string EstadoCivil { get; set; }

        [Required(ErrorMessage = "El RFC es requerido")]

        public string RFC { get; set; }

        [Required(ErrorMessage = "La Dirección es requerida")]

        public string Direccion { get; set; }

        [Required(ErrorMessage = "El E-mail es requerido")]

        [EmailAddress(ErrorMessage = "E-mail Invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Teléfono es requerido")]
        [Phone(ErrorMessage = "Teléfono Invalido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Puesto es requerido")]
        public string Puesto { get; set; }

        public bool IsActivo { get; set; } = true;

        public DateTime? FechaAlta { get; set; } = DateTime.Now;
        public DateTime? FechaBaja { get; set; }
    }
}
