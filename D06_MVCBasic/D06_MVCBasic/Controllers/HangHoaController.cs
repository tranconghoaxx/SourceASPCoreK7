using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D06_MVCBasic.Models;
using Microsoft.AspNetCore.Mvc;

namespace D06_MVCBasic.Controllers
{
    public class HangHoaController : Controller
    {
        static List<HangHoa> dsHangHoa = new List<HangHoa>();
        public IActionResult Index()
        {
            return View(dsHangHoa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa hh)
        {
            dsHangHoa.Add(hh);
            //return View();
            //chuyển dữ liệu qua view Index để hiện danh sách
            return View("Index", dsHangHoa);
            //chuyển tới action Index để hiện danh sách
            //return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            HangHoa hh = dsHangHoa.SingleOrDefault(p => p.MaHh == id);
            if (hh != null)
            {
                return View(hh);
            }
            return RedirectToAction("Index");
        }
    }
}