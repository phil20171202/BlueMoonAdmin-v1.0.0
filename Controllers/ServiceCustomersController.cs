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
        //number of days to be clasified as upcoming services
        public int days = 30;

        private readonly ApplicationDbContext _db;

        public ServiceCustomersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult ServiceContractManager()
        {
            
            

            ServiceViewModel ServiceManagement = new ServiceViewModel();
            ServiceManagement.CustomerCombineService = from c in _db.Customers
                                   join sc in _db.ServiceCustomers on c.Id equals sc.CustomerId into sc2
                                   from sc in sc2.DefaultIfEmpty()
                                   where sc.Service
                                   select new ServiceViewModel { customersVm = c, ServiceCustomer = sc };

            ServiceManagement.serviced = _db.ServiceHistory.Where(c=> c.Id >0).Count();
            ServiceManagement.OverDue = ServiceManagement.CustomerCombineService.Where(c => c.ServiceCustomer.NextServiceDate < DateTime.Now).Count();
            ServiceManagement.Upcoming = ServiceManagement.CustomerCombineService.Where(c => c.ServiceCustomer.NextServiceDate < DateTime.Now.AddDays(days)).Count() - ServiceManagement.OverDue  ;
            
             return View(ServiceManagement);
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


        public IActionResult AddService(int id)
        {
            var ServiceVM = new ServiceHistory();
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                ServiceVM.ServiceId = id;

            }
            if (ServiceVM == null)
            {
                return NotFound();
            }
            return View(ServiceVM);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddService(ServiceHistory obj)
        {
            int id = obj.ServiceId;
            
            var ServiceCust = new ServiceCustomer();
            ServiceCust = _db.ServiceCustomers.Find(id);
            if(obj.ServiceDate == DateTime.MinValue)
            {
                obj.ServiceDate = DateTime.Now;
            }
            ServiceCust.LastServiceDate = obj.ServiceDate;
            ServiceCust.NextServiceDate = obj.ServiceDate.AddMonths(6);
            _db.ServiceCustomers.Update(ServiceCust);
            _db.ServiceHistory.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("UpdateServiceContract", "ServiceCustomers", new { id });
        }



    }
}
