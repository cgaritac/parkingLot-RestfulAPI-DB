using MessagePack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Proyecto_3.Models;
using Proyecto_3.Servicios;

namespace Proyecto_3.Controllers
{
    public class TiquetesController : Controller
    {
        private readonly IServicioTiquete _iservicioTiquete;
        private readonly IServicioParqueo _iservicioParqueo;

        public TiquetesController(IServicioTiquete iservicioTiquete, IServicioParqueo iservicioParqueo)
        {
            _iservicioTiquete = iservicioTiquete;
            _iservicioParqueo = iservicioParqueo;
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////        

        
        
        // GET: TiquetesController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<Models.Tiquete> laLista;

            laLista = await _iservicioTiquete.Get();

            return View(laLista);
        }

        // GET: TiquetesController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            List<Models.Tiquete> tiquetes;

            tiquetes = await _iservicioTiquete.Get();

            int nextId = 1;

            // Si hay tiquetes en la lista, obtener el valor máximo de "Id" y agregar 1
            if (tiquetes.Count > 0)
            {
                nextId = tiquetes.Max(t => t.Id) + 1;
            }

            // Crear una nueva instancia de Tiquete con el próximo valor de "Id"
            Models.Tiquete nuevoTiquete = new Models.Tiquete
            {
                Id = nextId,
                Ingreso = DateTime.Now,
                IdParqueo = 1
            };

            return View(nuevoTiquete);
        }
   
        // POST: TiquetesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.Tiquete tiquete)
        {
            List<Models.Parqueo> listadoParqueos;
            bool pruebaParqueo = false;

            listadoParqueos = await _iservicioParqueo.Get();

            for (int i = 0; i < listadoParqueos.Count; i++)
            {
                if (listadoParqueos[i].Id == tiquete.IdParqueo)
                {
                    pruebaParqueo = true; break;
                }
            }

            if (listadoParqueos == null)
            {
                ModelState.AddModelError("Ingreso", "Debe crear primero un parqueo.");
            }else

            if (listadoParqueos.Count() == 0)
            {
                ModelState.AddModelError("Ingreso", "Debe crear primero un parqueo.");
            }

            if (listadoParqueos != null && listadoParqueos.Count() != 0)
            {
                // Verificar si la fecha y hora de ingreso están dentro del rango de tiempo del parqueo
                if (tiquete.Ingreso.TimeOfDay < listadoParqueos[0].HoraApertura.TimeOfDay || tiquete.Ingreso.TimeOfDay > listadoParqueos[0].HoraCierre.TimeOfDay)
                {
                    ModelState.AddModelError("Ingreso", "La hora de ingreso debe estar dentro del horario de apertura y cierre del parqueo.");
                }
            }

            if (!pruebaParqueo)
            {
                // Verificar si el parqueo ingresado existe                
                ModelState.AddModelError("IdParqueo", "El numero de parqueo ingresado no existe.");

            }

            if (ModelState.IsValid)
            {
                await _iservicioTiquete.Crear(tiquete);

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

        // GET: TiquetesController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var tiquete = await _iservicioTiquete.ObtenerTiquete(id);

            if (id != 0 && tiquete != null)
            {
                return View(tiquete);
            }

            else return RedirectToAction(nameof(Index));
        }

        // GET: TiquetesController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var tiquete = await _iservicioTiquete.ObtenerTiquete(id);

            tiquete.Salida = DateTime.Now;

            return View(tiquete);
        }

        // POST: TiquetesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Models.Tiquete tiquete)
        {
            List<Models.Parqueo> listadoParqueos;

            listadoParqueos = await _iservicioParqueo.Get();

            if (listadoParqueos.Count() == 0)
            {
                ModelState.AddModelError("Salida", "Debe crear primero un parqueo.");
            }

            if (listadoParqueos.Count() != 0)
            {
                if (tiquete.Salida <= tiquete.Ingreso)
                {
                    ModelState.AddModelError("Salida", "La fecha y hora de salida no puede ser mayor que la fecha y hora de entrada.");
                }
                else

                // Verificar si la fecha y hora de ingreso están dentro del rango de tiempo del parqueo
                if (tiquete.Salida.TimeOfDay < listadoParqueos[0].HoraApertura.TimeOfDay || tiquete.Salida.TimeOfDay > listadoParqueos[0].HoraCierre.TimeOfDay)
                {
                    ModelState.AddModelError("Salida", "La hora de salida debe estar dentro del horario de apertura y cierre del parqueo.");
                }
            }

            if (ModelState.IsValid)
            {

                await _iservicioTiquete.Put(id, tiquete);

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

        // GET: TiquetesController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var tiquete = await _iservicioTiquete.ObtenerTiquete(id);

            return View(tiquete);
        }

        // POST: TiquetesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            await _iservicioTiquete.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
