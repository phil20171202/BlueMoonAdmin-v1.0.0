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
            obj.Notes = _db.Notes.Where(c => c.CustomerId == CustomerID).ToList();
            
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
            var ServiceVM = new Notes();
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                ServiceVM.CustomerId = id;

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
        public IActionResult AddService(Notes obj)
        {
            obj.Category = "Service Notes";
            int customerID = obj.CustomerId;
            var record = _db.ServiceCustomers.FirstOrDefault(c=> c.CustomerId == customerID);
            int ServiceID = record.Id;


            var ServiceCust = new ServiceCustomer();
            ServiceCust = _db.ServiceCustomers.Find(ServiceID);

            if(obj.Date == DateTime.MinValue)
            {
                obj.Date = DateTime.Now;
            }
            ServiceCust.LastServiceDate = obj.Date;
            ServiceCust.NextServiceDate = obj.Date.AddMonths(6);
            _db.ServiceCustomers.Update(ServiceCust);
            _db.Notes.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("UpdateServiceContract", new { ServiceCust.Id });
        }

        #region Create Note

        public IActionResult CreateServiceNotes(int id)
        {
            var ServiceVM = new ServiceViewModel();
            ServiceVM.Note = new Notes();
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                ServiceVM.Note.CustomerId = id;
            }
            if (ServiceVM == null)
            {
                return NotFound();
            }
            return View(ServiceVM);
        }

        // Saves new note into the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateServiceNotes(ServiceViewModel obj)
        {
            var ServiceCust = new ServiceCustomer();
            ServiceCust = _db.ServiceCustomers.Find(obj.Note.CustomerId);


            obj.Note.Category = "Contract Notes";
            _db.Notes.Add(obj.Note);
            _db.SaveChanges();
            return RedirectToAction("UpdateServiceContract", new { ServiceCust.Id  });
        }


        #endregion

    }
}
