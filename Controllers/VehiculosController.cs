using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practica_Evaluada_1.Models;
using Practica_Evaluada_1.Services;

namespace Practica_Evaluada_1.Controllers
{
    public class VehiculosController : Controller
    {
        private readonly IVehiculoService _vehiculoService;
        private readonly IClienteService _clienteService;

        public VehiculosController(IVehiculoService vehiculoService, IClienteService clienteService)
        {
            _vehiculoService = vehiculoService;
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            var vehiculos = _vehiculoService.ObtenerVehiculos();
            return View(vehiculos);
        }

        public IActionResult Registrar()
        {
            CargarClientes();
            return View(new VehiculoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(VehiculoViewModel vehiculoViewModel)
        {
            if (!ModelState.IsValid)
            {
                CargarClientes();
                return View(vehiculoViewModel);
            }

            var mensajeValidacion = _vehiculoService.RegistrarVehiculo(vehiculoViewModel.ConvertirAVehiculo());

            if (mensajeValidacion is not null)
            {
                ModelState.AddModelError(string.Empty, mensajeValidacion);
                CargarClientes();
                return View(vehiculoViewModel);
            }

            TempData["Mensaje"] = "Vehiculo registrado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Modificar(int id)
        {
            var vehiculo = _vehiculoService.ObtenerVehiculoPorId(id);

            if (vehiculo is null)
            {
                return NotFound();
            }

            CargarClientes();
            return View(VehiculoViewModel.DesdeVehiculo(vehiculo));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Modificar(VehiculoViewModel vehiculoViewModel)
        {
            if (!ModelState.IsValid)
            {
                CargarClientes();
                return View(vehiculoViewModel);
            }

            var mensajeValidacion = _vehiculoService.ModificarVehiculo(vehiculoViewModel.ConvertirAVehiculo());

            if (mensajeValidacion is not null)
            {
                ModelState.AddModelError(string.Empty, mensajeValidacion);
                CargarClientes();
                return View(vehiculoViewModel);
            }

            TempData["Mensaje"] = "Vehiculo modificado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Borrar(int id)
        {
            _vehiculoService.BorrarVehiculo(id);
            TempData["Mensaje"] = "Vehiculo borrado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        private void CargarClientes()
        {
            ViewBag.Clientes = _clienteService.ObtenerClientes()
                .Select(cliente => new SelectListItem
                {
                    Value = cliente.Id.ToString(),
                    Text = $"{cliente.Cedula} - {cliente.NombreCompleto}"
                })
                .ToList();
        }
    }
}
