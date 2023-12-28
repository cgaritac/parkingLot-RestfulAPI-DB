using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reportes.Models
{
    public class Reporte
    {
        public DateTime Ingreso { get; set; }

        public DateTime Salida { get; set; }

        public string? Mes { get; set; }

        public Double Venta { get; set; }

        public int Posicion { get; set; }

        public int IdParqueo { get; set; }

        public string? Nombre { get; set; }
    }
}
