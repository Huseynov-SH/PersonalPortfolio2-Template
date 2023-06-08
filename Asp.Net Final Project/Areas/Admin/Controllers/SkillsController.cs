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
    public class SkillsController : Controller
    {
        private readonly AppDbContext _db;
        public SkillsController(AppDbContext db)
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
            var SectionName = await _db.SectionSkills.FindAsync(id);
            if (SectionName == null) return NotFound();

            return View(SectionName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SectionNameUpdate(int id, SectionSkills sectionSkills)
        {
            if (!ModelState.IsValid) return View(sectionSkills);

            SectionSkills sectionSkillsFromDb = await _db.SectionSkills.FindAsync(id);

            sectionSkillsFromDb.SectionName = sectionSkills.SectionName;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult PCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PCreate(SkillsProgressBar progressBar)
        {
            if (!ModelState.IsValid) return View(progressBar);

            await _db.SkillsProgressBar.AddAsync(progressBar);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CCreate(SkillsChart skillsChart)
        {
            if (!ModelState.IsValid) return View(skillsChart);

            await _db.SkillsChart.AddAsync(skillsChart);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PUpdate(int id)
        {
            var progresBar = await _db.SkillsProgressBar.FindAsync(id);
            if (progresBar == null) return NotFound();

            return View(progresBar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PUpdate(int id, SkillsProgressBar SkillsProgressBar)
        {
            if (!ModelState.IsValid) return View(SkillsProgressBar);

            SkillsProgressBar SkillsProgressBarFromDb = await _db.SkillsProgressBar.FindAsync(id);

            SkillsProgressBarFromDb.ProgressTitle = SkillsProgressBar.ProgressTitle;
            SkillsProgressBarFromDb.ProgressValue = SkillsProgressBar.ProgressValue;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CUpdate(int id)
        {
            var skillsChart = await _db.SkillsChart.FindAsync(id);
            if (skillsChart == null) return NotFound();

            return View(skillsChart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CUpdate(int id, SkillsChart skillsChart)
        {
            if (!ModelState.IsValid) return View(skillsChart);

            SkillsChart skillsChartFromDb = await _db.SkillsChart.FindAsync(id);

            skillsChartFromDb.ProgressTitle = skillsChart.ProgressTitle;
            skillsChartFromDb.ProgressValue = skillsChart.ProgressValue;
            skillsChartFromDb.BarColor = skillsChart.BarColor;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PDelete(int id)
        {
            var progresBar = await _db.SkillsProgressBar.FindAsync(id);
            if (progresBar == null) return NotFound();

            return View(progresBar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("PDelete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var progresBar = await _db.SkillsProgressBar.FindAsync(id);
            if (progresBar == null) return NotFound();

            _db.SkillsProgressBar.Remove(progresBar);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CDelete(int id)
        {
            var skillsChart = await _db.SkillsChart.FindAsync(id);
            if (skillsChart == null) return NotFound();

            return View(skillsChart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CDelete")]
        public async Task<IActionResult> CDeletePost(int id)
        {
            var skillsChart = await _db.SkillsChart.FindAsync(id);
            if (skillsChart == null) return NotFound();

            _db.SkillsChart.Remove(skillsChart);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}