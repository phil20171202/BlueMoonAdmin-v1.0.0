using BlueMoonAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }
    
        public IActionResult Index()
        {
            ViewBag.EngineerList = _calendarService.GetEngineersList();
             return View();
        }
    }
}


