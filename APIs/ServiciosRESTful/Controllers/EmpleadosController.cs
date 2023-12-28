using Empleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Parqueos.Models;
using ServiciosRESTful;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Empleados.Controllers
{
    [Route("api/Empleados")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private Contexto _miBD;

        public EmpleadosController(Contexto miBD)
        {
            _miBD = miBD;
        }




        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        // GET: api/<EmpleadosController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_miBD.Empleados.ToList());
        }

        // POST api/<EmpleadosController>
        [HttpPost("Create")]
        public ActionResult Create([FromBody] Models.Empleado empleado)
        {
            _miBD.Add(empleado);
            _miBD.SaveChanges();

            return Ok();
        }

        //// GET api/<EmpleadosController>/5
        [HttpGet("ObtenerEmpleado/{id}")]
        public ActionResult<Empleado> ObtenerEmpleado(int id)
        {
            Models.Empleado empleado = new Models.Empleado(); ;

            empleado = _miBD.Empleados.Where(e => e.Id == id).FirstOrDefault();

            return Ok(empleado);
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Models.Empleado empleado)
        {
            Models.Empleado empleadoAnterior = new Models.Empleado(); ;

            empleadoAnterior = _miBD.Empleados.Where(e => e.Id == id).FirstOrDefault();
            _miBD.Remove(empleadoAnterior);
            _miBD.Add(empleado);
            _miBD.SaveChanges();
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Models.Empleado empleado = new Models.Empleado(); ;

            empleado = _miBD.Empleados.Where(e => e.Id == id).FirstOrDefault();
            _miBD.Remove(empleado);
            _miBD.SaveChanges();
        }
    }
}
