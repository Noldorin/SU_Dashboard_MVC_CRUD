﻿using System.Web;
using System.Web.Mvc;

namespace Dashboard_FrontEnd_Prototype
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
