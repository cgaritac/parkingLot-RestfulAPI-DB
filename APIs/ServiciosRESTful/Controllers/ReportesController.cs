using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Parqueos.Models;
using Reportes.Models;
using ServiciosRESTful;
using System.Collections.Generic;
using System.Globalization;
using Tiquetes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reportes.Controllers
{
    [Route("api/Reportes")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private Contexto _miBD;

        public ReportesController(Contexto miBD)
        {
            _miBD = miBD;
        }


        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // Método para obtener el número de mes con base en el nombre
        [NonAction]
        private int NumeroMes(string nombreDelMes)
        {
            DateTimeFormatInfo Dato = CultureInfo.CurrentCulture.DateTimeFormat;

            return Array.IndexOf(Dato.MonthNames, nombreDelMes) + 1;
        }

        // GET api/<ReportesController>/5
        [HttpGet("ObtenerVentasMes/{idParqueo}/{mes}")]
        public ActionResult<Double> ObtenerVentasMes(int idParqueo, string mes)
        {
            int numeroMes = 0;
            double ventasMes = 0;

            //numeroMes = NumeroMes(mes);

            switch (mes.ToLower())
            {
                case "enero":
                    numeroMes = 1;
                    break;
                case "febrero":
                    numeroMes = 2;
                    break;
                case "marzo":
                    numeroMes = 3;
                    break;
                case "abril":
                    numeroMes = 4;
                    break;
                case "mayo":
                    numeroMes = 5;
                    break;
                case "junio":
                    numeroMes = 6;
                    break;
                case "julio":
                    numeroMes = 7;
                    break;
                case "agosto":
                    numeroMes = 8;
                    break;
                case "septiembre":
                    numeroMes = 9;
                    break;
                case "octubre":
                    numeroMes = 10;
                    break;
                case "noviembre":
                    numeroMes = 11;
                    break;
                case "diciembre":
                    numeroMes = 12;
                    break;
            }

            ventasMes = _miBD.Tiquetes.Where(t => t.Salida.Month == numeroMes && t.IdParqueo == idParqueo).Sum(t => t.Venta);

            return ventasMes;
        }

        // GET api/<ReportesController>/5
        [HttpGet("ObtenerVentasDia/{idParqueo}/{salida}")]
        public ActionResult<Double> ObtenerVentasDia(int idParqueo, DateTime salida)
        {
            double ventasDia = 0;

            ventasDia = _miBD.Tiquetes.Where(t => t.Salida.Date == salida.Date && t.IdParqueo == idParqueo).Sum(t => t.Venta);

            return ventasDia;
        }

        [HttpGet("ObtenerVentasRango/{idParqueo}/{Inicio}/{Fin}")]
        public ActionResult<double> ObtenerVentasRango(int idParqueo, DateTime Inicio, DateTime Fin)
        {
            double ventasRango = 0;

            // Se realiza el ajuste de las fechas para que incluyan toda la jornada del día
            DateTime FinDia = Fin.AddDays(1).AddSeconds(-1);

            ventasRango = _miBD.Tiquetes.Where(t => t.Salida >= Inicio && t.Salida <= FinDia && t.IdParqueo == idParqueo).Sum(t => t.Venta);

            return ventasRango;
        }

        [HttpGet("ObtenerMejoresParqueos/{mes}")]
        public ActionResult<IEnumerable<Reporte>> ObtenerMejoresParqueos(string mes)
        {
            int numeroMes = 0;

            //numeroMes = NumeroMes(mes);

            switch (mes.ToLower())
            {
                case "enero":
                    numeroMes = 1;
                    break;
                case "febrero":
                    numeroMes = 2;
                    break;
                case "marzo":
                    numeroMes = 3;
                    break;
                case "abril":
                    numeroMes = 4;
                    break;
                case "mayo":
                    numeroMes = 5;
                    break;
                case "junio":
                    numeroMes = 6;
                    break;
                case "julio":
                    numeroMes = 7;
                    break;
                case "agosto":
                    numeroMes = 8;
                    break;
                case "septiembre":
                    numeroMes = 9;
                    break;
                case "octubre":
                    numeroMes = 10;
                    break;
                case "noviembre":
                    numeroMes = 11;
                    break;
                case "diciembre":
                    numeroMes = 12;
                    break;
            }

            List<Reporte> mejoresParqueos = new List<Reporte>();

            mejoresParqueos = _miBD.Tiquetes
            .Where(t => t.Salida.Month == numeroMes)
            .GroupBy(t => t.IdParqueo)
            .OrderByDescending(group => group.Sum(t => t.Venta))
            .Take(2)
            .Select(group => new Reporte
            {
                IdParqueo = group.Key,
                Nombre = _miBD.Parqueos.FirstOrDefault(p => p.Id == group.Key).Nombre,
                Mes = mes,
                Venta = group.Sum(t => t.Venta)
            })
            .ToList();

            return mejoresParqueos;
        }
    }
}
