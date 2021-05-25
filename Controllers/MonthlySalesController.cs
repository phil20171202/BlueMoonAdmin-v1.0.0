using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Controllers
{
    public class MonthlySalesController : Controller
    {
        public IActionResult MonthlySales()
        {
            return View();
        }
    }
}
