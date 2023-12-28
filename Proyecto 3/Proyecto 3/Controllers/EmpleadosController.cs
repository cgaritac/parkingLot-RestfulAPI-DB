using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Proyecto_3.Models;
using Proyecto_3.Servicios;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Proyecto_3.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IServicioEmpleado _iservicioEmpleado;
        private readonly IServicioParqueo _iservicioParqueo;

        public EmpleadosController(IServicioEmpleado iservicioEmpleado, IServicioParqueo iservicioParqueo)
        {
            _iservicioEmpleado = iservicioEmpleado;
            _iservicioParqueo = iservicioParqueo;
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////



        // GET: EmpleadosController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<Models.Empleado> laLista;

            laLista = await _iservicioEmpleado.Get();

            return View(laLista);
        }

        // GET: EmpleadosController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            List<Models.Empleado> empleados;

            empleados = await _iservicioEmpleado.Get();

            int nextId = 1;

            // Si hay empleados en la lista, obtener el valor máximo de "Id" y agregar 1
            if (empleados.Count > 0)
            {
                nextId = empleados.Max(t => t.Id) + 1;
            }

            // Crear una nueva instancia de empleado con el próximo valor de "Id"
            Models.Empleado nuevoEmpleado = new Models.Empleado
            {
                Id = nextId,
                FechaIngreso = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                IdParqueo = 1
            };

            return View(nuevoEmpleado);
        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.Empleado empleado)
        {
            List<Models.Parqueo> listadoParqueos;
            bool pruebaParqueo = false;

            listadoParqueos = await _iservicioParqueo.Get();

            for (int i = 0; i < listadoParqueos.Count; i++)
            {
                if (listadoParqueos[i].Id == empleado.IdParqueo)
                {
                    pruebaParqueo = true; break;
                }
            }

            if (empleado.FechaIngreso <= empleado.FechaNacimiento)
            {
                ModelState.AddModelError("FechaIngreso", "La fecha de ingreso debe ser mayor que la fecha de nacimiento.");
            }

            if (!Regex.IsMatch(empleado.Telefono.ToString(), "^[2678]"))
            {
                ModelState.AddModelError("Telefono", "El número de teléfono debe comenzar con 2, 6, 7 u 8 (solo números).");
            }

            if (!pruebaParqueo)
            {
                // Verificar si el parqueo ingresado existe                
                ModelState.AddModelError("IdParqueo", "El numero de parqueo ingresado no existe.");

            }

            if (ModelState.IsValid)
            {
                await _iservicioEmpleado.Crear(empleado);

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

        // GET: EmpleadosController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var empleado = await _iservicioEmpleado.ObtenerEmpleado(id);

            if (id != 0 && empleado != null)
            {
                return View(empleado);
            }
            
            else return RedirectToAction(nameof(Index));
        }

        // GET: EmpleadosController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var empleado = await _iservicioEmpleado.ObtenerEmpleado(id);

            return View(empleado);
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Models.Empleado empleado)
        {
            if (empleado.FechaIngreso <= empleado.FechaNacimiento)
            {
                ModelState.AddModelError("FechaIngreso", "La fecha de ingreso debe ser mayor que la fecha de nacimiento.");
            }

            if (!Regex.IsMatch(empleado.Telefono.ToString(), "^[2678]"))
            {
                ModelState.AddModelError("Telefono", "El número de teléfono debe comenzar con 2, 6, 7 u 8 (solo números).");
            }

            if (ModelState.IsValid)
            {
                await _iservicioEmpleado.Put(id, empleado);

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

        // GET: EmpleadosController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var empleado = await _iservicioEmpleado.ObtenerEmpleado(id);

            return View(empleado);
        }

        // POST: EmpleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            await _iservicioEmpleado.Delete(id);

            return RedirectToAction(nameof(Index));
        }        
    }
}
