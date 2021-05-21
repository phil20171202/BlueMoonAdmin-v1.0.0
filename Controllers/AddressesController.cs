using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Controllers
{
    public class AddressesController : Controller
    {

        #region Database connect
        private readonly ApplicationDbContext _dbAddress;

        public AddressesController(ApplicationDbContext db)
        {
            _dbAddress = db;
        }
        #endregion

        #region Create Address

        public IActionResult CreateAddress(int id)
        {
            var AddressVM = new Addresses();
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                AddressVM.CustomerId = id;
            }
            if (AddressVM == null)
            {
                return NotFound();
            }
            return View(AddressVM);
        }

        // Saves new note into the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAddress(Addresses obj)
        {
            int id = obj.CustomerId;
            _dbAddress.Addresses.Add(obj);
            _dbAddress.SaveChanges();
            return RedirectToAction("ViewCustomer", "Customers", new { id });
        }


        #endregion
        #region View Address

        public IActionResult ViewAddress(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Addresses Address = _dbAddress.Addresses.SingleOrDefault(c => c.Id == id);
            if (Address == null)
            {
                return NotFound();
            }
            return View(Address);
        }
        #endregion
        #region Delete Address
        public IActionResult DeleteAddress(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _dbAddress.Addresses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // Delete address from database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAddress(Addresses obj)
        {
            if (ModelState.IsValid)
            {
                int id = obj.CustomerId;
                _dbAddress.Addresses.Remove(obj);
                _dbAddress.SaveChanges();
                return RedirectToAction("ViewCustomer", "Customers", new { id });
            }
            return View(obj);
        }
        #endregion
        #region Edit (update) Address
        public IActionResult UpdateAddress(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Addresses obj = _dbAddress.Addresses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Saves new contact to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAddress(Addresses obj)
        {
            if (ModelState.IsValid)
            {
                int id = obj.CustomerId;
                _dbAddress.Addresses.Update(obj);
                _dbAddress.SaveChanges();
                return RedirectToAction("ViewCustomer", "Customers", new { id });
            }
            return View(obj);
        }
        #endregion


    }
}
