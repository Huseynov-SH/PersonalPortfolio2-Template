using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class SkillsProgressBar
    {
        public int Id { get; set; }
        [Required, StringLength(40)]
        public string ProgressTitle { get; set; }
        [Required]
        public int ProgressValue { get; set; }


        public int SectionSkillsId { get; set; }
        public virtual SectionSkills SectionSkills { get; set; }
    }
}
