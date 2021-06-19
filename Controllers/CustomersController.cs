using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models;
using BlueMoonAdmin.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomersController(ApplicationDbContext db)
        {
            _db = db;
        }
        #region Customer

        public async Task<IActionResult> Index()
        {

            IEnumerable<Customers> objList = await _db.Customers.ToListAsync();
            

            return View(objList);
        }

        public async Task<IActionResult> CustomerDashboard()
        {
            var CustomerVM = new CustomerViewModel();
            CustomerVM.CustomerCount = await _db.Customers.CountAsync();
            return View(CustomerVM);
        }

        public async Task<IActionResult> ViewCustomer(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CustomerVM = new CustomerViewModel();
            CustomerVM.Customers = _db.Customers.SingleOrDefault(c => c.Id == id);
            CustomerVM.ServiceCustomer = _db.ServiceCustomers.SingleOrDefault(c => c.CustomerId == id);
            CustomerVM.Contacts = await _db.Contacts.Where(c => c.CustomerId == id).ToListAsync();            
            CustomerVM.Addresses = await _db.Addresses.Where(c => c.CustomerId == id).ToListAsync();
            CustomerVM.Notes = await _db.Notes.Where(c => c.CustomerId == id).ToListAsync();
            if (CustomerVM == null)
            {
                return NotFound();
            }
            return View(CustomerVM);          
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }

        // Saves new customer to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCustomer(Customers obj)
        {           
            _db.Customers.Add(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction("index");
        }
        // Loads selected customer details into update customer view
        public async Task<IActionResult> UpdateCustomer(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = await _db.Customers.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // Saves new customer to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCustomer(Customers obj)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Update(obj);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        //View customer you are about to delete
        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = await _db.Customers.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // Delete customer from database, this is now actioned from DeleteConfirmation screen.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomer(Customers obj)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Remove(obj);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #endregion

    }

}
