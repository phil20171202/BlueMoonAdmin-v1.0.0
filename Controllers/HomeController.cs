using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models;
using BlueMoonAdmin.Models.ViewModels;
using BlueMoonAdmin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;

namespace BlueMoonAdmin.Controllers
{

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //private readonly ILogger<HomeController> _logger;
        //private readonly IEmployyeService employyeService;

        //public HomeController(ILogger<HomeController> logger, IEmployyeService employyeService)
        //{
        //    _logger = logger;
        //    this.employyeService = employyeService;
        //}

        public IActionResult Index()
        {
            //var empleados = employyeService.GetAll();
            //return View();

            DashboardViewModel DBView = new DashboardViewModel();
            
            DBView.toDoList = _db.ToDoListItems;
            DBView.toDoListCount = _db.ToDoListItems.Count();
            DBView.TaskOverdueCount = _db.ToDoListItems.Where(c => c.ToDoDueDate > DateTime.Now && c.Completed == false ).Count();
            DBView.TaskCompleteCount = _db.ToDoListItems.Where(c => c.ToDoDueDate > DateTime.Now.AddDays(-30) && c.Completed == true).Count();
            DBView.TaskCompletedCount = _db.ToDoListItems.Where(c => c.ToDoDueDate > DateTime.Now.AddMonths(-12) && c.Completed == true).Count();

            return View(DBView);
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

        //public IActionResult Tables()
        //{
        //    var empleados = employyeService.GetAll();
        //    return View(empleados);
        //}

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
