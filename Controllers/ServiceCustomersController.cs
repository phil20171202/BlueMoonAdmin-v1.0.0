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
            List<Customers> customer = new List<Customers>();
            List<ServiceCustomer> studentAdditionalInfo = new List<ServiceCustomer>();
            var studentViewModel = from c in _db.Customers
                                   join sc in _db.ServiceCustomers on c.Id equals sc.CustomerId into sc2
                                   from sc in sc2.DefaultIfEmpty()
                                   where sc.Service
                                   select new ServiceViewModel { customersVm = c, ServiceCustomer = sc };
            return View(studentViewModel);
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
            ServiceViewModel obj = new ServiceViewModel();
            obj.ServiceCustomer = _db.ServiceCustomers.Find(id);
            int CustomerID = obj.ServiceCustomer.CustomerId;
            obj.Notes = _db.Notes.Where(c => c.Category == "Service" & c.CustomerId == CustomerID).ToList();
            obj.appointments = _db.Appointments.Where(c => c.CustomerServiceId == id).ToList();
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Saves new contact to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateServiceContract(ServiceViewModel obj)
        {
            if (ModelState.IsValid)
            {
               // int id = obj.ServiceCustomer.id;
                _db.ServiceCustomers.Update(obj.ServiceCustomer);
                _db.SaveChanges();
                return RedirectToAction("ServiceContractManager", "ServiceCustomers");
            }
            return View(obj);
        }
        #endregion

      


    }
}
