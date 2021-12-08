using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapKesifleri.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int Isbn { get; set; }
        public int? FirstEdition { get; set; }
        public double? Point { get; set; }
        public int? Page { get; set; }
        public string Summary { get; set; } = "Yok";
        public int Edition { get; set; }
        public int? LanguageId { get; set; }
        public Language Language { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int PublisherId{ get; set; }
        public Publisher Publisher { get; set; }

    }
}
