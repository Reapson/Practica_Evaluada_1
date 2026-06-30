using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practica_Evaluada_1.Services;
using Practica_Evaluada_1.Models;

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
            return View(_citaService.ObtenerCitas());
        }

        [HttpGet]
        public IActionResult Modificar(int id)
        {
            var cita = _citaService.ObtenerCitaPorId(id);

            if (cita == null)
                return RedirectToAction(nameof(Index));

            ViewBag.Clientes = new SelectList(
                _clienteService.ObtenerClientes(),
                "Id",
                "NombreCompleto");

            ViewBag.Vehiculos = new SelectList(
                _vehiculoService.ObtenerVehiculos(),
                "Id",
                "Placa");

            return View(cita);
        }

        [HttpPost]
        public IActionResult Modificar(Cita cita)
        {
            _citaService.ModificarCita(cita);

            TempData["Success"] = "Cita modificada correctamente";

            return RedirectToAction(nameof(Index));
        }
    }
}