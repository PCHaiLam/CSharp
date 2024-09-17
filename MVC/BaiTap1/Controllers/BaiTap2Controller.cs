using BaiTap1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap1.Controllers
{
    public class BaiTap2Controller : Controller
    {
        // GET: BaiTap2
        public ActionResult Index(CalBT2 cal)
        {
            if (cal.a == null || cal.b == null)
            {
                ViewBag.KQ = "Vui lòng nhập đủ a và b";
            }
            else
            {
                switch (cal.pt)
                {
                    case "+":
                        ViewBag.KQ = cal.a + cal.b;
                        break;
                    case "-":
                        ViewBag.KQ = cal.a - cal.b;
                        break;
                    case "*":
                        ViewBag.KQ = cal.a * cal.b;
                        break;
                    case "/":
                        if (cal.b == 0)
                            ViewBag.KQ = "Không hợp lệ";
                        else
                        ViewBag.KQ = cal.a / cal.b;
                        break;
                }
            }

            return View();
        }
    }
}