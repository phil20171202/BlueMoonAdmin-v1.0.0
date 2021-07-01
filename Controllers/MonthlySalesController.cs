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

            // Dont think you are usign this...   IEnumerable<MonthlySales> objList = _db.MonthlySalesFigure;
            int CurrentYear = DateTime.Now.Year;
            int LastYear = DateTime.Now.Year - 1;
            MonthlySalesViewModel DBView = new();
            DBView.MonthlySales = _db.MonthlySalesFigure.Where(s => s.Date.Year == CurrentYear || s.Date.Year == LastYear).ToList();
            DBView.YearToDate = DBView.MonthlySales.Sum(c => c.Amount);

            if (DBView.MonthlySales.FirstOrDefault(c => c.Date.Month == DateTime.Now.AddMonths(-1).Month) != null)
            {
                DBView.LastMonth = DBView.MonthlySales.FirstOrDefault(c => c.Date.Month == DateTime.Now.AddMonths(-1).Month).Amount;
            }
            else
            {
                DBView.LastMonth = 0;
            }
            // Generating the string to populate the year to date sales chart
            DBView.CurrectYear = new string[12];
            DBView.LastYear = new string[12];
            foreach (var item in DBView.MonthlySales.Where(c=> c.Date.Year == CurrentYear))
            {               
                DBView.CurrectYear[item.Date.Month - 1] = item.Amount.ToString();
            }
            foreach (var item in DBView.MonthlySales.Where(c => c.Date.Year == LastYear))
            {
                DBView.LastYear[item.Date.Month - 1] = item.Amount.ToString();
            }
            ViewBag.Current = string.Join(",", DBView.CurrectYear);
            ViewBag.LastYear = string.Join(",", DBView.LastYear);
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
