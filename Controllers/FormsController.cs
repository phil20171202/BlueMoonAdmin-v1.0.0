using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlueMoonAdmin.Controllers
{
    public class FormsController : Controller
    {
        public IActionResult FormUpload()
        {
            return View();
        }

    }
}