using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day09_Validation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day09_Validation.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult jQueryValidate()
        {
            return View();
        }

        public IActionResult CheckEmployeeNo(int EmployeeNo)
        {
            //Giả sữ đã có danh sách các mã nv sau
            List<int> dsMaNv = new List<int>{ 7777, 3996, 1221};
            return Json(!dsMaNv.Contains(EmployeeNo));
        }
        public IActionResult Employee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Employee(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("loi", "Server chưa hợp lệ");
            }
            return View();
        }
    }
}