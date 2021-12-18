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
    public class BookTranslatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookTranslatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookTranslator
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookTranslator.Include(b => b.Book).Include(b => b.Translator);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookTranslator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTranslator = await _context.BookTranslator
                .Include(b => b.Book)
                .Include(b => b.Translator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookTranslator == null)
            {
                return NotFound();
            }

            return View(bookTranslator);
        }

        // GET: BookTranslator/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "BookName");
            ViewData["TranslatorId"] = new SelectList(_context.Translator, "Id", "NameLastname");
            return View();
        }

        // POST: BookTranslator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,TranslatorId")] BookTranslator bookTranslator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookTranslator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "BookName", bookTranslator.BookId);
            ViewData["TranslatorId"] = new SelectList(_context.Translator, "Id", "NameLastname", bookTranslator.TranslatorId);
            return View(bookTranslator);
        }

        // GET: BookTranslator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTranslator = await _context.BookTranslator.FindAsync(id);
            if (bookTranslator == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "BookName", bookTranslator.BookId);
            ViewData["TranslatorId"] = new SelectList(_context.Translator, "Id", "NameLastname", bookTranslator.TranslatorId);
            return View(bookTranslator);
        }

        // POST: BookTranslator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,TranslatorId")] BookTranslator bookTranslator)
        {
            if (id != bookTranslator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookTranslator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookTranslatorExists(bookTranslator.Id))
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
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "BookName", bookTranslator.BookId);
            ViewData["TranslatorId"] = new SelectList(_context.Translator, "Id", "NameLastname", bookTranslator.TranslatorId);
            return View(bookTranslator);
        }

        // GET: BookTranslator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTranslator = await _context.BookTranslator
                .Include(b => b.Book)
                .Include(b => b.Translator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookTranslator == null)
            {
                return NotFound();
            }

            return View(bookTranslator);
        }

        // POST: BookTranslator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookTranslator = await _context.BookTranslator.FindAsync(id);
            _context.BookTranslator.Remove(bookTranslator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookTranslatorExists(int id)
        {
            return _context.BookTranslator.Any(e => e.Id == id);
        }
    }
}
