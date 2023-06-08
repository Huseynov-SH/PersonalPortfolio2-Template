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
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public PortfolioController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            MainPageVM mainPageVM = new MainPageVM
            {
                PortfolioCategory = _db.PortfolioCategory,
                PortfolioItem = _db.PortfolioItem,
            };
            return View(mainPageVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var portfolioItem = await _db.PortfolioItem.FindAsync(id);
            if (portfolioItem == null) return NotFound();

            return View(portfolioItem);
        }

        public async Task<IActionResult> Update(int id)
        {
            var portfolioItem = await _db.PortfolioItem.FindAsync(id);
            if (portfolioItem == null) return NotFound();

            ViewBag.Category = _db.PortfolioCategory;

            return View(portfolioItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, PortfolioItem portfolioItem)
        {
            if (!ModelState.IsValid) return View(portfolioItem);

            PortfolioItem portfolioItemFromDb = await _db.PortfolioItem.FindAsync(id);

            if (portfolioItem.Photo != null)
            {
                if (portfolioItem.Photo.IsImage())
                {
                    //Remove old image
                    RemoveFile(portfolioItemFromDb.Image, "portfolio", _env.WebRootPath);

                    //Save new image
                    portfolioItemFromDb.Image = await portfolioItem.Photo.SaveFileAsync(_env.WebRootPath, "portfolio");
                }
                else
                {
                    ModelState.AddModelError("Photo", "Photo is invalid");
                    return View(portfolioItem);
                }
            }

            portfolioItemFromDb.ProjectName = portfolioItem.ProjectName;
            portfolioItemFromDb.Tag = portfolioItem.Tag;
            portfolioItemFromDb.ProjectVideoLink = portfolioItem.ProjectVideoLink;
            portfolioItemFromDb.PortfolioCategoryId = portfolioItem.PortfolioCategoryId;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            ViewBag.Category = _db.PortfolioCategory;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioItem portfolioItem)
        {
            if (!ModelState.IsValid)
            {
                return View(portfolioItem);
            }

            if (portfolioItem.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo should be selected");
                return View(portfolioItem);
            }

            if (!portfolioItem.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Photo is not valid");
                return View(portfolioItem);
            }


            portfolioItem.Image = await portfolioItem.Photo.SaveFileAsync(_env.WebRootPath, "portfolio");

            await _db.PortfolioItem.AddAsync(portfolioItem);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var portfolioItem = await _db.PortfolioItem.FindAsync(id);
            if (portfolioItem == null) return NotFound();

            return View(portfolioItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var portfolioItem = await _db.PortfolioItem.FindAsync(id);
            if (portfolioItem == null) return NotFound();

            RemoveFile(portfolioItem.Image, "portfolio", _env.WebRootPath);
            _db.PortfolioItem.Remove(portfolioItem);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CUpdate(int id)
        {
            var portfolioCategory = await _db.PortfolioCategory.FindAsync(id);
            if (portfolioCategory == null) return NotFound();

            return View(portfolioCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CUpdate(int id, PortfolioCategory portfolioCategory)
        {
            if (!ModelState.IsValid) return View(portfolioCategory);

            PortfolioCategory portfolioCategoryFromDb = await _db.PortfolioCategory.FindAsync(id);

            portfolioCategoryFromDb.CategoryName = portfolioCategory.CategoryName;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CCreate(PortfolioCategory portfolioCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(portfolioCategory);
            }
            await _db.PortfolioCategory.AddAsync(portfolioCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CDelete(int id)
        {
            var portfolioCategory = await _db.PortfolioCategory.FindAsync(id);
            if (portfolioCategory == null) return NotFound();

            return View(portfolioCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CDelete")]
        public async Task<IActionResult> CDeletePost(int id)
        {
            var portfolioCategory = await _db.PortfolioCategory.FindAsync(id);
            if (portfolioCategory == null) return NotFound();

            _db.PortfolioCategory.Remove(portfolioCategory);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}