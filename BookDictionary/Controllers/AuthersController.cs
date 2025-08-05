using BookDictionary.Data;
using BookDictionary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookDictionary.Controllers
{
    public class AuthersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Authers
                .Include(c => c.Country);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auther = await _context.Authers
                .Include(b => b.Books)
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auther == null)
            {
                return NotFound();
            }

            return View(auther);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CountryId")] Auther auther)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auther);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name", auther.CountryId);
            return View(auther);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auther = await _context.Authers.FindAsync(id);
            if (auther == null)
            {
                return NotFound();
            }

            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name", auther.CountryId);
            return View(auther);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Country")] Auther auther)
        {
            if (id != auther.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auther);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutherExists(auther.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name", auther.CountryId);
            return View(auther);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auther = await _context.Authers
                .Include(b => b.Books)
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auther == null)
            {
                return NotFound();
            }

            return View(auther);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auther = await _context.Authers.FindAsync(id);
            if (auther != null)
            {
                _context.Authers.Remove(auther);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutherExists(int id)
        {
            return _context.Authers.Any(e => e.Id == id);
        }
    }
}
