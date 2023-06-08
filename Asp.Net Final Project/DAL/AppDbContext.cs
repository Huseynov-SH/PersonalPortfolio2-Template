using Asp.Net_Final_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<SectionAboutMe> SectionAboutMes { get; set; }
        public DbSet<IconInfoAboutMe> IconInfoAboutMes { get; set; }

        public DbSet<SectionMyInterests> SectionMyInterests { get; set; }
        public DbSet<MyInterestsInterestsItem> MyInterestsInterestsItem { get; set; }

        public DbSet<SectionService> SectionService { get; set; }
        public DbSet<ServiveServiceItem> ServiveServiceItem { get; set; }

        public DbSet<SectionTestimonial> SectionTestimonial { get; set; }
        public DbSet<TestimonailItem> TestimonailItem { get; set; }

        public DbSet<SectionPrice> SectionPrice { get; set; }
        public DbSet<PriceBox> PriceBox { get; set; }
        public DbSet<PriceBoxSkills> PriceBoxSkills { get; set; }

        public DbSet<SectionResume> SectionResume { get; set; }
        public DbSet<ResumeExperienceItem> ResumeExperienceItem { get; set; }
        public DbSet<ResumeEducationItem> ResumeEducationItem { get; set; }

        public DbSet<SectionSkills> SectionSkills { get; set; }
        public DbSet<SkillsProgressBar> SkillsProgressBar { get; set; }
        public DbSet<SkillsChart> SkillsChart { get; set; }

        public DbSet<SectionWorkProcess> SectionWorkProcess { get; set; }
        public DbSet<WorkingProcessItemLeft> WorkingProcessItemLeft { get; set; }
        public DbSet<WorkingProcessItemRight> WorkingProcessItemRight { get; set; }

        public DbSet<SectionHome> SectionHome { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Social> Social { get; set; }

        public DbSet<BlogItem> BlogItem { get; set; }
        public DbSet<BlogComments> BlogComments { get; set; }

        public DbSet<PortfolioCategory> PortfolioCategory { get; set; }
        public DbSet<PortfolioItem> PortfolioItem { get; set; }
    }
}
