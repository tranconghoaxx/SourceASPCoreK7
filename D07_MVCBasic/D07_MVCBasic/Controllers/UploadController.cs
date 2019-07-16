using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D07_MVCBasic.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadSingleFile(IFormFile myFile)
        {
            if (myFile != null)
            {
                string fullPath = Path.Combine(
                        //thư mục gốc project
                        Directory.GetCurrentDirectory(),
                        "wwwroot", "Data",
                        myFile.FileName                        
                    );

                //nếu kiểm tra file đã có
                //System.IO.File.Exists(fullPath)

                using (var f = new FileStream(fullPath, FileMode.Create))
                {
                    myFile.CopyTo(f);
                }

            }
            return View("Index");
        }

        public IActionResult UploadMultiFile(List<IFormFile> myFile)
        {
            foreach(var file in myFile)
            {
                string fullPath = Path.Combine(
                        //thư mục gốc project
                        Directory.GetCurrentDirectory(),
                        "wwwroot", "Data",
                        file.FileName
                    );

                using (var f = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(f);
                }

            }
            return View("Index");
        }


    }
}