using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class PortfolioCategory
    {
        public int Id { get; set; }
        [Required,StringLength(30)]
        public string CategoryName { get; set; }


        public virtual ICollection<PortfolioItem> PortfolioItem { get; set; }
    }
}
