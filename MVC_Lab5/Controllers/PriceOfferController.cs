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
    public class PriceOfferController : Controller
    {
        private readonly ITIDbContext _context= new ITIDbContext();

        //public PriceOfferController(ITIDbContext context)
        //{
        //    _context = context;
        //}

        // GET: PriceOffer
        public async Task<IActionResult> Index()
        {
            var iTIDbContext = _context.PriceOffers.Include(p => p.Book);
            return View(await iTIDbContext.ToListAsync());
        }

        // GET: PriceOffer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PriceOffers == null)
            {
                return NotFound();
            }

            var priceOffers = await _context.PriceOffers
                .Include(p => p.Book)
                .FirstOrDefaultAsync(m => m.PriceOffersId == id);
            if (priceOffers == null)
            {
                return NotFound();
            }

            return View(priceOffers);
        }

        // GET: PriceOffer/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
            return View();
        }

        // POST: PriceOffer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PriceOffersId,NewPrice,PromotionalText,BookId")] PriceOffers priceOffers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(priceOffers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", priceOffers.PriceOffersId);
            return View(priceOffers);
        }

        // GET: PriceOffer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PriceOffers == null)
            {
                return NotFound();
            }

            var priceOffers = await _context.PriceOffers.FindAsync(id);
            if (priceOffers == null)
            {
                return NotFound();
            }
            ViewData["PriceOffersId"] = new SelectList(_context.Books, "BookId", "Title", priceOffers.PriceOffersId);
            return View(priceOffers);
        }

        // POST: PriceOffer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PriceOffersId,NewPrice,PromotionalText,BookId")] PriceOffers priceOffers)
        {
            if (id != priceOffers.PriceOffersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priceOffers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceOffersExists(priceOffers.PriceOffersId))
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
            ViewData["PriceOffersId"] = new SelectList(_context.Books, "BookId", "Title", priceOffers.PriceOffersId);
            return View(priceOffers);
        }

        // GET: PriceOffer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PriceOffers == null)
            {
                return NotFound();
            }

            var priceOffers = await _context.PriceOffers
                .Include(p => p.Book)
                .FirstOrDefaultAsync(m => m.PriceOffersId == id);
            if (priceOffers == null)
            {
                return NotFound();
            }

            return View(priceOffers);
        }

        // POST: PriceOffer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PriceOffers == null)
            {
                return Problem("Entity set 'ITIDbContext.PriceOffers'  is null.");
            }
            var priceOffers = await _context.PriceOffers.FindAsync(id);
            if (priceOffers != null)
            {
                _context.PriceOffers.Remove(priceOffers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriceOffersExists(int id)
        {
          return (_context.PriceOffers?.Any(e => e.PriceOffersId == id)).GetValueOrDefault();
        }
    }
}
