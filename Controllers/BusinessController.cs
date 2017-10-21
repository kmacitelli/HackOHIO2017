using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HackOHIO2017.Data;
using HackOHIO2017.Models;

namespace HackOHIO.Controllers_
{
    public class BusinessController : Controller
    {
        private readonly BusinessDbContext _context;

        public BusinessController(BusinessDbContext context)
        {
            _context = context;
        }

        // GET: Business
        public async Task<IActionResult> Index()
        {
            var businessDbContext = _context.Business.Include(b => b.City);
            return View(await businessDbContext.ToListAsync());
        }

        // GET: Business/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var business = await _context.Business
                .Include(b => b.City)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (business == null)
            {
                return NotFound();
            }

            return View(business);
        }

        // GET: Business/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Id");
            return View();
        }

        // POST: Business/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,State,Zip,CityId")] Business business)
        {
            if (ModelState.IsValid)
            {
                business.Id = Guid.NewGuid();
                _context.Add(business);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Id", business.CityId);
            return View(business);
        }

        // GET: Business/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var business = await _context.Business.SingleOrDefaultAsync(m => m.Id == id);
            if (business == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Id", business.CityId);
            return View(business);
        }

        // POST: Business/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Address,State,Zip,CityId")] Business business)
        {
            if (id != business.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(business);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessExists(business.Id))
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
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Id", business.CityId);
            return View(business);
        }

        // GET: Business/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var business = await _context.Business
                .Include(b => b.City)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (business == null)
            {
                return NotFound();
            }

            return View(business);
        }

        // POST: Business/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var business = await _context.Business.SingleOrDefaultAsync(m => m.Id == id);
            _context.Business.Remove(business);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessExists(Guid id)
        {
            return _context.Business.Any(e => e.Id == id);
        }
    }
}
