using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class BlogComments
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string ShareDate { get; set; }
        [Required, StringLength(300)]
        public string Comment { get; set; }


        public int BlogItemId { get; set; }
        public virtual BlogItem BlogItem { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
