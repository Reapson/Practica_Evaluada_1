using Microsoft.AspNetCore.Mvc;

namespace Practica_Evaluada_1.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        public IActionResult Modificar()
        {
            return View();
        }
    }
}
