using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class ServiveServiceItem
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string ServiceIcon { get; set; }
        [Required, StringLength(30)]
        public string ServiceName { get; set; }
        [Required, StringLength(300)]
        public string ServiceDescription { get; set; }

        public int SectionServiceId { get; set; }
        public virtual SectionService SectionService { get; set; }
    }
}
