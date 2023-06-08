using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Asp.Net_Final_Project.Utilities
{
    public static class Utilities
    {

        public static void RemoveFile(string file,string inimg, string webRootPath)
        {
            string path = webRootPath + @"\img\" + inimg + @"\" + file;

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
