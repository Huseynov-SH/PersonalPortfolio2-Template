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
    public class PriceController : Controller
    {
        private readonly AppDbContext _db;
        public PriceController(AppDbContext db)
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
            var SectionName = await _db.SectionPrice.FindAsync(id);
            if (SectionName == null) return NotFound();

            return View(SectionName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SectionNameUpdate(int id, SectionPrice sectionPrice)
        {
            if (!ModelState.IsValid) return View(sectionPrice);

            SectionPrice sectionPriceFromDb = await _db.SectionPrice.FindAsync(id);

            sectionPriceFromDb.SectionName = sectionPrice.SectionName;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var priceBox = await _db.PriceBox.FindAsync(id);
            if (priceBox == null) return NotFound();

            return View(priceBox);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, PriceBox priceBox)
        {
            if (!ModelState.IsValid) return View(priceBox);

            PriceBox priceBoxFromDb = await _db.PriceBox.FindAsync(id);

            priceBoxFromDb.PriceBoxIcon = priceBox.PriceBoxIcon;
            priceBoxFromDb.PriceBoxType = priceBox.PriceBoxType;
            priceBoxFromDb.Price = priceBox.Price;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}