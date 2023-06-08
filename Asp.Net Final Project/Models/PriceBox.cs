using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class PriceBox
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string PriceBoxIcon { get; set; }
        [Required, StringLength(20)]
        public string PriceBoxType { get; set; }
        [Required]
        public int Price { get; set; }

        public int SectionPriceId { get; set; }
        public virtual SectionPrice SectionPrice { get; set; }
    }
}
