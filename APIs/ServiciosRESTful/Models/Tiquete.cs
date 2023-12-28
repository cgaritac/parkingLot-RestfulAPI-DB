using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiquetes.Models
{
    public class Tiquete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public DateTime Ingreso { get; set; }

        public DateTime Salida { get; set; }

        public string? Placa { get; set; }

        public Double Venta { get; set; }

        public string? Estado { get; set; }

        public int IdParqueo { get; set; }
    }
}
