using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Asp.Net_Final_Project.Models;
using Asp.Net_Final_Project.DAL;
using Asp.Net_Final_Project.ViewModels;

namespace Asp.Net_Final_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            MainPageVM mainPage = new MainPageVM
            {
                BlogItem = _db.BlogItem,
                BlogComments = _db.BlogComments,

                PortfolioCategory = _db.PortfolioCategory,
                PortfolioItem = _db.PortfolioItem,

                SectionHome = _db.SectionHome.First(s => s.Id == 1),

                Banner = _db.Banner,
                
                Social = _db.Social,

                SectionAboutMe = _db.SectionAboutMes.First(s=>s.Id == 1),
                IconInfoAboutMe = _db.IconInfoAboutMes,

                SectionMyInterests= _db.SectionMyInterests.First(s => s.Id == 1),
                MyInterestsInterestsItem = _db.MyInterestsInterestsItem,

                SectionService = _db.SectionService.First(s => s.Id == 1),
                ServiveServiceItem = _db.ServiveServiceItem,

                SectionTestimonial = _db.SectionTestimonial.First(s => s.Id == 1),
                TestimonailItem = _db.TestimonailItem,

                SectionPrice = _db.SectionPrice.First(s => s.Id == 1),
                PriceBox = _db.PriceBox,
                PriceBoxSkills = _db.PriceBoxSkills,

                SectionResume = _db.SectionResume.First(s => s.Id == 1),
                ResumeExperienceItem = _db.ResumeExperienceItem,
                ResumeEducationItem = _db.ResumeEducationItem,

                SectionSkills = _db.SectionSkills.First(s => s.Id == 1),
                SkillsProgressBar = _db.SkillsProgressBar,
                SkillsChart = _db.SkillsChart,

                SectionWorkProcess = _db.SectionWorkProcess.First(s => s.Id == 1),
                WorkingProcessItemLeft = _db.WorkingProcessItemLeft,
                WorkingProcessItemRight = _db.WorkingProcessItemRight,
                
            };
            return View(mainPage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
