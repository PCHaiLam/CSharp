﻿using System.Web;
using System.Web.Mvc;

namespace BaiTap5_63134417
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
