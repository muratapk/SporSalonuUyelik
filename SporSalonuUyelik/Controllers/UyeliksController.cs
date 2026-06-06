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
    public class UyeliksController : Controller
    {
        private readonly AppDbContext _context;

        public UyeliksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Uyeliks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Uyelikler.Include(u => u.Uye).Include(u => u.UyelikPaketi);
            //inner join yaparak Uyelikler tablosunu Uyeler ve UyelikPaketleri tablolarıyla ilişkilendiriyoruz. Böylece her bir üyeliğin hangi üyeye ve hangi paketle ilişkili olduğunu görebiliriz.
            return View(await appDbContext.ToListAsync());
        }

        // GET: Uyeliks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uyelik = await _context.Uyelikler
                .Include(u => u.Uye)
                .Include(u => u.UyelikPaketi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uyelik == null)
            {
                return NotFound();
            }

            return View(uyelik);
        }

        // GET: Uyeliks/Create
        public IActionResult Create()
        {
            ViewData["UyeId"] = new SelectList(_context.Uyeler, "Id", "Ad");
            ViewData["UyelikPaketiId"] = new SelectList(_context.UyelikPaketleri, "Id", "PaketAdi");
            return View();
        }

        // POST: Uyeliks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UyeId,UyelikPaketiId,BaslangicTarihi,BitisTarihi,AktifMi")] Uyelik uyelik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uyelik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UyeId"] = new SelectList(_context.Uyeler, "Id", "Ad", uyelik.UyeId);
            ViewData["UyelikPaketiId"] = new SelectList(_context.UyelikPaketleri, "Id", "PaketAdi", uyelik.UyelikPaketiId);
            return View(uyelik);
        }

        // GET: Uyeliks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uyelik = await _context.Uyelikler.FindAsync(id);
            if (uyelik == null)
            {
                return NotFound();
            }
            ViewData["UyeId"] = new SelectList(_context.Uyeler, "Id", "Ad", uyelik.UyeId);
            ViewData["UyelikPaketiId"] = new SelectList(_context.UyelikPaketleri, "Id", "PaketAdi", uyelik.UyelikPaketiId);
            return View(uyelik);
        }

        // POST: Uyeliks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UyeId,UyelikPaketiId,BaslangicTarihi,BitisTarihi,AktifMi")] Uyelik uyelik)
        {
            if (id != uyelik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uyelik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UyelikExists(uyelik.Id))
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
            ViewData["UyeId"] = new SelectList(_context.Uyeler, "Id", "Ad", uyelik.UyeId);
            ViewData["UyelikPaketiId"] = new SelectList(_context.UyelikPaketleri, "Id", "PaketAdi", uyelik.UyelikPaketiId);
            return View(uyelik);
        }

        // GET: Uyeliks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uyelik = await _context.Uyelikler
                .Include(u => u.Uye)
                .Include(u => u.UyelikPaketi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uyelik == null)
            {
                return NotFound();
            }

            return View(uyelik);
        }

        // POST: Uyeliks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uyelik = await _context.Uyelikler.FindAsync(id);
            if (uyelik != null)
            {
                _context.Uyelikler.Remove(uyelik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UyelikExists(int id)
        {
            return _context.Uyelikler.Any(e => e.Id == id);
        }
    }
}
