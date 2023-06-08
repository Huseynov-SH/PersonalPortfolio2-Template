using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Final_Project.DAL;
using Asp.Net_Final_Project.Extensions;
using Asp.Net_Final_Project.Models;
using Asp.Net_Final_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using static Asp.Net_Final_Project.Utilities.Utilities;

namespace Asp.Net_Final_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class SectionHomeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;

        public SectionHomeController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            MainPageVM mainPage = new MainPageVM
            {
                SectionHome = _db.SectionHome.First(s => s.Id == 1),

                Banner = _db.Banner,

                Social = _db.Social,

                SectionAboutMe = _db.SectionAboutMes.First(s => s.Id == 1),
                IconInfoAboutMe = _db.IconInfoAboutMes,

                SectionMyInterests = _db.SectionMyInterests.First(s => s.Id == 1),
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

        public async Task<IActionResult> Update(int id)
        {
            var sectionHome = await _db.SectionHome.FindAsync(id);
            if (sectionHome == null) return NotFound();

            return View(sectionHome);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SectionHome sectionHome)
        {
            if (!ModelState.IsValid) return View(sectionHome);

            SectionHome sectionHomeFromDb = await _db.SectionHome.FindAsync(id);

            if (sectionHome.Photo != null)
            {
                if (sectionHome.Photo.IsImage())
                {
                    //Remove old image
                    RemoveFile(sectionHomeFromDb.Image, "main", _env.WebRootPath);

                    //Save new image
                    sectionHomeFromDb.Image = await sectionHome.Photo.SaveFileAsync(_env.WebRootPath, "main");
                }
                else
                {
                    ModelState.AddModelError("Photo", "Photo is invalid");
                    return View(sectionHome);
                }
            }

            sectionHomeFromDb.FullName = sectionHome.FullName;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult BCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BCreate(Banner banner)
        {
            if (!ModelState.IsValid)
            {
                return View(banner);
            }
            await _db.Banner.AddAsync(banner);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> BUpdate(int id)
        {
            var banner = await _db.Banner.FindAsync(id);
            if (banner == null) return NotFound();

            return View(banner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BUpdate(int id, Banner banner)
        {
            if (!ModelState.IsValid) return View(banner);

            Banner bannerFromDb = await _db.Banner.FindAsync(id);

            bannerFromDb.BannerName = banner.BannerName;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> BDelete(int id)
        {
            var banner = await _db.Banner.FindAsync(id);
            if (banner == null) return NotFound();

            return View(banner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("BDelete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var banner = await _db.Banner.FindAsync(id);
            if (banner == null) return NotFound();

            _db.Banner.Remove(banner);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult SCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SCreate(Social social)
        {
            if (!ModelState.IsValid)
            {
                return View(social);
            }
            await _db.Social.AddAsync(social);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SUpdate(int id)
        {
            var social = await _db.Social.FindAsync(id);
            if (social == null) return NotFound();

            return View(social);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SUpdate(int id, Social social)
        {
            if (!ModelState.IsValid) return View(social);

            Social socialFromDb = await _db.Social.FindAsync(id);

            socialFromDb.Icon = social.Icon;
            socialFromDb.IconLink = social.IconLink;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SDelete(int id)
        {
            var social = await _db.Social.FindAsync(id);
            if (social == null) return NotFound();

            return View(social);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("SDelete")]
        public async Task<IActionResult> SDeletePost(int id)
        {
            var social = await _db.Social.FindAsync(id);
            if (social == null) return NotFound();

            _db.Social.Remove(social);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}