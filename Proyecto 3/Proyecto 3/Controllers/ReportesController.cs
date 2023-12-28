using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_3.Models;
using Proyecto_3.Servicios;

namespace Proyecto_3.Controllers
{
    public class ReportesController : Controller
    {
        private readonly IServicioReporte _iservicioReporte;
        private readonly IServicioTiquete _iservicioTiquete;

        public ReportesController(IServicioReporte iservicioReporte, IServicioTiquete iservicioTiquete)
        {
            _iservicioReporte = iservicioReporte;
            _iservicioTiquete = iservicioTiquete;
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////


        // GET: ReportesController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        // GET: ReportesController/VentasMes
        public async Task<ActionResult> VentasMes(int idParqueo, string mes)
        {
            if (idParqueo != 0 && mes != null)
            {
                Double ventasdelMes = await _iservicioReporte.ObtenerVentasMes(idParqueo, mes);

                Models.Reporte nuevoReporte = new Models.Reporte
                {
                    Venta = ventasdelMes,
                    Mes = mes,
                    IdParqueo = idParqueo
                };

                return View(nuevoReporte);
            }

            else return RedirectToAction(nameof(Index));
        }

        // GET: ReportesController/VentasDia
        public async Task<ActionResult> VentasDia(int idParqueo, DateTime salida)
        {
            if (idParqueo != 0)
            {
                Double ventasDelDia = await _iservicioReporte.ObtenerVentasDia(idParqueo, salida);

                Models.Reporte nuevoReporte = new Models.Reporte
                {
                    Venta = ventasDelDia,
                    Salida = salida.Date, 
                    IdParqueo = idParqueo
                };

                return View("VentasDia", nuevoReporte);  
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ReportesController/VentasRango
        public async Task<ActionResult> VentasRango(int idParqueo, DateTime ingreso, DateTime salida)
        {
            if (idParqueo != 0)
            {
                Double ventasEnRango = await _iservicioReporte.ObtenerVentasRango(idParqueo, ingreso, salida);

                Models.Reporte nuevoReporte = new Models.Reporte
                {
                    Venta = ventasEnRango,
                    Ingreso = ingreso.Date,  
                    Salida = salida.Date,      
                    IdParqueo = idParqueo
                };

                return View("VentasRango", nuevoReporte);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ReportesController/MejoresParqueos
        public async Task<ActionResult> MejoresParqueos(string mes)
        {
            if (!string.IsNullOrEmpty(mes))
            {
                var mejoresParqueos = await _iservicioReporte.ObtenerMejoresParqueos(mes);

                return View("MejoresParqueos", mejoresParqueos);
            }

            return RedirectToAction(nameof(Index));
        }
    }
        
}
