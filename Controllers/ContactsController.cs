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
        private readonly ApplicationDbContext _dbContact;

        public ContactsController(ApplicationDbContext db)
        {
            _dbContact = db;
        }
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
    }
}
