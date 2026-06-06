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
    public class UyelikPaketisController : Controller
    {
        private readonly AppDbContext _context;

        public UyelikPaketisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UyelikPaketis
        public async Task<IActionResult> Index()
        {
            return View(await _context.UyelikPaketleri.ToListAsync());
        }

        // GET: UyelikPaketis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uyelikPaketi = await _context.UyelikPaketleri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uyelikPaketi == null)
            {
                return NotFound();
            }

            return View(uyelikPaketi);
        }

        // GET: UyelikPaketis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UyelikPaketis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PaketAdi,SureGun,Ucret,Aciklama")] UyelikPaketi uyelikPaketi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uyelikPaketi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uyelikPaketi);
        }

        // GET: UyelikPaketis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uyelikPaketi = await _context.UyelikPaketleri.FindAsync(id);
            if (uyelikPaketi == null)
            {
                return NotFound();
            }
            return View(uyelikPaketi);
        }

        // POST: UyelikPaketis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PaketAdi,SureGun,Ucret,Aciklama")] UyelikPaketi uyelikPaketi)
        {
            if (id != uyelikPaketi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uyelikPaketi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UyelikPaketiExists(uyelikPaketi.Id))
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
            return View(uyelikPaketi);
        }

        // GET: UyelikPaketis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uyelikPaketi = await _context.UyelikPaketleri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uyelikPaketi == null)
            {
                return NotFound();
            }

            return View(uyelikPaketi);
        }

        // POST: UyelikPaketis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uyelikPaketi = await _context.UyelikPaketleri.FindAsync(id);
            if (uyelikPaketi != null)
            {
                _context.UyelikPaketleri.Remove(uyelikPaketi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UyelikPaketiExists(int id)
        {
            return _context.UyelikPaketleri.Any(e => e.Id == id);
        }
    }
}
