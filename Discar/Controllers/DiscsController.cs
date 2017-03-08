using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Discar.Models;

namespace Discar.Controllers
{
    public class DiscsController : Controller
    {
        private readonly DiscContext _context;

        public DiscsController(DiscContext context)
        {
            _context = context;    
        }

        [HttpGet("[controller]/[action]/{discId}")]
        public IActionResult Disc(int discId)
        {
            Disc model = _context.Discs.Where(d => d.DiscId == discId).First();
            return View(model);
        }
        // GET: Discs
        public async Task<IActionResult> Index()
        {
            var discContext = _context.Discs.Include(d => d.Brand);
            return View(await discContext.ToListAsync());
        }

        // GET: Discs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disc = await _context.Discs
                .Include(d => d.Brand)
                .SingleOrDefaultAsync(m => m.DiscId == id);
            if (disc == null)
            {
                return NotFound();
            }

            return View(disc);
        }

        // GET: Discs/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandId");
            return View();
        }

        // POST: Discs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiscId,DiscName,Plastic,Speed,Glide,Stability,Fade,Price,Url,BrandId")] Disc disc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disc);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandId", disc.BrandId);
            return View(disc);
        }

        // GET: Discs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disc = await _context.Discs.SingleOrDefaultAsync(m => m.DiscId == id);
            if (disc == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandId", disc.BrandId);
            return View(disc);
        }

        // POST: Discs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiscId,DiscName,Plastic,Speed,Glide,Stability,Fade,Price,Url,BrandId")] Disc disc)
        {
            if (id != disc.DiscId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscExists(disc.DiscId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandId", disc.BrandId);
            return View(disc);
        }

        // GET: Discs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disc = await _context.Discs
                .Include(d => d.Brand)
                .SingleOrDefaultAsync(m => m.DiscId == id);
            if (disc == null)
            {
                return NotFound();
            }

            return View(disc);
        }

        // POST: Discs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disc = await _context.Discs.SingleOrDefaultAsync(m => m.DiscId == id);
            _context.Discs.Remove(disc);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DiscExists(int id)
        {
            return _context.Discs.Any(e => e.DiscId == id);
        }
    }
}
