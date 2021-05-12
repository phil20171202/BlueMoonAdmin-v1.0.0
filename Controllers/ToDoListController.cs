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
            IEnumerable<ToDoListItem> objList = _db.ToDoListItems;
            return View(objList);
        }

        // GET-Create
        public IActionResult Create()
        {
       
            ToDoCategoryViewModel toDoCategoryViewModel = new ToDoCategoryViewModel()
            {
                Category = new ToDoListItem(),
                TypeDropDown = _db.CategoryTypes.Select(i => new SelectListItem()
                {
                    Text = i.CategoryTypeName,
                    Value = i.CategoryTypeName
                })
            };

            return View(toDoCategoryViewModel);
        }
        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDoCategoryViewModel obj)
        {
            //_db.CategoryTypes.Add(obj.Category); -- this needs sorting
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
