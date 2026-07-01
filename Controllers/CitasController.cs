using Microsoft.AspNetCore.Mvc;
using Practica_Evaluada_1.Models;
using Practica_Evaluada_1.Services;

namespace Practica_Evaluada_1.Controllers
{
    public class CitasController : Controller
    {
        private readonly ICitaService _citaService;
        private readonly IClienteService _clienteService;
        private readonly IVehiculoService _vehiculoService;

        public CitasController(
            ICitaService citaService,
            IClienteService clienteService,
            IVehiculoService vehiculoService)
        {
            _citaService = citaService;
            _clienteService = clienteService;
            _vehiculoService = vehiculoService;
        }

        public IActionResult Index()
        {
            var citas = _citaService.ObtenerCitas();
            return View(citas);
        }

        public IActionResult Registrar()
        {
            CargarDatos();
            return View(new CitaViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(CitaViewModel citaViewModel)
        {
            if (!ModelState.IsValid)
            {
                CargarDatos();
                return View(citaViewModel);
            }

            var mensajeValidacion = _citaService.RegistrarCita(citaViewModel.ConvertirACita());

            if (mensajeValidacion is not null)
            {
                ModelState.AddModelError(string.Empty, mensajeValidacion);
                CargarDatos();
                return View(citaViewModel);
            }

            TempData["Mensaje"] = "Cita registrada correctamente.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Modificar(int id)
        {
            var cita = _citaService.ObtenerCitaPorId(id);

            if (cita is null)
            {
                return NotFound();
            }

            CargarDatos();
            return View(CitaViewModel.DesdeCita(cita));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Modificar(CitaViewModel citaViewModel)
        {
            if (!ModelState.IsValid)
            {
                CargarDatos();
                return View(citaViewModel);
            }

            var mensajeValidacion = _citaService.ModificarCita(citaViewModel.ConvertirACita());

            if (mensajeValidacion is not null)
            {
                ModelState.AddModelError(string.Empty, mensajeValidacion);
                CargarDatos();
                return View(citaViewModel);
            }

            TempData["Mensaje"] = "Cita modificada correctamente.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Borrar(int id)
        {
            _citaService.BorrarCita(id);
            TempData["Mensaje"] = "Cita borrada correctamente.";
            return RedirectToAction(nameof(Index));
        }

        private void CargarDatos()
        {
            ViewBag.Clientes = _clienteService.ObtenerClientes();
            ViewBag.Vehiculos = _vehiculoService.ObtenerVehiculos();
        }
    }
}