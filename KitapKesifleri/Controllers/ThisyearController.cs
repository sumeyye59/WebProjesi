using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapKesifleri.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitapKesifleri.Controllers
{
    public class ThisyearController : Controller
    {
        private ApplicationDbContext _context;
        public ThisyearController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var bookList = (from b in _context.Book
                            select new bookDTO
                            { bookId = b.Id,
    BookName=b.BookName,
   Isbn=b.Isbn,

   BookCover=b.BookCover,
         kind=b.Category.CategoryName,
         Publiser=b.Publisher.PublisherName,
         Firstdate=b.Firstdate,
         Point=b.Point,
         Page=b.Page,
         Summary=b.Summary,
         Edition=b.Edition

                            }).ToList();
            foreach(var item in bookList)
            {
                item.Authors = GetAuthorList(item.bookId);
                item.Translators = GetTranslatorList(item.bookId);

            }
            var populer = bookList.Where(x => (x.Point > 7));
            return View(populer);
        }
        public string GetAuthorList(int? FKBookId)
        {
            string AuthorNameLastn = "";
            var authorList = (from a in _context.BookAuthor
                              .Where(x=>x.Id==FKBookId)
                              select new
                              {
                                  AuthorID=a.AuthorId,
                                  Author=a.Author.NameLastname,

                              }).ToList();
            foreach(var item in authorList)
            {
                AuthorNameLastn += "" + item.Author + " ;";
            }
            return AuthorNameLastn;
    }
        public string GetTranslatorList(int? FKBookId)
        {
            string TranslatorNameLastn = "";
            var translatorList = (from a in _context.BookTranslator
                              .Where(x => x.Id == FKBookId)
                              select new
                              {
                                  TranslatorID = a.TranslatorId,
                                  Translator = a.Translator.NameLastname,

                              }).ToList();
            foreach (var item in translatorList)
            {
                TranslatorNameLastn += "" + item.Translator + " ;";
            }
            return TranslatorNameLastn;

        }
    }
   
    public class bookDTO
    {
        public int bookId { get; internal set; }
        public string BookName { get; internal set; }
        public int Isbn { get; internal set; }
        public string BookCover { get; internal set; }
        public string Authors { get; internal set; }
        public string Translators { get; internal set; }
        public string kind { get; internal set; }
        public string Publiser { get; internal set; }
        public int? Firstdate { get; internal set; }
        public double? Point { get; internal set; }
        public int? Page { get; internal set; }
        public string Summary { get; internal set; }
        public int Edition { get; internal set; }
       
        
    }
}
