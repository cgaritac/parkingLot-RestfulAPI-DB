using Empleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Tiquetes.Models;
using Parqueos.Models;
using ServiciosRESTful;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tiquetes.Controllers
{
    [Route("api/Tiquetes")]
    [ApiController]
    public class TiquetesController : ControllerBase
    {
        private Contexto _miBD;

        public TiquetesController(Contexto miBD)
        {
            _miBD = miBD;
        }



        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        [NonAction]
        public static bool EsEntero(double numero)
        {
            // Comprueba si el número es igual a su versión redondeada al entero más cercano
            return numero == Math.Round(numero);
        }

        [NonAction]
        public static bool EsFraccionMayorA0_5(double numero)
        {
            if (!EsEntero(numero)) // Verifica si no es un número entero
            {
                // Obtiene la parte decimal del número
                double parteDecimal = numero - Math.Floor(numero);

                // Comprueba si la parte decimal es mayor a 0.5
                return parteDecimal > 0.5;
            }

            return false; // El número es entero, no es una fracción mayor a 0.5
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////



        // GET: api/<TiquetesController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_miBD.Tiquetes.ToList());
        }

        // POST api/<TiquetesController>
        [HttpPost("Create")]
        public ActionResult Create([FromBody] Models.Tiquete tiquete)
        {
            tiquete.Salida = new DateTime(1900, 1, 1, 12, 0, 0);


            _miBD.Add(tiquete);
            _miBD.SaveChanges();

            return Ok();
        }

        //// GET api/<TiquetesController>/5
        [HttpGet("ObtenerTiquete/{id}")]
        public ActionResult<Models.Tiquete> ObtenerTiquete(int id)
        {
            Models.Tiquete tiquete = new Models.Tiquete(); ;

            tiquete = _miBD.Tiquetes.Where(t => t.Id == id).FirstOrDefault();

            return Ok(tiquete);
        }

        // PUT api/<TiquetesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Models.Tiquete tiquete)
        {
            Models.Tiquete tiqueteAnterior = new Models.Tiquete(); ;
            Parqueo parqueo = new Parqueo(); ;
            int idParqueoEnTiquete = 0;

            tiqueteAnterior = _miBD.Tiquetes.Where(t => t.Id == id).FirstOrDefault();

            idParqueoEnTiquete = tiqueteAnterior.IdParqueo;

            parqueo = _miBD.Parqueos.Where(p => p.Id == idParqueoEnTiquete).FirstOrDefault();

            var HorasEstacionado = tiquete.Salida.Subtract(tiquete.Ingreso).TotalHours;

            // Cerrar el tiquete
            tiquete.Estado = "Cerrado";

            // Establecer la tarifa por hora y la tarifa por media hora
            double tarifaHora = Double.Parse(parqueo.TarifaHora);
            double tarifaMedia = Double.Parse(parqueo.TarifaMedia);

            double costo = 0.0;

            if (HorasEstacionado <= 0.5)
            {
                costo = tarifaMedia;
            }
            else if (EsEntero(HorasEstacionado))
            {
                costo = tarifaHora * HorasEstacionado;
            }
            else if (EsFraccionMayorA0_5(HorasEstacionado))
            {
                costo = tarifaHora * (HorasEstacionado + 1);
            }
            else
            {
                costo = Math.Floor(HorasEstacionado) * tarifaHora + 1 * tarifaMedia;
            }

            tiquete.Venta = costo;
            
            _miBD.Remove(tiqueteAnterior);
            _miBD.Add(tiquete);
            _miBD.SaveChanges();
        }

        // DELETE api/<TiquetesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Models.Tiquete tiquete = new Models.Tiquete(); ;

            tiquete = _miBD.Tiquetes.Where(t => t.Id == id).FirstOrDefault();
            _miBD.Remove(tiquete);
            _miBD.SaveChanges();
        }
    }
}
