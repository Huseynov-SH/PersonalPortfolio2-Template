using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class BlogItem
    {
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string Title { get; set; }
        [StringLength(500)]
        public string SubTitle { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [StringLength(50)]
        public string ShareDate { get; set; }
        [StringLength(50)]
        public string Tag { get; set; }
        [Required, StringLength(5000)]
        public string Context { get; set; }

        [NotMapped, Display(Name = "Select new image")]
        public IFormFile Photo { get; set; }

        public virtual ICollection<BlogComments> BlogComments { get; set; }
    }
}
