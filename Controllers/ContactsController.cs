using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Controllers.Api
{
    public class ContactsController : Controller
    {
        #region Database connect
        private readonly ApplicationDbContext _dbContact;

        public ContactsController(ApplicationDbContext db)
        {
            _dbContact = db;
        }
        #endregion

        #region Create contact

        public IActionResult CreateContact(int id)
        {
            var ContactVM = new Contacts();
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                ContactVM.CustomerId = id;
            }
            if (ContactVM == null)
            {
                return NotFound();
            }
            return View(ContactVM);
        }

        // Saves new contact into the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateContact(Contacts obj)
        {
            int id = obj.CustomerId;
            _dbContact.Contacts.Add(obj);
            _dbContact.SaveChanges();
            return RedirectToAction("ViewCustomer", "Customers", new { id});
        }


        #endregion

        #region Contact View
        public IActionResult ViewContact(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Contacts Contacts = _dbContact.Contacts.SingleOrDefault(c => c.Id == id);
            if (Contacts == null)
            {
                return NotFound();
            }
            return View(Contacts);
        }
        #endregion

        #region Edit (update) contact
        public IActionResult UpdateContact(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Contacts obj = _dbContact.Contacts.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Saves new contact to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateContact(Contacts obj)
        {
            if (ModelState.IsValid)
            {
                int id = obj.CustomerId;
                _dbContact.Contacts.Update(obj);
                _dbContact.SaveChanges();
                return RedirectToAction("ViewCustomer","Customers", new { id });
            }
            return View(obj);
        }
        #endregion

        #region Delete contact
        public IActionResult DeleteContact(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _dbContact.Contacts.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // Delete contact from database, this is now actioned from DeleteConfirmation screen.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteContact(Contacts obj)
        {
            if (ModelState.IsValid)
            {
                int id = obj.CustomerId;
                _dbContact.Contacts.Remove(obj);
                _dbContact.SaveChanges();
                return RedirectToAction("ViewCustomer", "Customers", new { id });
            }
            return View(obj);
        }
        #endregion
    }
}
