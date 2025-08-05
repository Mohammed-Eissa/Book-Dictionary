using BookDictionary.Data;
using BookDictionary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookDictionary.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Book_Genres)
                    .ThenInclude(bg => bg.Genre);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Book_Genres)
                .ThenInclude(bg => bg.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authers, "Id", "Name");
            ViewData["Genres"] = _context.Genres.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,AuthorId")] Book book, int[] selectedGenres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();

                if (selectedGenres != null)
                {
                    foreach (var genreId in selectedGenres)
                    {
                        _context.Book_Genres.Add(new Book_Genre { BookId = book.Id, GenreId = genreId });
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["AuthorId"] = new SelectList(_context.Authers, "Id", "Name", book.AuthorId);
            ViewData["Genres"] = _context.Genres.ToList();
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Book_Genres)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            ViewData["AuthorId"] = new SelectList(_context.Authers, "Id", "Name", book.AuthorId);
            ViewData["Genres"] = _context.Genres.ToList();
            ViewData["SelectedGenres"] = book.Book_Genres.Select(bg => bg.GenreId).ToList();

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,AuthorId")] Book book, int[] selectedGenres)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);

                    var existingBookGenres = _context.Book_Genres.Where(bg => bg.BookId == book.Id);
                    _context.Book_Genres.RemoveRange(existingBookGenres);

                    if (selectedGenres != null)
                    {
                        foreach (var genreId in selectedGenres)
                        {
                            _context.Book_Genres.Add(new Book_Genre { BookId = book.Id, GenreId = genreId });
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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

            ViewData["AuthorId"] = new SelectList(_context.Authers, "Id", "Name", book.AuthorId);
            ViewData["Genres"] = _context.Genres.ToList();
            ViewData["SelectedGenres"] = selectedGenres;
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Book_Genres)
                    .ThenInclude(bg => bg.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookGenres = _context.Book_Genres.Where(bg => bg.BookId == id);
                _context.Book_Genres.RemoveRange(bookGenres);

                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}