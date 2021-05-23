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
    public class ServiceCustomersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ServiceCustomersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult ServiceContractManager()
        {
           
            var ServiceVM = new ServiceViewModel();
            
            ServiceVM.ServiceCustomers = _db.ServiceCustomers.ToList();
            if (ServiceVM == null)
            {
                return NotFound();
            }

            ServiceVM.Overdue = ServiceVM.ServiceCustomers.Where(c => c.NextServiceDate < DateTime.Now).Count();


            return View(ServiceVM);

        }

        //
        #region Create Contract
        public IActionResult CreateServiceContract(int id)
        {
            var ContractVM = new ServiceCustomer();
            if (id == 0 )
            {
                return NotFound();
            }
            else
            {
                ContractVM.CustomerId = id;
                                
            }
            if (ContractVM == null)
            {
                return NotFound();
            }
            return View(ContractVM);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateServiceContract(ServiceCustomer obj)
        {
            int id = obj.CustomerId;
            _db.ServiceCustomers.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("ViewCustomer", "Customers", new { id });
        }
        #endregion

        #region Edit contract

        public IActionResult UpdateServiceContract(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            ServiceCustomer obj = _db.ServiceCustomers.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Saves new contact to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateServiceContract(ServiceCustomer obj)
        {
            if (ModelState.IsValid)
            {
                int id = obj.CustomerId;
                _db.ServiceCustomers.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("ViewCustomer", "Customers", new { id });
            }
            return View(obj);
        }
        #endregion

      


    }
}
