using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Final_Project.DAL;
using Asp.Net_Final_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Asp.Net_Final_Project.Models;

namespace Asp.Net_Final_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class WorkingProcessController : Controller
    {
        private readonly AppDbContext _db;
        public WorkingProcessController(AppDbContext db)
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
            var workProcess = await _db.SectionWorkProcess.FindAsync(id);
            if (workProcess == null) return NotFound();

            return View(workProcess);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SectionNameUpdate(int id, SectionWorkProcess workProsess)
        {
            if (!ModelState.IsValid) return View(workProsess);

            SectionWorkProcess workProsessFromDb = await _db.SectionWorkProcess.FindAsync(id);

            workProsessFromDb.SectionName = workProsess.SectionName;
            workProsessFromDb.Circle = workProsess.Circle;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> LUpdate(int id)
        {
            var workLeft = await _db.WorkingProcessItemLeft.FindAsync(id);
            if (workLeft == null) return NotFound();

            return View(workLeft);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LUpdate(int id, WorkingProcessItemLeft workingProcssLeft)
        {
            if (!ModelState.IsValid) return View(workingProcssLeft);

            WorkingProcessItemLeft workingProcssLeftFromDb = await _db.WorkingProcessItemLeft.FindAsync(id);

            workingProcssLeftFromDb.Step = workingProcssLeft.Step;
            workingProcssLeftFromDb.Title = workingProcssLeft.Title;
            workingProcssLeftFromDb.Idea = workingProcssLeft.Idea;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RUpdate(int id)
        {
            var workRight = await _db.WorkingProcessItemRight.FindAsync(id);
            if (workRight == null) return NotFound();

            return View(workRight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RUpdate(int id, WorkingProcessItemRight workingProcssRight)
        {
            if (!ModelState.IsValid) return View(workingProcssRight);

            WorkingProcessItemRight workingProcssRightFromDb = await _db.WorkingProcessItemRight.FindAsync(id);

            workingProcssRightFromDb.Step = workingProcssRight.Step;
            workingProcssRightFromDb.Title = workingProcssRight.Title;
            workingProcssRightFromDb.Idea = workingProcssRight.Idea;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> LDetails(int id)
        {
            var workLeft = await _db.WorkingProcessItemLeft.FindAsync(id);
            if (workLeft == null) return NotFound();

            return View(workLeft);
        }

        public async Task<IActionResult> RDetails(int id)
        {
            var workRight = await _db.WorkingProcessItemRight.FindAsync(id);
            if (workRight == null) return NotFound();

            return View(workRight);
        }
    }
}