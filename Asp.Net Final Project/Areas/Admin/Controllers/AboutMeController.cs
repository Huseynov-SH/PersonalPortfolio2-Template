using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Final_Project.DAL;
using Asp.Net_Final_Project.Extensions;
using Asp.Net_Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static Asp.Net_Final_Project.Utilities.Utilities;

namespace Asp.Net_Final_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class AboutMeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public AboutMeController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            var aboutMe = _db.SectionAboutMes;
            return View(aboutMe);
        }

        public async Task<IActionResult> Update(int id)
        {
            var aboutMe = await _db.SectionAboutMes.FindAsync(id);
            if (aboutMe == null) return NotFound();

            return View(aboutMe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SectionAboutMe sectionAboutMe)
        {
            if (!ModelState.IsValid) return View(sectionAboutMe);

            SectionAboutMe AboutMeFromDb = await _db.SectionAboutMes.FindAsync(id);

            if(sectionAboutMe.Photo != null)
            {
                if (sectionAboutMe.Photo.IsImage())
                {
                    //Remove old image
                    RemoveFile(AboutMeFromDb.Image,"main",_env.WebRootPath);

                    //Save new image
                    AboutMeFromDb.Image = await sectionAboutMe.Photo.SaveFileAsync(_env.WebRootPath,"main");
                }
                else
                {
                    ModelState.AddModelError("Photo", "Photo is invalid");
                    return View(sectionAboutMe);
                }
            }

            AboutMeFromDb.SectionName = sectionAboutMe.SectionName;
            AboutMeFromDb.FullName = sectionAboutMe.FullName;
            AboutMeFromDb.Location = sectionAboutMe.Location;
            AboutMeFromDb.Description = sectionAboutMe.Description;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}