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
    public class ToDoListController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ToDoListController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ToDoViewModel objList = new ToDoViewModel();
            objList.Tasks = _db.ToDoListItems;         
            objList.TaskOverdueCount = _db.ToDoListItems.Where(c => c.ToDoDueDate > DateTime.Now && c.Completed == false).Count();
            objList.TaskCompleteCount = _db.ToDoListItems.Where(c => c.ToDoDueDate > DateTime.Now.AddDays(-30) && c.Completed == true).Count();

            // completed is currenlty unused
            objList.TaskCompletedCount = _db.ToDoListItems.Where(c => c.ToDoDueDate > DateTime.Now.AddMonths(-12) && c.Completed == true).Count();

            objList.TaskPendingCount = _db.ToDoListItems.Where(c => c.ToDoDueDate > DateTime.Now && c.ToDoDueDate > DateTime.Now.AddDays(30) && c.Completed == false).Count();
            return View(objList);
        }
        public IActionResult Create()
        {

            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDoListItem obj)
        {
            _db.ToDoListItems.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET-Update
        public IActionResult UpdateToDoList(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ToDoListItems.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateToDoList(ToDoListItem obj)
        {
            if (ModelState.IsValid)
            {
                _db.ToDoListItems.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET-Delete
        public IActionResult DeleteToDoItem(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ToDoListItems.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteToDoItemPost(int? id)
        {
            var obj = _db.ToDoListItems.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ToDoListItems.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
       

