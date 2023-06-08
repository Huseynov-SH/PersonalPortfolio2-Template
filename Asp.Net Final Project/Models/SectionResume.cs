using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class SectionResume
    {
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string SectionName { get; set; }

        [Required, StringLength(30),Display(Name = "Left part")]
        public string FirstSubSectionName { get; set; }
        [Required, StringLength(30), Display(Name = "Right part")]
        public string SecondSubSectionName { get; set; }

        public virtual ICollection<ResumeExperienceItem> ResumeExperienceItem { get; set; }
        public virtual ICollection<ResumeEducationItem> ResumeEducationItem { get; set; }
    }
}
