﻿using System.Web.Mvc;

namespace LeagueOfLegendsFindTeamApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
