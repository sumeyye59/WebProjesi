using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitapKesifleri.Models
{
    public class Translator
    {
        public int Id { get; set; }
        [Display(Name = "Adı")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Doğum tarihi")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public Gender Gender { get; set; }
        public string NameLastname { get { return Name + " " + LastName; } }
    }
   

}
