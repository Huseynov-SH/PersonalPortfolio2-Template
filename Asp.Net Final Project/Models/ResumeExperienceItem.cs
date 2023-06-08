using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class ResumeExperienceItem
    {
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string Title { get; set; }
        [Required, StringLength(30)]
        public string Calendar { get; set; }
        [Required, StringLength(30)]
        public string Sec { get; set; }
        [Required, StringLength(300)]
        public string Description { get; set; }

        public int SectionResumeId { get; set; }
        public virtual SectionResume SectionResume { get; set; }
    }
}
