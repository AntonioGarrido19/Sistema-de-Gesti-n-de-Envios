using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentacion.Models;
using Presentacion.Models.Usuarios;

namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            DatoUsuarioViewModel usuarioViewModel = new DatoUsuarioViewModel() { Nombre="jjj",Id=1};
            List<DatoUsuarioViewModel> listado =new List<DatoUsuarioViewModel>();
            listado.Add(usuarioViewModel);
            ViewBag.Usuario = new SelectList(listado, "Id", "Nombre");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
