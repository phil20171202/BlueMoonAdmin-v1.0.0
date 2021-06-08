﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models;

namespace BlueMoonAdmin.Controllers
{
    public class LeadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Leads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Leads.ToListAsync());
        }

        // GET: Leads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leads = await _context.Leads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leads == null)
            {
                return NotFound();
            }

            return View(leads);
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
        public async Task<IActionResult> Create([Bind("Id,CompanyName,ContactName,EmailAddress,OfficeAddress,AddressLine,CityRegion,PostCode,TelephoneNumber,MobileNumber,WebAddress,LeadSince")] Leads leads)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leads);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leads);
        }

        // GET: Leads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leads = await _context.Leads.FindAsync(id);
            if (leads == null)
            {
                return NotFound();
            }
            return View(leads);
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
                    _context.Update(leads);
                    await _context.SaveChangesAsync();
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

            var leads = await _context.Leads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leads == null)
            {
                return NotFound();
            }

            return View(leads);
        }

        // POST: Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leads = await _context.Leads.FindAsync(id);
            _context.Leads.Remove(leads);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadsExists(int id)
        {
            return _context.Leads.Any(e => e.Id == id);
        }
    }
}
