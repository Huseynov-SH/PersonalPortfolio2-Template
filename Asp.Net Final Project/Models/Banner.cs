using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class Banner
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string BannerName { get; set; }
    }
}
