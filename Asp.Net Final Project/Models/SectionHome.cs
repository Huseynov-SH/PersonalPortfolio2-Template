using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class SectionHome
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [Required, StringLength(80)]
        public string FullName { get; set; }

        [NotMapped, Display(Name = "Select new Background image")]
        public IFormFile Photo { get; set; }

    }
}
