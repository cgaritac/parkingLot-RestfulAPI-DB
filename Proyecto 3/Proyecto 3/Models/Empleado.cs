using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Proyecto_3.Controllers.EmpleadosController;

namespace Proyecto_3.Models
{
    public class Empleado
    {
        [DisplayName("Número de Empleado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public int Id { get; set; }

        [DisplayName("Fecha de Ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public DateTime FechaIngreso { get; set; }

        [DisplayName("Nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public string? Nombre { get; set; }

        [DisplayName("Primer Apellido")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public string? PrimerApellido { get; set; }

        [DisplayName("Segundo Apellido")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public string? SegundoApellido { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Número de Cédula")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Favor ingresar solo números.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Favor ingresar su cedula con 10 digitos.")]
        public string? NumeroCedula { get; set; }

        [DisplayName("Dirección")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public string? Direccion { get; set; }

        [DisplayName("Correo Electrónico")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        [EmailAddress(ErrorMessage = "Por favor, ingrese una dirección de correo electrónico válida.")]
        public string? Email { get; set; }

        [DisplayName("Teléfono")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Favor ingresar solo números.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Favor ingresar su número telefónico con 8 dígitos.")]
        public string Telefono { get; set; }

        [DisplayName("Persona de Contacto")]
        public string? TipoContacto { get; set; }

        [DisplayName("N° Parqueo")]
        [RegularExpression("^[1-9]\\d*$", ErrorMessage = "Favor ingresar números mayores a 0.")]
        public int IdParqueo { get; set; }
    }
}
