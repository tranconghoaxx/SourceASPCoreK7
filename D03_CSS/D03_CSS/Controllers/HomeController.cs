using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using D03_CSS.Models;

namespace D03_CSS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult List()
        {
            //Mai mốt đọc CSDL về hàng hóa lấy ra theo đk
            //bây giờ giả sử tạo ngẩu nhiên n hàng hóa
            Random rd = new Random();
            int soSP = rd.Next(3, 20);

            List<HangHoa> danhSach = new List<HangHoa>();
            for(int i = 0; i < soSP; i++)
            {
                var hh = new HangHoa {
                    MaHH = i + 1,
                    TenHH = $"IPhone {rd.Next(9, 20)}",
                    Hinh = "iphone-x-256gb-gray.jpg",
                    GiaBan = rd.Next(1000, 10000)
                };
                danhSach.Add(hh);
            }

            //gửi dữ liệu sang View để hiển thị
            return View(danhSach);
            //return View("TenView", modelString);
        }

        //<Host>/Home/Product
        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
