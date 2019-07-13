using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace D06_MVCBasic.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(double A, double B, string PhepToan)
        {
            double kq = 0;
            string result = string.Empty;
            switch(PhepToan)
            {
                case "+": kq = A + B; break;
                case "-": kq = A - B; break;
                case "*": kq = A * B; break;
                case "/": kq = A / B; break;
                case "^": kq = Math.Pow(A, B); break;
            }

            //Truyền dữ liệu từ Action qua View dùng ViewBag
            ViewBag.A = A;
            ViewBag.B = B;
            ViewBag.KetQua = kq;
            ViewBag.ChuoiKQ = $"{A} {PhepToan} {B} = {kq}";
            return View("Index");
        }
    }
}