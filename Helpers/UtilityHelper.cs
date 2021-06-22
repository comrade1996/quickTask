using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quickTask.Helpers
{
    public static class UtilityHelper
    {

        public static IEnumerable<string> Genders = new string[] { "Male", "Female", "Unspecified" };
        public static IEnumerable<SelectListItem> Cities = new SelectListItem[] {
                            new SelectListItem { Value = "konoha", Text = "konoha" },
                            new SelectListItem { Value = "Sand", Text = "Sand" },
                            new SelectListItem { Value = "Rock", Text = "Rock" }

        };

    }
}
