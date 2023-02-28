using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;

namespace Restaurant.Controllers
{
    public class RestTabsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestTabsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RestTabs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Table.ToListAsync());
        }

        // GET: RestTabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            var restTabs = await _context.Table
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restTabs == null)
            {
                return NotFound();
            }

            return View(restTabs);
        }

        // GET: RestTabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RestTabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Seats,isSmoking")] RestTabs restTabs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restTabs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restTabs);
        }

        // GET: RestTabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            var restTabs = await _context.Table.FindAsync(id);
            if (restTabs == null)
            {
                return NotFound();
            }
            return View(restTabs);
        }

        // POST: RestTabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Seats,isSmoking")] RestTabs restTabs)
        {
            if (id != restTabs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restTabs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestTabsExists(restTabs.Id))
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
            return View(restTabs);
        }

        // GET: RestTabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            var restTabs = await _context.Table
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restTabs == null)
            {
                return NotFound();
            }

            return View(restTabs);
        }

        // POST: RestTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Table == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Table'  is null.");
            }
            var restTabs = await _context.Table.FindAsync(id);
            if (restTabs != null)
            {
                _context.Table.Remove(restTabs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestTabsExists(int id)
        {
          return _context.Table.Any(e => e.Id == id);
        }
    }
}
