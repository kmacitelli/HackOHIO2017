using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HackOHIO2017.Data;
using HackOHIO2017.Models;

namespace HackOHIO.Controllers
{
    public class InvestorController : Controller
    {
        private readonly BusinessDbContext _context;

        public InvestorController(BusinessDbContext context)
        {
            _context = context;
        }

        // GET: Investor
        public async Task<IActionResult> Index()
        {
            var businessDbContext = _context.Investor.Include(i => i.City);
            return View(await businessDbContext.ToListAsync());
        }

        // GET: Investor/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investor = await _context.Investor
                .Include(i => i.City)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (investor == null)
            {
                return NotFound();
            }

            return View(investor);
        }

        // GET: Investor/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.City, "Id", "PrettyName");
            return View();
        }

        // POST: Investor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Phone,Description,Address,Zip,CityId,Site")] Investor investor)
        {
            if (ModelState.IsValid)
            {
                investor.Id = Guid.NewGuid();
                _context.Add(investor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.City, "Id", "PrettyName", investor.CityId);
            return View(investor);
        }

        // GET: Investor/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investor = await _context.Investor.SingleOrDefaultAsync(m => m.Id == id);
            if (investor == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "Id", "PrettyName", investor.CityId);
            return View(investor);
        }

        // POST: Investor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Email,Phone,Description,Address,Zip,CityId,Site")] Investor investor)
        {
            if (id != investor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestorExists(investor.Id))
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
            ViewData["CityId"] = new SelectList(_context.City, "Id", "PrettyName", investor.CityId);
            return View(investor);
        }

        // GET: Investor/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investor = await _context.Investor
                .Include(i => i.City)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (investor == null)
            {
                return NotFound();
            }

            return View(investor);
        }

        // POST: Investor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var investor = await _context.Investor.SingleOrDefaultAsync(m => m.Id == id);
            _context.Investor.Remove(investor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestorExists(Guid id)
        {
            return _context.Investor.Any(e => e.Id == id);
        }
    }
}
