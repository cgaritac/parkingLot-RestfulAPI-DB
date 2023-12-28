using Proyecto_3.Models;

namespace Proyecto_3.Servicios
{
    public interface IServicioReporte
    {
        public Task<Double> ObtenerVentasMes(int idParqueo, string mes);

        public Task<Double> ObtenerVentasDia(int idParqueo, DateTime salida);

        public Task<Double> ObtenerVentasRango(int idParqueo, DateTime Inicio, DateTime Fin);

        public Task<IEnumerable<Reporte>> ObtenerMejoresParqueos(string mes);
    }
}
