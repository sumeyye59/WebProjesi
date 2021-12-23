using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapKesifleri.Models
{
    public class Comments
    {public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public int BookId { get; set; } 
        public virtual Book Book { get; set; }
    }

}
