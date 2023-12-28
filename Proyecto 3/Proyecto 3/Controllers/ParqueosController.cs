using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Proyecto_3.Models;
using Proyecto_3.Servicios;

namespace Proyecto_3.Controllers
{
    public class ParqueosController : Controller
    {
        private readonly IServicioParqueo _iservicioParqueo;

        public ParqueosController(IServicioParqueo iservicioParqueo)
        {
            _iservicioParqueo = iservicioParqueo;
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////



        // GET: ParqueosController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<Models.Parqueo> laLista;

            laLista = await _iservicioParqueo.Get();

            return View(laLista);
        }

        // GET: ParqueosController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            List<Models.Parqueo> parqueos;

            parqueos = await _iservicioParqueo.Get();

            int nextId = 1;

            // Si hay parqueos en la lista, obtener el valor máximo de "Id" y agregar 1
            if (parqueos.Count > 0)
            {
                nextId = parqueos.Max(t => t.Id) + 1;
            }

            // Crear una nueva instancia de Parqueo con el próximo valor de "Id"
            Models.Parqueo nuevoParqueo = new Models.Parqueo
            {
                Id = nextId
            };

            return View(nuevoParqueo);
        }

        // POST: ParqueosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.Parqueo parqueo)
        {
            if (parqueo.HoraCierre <= parqueo.HoraApertura)
            {
                ModelState.AddModelError("HoraApertura", "La hora de apertura no puede ser mayor que la hora de cierre.");
            }

            if (int.Parse(parqueo.TarifaHora) <= int.Parse(parqueo.TarifaMedia))
            {
                ModelState.AddModelError("TarifaHora", "La tarifa por hora debe ser mayor que la tarifa por media hora.");
            }

            if (ModelState.IsValid)
            {
                await _iservicioParqueo.Crear(parqueo);

                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: ParqueosController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var parqueo = await _iservicioParqueo.ObtenerParqueo(id);

            if (id != 0 && parqueo != null)
            {
                return View(parqueo);
            }

            else return RedirectToAction(nameof(Index));
        }

        // GET: ParqueosController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var parqueo = await _iservicioParqueo.ObtenerParqueo(id);

            return View(parqueo);
        }

        // POST: ParqueosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Models.Parqueo parqueo)
        {
            if (parqueo.HoraCierre <= parqueo.HoraApertura)
            {
                ModelState.AddModelError("HoraApertura", "La hora de apertura no puede ser mayor que la hora de cierre.");
            }

            if (int.Parse(parqueo.TarifaHora) <= int.Parse(parqueo.TarifaMedia))
            {
                ModelState.AddModelError("TarifaHora", "La tarifa por hora debe ser mayor que la tarifa por media hora.");
            }

            if (ModelState.IsValid)
            {
                await _iservicioParqueo.Put(id, parqueo);

                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: ParqueosController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var parqueo = await _iservicioParqueo.ObtenerParqueo(id);

            return View(parqueo);
        }

        // POST: ParqueosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            await _iservicioParqueo.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
