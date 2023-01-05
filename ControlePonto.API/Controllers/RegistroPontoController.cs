using Microsoft.AspNetCore.Mvc;

namespace ControlePonto.API.Controllers
{
    public class RegistroPontoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
