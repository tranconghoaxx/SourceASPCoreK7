using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using D10_JqueryValidation_Layout.Models;
using Microsoft.AspNetCore.Http;

namespace D10_JqueryValidation_Layout.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Register()
        {
            //tạo số ngẫu nhiên
            Random rd = new Random();
            string maNgauNhien = rd.Next(1000, 10000).ToString();

            //Lưu lại giá trị trên Server dùng Session
            HttpContext.Session.SetString("MaBaoMat", maNgauNhien);

            return View();
        }

        public string KiemTraMaBaoMat(string MaBaoMat)//thầy ơi sao đoạn này chạy không đúng vậy thầy
        {
            var sessionValue = HttpContext.Session.GetString("MaBaoMat");
            if (sessionValue == null) return "false";
            return (sessionValue == MaBaoMat) ? "true" : "false";
        }
    }
}
