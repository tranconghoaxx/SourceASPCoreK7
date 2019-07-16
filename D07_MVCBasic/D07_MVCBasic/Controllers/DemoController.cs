using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using D07_MVCBasic.Models;
using Microsoft.AspNetCore.Mvc;

namespace D07_MVCBasic.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ten = "Nhất Nghệ";
            ViewBag.Nam = 2003;
            ViewBag.HeSo = 5.99;
            return View();
        }

        public IActionResult ChiTiet()
        {
            var hh = new HangHoa
            {
                TenHh = "Galaxy Note 10",
                MaHh = 10,
                DonGia = 2199000,
                Hinh = "2.jpg",
                SoLuong = 13
            };

            ViewBag.HangHoa = hh;
            ViewBag.ThongTin = $"Thông tin sản phẩm {hh.TenHh}";

            //gửi dữ liệu qua View dạng Model
            return View(hh);
        }

        public IActionResult DanhSach()
        {
            Random rd = new Random();
            int soLuongHangHoa = rd.Next(3, 15);
            List<HangHoa> dsHangHoa = new List<HangHoa>();

            for (int i = 0; i < soLuongHangHoa; i++)
            {
                dsHangHoa.Add(new HangHoa
                {
                    MaHh = i + 1,
                    TenHh = $"Note {rd.Next(3,11)}",
                    DonGia = rd.Next(10000, 100000),
                    SoLuong = rd.Next(1, 100),
                    Hinh = $"{rd.Next(1,6)}.jpg"
                });
            }

            return View(dsHangHoa);

        }

        public string DemoSync()
        {            
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Demo demo = new Demo();
            demo.Test01();
            demo.Test02();
            demo.Test03();

            sw.Stop();

            return $"Chạy hết {sw.ElapsedMilliseconds} ms";
        }

        public async Task<string> DemoAsync()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Demo demo = new Demo();
            var a = demo.Test01Async();
            var b = demo.Test02Async();
            var c = demo.Test03Async();
            await a; //Task.WaitAny(a);
            await b; await c;
            //Task.WaitAll(a, b, c);//chờ tất cả hàm async chạy xong

            sw.Stop();

            return $"Chạy hết {sw.ElapsedMilliseconds} ms";
        }
    }
}