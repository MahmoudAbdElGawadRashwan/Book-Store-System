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
    public class TagController : Controller
    {
        private readonly ITIDbContext _context= new ITIDbContext();

        //public TagController(ITIDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Tag
        public async Task<IActionResult> Index()
        {
              return _context.Tags != null ? 
                          View(await _context.Tags.ToListAsync()) :
                          Problem("Entity set 'ITIDbContext.Tags'  is null.");
        }

        // GET: Tag/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tags == null)
            {
                return NotFound();
            }

            var tags = await _context.Tags
                .FirstOrDefaultAsync(m => m.TagID == id);
            if (tags == null)
            {
                return NotFound();
            }

            return View(tags);
        }

        // GET: Tag/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tag/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TagID,Category")] Tags tags)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tags);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tags);
        }

        // GET: Tag/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tags == null)
            {
                return NotFound();
            }

            var tags = await _context.Tags.FindAsync(id);
            if (tags == null)
            {
                return NotFound();
            }
            return View(tags);
        }

        // POST: Tag/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TagID,Category")] Tags tags)
        {
            if (id != tags.TagID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tags);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagsExists(tags.TagID))
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
            return View(tags);
        }

        // GET: Tag/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tags == null)
            {
                return NotFound();
            }

            var tags = await _context.Tags
                .FirstOrDefaultAsync(m => m.TagID == id);
            if (tags == null)
            {
                return NotFound();
            }

            return View(tags);
        }

        // POST: Tag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tags == null)
            {
                return Problem("Entity set 'ITIDbContext.Tags'  is null.");
            }
            var tags = await _context.Tags.FindAsync(id);
            if (tags != null)
            {
                _context.Tags.Remove(tags);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagsExists(int id)
        {
          return (_context.Tags?.Any(e => e.TagID == id)).GetValueOrDefault();
        }
    }
}
