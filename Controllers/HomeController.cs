using BlueMoonAdmin.Models;
using BlueMoonAdmin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BlueMoonAdmin.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployyeService employyeService;

        public HomeController(ILogger<HomeController> logger, IEmployyeService employyeService)
        {
            _logger = logger;
            this.employyeService = employyeService;
        }

        public IActionResult Index()
        {
            var empleados = employyeService.GetAll();
            return View(empleados);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult Charts()
        {
            return View();
        }

        public IActionResult Tables()
        {
            var empleados = employyeService.GetAll();
            return View(empleados);
        }

        public IActionResult _401()
        {
            return View();
        }

        public IActionResult _404()
        {
            return View();
        }

        public IActionResult _500()
        {
            return View();
        }

        public IActionResult LayoutStatic()
        {
            return View();
        }

        public IActionResult SidenavLight()
        {
            return View();
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
