using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapKesifleri.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public Gender Gender { get; set; }
    }
    public enum Gender
    {
        Woman=1,
        Man=2

    }
}
