using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitapKesifleri.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [Display(Name = "Yayınevi")]
        public string PublisherName { get; set; }
        [Display(Name = "Adresi")]
        public string Adress { get; set; }
        
        public string Tel { get; set; }

    }
}
