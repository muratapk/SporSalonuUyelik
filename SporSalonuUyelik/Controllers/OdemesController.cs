using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SporSalonuUyelik.Data;
using SporSalonuUyelik.Models;

namespace SporSalonuUyelik.Controllers
{
    public class OdemesController : Controller
    {
        private readonly AppDbContext _context;

        public OdemesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Odemes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Odemeler.Include(o => o.Uye);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Odemes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odeme = await _context.Odemeler
                .Include(o => o.Uye)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odeme == null)
            {
                return NotFound();
            }

            return View(odeme);
        }

        // GET: Odemes/Create
        public IActionResult Create()
        {
            ViewData["UyeId"] = new SelectList(_context.Uyeler, "Id", "Id");
            return View();
        }

        // POST: Odemes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UyeId,Tutar,OdemeTarihi,OdemeTipi,Aciklama")] Odeme odeme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odeme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UyeId"] = new SelectList(_context.Uyeler, "Id", "Id", odeme.UyeId);
            return View(odeme);
        }

        // GET: Odemes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odeme = await _context.Odemeler.FindAsync(id);
            if (odeme == null)
            {
                return NotFound();
            }
            ViewData["UyeId"] = new SelectList(_context.Uyeler, "Id", "Id", odeme.UyeId);
            return View(odeme);
        }

        // POST: Odemes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UyeId,Tutar,OdemeTarihi,OdemeTipi,Aciklama")] Odeme odeme)
        {
            if (id != odeme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odeme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdemeExists(odeme.Id))
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
            ViewData["UyeId"] = new SelectList(_context.Uyeler, "Id", "Id", odeme.UyeId);
            return View(odeme);
        }

        // GET: Odemes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odeme = await _context.Odemeler
                .Include(o => o.Uye)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odeme == null)
            {
                return NotFound();
            }

            return View(odeme);
        }

        // POST: Odemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odeme = await _context.Odemeler.FindAsync(id);
            if (odeme != null)
            {
                _context.Odemeler.Remove(odeme);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdemeExists(int id)
        {
            return _context.Odemeler.Any(e => e.Id == id);
        }
    }
}
