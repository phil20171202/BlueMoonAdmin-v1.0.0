using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public string EngineerId { get; set; }
        public int CustomerServiceId { get; set; }
        public Boolean IsEngineerApproved { get; set; }
        public string AdminId { get; set; }

    }
}
