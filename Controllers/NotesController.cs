using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Controllers
{
    public class NotesController : Controller
    {
        #region Database connect
        private readonly ApplicationDbContext _dbNotes;

        public NotesController(ApplicationDbContext db)
        {
            _dbNotes = db;
        }
        #endregion

        #region Create Note

        public IActionResult CreateNotes(int id)
        {
            var NoteVM = new Notes();
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                NoteVM.CustomerId = id;
            }
            if (NoteVM == null)
            {
                return NotFound();
            }
            return View(NoteVM);
        }

        // Saves new note into the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNotes(Notes obj)
        {
            int id = obj.CustomerId;
            _dbNotes.Notes.Add(obj);
            _dbNotes.SaveChanges();
            return RedirectToAction("ViewCustomer", "Customers", new { id });
        }


        #endregion
        #region View note

        public IActionResult ViewNotes(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Notes Notes = _dbNotes.Notes.SingleOrDefault(c => c.Id == id);
            if (Notes == null)
            {
                return NotFound();
            }
            return View(Notes);
        }
        #endregion
        #region Delete Note
        public IActionResult DeleteNotes(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _dbNotes.Notes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // Delete contact from database, this is now actioned from DeleteConfirmation screen.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteNotes(Notes obj)
        {
            if (ModelState.IsValid)
            {
                int id = obj.CustomerId;
                _dbNotes.Notes.Remove(obj);
                _dbNotes.SaveChanges();
                return RedirectToAction("ViewCustomer", "Customers", new { id });
            }
            return View(obj);
        }
        #endregion
        #region Edit (update) notes
        public IActionResult UpdateNotes(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Notes obj = _dbNotes.Notes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Saves new contact to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateNotes(Notes obj)
        {
            if (ModelState.IsValid)
            {
                int id = obj.CustomerId;
                _dbNotes.Notes.Update(obj);
                _dbNotes.SaveChanges();
                return RedirectToAction("ViewCustomer", "Customers", new { id });
            }
            return View(obj);
        }
        #endregion
    }
}
