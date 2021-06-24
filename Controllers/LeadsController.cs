using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models;
using BlueMoonAdmin.Models.ViewModels;

namespace BlueMoonAdmin.Controllers
{
    public class LeadsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LeadsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Leads
        public async Task<IActionResult> Index()
        {
            return View(await _db.Leads.ToListAsync());
        }

        public IActionResult LeadsDashboard()
        {
            return View();
        }

        // GET: Leads/Details/5
        public async Task<IActionResult> View(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LeadsViewModel LeadsVM = new LeadsViewModel();
             LeadsVM.Leads = await _db.Leads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (LeadsVM.Leads == null)
            {
                return NotFound();
            }

            return View(LeadsVM);
        }

        // GET: Leads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Leads leads)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Add(leads);
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(leads);
        //}
        public IActionResult Create(Leads obj)
        {
            _db.Leads.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("index");
        }

        // GET: Leads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            LeadsViewModel LeadsVM = new LeadsViewModel();
            LeadsVM.Leads = await _db.Leads.FindAsync(id);
            if (LeadsVM.Leads == null)
            {
                return NotFound();
            }
            return View(LeadsVM);
        }

        // POST: Leads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,ContactName,EmailAddress,OfficeAddress,AddressLine,CityRegion,PostCode,TelephoneNumber,MobileNumber,WebAddress,LeadSince")] Leads leads)
        {
            if (id != leads.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(leads);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadsExists(leads.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leads);
        }

        // GET: Leads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            LeadsViewModel LeadsVM = new LeadsViewModel();
            LeadsVM.Leads = await _db.Leads
                .FirstOrDefaultAsync(m => m.Id == id);

            if (LeadsVM.Leads == null)
            {
                return NotFound();
            }

            return View(LeadsVM);
        }

        // POST: Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leads = await _db.Leads.FindAsync(id);
            _db.Leads.Remove(leads);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadsExists(int id)
        {
            return _db.Leads.Any(e => e.Id == id);
        }


        public async Task<IActionResult> Convert(int id)
        {
            // Currently there the lead is not being deleted.
            if (ModelState.IsValid)
            {
                Leads CurrentLead = await _db.Leads.FirstAsync(c => c.Id == id);
                Customers NewCust = new Customers();
                NewCust.CompanyName = CurrentLead.CompanyName;
                NewCust.ContactName = CurrentLead.ContactName;
                NewCust.AddressLine = CurrentLead.AddressLine;
                NewCust.CityRegion = CurrentLead.CityRegion;
                NewCust.CustomerSince = DateTime.Now;
                NewCust.EmailAddress = CurrentLead.EmailAddress;
                NewCust.MobileNumber = CurrentLead.MobileNumber;
                NewCust.OfficeAddress = CurrentLead.OfficeAddress;
                NewCust.PostCode = CurrentLead.PostCode;
                NewCust.TelephoneNumber = CurrentLead.TelephoneNumber;
                NewCust.Website = CurrentLead.Website;
                NewCust.WasLead = true;
                NewCust.Vat = CurrentLead.Vat;
                _db.Customers.Add(NewCust);
                TempData["Message"] = CurrentLead.CompanyName + " has been converted successfully!";
                _db.Leads.Remove(CurrentLead);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Customers");
            }
            return View();
        }
    }
}
