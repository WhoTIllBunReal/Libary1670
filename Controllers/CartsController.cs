using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libary1670.Data;
using Libary1670.Models;

namespace Libary1670.Controllers
{
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
              return _context.Kart != null ? 
                          View(await _context.Kart.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Kart'  is null.");
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kart == null)
            {
                return NotFound();
            }

            var kart = await _context.Kart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kart == null)
            {
                return NotFound();
            }

            return View(kart);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Quantity,Total")] Kart kart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kart);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kart == null)
            {
                return NotFound();
            }

            var kart = await _context.Kart.FindAsync(id);
            if (kart == null)
            {
                return NotFound();
            }
            return View(kart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Quantity,Total")] Kart kart)
        {
            if (id != kart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KartExists(kart.Id))
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
            return View(kart);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kart == null)
            {
                return NotFound();
            }

            var kart = await _context.Kart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kart == null)
            {
                return NotFound();
            }

            return View(kart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kart == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Kart'  is null.");
            }
            var kart = await _context.Kart.FindAsync(id);
            if (kart != null)
            {
                _context.Kart.Remove(kart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KartExists(int id)
        {
          return (_context.Kart?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
