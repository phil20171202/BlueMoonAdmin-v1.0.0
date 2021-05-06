using BlueMoonAdmin.Services;
using BlueMoonAdmin.Utility;
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
            ViewBag.Duration = Helper.GetTimeDropDown();
            ViewBag.EngineerList = _calendarService.GetEngineersList();
            ViewBag.CustomerServiceList = _calendarService.GetCustomerServiceList();

            return View();
        }
    }
}


