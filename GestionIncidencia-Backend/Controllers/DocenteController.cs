using Microsoft.AspNetCore.Mvc;

namespace GestionIncidencia_Backend.Controllers
{
    public class DocenteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
