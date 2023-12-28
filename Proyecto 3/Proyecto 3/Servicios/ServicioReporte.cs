using Newtonsoft.Json;
using Proyecto_3.Models;

namespace Proyecto_3.Servicios
{
    public class ServicioReporte : IServicioReporte
    {
        private string _baseurl;

        public ServicioReporte()
        {

            _baseurl = "http://localhost:5135/";
        }

        public async Task<Double> ObtenerVentasMes(int idParqueo, string mes)
        {
            Double VentasDelMes = 1;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Reportes/ObtenerVentasMes/{idParqueo}/{mes}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Double>(json_respuesta);
                VentasDelMes = resultado;
            }
            return VentasDelMes;
        }

        public async Task<Double> ObtenerVentasDia(int idParqueo, DateTime salida)
        {
            Double VentasDelDia = 1;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var date = salida.ToString("yyyy-MM-dd");
            var response = await cliente.GetAsync($"api/Reportes/ObtenerVentasDia/{idParqueo}/{date}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Double>(json_respuesta);
                VentasDelDia = resultado;
            }
            return VentasDelDia;
        }

        public async Task<Double> ObtenerVentasRango(int idParqueo, DateTime ingreso, DateTime salida)
        {
            Double VentasEnRango = 1;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var dateInicio = ingreso.ToString("yyyy-MM-dd");
            var dateFin = salida.ToString("yyyy-MM-dd");
            var response = await cliente.GetAsync($"api/Reportes/ObtenerVentasRango/{idParqueo}/{dateInicio}/{dateFin}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Double>(json_respuesta);
                VentasEnRango = resultado;
            }
            return VentasEnRango;
        }

        public async Task<IEnumerable<Reporte>> ObtenerMejoresParqueos(string mes)
        {
            IEnumerable<Reporte> mejoresParqueos = new List<Reporte>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Reportes/ObtenerMejoresParqueos/{mes}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<IEnumerable<Reporte>>(json_respuesta);
                mejoresParqueos = resultado;
            }
            return mejoresParqueos;
        }
    }
}
