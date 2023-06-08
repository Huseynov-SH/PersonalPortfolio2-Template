using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class PortfolioItem
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [Required,StringLength(30)]
        public string ProjectName { get; set; }
        [StringLength(255)]
        public string ProjectVideoLink { get; set; }
        [Required,StringLength(20)]
        public string Tag { get; set; }

        [NotMapped, Display(Name = "Select new image")]
        public IFormFile Photo { get; set; }
        [Display(Name = "Select Category")]
        public int PortfolioCategoryId { get; set; }
        public virtual PortfolioCategory PortfolioCategory { get; set; }
    }
}
