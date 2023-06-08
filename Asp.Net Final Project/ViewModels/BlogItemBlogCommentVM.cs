using Asp.Net_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.ViewModels
{
    public class BlogItemBlogCommentVM
    {
        public BlogItem BlogItem { get; set; }
        public IEnumerable<BlogComments> BlogComments { get; set; }
    }
}
