using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Controllers.Api
{
    public class AppointmentApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
