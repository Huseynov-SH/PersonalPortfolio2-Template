using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Final_Project.DAL;
using Asp.Net_Final_Project.Models;
using Asp.Net_Final_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Final_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class ResumeController : Controller
    {
        private readonly AppDbContext _db;
        public ResumeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            MainPageVM mainPageVM = new MainPageVM
            {
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
            return View(mainPageVM);
        }

        public async Task<IActionResult> SectionNameUpdate(int id)
        {
            var SectionName = await _db.SectionResume.FindAsync(id);
            if (SectionName == null) return NotFound();

            return View(SectionName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SectionNameUpdate(int id, SectionResume sectionResume)
        {
            if (!ModelState.IsValid) return View(sectionResume);

            SectionResume sectionResumeFromDb = await _db.SectionResume.FindAsync(id);

            sectionResumeFromDb.SectionName = sectionResume.SectionName;
            sectionResumeFromDb.FirstSubSectionName = sectionResume.FirstSubSectionName;
            sectionResumeFromDb.SecondSubSectionName = sectionResume.SecondSubSectionName;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> LDetails(int id)
        {
            var experienceItem = await _db.ResumeExperienceItem.FindAsync(id);
            if (experienceItem == null) return NotFound();

            return View(experienceItem);
        }

        public async Task<IActionResult> RDetails(int id)
        {
            var educationItem = await _db.ResumeEducationItem.FindAsync(id);
            if (educationItem == null) return NotFound();

            return View(educationItem);
        }

        public async Task<IActionResult> LUpdate(int id)
        {
            var experienceItem = await _db.ResumeExperienceItem.FindAsync(id);
            if (experienceItem == null) return NotFound();

            return View(experienceItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LUpdate(int id, ResumeExperienceItem experienceItem)
        {
            if (!ModelState.IsValid) return View(experienceItem);

            ResumeExperienceItem experienceItemFromDb = await _db.ResumeExperienceItem.FindAsync(id);

            experienceItemFromDb.Title = experienceItem.Title;
            experienceItemFromDb.Calendar = experienceItem.Calendar;
            experienceItemFromDb.Sec = experienceItem.Sec;
            experienceItemFromDb.Description = experienceItem.Description;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RUpdate(int id)
        {
            var educationItem = await _db.ResumeEducationItem.FindAsync(id);
            if (educationItem == null) return NotFound();

            return View(educationItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RUpdate(int id, ResumeEducationItem educationItem)
        {
            if (!ModelState.IsValid) return View(educationItem);

            ResumeEducationItem educationItemFromDb = await _db.ResumeEducationItem.FindAsync(id);

            educationItemFromDb.Title = educationItem.Title;
            educationItemFromDb.Calendar = educationItem.Calendar;
            educationItemFromDb.Sec = educationItem.Sec;
            educationItemFromDb.Description = educationItem.Description;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult LCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LCreate(ResumeExperienceItem experienceItem)
        {
            if (!ModelState.IsValid)
            {
                return View(experienceItem);
            }
            await _db.ResumeExperienceItem.AddAsync(experienceItem);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RCreate(ResumeEducationItem educationItem)
        {
            if (!ModelState.IsValid)
            {
                return View(educationItem);
            }
            await _db.ResumeEducationItem.AddAsync(educationItem);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> LDelete(int id)
        {
            var experienceItem = await _db.ResumeExperienceItem.FindAsync(id);
            if (experienceItem == null) return NotFound();

            return View(experienceItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("LDelete")]
        public async Task<IActionResult> LDeletePost(int id)
        {
            var experienceItem = await _db.ResumeExperienceItem.FindAsync(id);
            if (experienceItem == null) return NotFound();

            _db.ResumeExperienceItem.Remove(experienceItem);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RDelete(int id)
        {
            var educationItem = await _db.ResumeEducationItem.FindAsync(id);
            if (educationItem == null) return NotFound();

            return View(educationItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("RDelete")]
        public async Task<IActionResult> RDeletePost(int id)
        {
            var educationItem = await _db.ResumeEducationItem.FindAsync(id);
            if (educationItem == null) return NotFound();

            _db.ResumeEducationItem.Remove(educationItem);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}