using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class MyInterestsInterestsItem
    {
        public int Id { get; set; }
        [Required,StringLength(80),Display(Name = "Interests Icon")]
        public string InterestsIcon { get; set; }
        [Required,StringLength(20), Display(Name = "Interests Name")]
        public string InterestsName { get; set; }

        public int SectionMyInterestsId { get; set; }
        public virtual SectionMyInterests SectionMyInterests { get; set; }
    }
}
