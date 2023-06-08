using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Models
{
    public class SectionWorkProcess
    {
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string SectionName { get; set; }
        [Required, StringLength(30)]
        public string Circle { get; set; }

        public virtual ICollection<WorkingProcessItemLeft> WorkingProcessItemLeft { get; set; }
        public virtual ICollection<WorkingProcessItemRight> WorkingProcessItemRight { get; set; }
    }
}
