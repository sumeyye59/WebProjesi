using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KitapKesifleri.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string MemberName { get; set; }
        public string Admin { get; set; } = "hayır";
    }
}
