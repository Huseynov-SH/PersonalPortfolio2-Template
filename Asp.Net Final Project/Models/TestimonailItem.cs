using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class TestimonailItem
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [Required, StringLength(40)]
        public string FullName { get; set; }
        [Required, StringLength(30)]
        public string Job { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required, StringLength(400)]
        public string Comment { get; set; }

        [NotMapped,Display(Name ="Select new image")]
        public IFormFile Photo { get; set; }

        public int SectionTestimonialId { get; set; }
        public virtual SectionTestimonial SectionTestimonial { get; set; }
    }
}
