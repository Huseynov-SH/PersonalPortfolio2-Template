using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Final_Project.DAL;
using Asp.Net_Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Final_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class IconInfoController : Controller
    {
        private readonly AppDbContext _db;
        public IconInfoController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var iconInfo = _db.IconInfoAboutMes;
            return View(iconInfo);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IconInfoAboutMe iconInfoAboutMe)
        {
            if (!ModelState.IsValid)
            {
                return View(iconInfoAboutMe);
            }
            await _db.IconInfoAboutMes.AddAsync(iconInfoAboutMe);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var iconInfoAboutMe = await _db.IconInfoAboutMes.FindAsync(id);
            if (iconInfoAboutMe == null) return NotFound();

            return View(iconInfoAboutMe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var iconInfoAboutMe = await _db.IconInfoAboutMes.FindAsync(id);
            if (iconInfoAboutMe == null) return NotFound();

            _db.IconInfoAboutMes.Remove(iconInfoAboutMe);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var iconInfoAboutMe = await _db.IconInfoAboutMes.FindAsync(id);
            if (iconInfoAboutMe == null) return NotFound();

            return View(iconInfoAboutMe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, IconInfoAboutMe iconInfoAboutMe)
        {
            if (!ModelState.IsValid) return View(iconInfoAboutMe);

            IconInfoAboutMe iconInfoFromDb = await _db.IconInfoAboutMes.FindAsync(id);

            iconInfoFromDb.IconInfo = iconInfoAboutMe.IconInfo;
            iconInfoFromDb.TitInfo = iconInfoAboutMe.TitInfo;
            iconInfoFromDb.SubTitInfo = iconInfoAboutMe.SubTitInfo;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}