﻿using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models;
using Microsoft.AspNetCore.Mvc;
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



        public IActionResult Index()
        {

            IEnumerable<Customers> objList = _db.Customers;
            return View(objList);
        }

        public IActionResult CreateCustomer()
        {

            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCustomer(Customers obj)
        {
            _db.Customers.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET-Update
        public IActionResult UpdateCustomer(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Customers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCustomer(Customers obj)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


    }

}
