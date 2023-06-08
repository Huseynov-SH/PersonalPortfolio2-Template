using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class WorkingProcessItemLeft
    {
        public int Id { get; set; }
        [Required]
        public int Step { get; set; }
        [Required, StringLength(20)]
        public string Title { get; set; }
        [Required, StringLength(300)]
        public string Idea { get; set; }

        public int SectionWorkProcessId { get; set; }
        public virtual SectionWorkProcess SectionWorkProcess { get; set; }
    }
}
