using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models.ViewModels
{
    public class AppointmentViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Duration { get; set; }
        public string EngineerId { get; set; }
        public string CustomerServiceId { get; set; }
        public Boolean IsEngineerApproved { get; set; }
        public string AdminId { get; set; }

        public string EngineerName { get; set; }
        public string CustomerName { get; set; }
        public string AdminName { get; set; }
        public Boolean IsForClient { get; set; }
    }
}
