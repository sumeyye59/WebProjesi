using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapKesifleri.Models
{
    public class BookTranslator
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int TranslatorId { get; set; }
        public Book Book { get; set; }
        public Translator Translator{ get; set; }
    }
}
