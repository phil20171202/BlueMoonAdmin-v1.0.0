using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Utility
{
    public static class Helper
    {
        public static string Admin = "Admin";
        public static string Engineer = "Engineers";
        public static string Customerservice = "Customer Services";

        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value=Helper.Admin,Text=Helper.Admin},
                new SelectListItem{Value=Helper.Engineer,Text=Helper.Engineer},
                new SelectListItem{Value=Helper.Customerservice,Text=Helper.Customerservice}
            };
        }
    }
}
