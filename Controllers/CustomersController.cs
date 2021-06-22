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
        #region Database Connection
        private readonly ApplicationDbContext _db;
        public CustomersController(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion
        #region Views
        // Load customer list into a table
        public async Task<IActionResult> Index()
        {
            // reads message sent from previous page
            ViewBag.Message = TempData["Message"];        
            IEnumerable<Customers> objList = await _db.Customers.ToListAsync();
            return View(objList);
        }
        // Load dashboard and display customer count
        public async Task<IActionResult> CustomerDashboard()
        {
            var CustomerVM = new CustomerViewModel();
            CustomerVM.CustomerCount = await _db.Customers.CountAsync();
            return View(CustomerVM);
        }
        //View selected customer details
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
        //Display create customer page
        public IActionResult CreateCustomer()
        {
            return View();
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
        //View the customer you are about to delete
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
        #endregion
        #region HTTP Posts
        // Saves new customer to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCustomer(Customers obj)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                _db.Customers.Add(obj);
                await _db.SaveChangesAsync();
                TempData["Message"] = obj.CompanyName + " has been created successfully!";
                ViewBag.SuccessMessage = obj.CompanyName + " has been created successfully!";
                return RedirectToAction("index");
            }
            return View();
        }
        // Saves changes to customer to database
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
