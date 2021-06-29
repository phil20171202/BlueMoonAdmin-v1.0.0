using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models;
using BlueMoonAdmin.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Controllers
{
    public class MonthlySalesController : Controller
    {
        
        private readonly ApplicationDbContext _db;
    
        public MonthlySalesController (ApplicationDbContext db)
        {
            _db = db;
        }
         public IActionResult MonthlySales()
        {
            // commented out as not used yet and was returning a view error
            //IEnumerable<MonthlySales> objList = _db.MonthlySalesFigure;
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MonthlySales obj)
        {
            _db.MonthlySalesFigure.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("MonthlySales");
        }
    }
}
