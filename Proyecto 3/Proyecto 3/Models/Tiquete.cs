using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_3.Models
{
    public class Tiquete
    {
        [DisplayName("Número de Tiquete")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public int Id { get; set; }

        [DisplayName("Fecha y hora de ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public DateTime Ingreso { get; set; }

        [DisplayName("Fecha y hora de salida")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public DateTime Salida { get; set; }

        [DisplayName("Número de placa")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        [RegularExpression(@"^([A-Za-z]{3}\d{3}|\d{6})$", ErrorMessage = "La placa debe tener 3 letras seguidas de 3 números o 6 números sin letras.")]
        [StringLength(6)]
        public string? Placa { get; set; }

        [DisplayName("Monto total (\t₡ )")]
        public Double Venta { get; set; }

        [DisplayName("Estado de tiquete")]
        public string? Estado { get; set; }

        [DisplayName("N° Parqueo")]
        [RegularExpression("^[1-9]\\d*$", ErrorMessage = "Favor ingresar números mayores a 0.")]
        public int IdParqueo { get; set; }
    }
}
