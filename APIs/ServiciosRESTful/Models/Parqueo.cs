using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parqueos.Models
{
    public class Parqueo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int CantidadVehiculosMax { get; set; }

        public DateTime HoraApertura { get; set; }

        public DateTime HoraCierre { get; set; }

        public string TarifaHora { get; set; }

        public string TarifaMedia { get; set; }
    }
}
