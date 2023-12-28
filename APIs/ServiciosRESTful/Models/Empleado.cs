using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleados.Models
{
    public class Empleado
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public DateTime FechaIngreso { get; set; }

        public string? Nombre { get; set; }

        public string? PrimerApellido { get; set; }

        public string? SegundoApellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string? NumeroCedula { get; set; }

        public string? Direccion { get; set; }

        public string? Email { get; set; }

        public string Telefono { get; set; }

        public string? TipoContacto { get; set; }

        public int IdParqueo { get; set; }
    }
}
