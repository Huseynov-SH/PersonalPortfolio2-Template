using Asp.Net_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.ViewModels
{
    public class MainPageVM
    {
        public IEnumerable<PortfolioCategory> PortfolioCategory { get; set; }

        public IEnumerable<PortfolioItem> PortfolioItem { get; set; }

        public IEnumerable<BlogItem> BlogItem { get; set; }

        public IEnumerable<BlogComments> BlogComments { get; set; }

        public IEnumerable<Banner> Banner { get; set; }
        public IEnumerable<Social> Social { get; set; }
        public SectionHome SectionHome { get; set; }

        public SectionAboutMe SectionAboutMe { get; set; }
        public IEnumerable<IconInfoAboutMe> IconInfoAboutMe { get; set; }

        public SectionMyInterests SectionMyInterests { get; set; }
        public IEnumerable<MyInterestsInterestsItem> MyInterestsInterestsItem { get; set; }

        public SectionService SectionService { get; set; }
        public IEnumerable<ServiveServiceItem> ServiveServiceItem { get; set; }

        public SectionTestimonial SectionTestimonial { get; set; }
        public IEnumerable<TestimonailItem> TestimonailItem { get; set; }

        public SectionPrice SectionPrice { get; set; }
        public IEnumerable<PriceBox> PriceBox { get; set; }
        public IEnumerable<PriceBoxSkills> PriceBoxSkills { get; set; }

        public SectionResume SectionResume { get; set; }
        public IEnumerable<ResumeExperienceItem> ResumeExperienceItem { get; set; }
        public IEnumerable<ResumeEducationItem> ResumeEducationItem { get; set; }

        public SectionSkills SectionSkills { get; set; }
        public IEnumerable<SkillsProgressBar> SkillsProgressBar { get; set; }
        public IEnumerable<SkillsChart> SkillsChart { get; set; }

        public SectionWorkProcess SectionWorkProcess { get; set; }
        public IEnumerable<WorkingProcessItemLeft> WorkingProcessItemLeft { get; set; }
        public IEnumerable<WorkingProcessItemRight> WorkingProcessItemRight { get; set; }
    }
}
