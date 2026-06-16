using Microsoft.AspNetCore.Mvc;
using Practica_Evaluada_1.Models;
using Practica_Evaluada_1.Services;

namespace Practica_Evaluada_1.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            var clientes = _clienteService.ObtenerClientes();
            return View(clientes);
        }

        public IActionResult Detalle(int id)
        {
            var cliente = _clienteService.ObtenerClientePorId(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        public IActionResult Registrar()
        {
            return View(new ClienteViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(clienteViewModel);
            }

            _clienteService.RegistrarCliente(clienteViewModel.ConvertirACliente());
            TempData["Mensaje"] = "Cliente registrado correctamente.";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Modificar(int id)
        {
            var cliente = _clienteService.ObtenerClientePorId(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return View(ClienteViewModel.DesdeCliente(cliente));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Modificar(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(clienteViewModel);
            }

            _clienteService.ModificarCliente(clienteViewModel.ConvertirACliente());
            TempData["Mensaje"] = "Cliente modificado correctamente.";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Borrar(int id)
        {
            var cliente = _clienteService.ObtenerClientePorId(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarBorrado(int id)
        {
            _clienteService.BorrarCliente(id);
            TempData["Mensaje"] = "Cliente borrado correctamente.";

            return RedirectToAction(nameof(Index));
        }
    }
}
