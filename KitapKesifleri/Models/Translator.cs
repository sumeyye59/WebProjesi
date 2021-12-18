using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapKesifleri.Models
{
    public class Translator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public Gender Gender { get; set; }
        public string NameLastname { get { return Name + " " + LastName; } }
    }
   

}
