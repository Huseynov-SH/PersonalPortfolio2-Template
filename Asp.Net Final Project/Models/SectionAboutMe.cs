using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class SectionAboutMe
    {
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string SectionName { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [Required, StringLength(80)]
        public string FullName { get; set; }
        [Required, StringLength(100)]
        public string Location { get; set; }
        [Required, StringLength(700)]
        public string Description { get; set; }

        [NotMapped, Display(Name = "Select new image")]
        public IFormFile Photo { get; set; }

        public virtual ICollection<IconInfoAboutMe> IconInfoAboutMes { get; set; }
    }
}
