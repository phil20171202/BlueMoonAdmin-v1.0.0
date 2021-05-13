using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Controllers
{
    public class ServiceCustomersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ServiceCustomersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult ServiceContractManager()
        {
            IEnumerable<ServiceCustomer> objList = _db.ServiceCustomers;
            return View(objList);
        }

        //
        public IActionResult CreateServiceContract()
        {

            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateServiceContract(ServiceCustomer obj)
        {
            _db.ServiceCustomers.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("ServiceContractManager");
        }
    }
}
