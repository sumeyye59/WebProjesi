using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitapKesifleri.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Display(Name = "Ülke")]
        public string CountryName { get; set; }

    }
}
