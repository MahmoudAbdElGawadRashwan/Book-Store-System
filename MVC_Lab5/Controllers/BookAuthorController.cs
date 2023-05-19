using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Lab5.Models;

namespace MVC_Lab5.Controllers
{
    public class BookAuthorController : Controller
    {
        private readonly ITIDbContext _context = new ITIDbContext();

        //public BookAuthorController(ITIDbContext context)
        //{
        //    _context = context;
        //}

        // GET: BookAuthor
        public async Task<IActionResult> Index()
        {
            var iTIDbContext = _context.BookAuthor.Include(b => b.Author).Include(b => b.Book);
            return View(await iTIDbContext.ToListAsync());
        }

        // GET: BookAuthor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookAuthor == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthor
                .Include(b => b.Author)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            return View(bookAuthor);
        }

        // GET: BookAuthor/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId");
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
            return View();
        }

        // POST: BookAuthor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,AuthorId,Order")] BookAuthor bookAuthor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookAuthor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId", bookAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", bookAuthor.BookId);
            return View(bookAuthor);
        }

        // GET: BookAuthor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookAuthor == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthor.FindAsync(id);
            if (bookAuthor == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId", bookAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", bookAuthor.BookId);
            return View(bookAuthor);
        }

        // POST: BookAuthor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,AuthorId,Order")] BookAuthor bookAuthor)
        {
            if (id != bookAuthor.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookAuthorExists(bookAuthor.BookId))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId", bookAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", bookAuthor.BookId);
            return View(bookAuthor);
        }

        // GET: BookAuthor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookAuthor == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthor
                .Include(b => b.Author)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            return View(bookAuthor);
        }

        // POST: BookAuthor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookAuthor == null)
            {
                return Problem("Entity set 'ITIDbContext.BookAuthor'  is null.");
            }
            var bookAuthor = await _context.BookAuthor.FindAsync(id);
            if (bookAuthor != null)
            {
                _context.BookAuthor.Remove(bookAuthor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookAuthorExists(int id)
        {
          return (_context.BookAuthor?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
