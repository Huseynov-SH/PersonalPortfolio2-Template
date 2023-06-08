using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Final_Project.DAL;
using Asp.Net_Final_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Final_Project.Controllers
{
    [Authorize()]
    public class SingleBlogController : Controller
    {
        private readonly AppDbContext _db;

        public SingleBlogController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(int id)
        {
            var blogItem = await _db.BlogItem.FindAsync(id);
            if (blogItem == null) return NotFound();

            BlogItemBlogCommentVM singleBlog = new BlogItemBlogCommentVM
            {
                BlogItem = _db.BlogItem.First(s => s.Id == id),
                BlogComments = _db.BlogComments.Where(bc => bc.BlogItemId == id)
            };

            return View(singleBlog);
            //var singleBlog = await _db.BlogItem.FindAsync(id);
            //if (singleBlog == null) return NotFound();

            //return View(singleBlog);
        }
    }
}