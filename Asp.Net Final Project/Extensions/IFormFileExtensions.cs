using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Final_Project.Extensions
{
    public static class IFormFileExtensions
    {
        public static async Task<string> SaveFileAsync(this IFormFile file, string webRootPath, string inimg)
        {
            string uniqueId = Guid.NewGuid().ToString();
            string newFileName = uniqueId + file.FileName;
            string path = webRootPath + @"\img\" + inimg + @"\" + newFileName;

            using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }
            return newFileName;
        }

        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
    }
}
