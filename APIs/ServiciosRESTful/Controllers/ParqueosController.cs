using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using ServiciosRESTful;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Parqueos.Controllers
{
    [Route("api/Parqueos")]
    [ApiController]
    public class ParqueosController : ControllerBase
    {
        private Contexto _miBD;

        public ParqueosController(/*IMemoryCache elCache,*/ Contexto miBD)
        {
            _miBD = miBD;
        }



        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        
        
        // GET: api/<ParqueosController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_miBD.Parqueos.ToList());
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] Models.Parqueo parqueo)
        {
            _miBD.Add(parqueo);
            _miBD.SaveChanges();

            return Ok();
        }

        //// GET api/<ParqueosController>/5
        [HttpGet("ObtenerParqueo/{id}")]
        public ActionResult<Models.Parqueo> ObtenerParqueo(int id)
        {
            Models.Parqueo parqueo = new Models.Parqueo(); ;

            parqueo = _miBD.Parqueos.Where(p => p.Id == id).FirstOrDefault();

            return Ok(parqueo);
        }

        // PUT api/<ParqueosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Models.Parqueo parqueo)
        {
            Models.Parqueo parqueoAnterior = new Models.Parqueo(); ;

            parqueoAnterior = _miBD.Parqueos.Where(p => p.Id == id).FirstOrDefault();
            _miBD.Remove(parqueoAnterior);
            _miBD.Add(parqueo);
            _miBD.SaveChanges();
        }

        // DELETE api/<ParqueosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Models.Parqueo parqueo = new Models.Parqueo(); ;

            parqueo = _miBD.Parqueos.Where(p => p.Id == id).FirstOrDefault();
            _miBD.Remove(parqueo);
            _miBD.SaveChanges();
        }
    }
}
