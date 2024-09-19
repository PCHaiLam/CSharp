using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap2_63134417.Controllers
{
    public class SinhVien_63134417Controller : Controller
    {
        // GET: SinhVien_63134417
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string id)
        {
            id = Request["id"].ToString();
            string name = Request["name"].ToString(); ;
            double mark = double.Parse(Request["mark"]);

            ViewBag.Id = id;
            ViewBag.Name = name;
            ViewBag.Mark = mark;
            return View();
        }
        //************************************************************************************************//

        //************************************************************************************************//
        //************************************************************************************************//

    }
}