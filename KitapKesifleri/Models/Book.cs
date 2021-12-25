using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitapKesifleri.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Adı")]
        public string BookName { get; set; }

        public int Isbn { get; set; }
        
        [Display(Name = "Kapağı")]
        public string BookCover { get; set; }
        [Required]
        [Display(Name = "İlk Basım Yılı")]
       // [StringLength(4, ErrorMessage = "4 basamaklı bir yıl girin.", MinimumLength = 4)]
        public int? Firstdate { get; set; }
        [Required]
        [Display(Name = "Puanı")]
        //[StringLength(2, ErrorMessage = "0-10 arası sayı girin.", MinimumLength = 1)]
        public double? Point { get; set; }
        public int? Page { get; set; }
        public string Summary { get; set; } 
        public int Edition { get; set; }
        public int? LanguageId { get; set; }
        public Language Language { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int PublisherId{ get; set; }
        public Publisher Publisher { get; set; }

    }
}
