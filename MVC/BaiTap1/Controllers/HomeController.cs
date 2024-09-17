using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(double? a, double? b, string pt = "+")
        {
            if (a == null || b == null)
            {
                ViewBag.KQ = "Vui lòng nhập đủ a và b";
            }
            else
            {
                switch (pt)
                {
                    case "+":
                        ViewBag.KQ = a + b;
                        break;
                    case "-":
                        ViewBag.KQ = a - b;
                        break;
                    case "*":
                        ViewBag.KQ = a * b;
                        break;
                    case "/":
                        if (b == 0)
                            ViewBag.KQ = "Không hợp lệ";
                        else
                            ViewBag.KQ = a / b;
                        break;
                }
            }

            return View();
        }



    }
}