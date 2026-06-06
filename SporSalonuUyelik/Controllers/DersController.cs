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
    public class DersController : Controller
    {
        private readonly AppDbContext _context;

        public DersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Ders
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Dersler.Include(d => d.Antrenor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Ders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ders = await _context.Dersler
                .Include(d => d.Antrenor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ders == null)
            {
                return NotFound();
            }

            return View(ders);
        }

        // GET: Ders/Create
        public IActionResult Create()
        {
            ViewData["AntrenorId"] = new SelectList(_context.Antrenorler, "Id", "Id");
            return View();
        }

        // POST: Ders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DersAdi,DersTarihi,Kontenjan,AntrenorId")] Ders ders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AntrenorId"] = new SelectList(_context.Antrenorler, "Id", "Id", ders.AntrenorId);
            return View(ders);
        }

        // GET: Ders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ders = await _context.Dersler.FindAsync(id);
            if (ders == null)
            {
                return NotFound();
            }
            ViewData["AntrenorId"] = new SelectList(_context.Antrenorler, "Id", "Id", ders.AntrenorId);
            return View(ders);
        }

        // POST: Ders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DersAdi,DersTarihi,Kontenjan,AntrenorId")] Ders ders)
        {
            if (id != ders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DersExists(ders.Id))
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
            ViewData["AntrenorId"] = new SelectList(_context.Antrenorler, "Id", "Id", ders.AntrenorId);
            return View(ders);
        }

        // GET: Ders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ders = await _context.Dersler
                .Include(d => d.Antrenor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ders == null)
            {
                return NotFound();
            }

            return View(ders);
        }

        // POST: Ders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ders = await _context.Dersler.FindAsync(id);
            if (ders != null)
            {
                _context.Dersler.Remove(ders);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DersExists(int id)
        {
            return _context.Dersler.Any(e => e.Id == id);
        }
    }
}
