using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using D08_Validation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace D08_Validation.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            //StudentInfo sv = new StudentInfo();
            //return View(sv);
            return View();
        }

        [HttpPost]
        public IActionResult Index(StudentInfo sv, string SaveFile)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("loi", "Không hợp lệ trên server");
                return View();
            }

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            if (SaveFile == "Save Text file")
            {
                string[] lines = {
                    sv.StudentId.ToString(),
                    sv.FullName,
                    sv.Mark.ToString(),
                    sv.IsPass.ToString(),
                    sv.Rank
                };

                System.IO.File.WriteAllLines(
                    Path.Combine(path, "Student.txt"), lines);
            }
            else if (SaveFile == "Save JSON file")
            {
                System.IO.File.WriteAllText(
                    Path.Combine(path, "Student.json"),
                    JsonConvert.SerializeObject(sv)
                );
            }

            return View(sv);
        }

        public IActionResult ReadFile(string type)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            StudentInfo sv = new StudentInfo();

            if(type == "json")
            {
                string content = System.IO.File.ReadAllText(Path.Combine(path, "Student.json"));

                sv = JsonConvert.DeserializeObject<StudentInfo>(content);
            }
            else if(type == "text")
            {
                string[] content = System.IO.File.ReadAllLines(Path.Combine(path, "Student.txt"));

                sv.StudentId = int.Parse(content[0]);
                sv.FullName = content[1];
                sv.Mark = float.Parse(content[2]);
                //sv.Mark = Convert.ToSingle(content[2]);
            }

            return View("Index", sv);
        }
    }
}