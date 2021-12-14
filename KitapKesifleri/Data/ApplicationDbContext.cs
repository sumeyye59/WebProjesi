using System;
using System.Collections.Generic;
using System.Text;
using KitapKesifleri.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KitapKesifleri.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BookAuthor> BookAuthor  { get; set; }
        public DbSet<BookTranslator> BookTranslator { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Translator> Translator { get; set; }
        
    }
}
