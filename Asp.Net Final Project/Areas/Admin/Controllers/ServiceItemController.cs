using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Final_Project.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Asp.Net_Final_Project.Models;
using Asp.Net_Final_Project.ViewModels;

namespace Asp.Net_Final_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class ServiceItemController : Controller
    {
        private readonly AppDbContext _db;
        public ServiceItemController(AppDbContext db)
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
            var SectionName = await _db.SectionService.FindAsync(id);
            if (SectionName == null) return NotFound();

            return View(SectionName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SectionNameUpdate(int id, SectionService sectionService)
        {
            if (!ModelState.IsValid) return View(sectionService);

            SectionService sectionServiceFromDb = await _db.SectionService.FindAsync(id);

            sectionServiceFromDb.SectionName = sectionService.SectionName;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var serviceItem = await _db.ServiveServiceItem.FindAsync(id);
            if (serviceItem == null) return NotFound();

            return View(serviceItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiveServiceItem serviceItem)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceItem);
            }
            await _db.ServiveServiceItem.AddAsync(serviceItem);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var serviceItem = await _db.ServiveServiceItem.FindAsync(id);
            if (serviceItem == null) return NotFound();

            return View(serviceItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var serviceItem = await _db.ServiveServiceItem.FindAsync(id);
            if (serviceItem == null) return NotFound();

            _db.ServiveServiceItem.Remove(serviceItem);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var serviceItem = await _db.ServiveServiceItem.FindAsync(id);
            if (serviceItem == null) return NotFound();

            return View(serviceItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ServiveServiceItem serviceItem)
        {
            if (!ModelState.IsValid) return View(serviceItem);

            ServiveServiceItem serviceItemFromDb = await _db.ServiveServiceItem.FindAsync(id);

            serviceItemFromDb.ServiceIcon = serviceItem.ServiceIcon;
            serviceItemFromDb.ServiceName = serviceItem.ServiceName;
            serviceItemFromDb.ServiceDescription = serviceItem.ServiceDescription;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}