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
    public class TestimonialsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public TestimonialsController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
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
            var SectionName = await _db.SectionTestimonial.FindAsync(id);
            if (SectionName == null) return NotFound();

            return View(SectionName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SectionNameUpdate(int id, SectionTestimonial testimonial)
        {
            if (!ModelState.IsValid) return View(testimonial);

            SectionTestimonial testimonialFromDb = await _db.SectionTestimonial.FindAsync(id);

            testimonialFromDb.SectionName = testimonial.SectionName;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var testimonialsItem = await _db.TestimonailItem.FindAsync(id);
            if (testimonialsItem == null) return NotFound();

            return View(testimonialsItem);
        }

        public async Task<IActionResult> Update(int id)
        {
            var testimonialsItem = await _db.TestimonailItem.FindAsync(id);
            if (testimonialsItem == null) return NotFound();

            return View(testimonialsItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, TestimonailItem testimonailItem)
        {
            if (!ModelState.IsValid) return View(testimonailItem);

            TestimonailItem testimonailItemFromDb = await _db.TestimonailItem.FindAsync(id);

            if (testimonailItem.Photo != null)
            {
                if (testimonailItem.Photo.IsImage())
                {
                    //Remove old image
                    RemoveFile(testimonailItemFromDb.Image, "testimonials", _env.WebRootPath);

                    //Save new image
                    testimonailItemFromDb.Image = await testimonailItem.Photo.SaveFileAsync(_env.WebRootPath, "testimonials");
                }
                else
                {
                    ModelState.AddModelError("Photo", "Photo is invalid");
                    return View(testimonailItem);
                }
            }
            if (testimonailItem.Rating > 5)
            {
                ModelState.AddModelError("Rating", "Maximum value 5");
                return View(testimonailItem);
            }

            testimonailItemFromDb.FullName = testimonailItem.FullName;
            testimonailItemFromDb.Job = testimonailItem.Job;
            testimonailItemFromDb.Rating = testimonailItem.Rating;
            testimonailItemFromDb.Comment = testimonailItem.Comment;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestimonailItem testimonailItem)
        {
            if (!ModelState.IsValid)
            {
                return View(testimonailItem);
            }

            if(testimonailItem.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo should be selected");
                return View(testimonailItem);
            }

            if (!testimonailItem.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Photo is not valid");
                return View(testimonailItem);
            }

            if (testimonailItem.Rating > 6)
            {
                ModelState.AddModelError("Rating", "Please enter a value less than or equal to 5");
                return View(testimonailItem);
            }
            

           testimonailItem.Image = await testimonailItem.Photo.SaveFileAsync(_env.WebRootPath, "testimonials");

            await _db.TestimonailItem.AddAsync(testimonailItem);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var testimonialsItem = await _db.TestimonailItem.FindAsync(id);
            if (testimonialsItem == null) return NotFound();

            return View(testimonialsItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var testimonialsItem = await _db.TestimonailItem.FindAsync(id);
            if (testimonialsItem == null) return NotFound();

            RemoveFile(testimonialsItem.Image, "testimonials", _env.WebRootPath);
            _db.TestimonailItem.Remove(testimonialsItem);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}