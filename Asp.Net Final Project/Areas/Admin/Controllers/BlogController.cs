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
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;

        public BlogController(AppDbContext db, IHostingEnvironment env)
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
                BlogItem = _db.BlogItem,
                BlogComments = _db.BlogComments,
            };
            return View(mainPageVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var blogItem = await _db.BlogItem.FindAsync(id);
            if (blogItem == null) return NotFound();

            return View(blogItem);
        }

        public async Task<IActionResult> Update(int id)
        {
            var blogItem = await _db.BlogItem.FindAsync(id);
            if (blogItem == null) return NotFound();

            return View(blogItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, BlogItem blogItem)
        {
            if (!ModelState.IsValid) return View(blogItem);

            BlogItem blogItemFromDb = await _db.BlogItem.FindAsync(id);

            if (blogItem.Photo != null)
            {
                if (blogItem.Photo.IsImage())
                {
                    //Remove old image
                    RemoveFile(blogItemFromDb.Image, "blog", _env.WebRootPath);

                    //Save new image
                    blogItemFromDb.Image = await blogItem.Photo.SaveFileAsync(_env.WebRootPath, "blog");
                }
                else
                {
                    ModelState.AddModelError("Photo", "Photo is invalid");
                    return View(blogItem);
                }
            }

            blogItemFromDb.Title = blogItem.Title;
            blogItemFromDb.SubTitle = blogItem.SubTitle;
            blogItemFromDb.ShareDate = blogItem.ShareDate;
            blogItemFromDb.Tag = blogItem.Tag;
            blogItemFromDb.Context = blogItem.Context;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogItem blogItem)
        {
            if (!ModelState.IsValid)
            {
                return View(blogItem);
            }

            if (blogItem.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo should be selected");
                return View(blogItem);
            }

            if (!blogItem.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Photo is not valid");
                return View(blogItem);
            }


            blogItem.Image = await blogItem.Photo.SaveFileAsync(_env.WebRootPath, "blog");

            await _db.BlogItem.AddAsync(blogItem);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var blogItem = await _db.BlogItem.FindAsync(id);
            if (blogItem == null) return NotFound();

            return View(blogItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var blogItem = await _db.BlogItem.FindAsync(id);
            if (blogItem == null) return NotFound();

            RemoveFile(blogItem.Image, "blog", _env.WebRootPath);
            _db.BlogItem.Remove(blogItem);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}