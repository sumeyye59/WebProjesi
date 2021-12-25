using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitapKesifleri.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Adı")]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        public string LastName { get; set; }
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Ülke")]
        public int? CountryId { get; set; }
       
        public Country Country { get; set; }
        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }
        public string NameLastname { get { return Name + " " + LastName; } }
    }
    public enum Gender
    {
        Kadın = 1,
       Erkek = 2

    }
}
