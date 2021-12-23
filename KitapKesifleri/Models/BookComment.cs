using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapKesifleri.Models
{
    public class BookComment
    {
        public IEnumerable<Book> Value1 { get; set; }
        public IEnumerable<Comments> Value2 { get; set; }

    }
}
