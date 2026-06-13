using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Primer avance desarrollado: listado general de clientes con sus telefonos.
        /// </summary>
        public IActionResult Index()
        {
            var clientes = _clienteService.ObtenerClientes();
            return View(clientes);
        }

        public IActionResult Detalle(int id)
        {
            // TODO: Companeros, desarrollar el detalle de un cliente especifico.
            return View();
        }

        public IActionResult Registrar()
        {
            // TODO: Companeros, desarrollar el formulario para registrar cliente y N telefonos.
            return View();
        }

        public IActionResult Modificar(int id)
        {
            // TODO: Companeros, desarrollar la modificacion de datos y telefonos del cliente.
            return View();
        }

        public IActionResult Borrar(int id)
        {
            // TODO: Companeros, desarrollar la confirmacion y borrado del cliente con sus telefonos.
            return View();
        }
    }
}
