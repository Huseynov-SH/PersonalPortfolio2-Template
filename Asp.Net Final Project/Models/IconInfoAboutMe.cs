using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class IconInfoAboutMe
    {
        public int Id { get; set; }
        [Required,StringLength(80), Display(Name = "Icon Name")]
        public string IconInfo { get; set; }
        [Required,StringLength(20), Display(Name = "Icon Title")]
        public string TitInfo { get; set; }
        [Required, StringLength(30), Display(Name = "Icon SubTitle")]
        public string SubTitInfo { get; set; }


        public int SectionAboutMeId { get; set; }
        public virtual SectionAboutMe SectionAboutMe { get; set; }
    }
}
