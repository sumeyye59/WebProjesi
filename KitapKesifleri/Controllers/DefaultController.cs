using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapKesifleri.Data;
using Microsoft.AspNetCore.Mvc;
using KitapKesifleri.Models;
namespace KitapKesifleri.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IActionResult Index()
        {
            
            return View();
        }
        public PartialViewResult Partial()
        {
            var values = _context.Book.Take(3).OrderByDescending(x => x.Firstdate).ToList();
            return PartialView(values);
        }
    }
}
