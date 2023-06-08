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
    public class InterestsItemController : Controller
    {
        private readonly AppDbContext _db;
        public InterestsItemController(AppDbContext db)
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
            var myInterests = await _db.SectionMyInterests.FindAsync(id);
            if (myInterests == null) return NotFound();

            return View(myInterests);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SectionNameUpdate(int id, SectionMyInterests myInterests)
        {
            if (!ModelState.IsValid) return View(myInterests);

            SectionMyInterests myInterestsFromDb = await _db.SectionMyInterests.FindAsync(id);

            myInterestsFromDb.SectionName = myInterests.SectionName;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MyInterestsInterestsItem InterestsItem)
        {
            if (!ModelState.IsValid)
            {
                return View(InterestsItem);
            }
            await _db.MyInterestsInterestsItem.AddAsync(InterestsItem);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var InterestsItem = await _db.MyInterestsInterestsItem.FindAsync(id);
            if (InterestsItem == null) return NotFound();

            return View(InterestsItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var InterestsItem = await _db.MyInterestsInterestsItem.FindAsync(id);
            if (InterestsItem == null) return NotFound();

            _db.MyInterestsInterestsItem.Remove(InterestsItem);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var InterestsItem = await _db.MyInterestsInterestsItem.FindAsync(id);
            if (InterestsItem == null) return NotFound();

            return View(InterestsItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, MyInterestsInterestsItem InterestsItem)
        {
            if (!ModelState.IsValid) return View(InterestsItem);

            MyInterestsInterestsItem ItemInterestsItem = await _db.MyInterestsInterestsItem.FindAsync(id);

            ItemInterestsItem.InterestsIcon = InterestsItem.InterestsIcon;
            ItemInterestsItem.InterestsName = InterestsItem.InterestsName;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}