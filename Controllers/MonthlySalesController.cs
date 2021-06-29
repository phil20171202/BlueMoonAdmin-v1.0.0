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

            IEnumerable<MonthlySales> objList = _db.MonthlySalesFigure;

            MonthlySalesViewModel DBView = new();
            DBView.MonthlySales = _db.MonthlySalesFigure.Where(s => s.Date.Year == DateTime.Now.Year).ToList();
            DBView.YearToDate = DBView.MonthlySales.Sum(c => c.Amount);
            DBView.LastMonth = DBView.MonthlySales.FirstOrDefault(c => c.Date.Month == DateTime.Now.AddMonths(-1).Month).Amount;
            // Generating the string to populate the year to date sales chart
            foreach (var item in DBView.MonthlySales)
            {
                DBView.ChartSales += item.Amount.ToString() + ",";
            }

            return View(DBView);
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
