using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class AppUser:IdentityUser
    {
        [Required,StringLength(50)]
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Blocked { get; set; }
    }
}
