using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_3.Models
{
    public class Parqueo
    {
        [DisplayName("Número de Parqueo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public string? Nombre { get; set; }

        [DisplayName("Cantidad máxima")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public int CantidadVehiculosMax { get; set; }

        [DisplayName("Hora de apertura")]
        [DataType(DataType.Time)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public DateTime HoraApertura { get; set; }

        [DisplayName("Hora de cierre")]
        [DataType(DataType.Time)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        public DateTime HoraCierre { get; set; }

        [DisplayName("Tarifa (\t₡/hora )")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Favor ingresar solo números.")]
        [StringLength(5)]
        public string TarifaHora { get; set; }

        [DisplayName("Tarifa (\t₡/½hora )")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Favor ingresar solo números.")]
        [StringLength(5)]
        public string TarifaMedia { get; set; }
    }
}
