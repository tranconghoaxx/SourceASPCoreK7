using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace D06_MVCBasic.Controllers
{
    public class DemoController : Controller
    {
        public string Index()
        {
            return "Index";
        }

        public double Test()
        {
            return 1900.157;
        }

        [Route("/Clock")] // --> /Clock
        [Route("Gio")]
        [Route("Hello/Hi")] //--> /Hello/Hi
        public long A()
        {
            return DateTime.Now.Ticks;
        }

        [Route("Say/{name}/{age}")] //--> /Say/Tèo/Nguyễn/5
        public string B(string name="", int age = 0)
        {
            return $"Xin chào {name}";
        }

        [Route("Chao")] //--> /Chao?name=Tèo
        public string C(string name = "")
        {
            return $"Xin chào {name}";
        }

        [Route("dien-thoai/{sp}")]
        public string D(string sp = "")
        {
            return $"Đang muốn mua {sp}";
        }

        public IActionResult Demo()
        {
            string ten = "Nhất Nghệ";
            return View("Demo", ten);
        }

        public IActionResult Demo2()
        {
            string ten = "105 BHTQ";
            return View("Demo", ten);
        }
    }
}