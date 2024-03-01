using System.ComponentModel.DataAnnotations;

namespace EmpleadosAPI.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string APaterno { get; set; }
        [Required]
        public string AMaterno { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public string EstadoCivil { get; set; }
        [Required]
        public string RFC { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Telefono { get; set; }
        [Required]
        public string Puesto { get; set; }
        [Required]
        public bool IsActivo { get; set; }
        [Required]
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

    }
}
