using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KitapKesifleri.Data;
using KitapKesifleri.Models;

namespace KitapKesifleri.Controllers
{
    public class TranslatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TranslatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Translator
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Translator.Include(t => t.Country);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Translator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translator = await _context.Translator
                .Include(t => t.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (translator == null)
            {
                return NotFound();
            }

            return View(translator);
        }

        // GET: Translator/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id");
            return View();
        }

        // POST: Translator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,BirthDate,CountryId,Gender")] Translator translator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(translator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id", translator.CountryId);
            return View(translator);
        }

        // GET: Translator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translator = await _context.Translator.FindAsync(id);
            if (translator == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id", translator.CountryId);
            return View(translator);
        }

        // POST: Translator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,BirthDate,CountryId,Gender")] Translator translator)
        {
            if (id != translator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(translator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranslatorExists(translator.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id", translator.CountryId);
            return View(translator);
        }

        // GET: Translator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translator = await _context.Translator
                .Include(t => t.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (translator == null)
            {
                return NotFound();
            }

            return View(translator);
        }

        // POST: Translator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var translator = await _context.Translator.FindAsync(id);
            _context.Translator.Remove(translator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranslatorExists(int id)
        {
            return _context.Translator.Any(e => e.Id == id);
        }
    }
}
