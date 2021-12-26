using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KitapKesifleri.Data;
using KitapKesifleri.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace KitapKesifleri.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public BookController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Book.Include(b => b.Category).Include(b => b.Language).Include(b => b.Publisher);
            return View(await applicationDbContext.ToListAsync());
        }
        [HttpGet]
        public PartialViewResult Yorumyap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        public IActionResult YorumYap()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YorumYap([Bind("Id,Name,Comment,BookId")] Comments c)
        {
            if (ModelState.IsValid)
            {
                _context.Add(c);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllBooks));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", c.BookId);
            
            return View(c);
            //_context.Comments.Add(c);
            ////_context.SaveChanges();
            //return PartialView();
        }
        // GET: Book
        public async Task<IActionResult> AllBooks()
        {
            var applicationDbContext = _context.Book.Include(b => b.Category).Include(b => b.Language).Include(b => b.Publisher);
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: Book/Details/5
        BookComment bc = new BookComment();
        public IActionResult Details(int? id)
        {
            bc.Value1 = _context.Book.Where(x=>x.Id==id).ToList();
            bc.Value2 = _context.Comments.Where(x => x.BookId == id).ToList();
            
            // var found = _context.Book.Where(x => x.Id == id).ToList();
            
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var book = await _context.Book
            //    .Include(b => b.Category)
            //    .Include(b => b.Language)
            //    .Include(b => b.Publisher)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (book == null)
            //{
            //    return NotFound();
            //}

            return View(bc);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "CategoryName");
            ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "LanguageName");
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "PublisherName");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookName,Isbn,BookCover,Firstdate,Point,Page,Summary,Edition,LanguageId,CategoryId,PublisherId")] Book book)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images");
                var extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                book.BookCover = @"\images\" + fileName + extension;

                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", book.CategoryId);
            ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Id", book.LanguageId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Id", book.PublisherId);
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", book.CategoryId);
            ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Id", book.LanguageId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Id", book.PublisherId);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookName,Isbn,BookCover,Firstdate,Point,Page,Summary,Edition,LanguageId,CategoryId,PublisherId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", book.CategoryId);
            ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Id", book.LanguageId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Id", book.PublisherId);
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Category)
                .Include(b => b.Language)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
